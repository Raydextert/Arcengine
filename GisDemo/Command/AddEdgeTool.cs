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
    //该类不可再继承
    public sealed class AddEdgeTool:BaseTool
    {
        private IHookHelper m_hookHelper = null;
        private IGeometricNetwork geometricNetwork;

        public IGeometricNetwork GeometricNetwork
        {
            set
            {
                geometricNetwork = value;
            }
        }

        private List<IEdgeFlag > listEdgeFlag;
        public List<IEdgeFlag> ListEdgeFlag
        {
            set
            {
                listEdgeFlag = value;
            }
        }

        public AddEdgeTool()
        {
            this.m_caption = "添加交汇边";
            this.m_category = "几何网络分析";
            this.m_message = "在地图上点击管线，将其添加为网络分析的线要素";
            this.m_toolTip = "添加分析管线";
            string path = Application.StartupPath;
            string filepath = path.Substring(0, path.LastIndexOf("\\"));
            this.m_cursor = new System.Windows.Forms.Cursor(filepath + "\\" + "Icon\\Cursors\\UtilityNetworkJunctionAdd16.cur");
        
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

            //查询与点最近的EID
            IPointToEID pointToEID = new PointToEIDClass();
            pointToEID.GeometricNetwork = geometricNetwork;
            pointToEID.SourceMap = map;
            pointToEID.SnapTolerance = 10;

            IPoint  outPoint = new PointClass();
            int nearestEdgeID = -1;
            double percent = -1;
            pointToEID.GetNearestEdge(inPoint, out nearestEdgeID, out outPoint,out percent);

            if (outPoint == null || outPoint.IsEmpty) return;
            //获取与点最邻近的边
            INetElements netElments = geometricNetwork.Network as INetElements;
            int userClSSID = 0;
            int userID = 0;
            int userSubID = 0;
            netElments.QueryIDs(nearestEdgeID , esriElementType.esriETEdge, out userClSSID, out userID, out userSubID);
            INetFlag netFlag = new EdgeFlagClass() as INetFlag;
            netFlag.UserClassID = userClSSID;
            netFlag.UserID = userID;
            netFlag.UserSubID = userSubID;
            //添加管线标识
            listEdgeFlag.Add(netFlag as IEdgeFlag);

            //绘制点所在的边
            DrawElement(outPoint);
        }

        private void DrawElement(IPoint point)
        {
            if (point == null || point.IsEmpty) return;
            ISimpleMarkerSymbol MarkerSymbol = new SimpleMarkerSymbolClass();
            MarkerSymbol.Size = 8;
            MarkerSymbol.Color = ExportMap.Getcolor(85, 255, 0);
            MarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSSquare;
            IElement element = new MarkerElementClass();
            element.Geometry = point;
            ((IMarkerElement)element).Symbol = MarkerSymbol;
            //设置添加要素点名称
            ((IElementProperties)element).Name = "Flag";
            this.m_hookHelper.ActiveView.GraphicsContainer.AddElement(element, 0);
            this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_hookHelper.ActiveView.Extent);
        }
    }
}
