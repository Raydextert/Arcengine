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
    }
}
