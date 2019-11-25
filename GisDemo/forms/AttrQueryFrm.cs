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
/*===============================================
 * 
 *   
 * 属性查询窗体
 * 
 * 作者：zrc 日期：2019/11/18
 *================================================
 */
namespace GisDemo.forms
{
    public partial class AttrQueryFrm : Form
    {
        public AttrQueryFrm()
        {
            InitializeComponent();
        }
        private IMapControlDefault mapcontrol = null;
        public  IMapControlDefault Mapcontrol
        {
            set { mapcontrol = value; }
            get { return mapcontrol; }
        }

        IFeatureLayer fteLyr = null;
        private IFeatureClass fteClss=null;
        esriFieldType fieldType;
        private void AttrQueryFrm_Load(object sender, EventArgs e)
        {
            loadLyrs();
        }

        #region 私有方法
        private void loadLyrs()
        {
            if (Mapcontrol == null) return;
            for (int i = 0; i < Mapcontrol.LayerCount; i++)
            {
                object lyrname = this.Mapcontrol.get_Layer(i).Name;
                this.LyrCmbx.Items.Add(lyrname);
            }
            if (this.LyrCmbx.Items.Count == 0) return;
            this.LyrCmbx.Text = this.LyrCmbx.Items[0].ToString();
        }

        private void loadFields(string lyrname)
        {
            if (string.IsNullOrEmpty(lyrname)) return;
            this.fieldslistBox.Items.Clear();
            fteLyr = null;
            for (int i = 0; i < this.Mapcontrol.LayerCount; i++)
            {
                if (this.Mapcontrol.get_Layer(i).Name == lyrname)
                {
                    fteLyr = this.Mapcontrol.get_Layer(i) as IFeatureLayer;
                    break;
                }
            }
            //加载字段
            if (fteLyr == null) return;
            fteClss = fteLyr.FeatureClass;
            for (int j = 0; j < fteLyr.FeatureClass.Fields.FieldCount; j++)
            {
                this.fieldslistBox.Items.Add(fteLyr.FeatureClass.Fields.get_Field(j).Name);
            }
        }

        private void GetUniqueVal()
        {
            if (fteClss == null) return;
            this.ValueList.Items.Clear();
            int fieldIndex = -1;
            string fieldSel = this.fieldslistBox.SelectedItem.ToString();
            for (int i = 0; i < fteClss.Fields.FieldCount; i++)
            {
                
                if (fteClss.Fields.get_Field(i).Name ==fieldSel &&!string .IsNullOrEmpty (fieldSel))
                {
                    fieldIndex = i;
                    break;
                }
            }
            if (fieldIndex == -1) return;
            fieldType = fteClss.Fields.get_Field(fieldIndex).Type;
            IFeatureCursor pCursor = fteClss.Search(null, false);
            IFeature pFeature = pCursor .NextFeature ();
            while (pFeature != null)
            {
                this.ValueList.Items.Add(pFeature.get_Value(fieldIndex));
                pFeature = pCursor.NextFeature();
            }
        }

        private void ExpandMap(IFeatureCursor Cursor)
        {
            if (Cursor == null) return;
            IFeature pFeature = Cursor.NextFeature();
            IEnvelope pEnve = new EnvelopeClass();
            while (pFeature != null)
            {
                //先缩放再高亮
                pEnve.Union(pFeature.Extent);
                pFeature = Cursor.NextFeature();
            }
            this.Mapcontrol.ActiveView.Extent = pEnve;
            this.Mapcontrol.Refresh();
            //即时调用更新窗体方法，进而首先进行缩放
            this.Mapcontrol.ActiveView.ScreenDisplay.UpdateWindow();
        }

        private void FlashFeature(IFeatureCursor Cursor)
        {
            //高亮显示要素
            this.Mapcontrol.Map.ClearSelection();
            this.Mapcontrol.Refresh();
            if (Cursor == null) return;
            IFeature pFeature = Cursor.NextFeature();
            while (pFeature != null)
            {
                //先缩放再高亮
                this.Mapcontrol.Map.SelectFeature(fteLyr, pFeature);
                this.Mapcontrol.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                this.Mapcontrol.Refresh();
                pFeature = Cursor.NextFeature();
            }
        }
        #endregion 

        private void fieldslistBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LyrCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.LyrCmbx.Items.Count == 0) return;
            string Lyrname = this.LyrCmbx.SelectedItem.ToString();
            loadFields(Lyrname);
        }

        private void uniquevalueBtn_Click(object sender, EventArgs e)
        {
            GetUniqueVal();
        }

        private void equalbtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.exptxtBox.Text += "=";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fieldslistBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.exptxtBox.Text += this .fieldslistBox .SelectedItem .ToString ();
            //获取字段类型
        }

        private void ValueList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (fieldType)
            { 
                case esriFieldType.esriFieldTypeInteger:
                case esriFieldType.esriFieldTypeSmallInteger:
                case esriFieldType.esriFieldTypeSingle:
                case esriFieldType.esriFieldTypeDouble:
                case esriFieldType.esriFieldTypeOID:
                case esriFieldType.esriFieldTypeGUID:
                    this.exptxtBox.Text += this.ValueList.SelectedItem.ToString();
                    break;
                default :
                this.exptxtBox.Text += "\'"+this.ValueList.SelectedItem.ToString()+"\'";
                break;
            }
            
        }

        private void greaterbtn_Click(object sender, EventArgs e)
        {
            this.exptxtBox.Text += ">";
        }

        private void smallerbtn_Click(object sender, EventArgs e)
        {
            this.exptxtBox.Text += "<";
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            this.exptxtBox.Text = "";
        }

        private void likebtn_Click(object sender, EventArgs e)
        {
            this.exptxtBox.Text += "Like";
        }

        private void andbtn_Click(object sender, EventArgs e)
        {
            this.exptxtBox.Text += "AND";
        }

        private void orbtn_Click(object sender, EventArgs e)
        {
            this.exptxtBox.Text += "OR";
        }

        private void surebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.exptxtBox.Text == "") return;
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = this.exptxtBox.Text;
                IFeatureCursor pCursor = fteClss.Search(filter, false);
                if (pCursor == null) return;
                //ExpandMap(pCursor);
                FlashFeature(pCursor);
                this.Close();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("表达式错误"+"\n"+ex.Message);
                return;
            }
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.exptxtBox.Text == "") return;
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = this.exptxtBox.Text;
                IFeatureCursor pCursor = fteClss.Search(filter, false);
                if (pCursor == null) return;
                //ExpandMap(pCursor);
                FlashFeature(pCursor);
            }
            catch (Exception ex)
            {
                MessageBox.Show("表达式错误" + "\n" + ex.Message);
                return;
            }
        }

        private void CancleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
