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
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.NetworkAnalysis;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using GisDemo.Command;
namespace GisDemo.forms
{
    public partial class NetAnalysisFrm : Form
    {
        public NetAnalysisFrm()
        {
            InitializeComponent();
            traceFlowsolverGen = new TraceFlowSolverClass();
            netsolver = traceFlowsolverGen as INetSolver;
        }
        private IMapControlDefault mapcontrol = null;
        public IMapControlDefault Mapcontrol
        {
            set { mapcontrol = value; }
            get { return mapcontrol; }
        }
        
        private IGeometricNetwork m_GeometryNetwork = null;

        /// <summary>
        ///执行网络分析的借口
        /// </summary>
        private ITraceFlowSolverGEN traceFlowsolverGen;

        /// <summary>
        /// 执行网络分析的另一接口
        /// </summary>
        private INetSolver netsolver;
        
        /// <summary>
        /// 管点标识列表
        /// </summary>
        private List<IJunctionFlag> listJunctionsFlag =new List<IJunctionFlag> ();

        /// <summary>
        /// 记录节点边数组
        /// </summary>
        private List<IEdgeFlag> listEdgeFlag = new List<IEdgeFlag>();

        /// <summary>
        /// 记录管点障碍列表
        /// </summary>
        private List<int> JunctionBarrierEIDs = new List<int>();

        /// <summary>
        /// 记录管线障碍列表
        /// </summary>
        private List<int> EdgeBarrierEIDs = new List<int>();
        #region 
        
        private void LoadGeometryNetwork()
        {
            if (Mapcontrol == null) return;
            for (int i = 0; i < Mapcontrol.LayerCount; i++)
            {
                IFeatureLayer pfteLyr = Mapcontrol.get_Layer(i) as IFeatureLayer;
                //获取要素数据集
                IFeatureDataset fteDataset = pfteLyr.FeatureClass.FeatureDataset;
                //获取网络数据集合
                INetworkCollection2 netcoll = fteDataset as INetworkCollection2;
                //获取数据集
                m_GeometryNetwork = netcoll.get_GeometricNetwork(0);
                if (m_GeometryNetwork == null) continue;
                else
                { 
                       //获取逻辑网络数据集
                    netsolver.SourceNetwork = m_GeometryNetwork.Network;
                    //获取几何网络数据名
                    IDataset dataset = m_GeometryNetwork as IDataset;
                    if (!this.NetlistCmbx.Items.Contains(dataset.Name))
                    {  
                      this.NetlistCmbx.Items.Add(dataset.Name);
                    }
                    break;
                }
               
            }
            if (this.NetlistCmbx.Items.Count == 0) return;
            this.NetlistCmbx.Text = this.NetlistCmbx.Items[0].ToString();

        }

