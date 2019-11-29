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
    public sealed class AddJunctionFlagTool:BaseTool 
    {
        private IHookHelper m_hookHelper = null;

        private IGeometricNetwork geomretyNetwork;

        private List<IJunctionFlag> listJunctionFlags;

        public List<IJunctionFlag> ListJunctionFlags
        {
            set
            {
                listJunctionFlags = value;
            }
        }
        //接口数组都是引用类型
        public IGeometricNetwork GeometryNetwork
        {
            set
            {
                geomretyNetwork = value;
            }
        }

        public AddJunctionFlagTool()
        {
            this.m_caption = "添加交汇点";
            this.m_category = "几何网络分析";
            this.m_message = "在地图上点击管点，将其添加为网络分析的点要素";
            this.m_toolTip = "添加分析管点";
            string path = Application.StartupPath;
            string filepath = path.Substring(0, path.LastIndexOf("\\"));
            this.m_cursor = new System.Windows.Forms.Cursor(filepath + "\\" + "Icon\\Cursors\\UtilityNetworkJunctionAdd16.cur");
        }

        public override void OnCreate(object hook)
        {
            
            if(hook == null) return;
            m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = hook;
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            base.OnMouseDown(Button, Shift, X, Y);
            if (Button != 1) return;
            //获取坐标点
            IPoint inPoint = new PointClass();
            inPoint = m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
           
            IMap map = m_hookHelper.FocusMap;

            //查询与坐标点最近的管点
            IPointToEID pointToEID = new PointToEIDClass();
            //
            if (geomretyNetwork == null) return;
            pointToEID.GeometricNetwork = geomretyNetwork;
            pointToEID.SourceMap = map;
            pointToEID.SnapTolerance = 10;
            IPoint outPoint=new PointClass ();
            int nearestJunctionEID = -1;
            pointToEID.GetNearestJunction(inPoint,out nearestJunctionEID ,out outPoint);
            if (outPoint == null || outPoint.IsEmpty) return;
            //获取管点标识并加入列表
            INetElements netElemnts = geomretyNetwork.Network  as INetElements;

            int UserClassID = 0;
            int UserID = 0;
            int UserSubID = 0;
            netElemnts.QueryIDs(nearestJunctionEID, esriElementType.esriETJunction, out UserClassID, out UserID, out UserSubID);
            
            //设置并添加管点标识
            INetFlag netFlag = new JunctionFlagClass() as INetFlag;
            netFlag.UserClassID = UserClassID;
            netFlag.UserID = UserID;
            netFlag.UserSubID = UserSubID;
            //
            listJunctionFlags.Add(netFlag as IJunctionFlag);
            //绘制点要素
            DrawElement(outPoint);
         
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            
            //TODO: Add ToolAddJunctionFlag. OnMouseMove implementation
        }
        #region 私有方法

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
            this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_hookHelper.ActiveView.Extent );
        }
        #endregion
    }
}
