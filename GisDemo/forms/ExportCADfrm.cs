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
using GisDemo.Command;
namespace GisDemo.forms
{
    public partial class ExportCADfrm : Form
    {
        public ExportCADfrm()
        {
            InitializeComponent();
        }
        private IFeatureLayer fteLyr = null;
       
        private IMapControlDefault mapcontrol = null;
        public IMapControlDefault Mapcontrol { get { return mapcontrol; } set { mapcontrol = value; } }
        private void Filebrowserbtn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.AddExtension = true;
                dlg.RestoreDirectory = true;
                dlg.Filter = "CAD文件(*.dwg)|*.dwg";
                dlg.FileName = fteLyr.Name;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string foldpath = dlg.FileName.Substring(0, dlg.FileName.LastIndexOf("\\"));
                    if (!System.IO.Directory.Exists(foldpath))
                    {
                        System.IO.Directory.CreateDirectory(foldpath);
                    }
                    this.pathtxt.Text = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Lyrlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Mapcontrol.LayerCount; i++)
            {
                if (this.Lyrlist.SelectedItem.ToString()== this.Mapcontrol.get_Layer(i).Name)
                {
                    fteLyr = this.Mapcontrol.get_Layer(i) as IFeatureLayer;
                    break;
                }
            }
        }

        private void ExportCADfrm_Load(object sender, EventArgs e)
        {
            if (Mapcontrol == null) return;
            for (int i = 0; i < this.Mapcontrol.LayerCount; i++)
            {
                this.Lyrlist.Items.Add(Mapcontrol.get_Layer(i).Name);
            }
        }

        private void Exportbtn_Click(object sender, EventArgs e)
        {
            ExportCADTool tool = new ExportCADTool();
            tool.Mapcontrol = this.Mapcontrol;
            if (string.IsNullOrEmpty(this.pathtxt.Text))
            {
                MessageBox.Show("请选择输出路径");
                return;
            }
            string lsshp=System .IO .Path.GetDirectoryName (this .pathtxt.Text)+"\\"+this .Lyrlist .SelectedItem.ToString ()+".shp";
            tool.ShpToCAD(fteLyr.FeatureClass,lsshp, this.pathtxt .Text, this.TypeCmbx.Text);
            this.Dispose();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
