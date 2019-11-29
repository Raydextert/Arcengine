using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.NetworkAnalysis;
using System.Collections.Generic;
using ESRI.ArcGIS.Geodatabase;
using GisDemo.Command;
namespace GisDemo.Command
{
    public class AddJunctionBarrierTool:BaseTool
    {
        private IHookHelper m_hookHelper = null;

        private IGeometricNetwork geometricNetwork;
        private List<int> junctionBarrierEIDs;
     
        public IGeometricNetwork GeometricNetwork
        {
            set { geometricNetwork = value; }
        }

        public List<int> JunctionBarrierEIDs
        {
            set { junctionBarrierEIDs = value; }
        }

        public AddJunctionBarrierTool()
        {
            this.m_caption = "添加障碍点";
            this.m_category = "几何网络分析";
            this.m_message = "在地图上点击管点，将其添加为网络分析障碍的点要素";
            this.m_toolTip = "添加分析管点";
            string path = Application.StartupPath;
            string filepath = path.Substring(0, path.LastIndexOf("\\"));
            this.m_cursor = new System.Windows.Forms.Cursor(filepath + "\\" + "Icon\\Cursors\\UtilityNetworkBarrierJunctionAddTool16_1.cur");
        
        }

        public override void OnCreate(object hook)
        {
            if (hook == null) return;
            m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            if (Button != 1) return;
            IPoint inPoint = new PointClass();
            inPoint = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
            IMap map = this.m_hookHelper.FocusMap;
            //获取最邻近的要素ID
            IPointToEID pointToEID = new PointToEIDClass();
            pointToEID.GeometricNetwork = geometricNetwork;
            pointToEID.SourceMap = map;
            pointToEID.SnapTolerance = 10;
            int nearstJunctionEID = -1;
            IPoint outPoint = new PointClass();
            pointToEID.GetNearestJunction(inPoint, out nearstJunctionEID, out outPoint);
            if (outPoint == null || outPoint.IsEmpty) return;
            junctionBarrierEIDs.Add(nearstJunctionEID);
            //绘制要素  
            DrawElement(outPoint);
        }

        private void DrawElement(IPoint point)
        {
            if (point == null || point.IsEmpty) return;
            ISimpleMarkerSymbol MarkerSymbol = new SimpleMarkerSymbolClass();
            MarkerSymbol.Size = 8;
            MarkerSymbol.Color = Method.Getcolor(255,0, 0);
            //绘制形状为十字丝
            MarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSX;
            IElement element = new MarkerElementClass();
            element.Geometry = point;
            ((IMarkerElement)element).Symbol = MarkerSymbol;
            //设置添加要素点名称
            ((IElementProperties)element).Name = "Barrier";
            this.m_hookHelper.ActiveView.GraphicsContainer.AddElement(element, 0);
            this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_hookHelper.ActiveView.Extent);
        }
    }
}
