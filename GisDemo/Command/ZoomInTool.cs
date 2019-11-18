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
using Plugin.UIContent.ExtensionsTool;
/*===================================================
 * 
 * 本类功能概述：地图放大
 * 
 * 
 * 作者：ZRC  时间：2019/11/14
 *===================================================
 */
namespace GisDemo.Command
{
    public class ZoomInTool : DciBaseTool
    {
        private IHookHelper m_Hookhelper = null;
        private IMapControlDefault mapControl = null;
       
        public ZoomInTool()
        {
            this.m_caption = "地图放大";
            this.m_category = "地图缩放工具";
            string path = Application.StartupPath;
            string filepath = path.Substring(0, path.LastIndexOf("\\"));
            this.m_cursor = new System.Windows.Forms.Cursor(filepath +"\\"+ "Icon\\Cursors\\ZoomInTool_B_16.cur");
        }
        public override void OnCreate(object hook)
        {
            base.OnCreate(hook);
            if (hook == null) return;
            m_Hookhelper = new HookHelperClass();
            m_Hookhelper.Hook = hook;
            this.mapControl = m_Hookhelper.Hook as IMapControlDefault;
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            base.OnMouseDown(Button, Shift, X, Y);
            if (Button != 1) return;
            try 
            {
                IPoint Dwnpoint = this.mapControl.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                IEnvelope pEnve = this.mapControl.TrackRectangle() as IEnvelope;
                if (!pEnve.IsEmpty)
                {
                    this.mapControl.ActiveView.Extent = pEnve;
                    this.mapControl.ActiveView.Refresh();
                }
                if (Dwnpoint != null &&!Dwnpoint.IsEmpty)
                {
                    IEnvelope envelope = this.mapControl.ActiveView.Extent ;
                    envelope.Expand(0.5, 0.5, true);
                    this.mapControl.ActiveView.Extent = envelope;
                    this.mapControl.ActiveView.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
