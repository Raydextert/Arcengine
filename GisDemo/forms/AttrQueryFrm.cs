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

        string sql = null;
        private IFeatureClass fteClss=null ;
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
            IFeatureLayer fteLyr = null;
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
            IFeatureCursor pCursor = fteClss.Search(null, false);
            IFeature pFeature = pCursor .NextFeature ();
            while (pFeature != null)
            {
                this.ValueList.Items.Add(pFeature.get_Value(fieldIndex));
                pFeature = pCursor.NextFeature();
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
    }
}