        private void showFlowDirection(IFeatureClass featureclass, IUtilityNetworkGEN UtilityNetworkGEN)
        {
            try
            {
                   //获取要素类的ID号
                INetElements netElement = UtilityNetworkGEN as INetElements;
                //获取流向
                esriFlowDirection flowDirection = new ESRI.ArcGIS.Geodatabase.esriFlowDirection();
                //定义当前要素的EID
                int currentEID = -1;
                IFeatureCursor pCursor = featureclass.Search(null, false);
                IFeature pfte = pCursor.NextFeature();
                while (pfte != null)
                {
                    currentEID = netElement.GetEID(featureclass.FeatureClassID, pfte.OID, 0, esriElementType.esriETEdge);
                    flowDirection = UtilityNetworkGEN.GetFlowDirection(currentEID);

                    //绘制流向
                    DrawFlowDirection(pfte, Mapcontrol, flowDirection);
                    pfte = pCursor.NextFeature();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void DrawFlowDirection(IFeature feature, IMapControlDefault mapc,esriFlowDirection flowdir)
        { 
                 //获取线段中点
            IPolyline polyline = feature.Shape as IPolyline;
            IPoint midpoint = new PointClass();
            polyline.QueryPoint(esriSegmentExtension.esriNoExtension, polyline.Length / 2, false, midpoint);
            //绘制特征符号
            IArrowMarkerSymbol arrowSymbol = new ArrowMarkerSymbolClass();
            ISimpleMarkerSymbol markerSymbol = new SimpleMarkerSymbolClass();

            IElement element = null;
            //绘制沿顺着数字化流向
            if (flowdir == esriFlowDirection.esriFDWithFlow)
            {
                arrowSymbol.Size = 12;
                arrowSymbol.Color = ExportMap.Getcolor(0, 0, 0);
                arrowSymbol.Angle = GetlineAngle(polyline.FromPoint, polyline.ToPoint);

                //绘制

                element = new MarkerElementClass();
                element.Geometry = midpoint;
                ((IMarkerElement)element).Symbol = arrowSymbol;
                //设置绘制元素名称
                ((IElementProperties)element).Name = "Flow";            
            }
            //方向顺着逆数字化的
            if (flowdir == esriFlowDirection.esriFDAgainstFlow)
            {
                arrowSymbol.Size = 12;
                arrowSymbol.Color = ExportMap.Getcolor(0, 0, 0);
                arrowSymbol.Angle = GetlineAngle(polyline.FromPoint, polyline.ToPoint);

                //绘制

                element = new MarkerElementClass();
                element.Geometry = midpoint;
                ((IMarkerElement)element).Symbol = arrowSymbol;
                //设置绘制元素名称
                ((IElementProperties)element).Name = "Flow";
            }
            //方向未初始化的
            if (flowdir == esriFlowDirection.esriFDUninitialized)
            {
                markerSymbol.Color = ExportMap.Getcolor(0, 0, 0);
                markerSymbol.Size = 8;

                element = new MarkerElementClass();
                element.Geometry = midpoint;
                ((IMarkerElement)element).Symbol = markerSymbol;
                //设置绘制元素名称
                ((IElementProperties)element).Name = "Flow";
            }
            //方向未定义的
            if (flowdir == esriFlowDirection.esriFDIndeterminate)
            {

                markerSymbol.Color = ExportMap.Getcolor(0, 0, 0);
                markerSymbol.Size = 8;

                element = new MarkerElementClass();
                element.Geometry = midpoint;
                ((IMarkerElement)element).Symbol = markerSymbol;
                //设置绘制元素名称
                ((IElementProperties)element).Name = "Flow";
            }
            mapc.ActiveView.GraphicsContainer.AddElement(element, 0);
        }

        private double GetlineAngle(IPoint startpoint, IPoint endpoint)
        {
            double angle = -1;
            //在同一水平线上
            if (startpoint.Y == endpoint.Y)
            {
                if (endpoint.X >= startpoint.X)
                    angle = 0;
                else
                    angle = 180;
            }
            //在同一竖直线上
            if (startpoint.X == endpoint.X)
            {
                if (endpoint.Y >= startpoint.Y)
                    angle = 90;
                else
                    angle = 270;
            }
            //当点位于一、二象限的时候
            if (endpoint.Y > startpoint.Y)
            {
                if (endpoint.X > startpoint.X)
                    angle = Math.Atan((endpoint.Y - startpoint.Y) / (endpoint.X - startpoint.X));
                if(endpoint .X <startpoint .X )
                    angle = Math.Atan((endpoint.Y - startpoint.Y) / (startpoint.X-endpoint .X ))+90;
            }
            if (endpoint.Y < startpoint.Y)
            {
                if (endpoint.X > startpoint.X)
                    angle = 360-Math.Atan((startpoint.Y - endpoint.Y) / (endpoint.X - startpoint.X));
                if (endpoint.X < startpoint.X)
                    angle = Math.Atan((startpoint.Y - endpoint.Y) / (startpoint.X - endpoint.X)) + 180;
            }
            return angle;
        }
        #endregion

        private void NetAnalysisFrm_Load(object sender, EventArgs e)
        {
              //加载集合网络名称
            LoadGeometryNetwork();
        }

        private void FlowDiretionBtn_Click(object sender, EventArgs e)
        {
            if (m_GeometryNetwork == null) return;
            INetwork network = m_GeometryNetwork.Network;
            //获取描述网络流向的接口
            IUtilityNetworkGEN utilityNetworkGEN = network as IUtilityNetworkGEN;
            //获取线要素类
            //建立线要素类字典
            Dictionary<IFeatureClass, string> dic = new Dictionary<IFeatureClass, string>();
            for (int i = 0; i < this.Mapcontrol.LayerCount; i++)
            {
                IFeatureLayer Lyr = this.Mapcontrol.get_Layer(i) as IFeatureLayer;
                if (Lyr == null) continue;
                if (Lyr.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                {    
                    if(!dic .ContainsValue (Lyr .FeatureClass .AliasName ))
                       dic.Add(Lyr.FeatureClass, Lyr .FeatureClass .AliasName );
                }
            }
            //遍历字典
            foreach (KeyValuePair<IFeatureClass, string> key in dic)
            {
                showFlowDirection(key.Key, utilityNetworkGEN);       
            }
            this.Mapcontrol.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.Mapcontrol.FullExtent);
        }

        private void AddJunctionFlagBtn_Click(object sender, EventArgs e)
        {
            //添加交汇点
            AddJunctionFlagTool tool = new AddJunctionFlagTool();
            tool.GeometryNetwork = m_GeometryNetwork;
            
            //记录节点集合
            tool.ListJunctionFlags = listJunctionsFlag;
            tool.OnCreate((object)this.Mapcontrol);
            this.Mapcontrol.CurrentTool = tool as ITool;
        }

        private void AddEdgeFlagBtn_Click(object sender, EventArgs e)
        {
            AddEdgeTool tool = new AddEdgeTool();
            tool.OnCreate((object)this.Mapcontrol);
            tool.GeometricNetwork = m_GeometryNetwork;
            tool.ListEdgeFlag = listEdgeFlag;
            this.Mapcontrol.CurrentTool = tool as ITool;
        }

        private void AddJunctionBarrierBtn_Click(object sender, EventArgs e)
        {
            AddJunctionBarrierTool tool = new AddJunctionBarrierTool();
            tool.OnCreate(this.Mapcontrol);
            tool.GeometricNetwork = m_GeometryNetwork;
            tool.JunctionBarrierEIDs = JunctionBarrierEIDs;
            this.Mapcontrol.CurrentTool = tool as ITool;
        }

        private void AddEdgeBarrierBtn_Click(object sender, EventArgs e)
        {
            AddEdgeBarrierTool tool = new AddEdgeBarrierTool();
            tool.OnCreate(this.Mapcontrol);
            tool.GemmetricNetwork = m_GeometryNetwork;
            tool.EdgeBarrierEIDs = EdgeBarrierEIDs;
            this.Mapcontrol.CurrentTool = tool as ITool;
        }

        private void ResultBtn_Click(object sender, EventArgs e)
        {
            try
            {
                #region 设置管点分析分析条件
                //为追踪任务分析器设置管点
                IJunctionFlag[] arrayJunctionFlag = new IJunctionFlag[listJunctionsFlag.Count];
                for (int i = 0; i < arrayJunctionFlag.Length; i++)
                    arrayJunctionFlag[i] = listJunctionsFlag[i];
                traceFlowsolverGen.PutJunctionOrigins(ref arrayJunctionFlag);
                //为追踪任务分析器设置管线
                IEdgeFlag[] arrayEdgeFlag = new IEdgeFlag[listEdgeFlag.Count];
                for (int i = 0; i < arrayEdgeFlag.Length; i++)
                    traceFlowsolverGen.PutEdgeOrigins(ref arrayEdgeFlag);

                //为管点分析器设置障碍点
                INetElementBarriersGEN netElementBarriersGEN = new NetElementBarriersClass();
                netElementBarriersGEN.Network = m_GeometryNetwork.Network;
                if (JunctionBarrierEIDs.Count > 0)
                {
                    int[] junctionBarrierEIDs = new int[JunctionBarrierEIDs.Count];
                    for (int j = 0; j < junctionBarrierEIDs.Length; j++)
                        junctionBarrierEIDs[j] = JunctionBarrierEIDs[j];
                    netElementBarriersGEN.ElementType = esriElementType.esriETJunction;
                    netElementBarriersGEN.SetBarriersByEID(ref junctionBarrierEIDs);
                    netsolver.set_ElementBarriers(esriElementType.esriETJunction, netElementBarriersGEN as INetElementBarriers);
                }
                else  //否则将管点设置为空
                    netsolver.set_ElementBarriers(esriElementType.esriETJunction, null);
                //未管点分析器设置障碍线
                if (EdgeBarrierEIDs.Count > 0)
                {
                    int[] edgeBarrierEIDs = new int[EdgeBarrierEIDs.Count];
                    for (int j = 0; j < EdgeBarrierEIDs.Count; j++)
                        edgeBarrierEIDs[j] = EdgeBarrierEIDs[j];
                    netElementBarriersGEN.ElementType = esriElementType.esriETEdge;
                    netElementBarriersGEN.SetBarriersByEID(ref edgeBarrierEIDs);
                    netsolver.set_ElementBarriers(esriElementType.esriETEdge, netElementBarriersGEN as INetElementBarriers);
                }
                else //否则将管线设置为空
                    netsolver.set_ElementBarriers(esriElementType.esriETEdge, null);

                #endregion

                //定义相关变量
                IEnumNetEID junctionEIDs = new EnumNetEIDArrayClass();
                IEnumNetEID edgeEIDs = new EnumNetEIDArrayClass();
              
                object[] segmentsCosts = null;
                object totalCost = null;
                int Counts = -1;
                #region 各种几何网络分析的结果
                switch (this.AnalysisCategoryCmbx.SelectedIndex)
                {    
                        //查询共同祖先
                    case 0:
                        traceFlowsolverGen.FindCommonAncestors(esriFlowElements.esriFEJunctionsAndEdges, out junctionEIDs, out edgeEIDs);
                        break;
                    //查找相连接的网络要素
                    case 1:
                        traceFlowsolverGen.FindFlowElements(esriFlowMethod.esriFMConnected, esriFlowElements.esriFEJunctionsAndEdges, out  junctionEIDs, out edgeEIDs);
                        break;
                        //查找网络中连接的环
                    case 2:
                        traceFlowsolverGen.FindCircuits(esriFlowElements .esriFEJunctionsAndEdges ,out junctionEIDs ,out edgeEIDs );
                        break;
                       //查找未连接的网络要素
                    case 3:
                        traceFlowsolverGen.FindFlowUnreachedElements(esriFlowMethod.esriFMConnected, esriFlowElements.esriFEJunctionsAndEdges, out junctionEIDs, out edgeEIDs);
                        break;
                        //查找上游路径，同时跟踪耗费
                    case 4:
                        Counts = GetSegmentCounts();
                        segmentsCosts = new object[Counts];
                        traceFlowsolverGen.FindSource(esriFlowMethod.esriFMUpstream, esriShortestPathObjFn.esriSPObjFnMinSum, out junctionEIDs, out edgeEIDs, Counts, ref segmentsCosts);
                        break;
                        //获取网络路径，追踪网络耗费。count比所有的的标识总数少一个，但如果管点和管线标识同时存在的时候该功能不可用
                    case 5:
                        if (listEdgeFlag.Count > 0 && listJunctionsFlag.Count > 0)
                            break;
                        else if (listJunctionsFlag.Count > 0)
                            Counts = listJunctionsFlag.Count - 1;
                        else if (listEdgeFlag.Count > 0)
                            Counts = listEdgeFlag.Count - 1;
                        else
                            break;
                        segmentsCosts = new object[Counts];
                        traceFlowsolverGen.FindPath(esriFlowMethod.esriFMConnected, esriShortestPathObjFn.esriSPObjFnMinSum, out junctionEIDs, out edgeEIDs, Counts, ref segmentsCosts);
                        break;
                      //下游追踪
                    case 6:
                        traceFlowsolverGen.FindFlowElements(esriFlowMethod.esriFMDownstream, esriFlowElements.esriFEJunctionsAndEdges, out junctionEIDs, out edgeEIDs);
                        break;
                     //查找上游路径消耗，同时获取网络追踪的耗费
                    case 7:
                        totalCost = new object();
                        traceFlowsolverGen.FindAccumulation(esriFlowMethod.esriFMUpstream, esriFlowElements.esriFEJunctionsAndEdges, out junctionEIDs, out edgeEIDs,out totalCost);
                        break;
                    //上游追踪
                    case 8:
                        Counts = GetSegmentCounts();
                        segmentsCosts = new object[Counts];
                        traceFlowsolverGen.FindSource(esriFlowMethod.esriFMUpstream, esriShortestPathObjFn.esriSPObjFnMinSum, out junctionEIDs, out edgeEIDs, Counts, ref segmentsCosts);
                        break;
                    default :
                        break;
                }   

                #endregion 
                
                //绘制结果图像
                DrawTraceRsult(junctionEIDs, edgeEIDs);
                this.Mapcontrol.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.Mapcontrol.ActiveView.Extent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }



        #region 私有方法
        /// <summary>
        /// 根据管线和管点两个列表返回二者数量的总和
        /// </summary>
        /// <returns>返回列表的总个数</returns>
        private int GetSegmentCounts()
        {
            int count = 0;
            if (listEdgeFlag.Count > 0 && listJunctionsFlag.Count > 0)
            {
                count = listJunctionsFlag.Count + listEdgeFlag.Count;
            }
            else if (listEdgeFlag.Count > 0)
            {
                count = listEdgeFlag.Count;
            }
            else if (listJunctionsFlag.Count > 0)
            {
                count = listJunctionsFlag.Count;
            }
            else
                count = 0;
            return count;
        }
        
        private void DrawTraceRsult(IEnumNetEID JunctionEIDs,IEnumNetEID EdgEIDs)
        {
            if (JunctionBarrierEIDs == null || EdgEIDs == null) return;
            INetElements netElements = m_GeometryNetwork.Network as INetElements;
            int userClssID = -1;
            int userID = -1;
            int userSubID = -1;
            int eid = -1;
            //
            IFeatureClass fteClss;
            IFeature feature;
            //设置管点和管线显示的Symbol
            ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
            simpleMarkerSymbol.Color = Method .Getcolor (255,0,0);
            simpleMarkerSymbol.Size = 6;
            simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
            simpleLineSymbol.Color = Method.Getcolor(255, 0, 0);
            simpleLineSymbol.Width = 2;
            simpleLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            IElement element;
            //获取管点结果
            for (int i = 0; i < JunctionEIDs.Count; i++)
            {
                eid = JunctionEIDs.Next();
                netElements.QueryIDs(eid ,esriElementType.esriETJunction ,out userClssID ,out userID ,out userSubID );
                fteClss = GetFteClssByID(userClssID, this.Mapcontrol.Map);
                if (fteClss != null)
                {
                    feature = fteClss.GetFeature(userID);
                    element = new MarkerElementClass();
                    element.Geometry = feature.Shape;
                    ((IMarkerElement)element).Symbol = simpleMarkerSymbol;
                    ((IElementProperties)element).Name = "Result";
                    this.Mapcontrol.ActiveView.GraphicsContainer.AddElement(element, 0);
                }
            }
            //获取管线结果
            for (int j = 0; j < EdgEIDs.Count; j++)
            {
                eid = EdgEIDs.Next();
                netElements.QueryIDs(eid, esriElementType.esriETEdge, out userClssID, out userID, out userSubID);
                 fteClss = GetFteClssByID(userClssID,this .Mapcontrol .Map );
                 if (fteClss != null)
                 {
                     feature = fteClss.GetFeature(userID);
                     element = new LineElementClass ();
                     element.Geometry = feature.Shape;
                     ((ILineElement )element).Symbol = simpleLineSymbol;
                     ((IElementProperties)element).Name = "Result";
                     this.Mapcontrol.ActiveView.GraphicsContainer.AddElement(element, 0);
                  
                 }
            }

        }
        
        private IFeatureClass GetFteClssByID(int userFeatureClassID, IMap map)
        {
            IFeatureClass featureclass;
            for (int i = 0; i < map.LayerCount; i++)
            {
                IFeatureLayer Lyr = map.get_Layer(i) as IFeatureLayer;
                if (userFeatureClassID == Lyr.FeatureClass.FeatureClassID)
                {
                    featureclass = Lyr.FeatureClass;
                    return featureclass;
                }
            }
            return null;
        }

        private void ClearElement(IActiveView actiview ,string elementType)
        {
            IGraphicsContainer graphicsContainer = actiview.GraphicsContainer;
            graphicsContainer.Reset();
            IElement element = graphicsContainer.Next();
            while (element != null)
            {
                if (((IElementProperties)element).Name == elementType)
                {
                    graphicsContainer.DeleteElement(element);
                }
                element = graphicsContainer.Next();
            }
            actiview.Refresh();
        }
        #endregion

        private void ClearMarkItem_Click(object sender, EventArgs e)
        {
            //清除标记
            ClearElement(this.Mapcontrol.ActiveView, "Flag");
        }

        private void ClearBarrierItem_Click(object sender, EventArgs e)
        {
               //清除障碍
            ClearElement(this.Mapcontrol.ActiveView, "Barrier");
        }

        private void ClearResultItem_Click(object sender, EventArgs e)
        {
             //清除结果
            ClearElement(this.Mapcontrol.ActiveView, "Result");
        }

        private void ClearFlowItem_Click(object sender, EventArgs e)
        {
            //清除流向
            ClearElement(this.Mapcontrol.ActiveView, "Flow");
        }
    }
}
