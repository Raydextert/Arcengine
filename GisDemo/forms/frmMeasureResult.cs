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
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Geoprocessor;
namespace GisDemo.forms
{
    public partial class frmMeasureResult : Form
    {
        public frmMeasureResult()
        {
            InitializeComponent();
        }
        public void showResult(double[] a,string sMapunits,string pMouseoperate)
        {
            if (a == null) return;
            if (pMouseoperate == "MeasureLength")
            { 
              this.lblMeasureResult.Text = string.Format("当前线段长度：{0:.###}{1};\r\n总长度: {2:.###}{1}", a[0], sMapunits, a[1]);
            }
            if (pMouseoperate == "MeasureArea")
            {
                this.lblMeasureResult.Text = string.Format("当前面积大小：{0:.###}{1};\r\n总长度: {2:.###}{1}", a[0], sMapunits, a[1]);
            }
            
        }
    }
}
