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

namespace GisDemo.Command
{
    public class ClearselectionTool:BaseTool 
    {
        private IHookHelper m_hookHelper = null;
        private IMapControlDefault m_Mapcontrol = null;

        public override void OnCreate(object hook)
        {
           
            if (hook == null) return;
            m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;
            m_Mapcontrol = m_hookHelper.Hook as IMapControlDefault;
        }

        public ClearselectionTool()
        {
            this.m_toolTip = "清除所选要素";
            this.m_caption = "清除工具";
            this.m_category = "清除要素";
        }
        public override void OnClick()
        {
            base.OnClick();
            if (m_Mapcontrol == null) return;
            this.m_Mapcontrol.Map.ClearSelection();
            this.m_Mapcontrol.Refresh();
        }
    }
}
