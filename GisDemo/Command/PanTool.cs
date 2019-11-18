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
/*=========================================================
 * 
 *  功能概述：漫游
 * 
 * ========================================================
 */
namespace GisDemo.Command
{
    public class PanTool:DciBaseTool 
    {
        private IHookHelper m_hookHelper = null;
        private IMapControlDefault mapcontrol = null;
        public PanTool()
        {
            this.m_caption = "漫游";
            this.m_category = "地图操作";
            string path = Application.StartupPath;
            string filepath = path.Substring(0, path.LastIndexOf("\\"));
            this.m_cursor = new System.Windows.Forms.Cursor(filepath + "\\" + "Icon\\Cursors\\PanTool_B_16.cur");   
        }

        public override void OnCreate(object hook)
        {
            base.OnCreate(hook);
            if (hook == null) return;
            m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;
            mapcontrol = m_hookHelper.Hook as IMapControlDefault;
            this.mapcontrol.Pan();
        }

        public override void OnClick()
        {
            base.OnClick();
            
        }
    }
}
