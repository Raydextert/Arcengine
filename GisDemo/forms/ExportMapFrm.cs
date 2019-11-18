using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using GisDemo.Command;
namespace GisDemo.forms
{
    public partial class ExportMapFrm : Form
    {
        #region 字段属性
        private IActiveView  _Actiview = null;
        private IGeometry pGeometry = null;
        private string savePath = null;
        private bool bRegion = false;
        public IGeometry GetGeometry
        {
            set
            {
                pGeometry = value;
            }
        }
        public bool IsRgion
        {
            set
            {
                bRegion = value;
            }
        }
        #endregion
        public ExportMapFrm(AxMapControl _Mapcontrol)
        {
            InitializeComponent();
            _Actiview = _Mapcontrol.ActiveView;
        }

        private void ExportMap_Load(object sender, EventArgs e)
        {
            InitExportFrm();
        }
        private void InitExportFrm()
        {
            //获取分辨率
            Cmxresolution.Text = _Actiview.ScreenDisplay.DisplayTransformation.Resolution.ToString();
            Cmxresolution.Items.Add(Cmxresolution.Text);
            //判断全部还是部分导出
            if (bRegion)
            {
                IEnvelope envelope = pGeometry.Envelope;
                tagRECT pRect = new tagRECT();
                _Actiview.ScreenDisplay.DisplayTransformation.TransformRect(envelope, ref pRect, 9);
                if (Cmxresolution.Text != null)
                {
                    this.widthtxt.Text = pRect.right.ToString();
                    this.heighttxt.Text = pRect.bottom.ToString();

                }
            }
            else
            {
                if (Cmxresolution.Text != null)
                {
                    this.widthtxt.Text = this._Actiview.ExportFrame.right.ToString();
                    this.heighttxt.Text = this._Actiview.ExportFrame.bottom.ToString();
                }

            }
            
        
        }

        private void folderBrowserbtn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.DefaultExt = "jpg|bmp|gif|tif|png|pdf";
                dlg.Filter = "JPGE 文件(*.jpg)|*.jpg|BMP 文件(*.bmp)|*.bmp|GIF 文件(*.gif)|*.gif|TIF 文件(*.tif)|*.tif|PNG 文件(*.png)|*.png|PDF 文件(*.pdf)|*.pdf";
                dlg.RestoreDirectory = true;
                dlg.AddExtension = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    savePath = dlg.FileName;
                    this.pathtxt.Text = dlg.FileName;
                }

            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 实现导出地图功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exportbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Cmxresolution.Text))
            {
                MessageBox.Show("请输入分辨率", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(this.pathtxt.Text))
            {
                MessageBox.Show("请选择路径", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToInt32(Cmxresolution.Text) == 0)
            {
                MessageBox.Show("请输入正确的分辨率", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int resolution = int.Parse(this.Cmxresolution.Text);
            int width = int.Parse(this.widthtxt.Text);
            int height = int.Parse(this.heighttxt.Text);
            ExportMap.ExportView(_Actiview, resolution, pGeometry, width, height,this .pathtxt.Text , bRegion);
            _Actiview.GraphicsContainer.DeleteAllElements();
            _Actiview.Refresh();
            MessageBox.Show("导出成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportMapFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._Actiview.GraphicsContainer.DeleteAllElements();
            this._Actiview.Refresh();
            Dispose();
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this._Actiview.GraphicsContainer.DeleteAllElements();
            this._Actiview.Refresh();
            Dispose();
        }

        private void Cmxresolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            //分辨率变化输出图形也随之变化
            double resolution = (int)this._Actiview.ScreenDisplay.DisplayTransformation.Resolution;
            if (Cmxresolution.Text == "")
            {
                this.widthtxt.Text = "";
                this.heighttxt.Text = "";
                return;
            }
            if (bRegion)
            {
                IEnvelope envelope = pGeometry.Envelope;
                tagRECT pRECT = new tagRECT();
                _Actiview.ScreenDisplay.DisplayTransformation.TransformRect(envelope, ref pRECT, 9);
                if (Cmxresolution.Text != "")
                {
                    this.widthtxt.Text = Math.Round(pRECT.right * (double.Parse(Cmxresolution.Text) / resolution)).ToString();
                    this.heighttxt.Text = Math.Round(pRECT.bottom  * (double.Parse(Cmxresolution.Text) / resolution)).ToString();

                }
            }
            else
            {
                this.widthtxt.Text = Math.Round(this._Actiview.ExportFrame.right * (double.Parse(Cmxresolution.Text) / resolution)).ToString();
                this.widthtxt.Text = Math.Round(this._Actiview.ExportFrame.bottom  * (double.Parse(Cmxresolution.Text) / resolution)).ToString();
            }
        }

       
    }
}
