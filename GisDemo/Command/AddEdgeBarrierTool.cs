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

namespace GisDemo.Command
{
    public class AddEdgeBarrierTool:BaseTool 
    {
        private IGeometricNetwork geometricNetwork = null;
        private IHookHelper m_hookHelper = null;
        private List<int> edgeBarrierEIDs;
            
        public IGeometricNetwork GemmetricNetwork
        {
            set { geometricNetwork = value; }
        }
        public List<int> EdgeBarrierEIDs
        {
            set { edgeBarrierEIDs = value; }
        }

        public AddEdgeBarrierTool()
        {
            this.m_caption = "添加交汇边";
            this.m_category = "几何网络分析";
            this.m_message = "在地图上点击管线，将其添加为网络分析的线要素";
            this.m_toolTip = "添加分析管线";
            string path = Application.StartupPath;
            string filepath = path.Substring(0, path.LastIndexOf("\\"));
            this.m_cursor = new System.Windows.Forms.Cursor(filepath + "\\" + "Icon\\Cursors\\UtilityNetworkBarrierAdd16_1.cur");
        
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
            //
            IPointToEID pointToEID = new PointToEIDClass();
            pointToEID.GeometricNetwork = geometricNetwork;
            pointToEID.SourceMap = m_hookHelper.FocusMap;
            pointToEID.SnapTolerance = 10;
            //
            int nearestEID = -1;
            double  percent = -1;
            IPoint outPoint = new PointClass();
            pointToEID.GetNearestEdge(inPoint, out nearestEID, out outPoint,out percent);
            //
            if (outPoint.IsEmpty || outPoint == null) return;
            edgeBarrierEIDs.Add(nearestEID);
            //绘制图形
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
