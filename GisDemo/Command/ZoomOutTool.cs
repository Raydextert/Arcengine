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
/*===========================================
 * 
 *  本类功能概述：地图缩小功能
 *  
 * 
 *作者：ZRC  时间：2019/11/14
 *================================================
 */
namespace GisDemo.Command
{
   public class ZoomOutTool:DciBaseTool 
    {
       private IHookHelper m_hookHelper = null;
       private IMapControlDefault mapcontrol = null;
       public ZoomOutTool()
       {
           this.m_caption = "地图缩小";
           this.m_category = "地图操作";
           string path = Application.StartupPath;
           string filepath = path.Substring(0, path.LastIndexOf("\\"));
           this.m_cursor = new System.Windows.Forms.Cursor(filepath + "\\" + "Icon\\Cursors\\ZoomOutTool_B_16.cur");   
       }

       public override void OnCreate(object hook)
       {
           base.OnCreate(hook);
           if(hook == null) return;
           m_hookHelper = new HookHelperClass();
           m_hookHelper.Hook = hook;
           mapcontrol = m_hookHelper.Hook as IMapControlDefault;
       }

       public override void OnMouseDown(int Button, int Shift, int X, int Y)
       {
           base.OnMouseDown(Button, Shift, X, Y);
           if (Button != 1) return;
           IPoint Dwnpoint = this.mapcontrol.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
           IEnvelope pEnve = this.mapcontrol.TrackRectangle();
           if (!pEnve.IsEmpty)
           {
               IEnvelope currentExtent, NewIEN = null;
               currentExtent =this.mapcontrol.ActiveView .Extent;
               double dXmin = 0, dYmin = 0, dXmax = 0, dYmax = 0, dHeight = 0, dWidth = 0;
               dWidth = currentExtent.Width * (currentExtent.Width / pEnve.Width);
               dHeight = currentExtent.Height * (currentExtent.Height / pEnve.Height);
               dXmin = currentExtent.XMin - ((pEnve.XMin - currentExtent.XMin) * (currentExtent.Width / pEnve.Width));
               dYmin = currentExtent.YMin - ((pEnve.YMin - currentExtent.YMin) * (currentExtent.Height / pEnve.Height));
               dXmax = dXmin + dWidth;
               dYmax = dYmin + dHeight;

               NewIEN = new EnvelopeClass();
               NewIEN.PutCoords(dXmin, dYmin, dXmax, dYmax);
               this.mapcontrol.ActiveView.Extent = NewIEN;
               this.mapcontrol.ActiveView.Refresh();
           }
           if (Dwnpoint != null &&!Dwnpoint.IsEmpty)
           {
               IEnvelope envelope = this.mapcontrol.ActiveView.Extent;
               envelope.Expand(2, 2, true);
               this.mapcontrol.ActiveView.Extent = envelope;
               this.mapcontrol.ActiveView.Refresh();
           }

       }
    }
}
