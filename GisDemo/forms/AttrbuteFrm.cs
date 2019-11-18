using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using System.IO;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.ADF.BaseClasses;

namespace GisDemo.forms
{
    public partial class AttrbuteFrm : Form
    {
        private IMapControlDefault mapcontrol = null;
        private IFeatureLayer fteLyr = null;
        public IFeatureLayer FteLyr
        {
            set { fteLyr = value; }
            get { return fteLyr; }
        }
        const int pagesize = 50;
        int currentpage = 1;
        int pagecount = 0;
        List<IFeature> fte_list = new List<IFeature>();
        List<string> fieldNames = new List<string>() { "Shape", "ID" };
        public int Currentpage
        {
            get
            {
                if (currentpage == pagecount&&pagecount >1)
                {
                    this.propertyNavigator.MoveLastItem .Enabled = false;
                    this.propertyNavigator.MoveNextItem.Enabled = false;
                    this.propertyNavigator.MoveFirstItem.Enabled = true;
                    this.propertyNavigator.MovePreviousItem.Enabled = true;
                }
                if (currentpage == 1&&pagecount >1)
                {
                    this.propertyNavigator.MoveFirstItem.Enabled = false;
                    this.propertyNavigator.MovePreviousItem.Enabled = false;
                    this.propertyNavigator.MoveNextItem.Enabled = true;
                    this.propertyNavigator.MoveLastItem.Enabled = true;
                }
                if (pagecount == 1)
                {
                    this.propertyNavigator.MoveFirstItem.Enabled = false;
                    this.propertyNavigator.MovePreviousItem.Enabled = false;
                    this.propertyNavigator.MoveNextItem.Enabled = false;
                    this.propertyNavigator.MoveLastItem.Enabled = false;
                }
                return currentpage;
            }
            set
            {
                currentpage = value;
            }
        
        }
        private AttrbuteFrm()
        {
            InitializeComponent();
        }

        private static AttrbuteFrm _instance = null;

        //获取实例互斥锁，readonly修饰动态声明常量
        private static readonly object _MetuexLocker = new object();

        public static AttrbuteFrm attrbuteFrm(object hook)
        {
            if (_instance == null)
            {
                lock (_MetuexLocker)
                {
                    if (_instance == null)
                    {
                        _instance = new AttrbuteFrm();
                    }
                }

            }
            _instance.mapcontrol = hook as IMapControlDefault;
            return _instance;
        }

        public static AttrbuteFrm attrbuteFrmSub(object hook)
        {
            lock (_MetuexLocker)
            {
                if (_instance == null)
                {
                    _instance = new AttrbuteFrm();
                }
                if (_instance.IsDisposed)
                {
                    _instance = new AttrbuteFrm();
                }
            
            }
            _instance.mapcontrol = hook as IMapControlDefault;
            return _instance;
        }

        //显示窗体函数
        public void showFrm()
        {
            if (_instance == null) return;

            try
            {
                IntPtr ptr = new IntPtr( mapcontrol.ActiveView .ScreenDisplay.hWnd );
                this.Owner = Form.FromHandle(ptr).FindForm();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void AttrbuteFrm_Load(object sender, EventArgs e)
        {
            try
            {
                //获取要素总量
                if (fteLyr == null) return;
                this.Text = fteLyr.Name.ToString();
                IFeatureClass fteClss = FteLyr.FeatureClass;
                IFeatureCursor pCusor = fteClss.Search(null, false);
                IFeature feature = pCusor.NextFeature();
                while(feature != null)
                {
                    fte_list.Add(feature);
                    feature = pCusor.NextFeature();
                }
                pagecount =(int) Math.Ceiling((double)fte_list.Count / pagesize);
                this.propertyNavigator.CountItem.Text = pagecount.ToString();
                this.propertyNavigator.PositionItem.Text = Currentpage.ToString();
                bindData(fteLyr, Currentpage );
                this.lblcurpage.Text = "每页总数";
                this.pageCountTxt.Text = pagesize.ToString();
                this.pageCountTxt.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bindData(IFeatureLayer Lyr,int cutpage)
        {
            if (Lyr == null)
                return;
            DataTable table = new DataTable();
            //加载
            IFeatureClass fteclss = Lyr.FeatureClass;
            for (int i = 0; i < fteclss.Fields.FieldCount; i++)
            {
                table.Columns.Add(fteclss.Fields.get_Field(i).AliasName);
            }
            this.propertyGridView.DataSource = table;
            //判断索引是否大于要素数量
            int srow = (cutpage - 1) * pagesize >= fte_list.Count ? fte_list.Count-1: (cutpage - 1) * pagesize;
            int endrow = (cutpage * pagesize - 1)>=fte_list .Count?fte_list .Count-1:(cutpage *pagesize -1);
            //添加数据
            for (; srow <= endrow; srow++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < fteclss.Fields.FieldCount; j++)
                {
                    row[j] = fte_list[srow].get_Value(j).ToString();
                } 
                table.Rows.Add(row);
            }
                #region 设置表格样式

                this.propertyGridView.ClearSelection();
            //排序问题
            for (int i = 0; i < this.propertyGridView.Columns.Count; i++)
            {
                this.propertyGridView.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            int width = 0;
            for (int j = 0; j < this.propertyGridView.ColumnCount; j++)
            {
                this.propertyGridView.AutoResizeColumn(j, DataGridViewAutoSizeColumnMode.AllCells);
                width += this.propertyGridView.Columns[j].Width;
            }
            //判断与窗体大小
            if (width > this.propertyGridView.Width)
            {
                this.propertyGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                this.propertyGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            this.propertyGridView.AllowUserToAddRows = false;

            for (int j = 0; j < this.propertyGridView.ColumnCount; j++)
            {
                string colname = this.propertyGridView.Columns[j].Name;
                if (fieldNames.Contains(colname))
                {
                    this.propertyGridView.Columns[j].Visible = false;
                }
            }
                #endregion
                this.propertyGridView.Refresh();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (Currentpage == 1) return;
            Currentpage = 1;
            bindData(fteLyr, Currentpage);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (Currentpage == 1) return;
            Currentpage--;
            bindData(fteLyr, Currentpage);
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (Currentpage == pagecount) return;
            Currentpage++;
            bindData(fteLyr ,Currentpage );
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (Currentpage == pagecount) return;
            Currentpage = pagecount;
            bindData(fteLyr, Currentpage);
        }
    }
}
