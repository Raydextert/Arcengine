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
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Geoprocessor;
using GisDemo.forms;
using GisDemo.Command;
namespace GisDemo
{
    //定义委托调用其他窗体控件
    public delegate void showResult(double  []a,string mapunits,string mouseOperate);
    public partial class MainFrm : Form
    {
        #region 字段变量
        ExportMapFrm exportmapFrm = null;//地图导出窗体
        frmMeasureResult frmMeasureResult = null;//量测窗体
        string pMouseOperate = null;
        private string sMapunits = "未知单位";
        
        private double TotalLength;//总长度
        private double SegmentLength;//部分長度

        IPoint Dwnpoint = null;
        IPoint movepnt = null;

        INewLineFeedback m_newline = null;
        INewPolygonFeedback m_newpolygon = null;
        IPointCollection Area_Pocoll = null;
        private object missing = Type.Missing;
        private IFeatureLayer featureLyr = null;
        private AttrbuteFrm attrFrm = null;
        private AttrQueryFrm attrqueryFrm = null;

        //网络分析窗体

        private NetAnalysisFrm netAnalysisFrm = null;
        #endregion
        public MainFrm()
        {
            InitializeComponent();
            this.axTOOControl.SetBuddyControl(this.axMapcontrol);
            this.axToolbarControl.SetBuddyControl(this.axMapcontrol);
        }

        //事件
        private event showResult ShowResultEvent;

        private void LoadMxdItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.RestoreDirectory = true;
                dlg.Filter = "地图文档(*.mxd)|*.mxd";
                dlg.Multiselect = false;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string filefullpath = dlg.FileName; ;
                    if (string.IsNullOrEmpty(filefullpath))
                        return;
                   //检查地图有效性
                    if (this.axMapcontrol.CheckMxFile(filefullpath))
                    {
                        this.axMapcontrol.LoadMxFile(filefullpath);
                    }
                    else
                    {
                        MessageBox.Show("打开失败，无效的地图文档", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                ControlsAddDataCommand addData = new ControlsAddDataCommandClass();
                addData.OnCreate(this.axMapcontrol.GetOcx());
                addData.OnClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                string mxdpath = this.axMapcontrol.DocumentFilename;
                IMapDocument mapDoc = new MapDocumentClass();
                if (!string.IsNullOrEmpty(mxdpath) && this.axMapcontrol.CheckMxFile(mxdpath))
                {
                    if (mapDoc.get_IsReadOnly(mxdpath))
                    {
                        MessageBox.Show("该文档为只读不能保存");
                        return;
                    }
                }
                else
                { 
                     //当没有默认路径时
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.AddExtension = true;
                    dlg.Filter = "地图文档(*.mxd)|*.mxd";
                    dlg.RestoreDirectory = true;
                    dlg.OverwritePrompt = true;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        mxdpath = dlg.FileName;

                    }
                    else
                    {
                        return;
                    }
                }
                mapDoc.New(mxdpath);
                mapDoc.ReplaceContents(this.axMapcontrol.Map as IMxdContents);
                mapDoc.Save(mapDoc.UsesRelativePaths, true);
                mapDoc.Close();
                MessageBox.Show("保存地图文档成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败"+ex.Message);
            }

        }

        private void SaveAsItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.RestoreDirectory = true;
                dlg.Filter = "地图文档(*.mxd)|*.mxd";
                dlg.AddExtension = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string mxdpath = dlg.FileName;
                    if (string.IsNullOrEmpty(mxdpath)) return;
                    IMapDocument mapDoc = new MapDocumentClass();
                    mapDoc.New(mxdpath);
                    mapDoc.ReplaceContents(this.axMapcontrol.Map as IMxdContents);
                    mapDoc.Save(true, true);
                    mapDoc.Close();
                    MessageBox.Show("保存成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败" + ex.Message);
            }

        }

        private void ExportMapItem_Click(object sender, EventArgs e)
        {

            try
            {
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出失败" + ex.Message);
            }
        }

        /// <summary>
        /// 区域导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegionExportItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.axMapcontrol.CurrentTool = null;
                this.axMapcontrol.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
                pMouseOperate = "区域导出";

            }
            catch (Exception ex)
            {
                MessageBox.Show("导出地图失败"+ex.Message);
            }
        }

        private void ExportToMapItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (exportmapFrm == null || exportmapFrm.IsDisposed)
                { 
                    exportmapFrm = new ExportMapFrm(this.axMapcontrol);
                }
                exportmapFrm.GetGeometry = this.axMapcontrol.ActiveView.Extent;
                exportmapFrm.IsRgion = false;
                exportmapFrm.Show();
                //激活窗体并赋予它焦点
                exportmapFrm.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        /// <summary>
        ///鼠标点击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axMapcontrol_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            Dwnpoint = new PointClass();
            Dwnpoint = this.axMapcontrol.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
            if (e.button != 1) return;
            #region 地图操作
            switch (pMouseOperate)
            { 
                case  "区域导出":
                 //删除绘制的图片
                    this.axMapcontrol.ActiveView.GraphicsContainer.DeleteAllElements();
                    this.axMapcontrol.ActiveView.Refresh();
                    IPolygon polygon = DrawPolygon(this.axMapcontrol);
                    if (polygon == null) return;
                    ExportMap.AddElement(polygon, this.axMapcontrol.ActiveView);
                    if (polygon == null) return;
                    if (exportmapFrm == null || exportmapFrm.IsDisposed)
                    {
                        exportmapFrm = new ExportMapFrm(this .axMapcontrol );
                        exportmapFrm.IsRgion = true;
                        exportmapFrm.GetGeometry = polygon as IGeometry;
                        exportmapFrm.Show();
                    }
                    exportmapFrm.GetGeometry = polygon;
                    exportmapFrm.IsRgion = true;
                    //获取当前控件焦点
                    exportmapFrm.Activate();
                    break;
                case "MeasureLength":
                    if (m_newline == null)
                    {
                        m_newline = new NewLineFeedbackClass();
                        m_newline.Display = this.axMapcontrol.ActiveView.ScreenDisplay;
                        m_newline.Start(Dwnpoint);
                        TotalLength = 0;
                    }
                    else
                    {
                        TotalLength += SegmentLength;
                        m_newline.AddPoint(Dwnpoint);
                    }
                    break;
                case "MeasureArea":
                    if (m_newpolygon == null||Area_Pocoll==null )
                    {
                        m_newpolygon = new NewPolygonFeedbackClass();
                        Area_Pocoll = new PolygonClass();
                        m_newpolygon.Display = this.axMapcontrol.ActiveView.ScreenDisplay;
                        m_newpolygon.Start(Dwnpoint);
                        Area_Pocoll.AddPoint(Dwnpoint);
                        TotalLength = 0;
                    }
                    else
                    {
                        m_newpolygon.AddPoint(Dwnpoint);
                        Area_Pocoll.AddPoint(Dwnpoint);
                        TotalLength += SegmentLength;
                    }
                    break;
            }


            #endregion
        }

        private IPolygon DrawPolygon(AxMapControl mapcontrol)
        {
            if (mapcontrol == null) return null;
            IGeometry pGeometry = null;
            //实例图形绘制对象
            IRubberBand rub = new RubberPolygonClass();
            pGeometry = rub.TrackNew(mapcontrol.ActiveView.ScreenDisplay, null);
            return pGeometry as IPolygon;
        }

        private void axMapcontrol_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            sMapunits = GetMapunits(this.axMapcontrol.Map.MapUnits);
            this.barCoortxt.Text = string.Format("当前坐标：X={0:#.###} Y={1:#.###} {2}", e.mapX, e.mapY,sMapunits);
            movepnt=new PointClass ();
            movepnt .PutCoords (e.mapX ,e .mapY );
            switch (pMouseOperate)
            { 
                case "MeasureLength":
                    if (m_newline != null&&movepnt !=null)
                    {
                        m_newline.MoveTo(movepnt);
                        //计算两点距离
                        double deltaX = 0;
                        double deltaY = 0;
                        deltaX = movepnt.X - Dwnpoint.X;
                        deltaY = movepnt.Y - Dwnpoint.Y;
                        SegmentLength = Math.Round(Math.Sqrt(deltaX * deltaX + deltaY * deltaY));
                        TotalLength = TotalLength + SegmentLength;
                        if (frmMeasureResult != null)
                        { 
                            //绑定事件
                            ShowResultEvent += new showResult(frmMeasureResult.showResult);
                            ShowResultEvent(new double[] { SegmentLength, TotalLength }, sMapunits,pMouseOperate);
                            TotalLength = TotalLength - SegmentLength;//鼠标移动到新点重新开始算
                        }
                   }
                    break;
                case "MeasureArea":
                    if (m_newpolygon != null && Area_Pocoll != null)
                    {
                        m_newpolygon.MoveTo(movepnt);
                        IPointCollection pocoll = new PolygonClass();
                        IGeometry pGeo = null;
                        IPolygon polygon = null;
                        ITopologicalOperator topo = null;
                        for (int i = 0; i < Area_Pocoll.PointCount; i++)
                        {
                            pocoll.AddPoint(Area_Pocoll.get_Point(i),missing,missing );
                        }
                        if (movepnt == null || movepnt.IsEmpty) return;
                        pocoll.AddPoint(movepnt, missing, missing);
                        if (pocoll.PointCount < 3) return;
                        polygon = pocoll as IPolygon;
                        if (polygon == null) return;
                        //多边形闭合
                        polygon.Close();
                        pGeo = polygon as IGeometry;
                        topo = pGeo as ITopologicalOperator;
                        //使几何图形的拓扑正确
                        topo.Simplify();
                        pGeo.Project(this.axMapcontrol.SpatialReference);
                        IArea area = pGeo as IArea;
                        if (frmMeasureResult != null && !frmMeasureResult.IsDisposed)
                        {
                            ShowResultEvent += new showResult(frmMeasureResult.showResult);
                            ShowResultEvent(new double[] { area.Area, polygon.Length }, sMapunits, pMouseOperate);
                        }
                    }
                    break;
            }

        }

        #region 私有方法
        private string GetMapunits(esriUnits _Mapunit)
        {
            string sMapunit = string.Empty;
            switch (_Mapunit)
            { 
                case esriUnits.esriCentimeters :
                    sMapunits = "厘米";
                    break;
                case  esriUnits.esriDecimalDegrees:
                    sMapunit = "十进制";
                     break ;
                case esriUnits.esriDecimeters:
                    sMapunit="分米";
                    break ;
                case esriUnits.esriFeet:
                    sMapunit ="尺";
                    break ;
                case esriUnits.esriInches:
                  sMapunit ="英寸";
                    break ;
                case esriUnits.esriKilometers:
                    sMapunit ="千米";
                    break ;
                case esriUnits.esriMeters:
                    sMapunit ="米";
                    break ;
                case esriUnits.esriMiles:
                    sMapunit ="英里";
                    break ;
                case  esriUnits.esriMillimeters:
                    sMapunit ="毫米";
                    break ;
                case esriUnits.esriNauticalMiles:
                    sMapunit ="海里";
                    break ;
                case esriUnits.esriPoints:
                    sMapunit="点";
                    break ;
                case  esriUnits.esriUnitsLast:
                    sMapunit="UnitsLast";
                    break ;
                case esriUnits.esriUnknownUnits:
                   sMapunit ="未知单位";
                    break ;
                case esriUnits.esriYards:
                    sMapunit ="码";
                    break ;
                default :
                    break ;
            }
          return sMapunit;
        }

        private void DrawElement(IGeometry pGeo)
        {
            if (pGeo == null) return;
            //线
            if (pGeo is IPolyline)
            {
                ISimpleLineSymbol linesymbol = new SimpleLineSymbolClass();
                linesymbol.Color = ExportMap.Getcolor(255, 255, 255);
                linesymbol.Width = 1;
                ILineElement m_LineElement = new LineElementClass();
                m_LineElement.Symbol = linesymbol;

                 //
                IElement pEle = m_LineElement as IElement;
                pEle.Geometry = pGeo;
                this.axMapcontrol.ActiveView.GraphicsContainer.AddElement(pEle, 0);
                this.axMapcontrol.ActiveView.Refresh();
            }
        }

        
        #endregion

        private void Calculatebtn_Click(object sender, EventArgs e)
        {
            this.axMapcontrol.CurrentTool = null;
            pMouseOperate = "MeasureLength";
            if (frmMeasureResult == null || frmMeasureResult.IsDisposed)
            {
                frmMeasureResult = new frmMeasureResult();
            }
            frmMeasureResult.Show();
            frmMeasureResult.Activate();
        }

        private void axMapcontrol_OnDoubleClick(object sender, IMapControlEvents2_OnDoubleClickEvent e)
        {
            IPoint dblpnt = new PointClass();
            dblpnt.PutCoords(e.mapX, e.mapY);
            switch (pMouseOperate)
            { 
                case "MeasureLength":
                    if (m_newline != null)
                    {
                        if(dblpnt.IsEmpty ||dblpnt ==null )return ;
                        IPolyline polyline = m_newline.Stop();
                        //绘制路径
                        DrawElement(polyline as IGeometry);
                        m_newline = null;
                        //显示长度
                        if (frmMeasureResult != null &&!frmMeasureResult.IsDisposed)
                        {
                            //double deltaX = dblpnt.X - Dwnpoint.X;
                            //double deltaY = dblpnt.Y - Dwnpoint.Y;
                            //SegmentLength = Math.Round(Math.Sqrt(deltaX * deltaX + deltaY * deltaY));
                            ShowResultEvent(new double[] { SegmentLength, TotalLength }, sMapunits,pMouseOperate);
                            //清除绘制要素
                            this.axMapcontrol.ActiveView.GraphicsContainer.DeleteAllElements();
                        }
                    }
                    break;
                case "MeasureArea":
                    if (m_newpolygon != null)
                    {
                        Area_Pocoll.AddPoint(dblpnt, missing, missing);
                        IPolygon polygon = m_newpolygon.Stop() as IPolygon;
                        if (Area_Pocoll.PointCount < 3||polygon.IsEmpty ) return;
                        polygon.Close();
                        IGeometry pGeo = polygon as IGeometry;
                        ITopologicalOperator topo = pGeo as ITopologicalOperator;
                        topo.Simplify();
                        pGeo.Project(this.axMapcontrol.SpatialReference);
                        IArea area = pGeo as IArea;
                        if (frmMeasureResult != null && !frmMeasureResult.IsDisposed)
                        {

                            ShowResultEvent(new double[] { area.Area, polygon.Length }, sMapunits, pMouseOperate);   
                        }
                    }
                    break;
            }
        }

        private void AreaCalbtn_Click(object sender, EventArgs e)
        {
            this.axMapcontrol.CurrentTool = null;
            pMouseOperate = "MeasureArea";
            if (frmMeasureResult == null || frmMeasureResult.IsDisposed)
            {
                frmMeasureResult = new frmMeasureResult();
            }
            frmMeasureResult.Show();
            frmMeasureResult.Activate();
        }

        private void ZoomInTool_Click(object sender, EventArgs e)
        {
            ZoomInTool tool = new ZoomInTool();
            tool.OnCreate(this.axMapcontrol.GetOcx());
            this.axMapcontrol.CurrentTool = tool as ITool;
        }

        private void ZoomOutTool_Click(object sender, EventArgs e)
        {
            ZoomOutTool tool = new ZoomOutTool();
            tool.OnCreate(this.axMapcontrol.GetOcx());
            this.axMapcontrol.CurrentTool = tool as ITool;
        }

        private void PanToolbtn_Click(object sender, EventArgs e)
        {
            //PanTool tool = new PanTool();
            //tool.OnCreate(this.axMapcontrol.GetOcx());
            //this.axMapcontrol.CurrentTool = tool as ITool;
            ICommand tool = new ControlsMapPanToolClass();
            tool.OnCreate(this.axMapcontrol.GetOcx());
            this.axMapcontrol.CurrentTool = tool as ITool;
        }

        private void FullExtentbtn_Click(object sender, EventArgs e)
        {
            this.axMapcontrol.ActiveView.Extent = this.axMapcontrol.FullExtent;
            this.axMapcontrol.ActiveView.Refresh();
        }

        private void AttributeFrmItem_Click(object sender, EventArgs e)
        {
            //打开属性表
            //实例互斥锁
            try
            {
                attrFrm = AttrbuteFrm.attrbuteFrm(this.axMapcontrol .GetOcx ());
                if (attrFrm.IsDisposed)
                {
                    attrFrm = AttrbuteFrm.attrbuteFrmSub(this.axMapcontrol .GetOcx ());
                }
                attrFrm.FteLyr = featureLyr;
                attrFrm.showFrm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void axTOOControl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
               ///右键打开菜单项
            try
            {
                if (e.button == 1) return;
                esriTOCControlItem pItem = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap pMap = null;
                ILayer Lyr = null;
                object unk = null;
                object data = null;
                this.axTOOControl.HitTest(e.x, e.y, ref pItem, ref pMap, ref Lyr, ref unk, ref data);
                 
                if (pItem == esriTOCControlItem.esriTOCControlItemLayer &&(Lyr as IFeatureLayer )!=null)
                {
                    this.LyrContxtMenuStrip.Show(MousePosition);
                }
                if (pItem == esriTOCControlItem.esriTOCControlItemMap)
                {
                    this.MapMenuStrip.Show(MousePosition);
                }
                featureLyr = Lyr as IFeatureLayer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddDataItem_Click(object sender, EventArgs e)
        {
            ControlsAddDataCommand cmd = new ControlsAddDataCommandClass();
            cmd.OnCreate(this.axMapcontrol.GetOcx());
            cmd.OnClick();
         }

        private void ExpandLyrItem_Click(object sender, EventArgs e)
        {
            //展开所有图层
            for (int i = 0; i < this.axMapcontrol.LayerCount; i++)
            {
                ILegendInfo m_LengendInfo = this.axMapcontrol.get_Layer(i) as ILegendInfo;
                for (int j = 0; j < m_LengendInfo.LegendGroupCount; j++)
                {
                    ILegendGroup pLenGroup = m_LengendInfo.get_LegendGroup(j) as ILegendGroup;
                    pLenGroup.Visible = true;
                }
            }
            this.axTOOControl.Update();
        }

        private void FoldLyrsItem_Click(object sender, EventArgs e)
        {
            //折叠所有图层
            for (int i = 0; i < this.axMapcontrol.LayerCount; i++)
            {
                ILegendInfo m_LengendInfo = this.axMapcontrol.get_Layer(i) as ILegendInfo;
                for (int j = 0; j < m_LengendInfo.LegendGroupCount; j++)
                {
                    ILegendGroup pLenGroup = m_LengendInfo.get_LegendGroup(j) as ILegendGroup;
                    pLenGroup.Visible = false;
                }
            }
            this.axTOOControl.Update();
        }

        private void OpenLyrsItem_Click(object sender, EventArgs e)
        {
              //打开所有图层
            for (int i = 0; i < this.axMapcontrol.LayerCount; i++)
            {
                ILayer lyr = this.axMapcontrol.get_Layer(i);
                lyr.Visible = true;
            }
            this.axMapcontrol.ActiveView.Refresh();
        }

        private void CloseLyrsItem_Click(object sender, EventArgs e)
        {
            //关闭所有图层
            for (int i = 0; i < this.axMapcontrol.LayerCount; i++)
            {
                ILayer lyr = this.axMapcontrol.get_Layer(i);
                lyr.Visible = false;
            }
            this.axMapcontrol.ActiveView.Refresh();
        }

        private void LyrExtentItem_Click(object sender, EventArgs e)
        {
              //缩放至图层
            if (featureLyr == null) return;
            IEnvelope pEnve = null;
            IFeatureClass fteClss = featureLyr.FeatureClass;
            IFeatureCursor pCursor = fteClss.Search(null, false);
            IFeature pfte;
            while ((pfte =pCursor .NextFeature ())!=null )
            {
                pEnve.Union(pfte.Extent);
            }
            this.axMapcontrol.ActiveView.Extent = pEnve;
            this.axMapcontrol.ActiveView.Refresh();
        }

        private void LyrToPicItem_Click(object sender, EventArgs e)
        {

        }

        private void ExportToCADItem_Click(object sender, EventArgs e)
        {
             //
            ExportCADfrm frm = new ExportCADfrm();
            frm.Mapcontrol = this.axMapcontrol.GetOcx () as IMapControlDefault;
            frm.Show();
        }

        private void AttrQueryItem_Click(object sender, EventArgs e)
        {
            if (attrqueryFrm == null || attrqueryFrm.IsDisposed)
            {
                attrqueryFrm = new AttrQueryFrm();
                attrqueryFrm.Mapcontrol = this.axMapcontrol.GetOcx() as IMapControlDefault;
                attrqueryFrm.Show();
            }
        }

        private void QuerystatisticsItem_Click(object sender, EventArgs e)
        {

        }

        private void Clearselectionbtn_Click(object sender, EventArgs e)
        {
            ClearselectionTool tool = new ClearselectionTool();
            tool.OnCreate(this.axMapcontrol.GetOcx());
            this.axMapcontrol.CurrentTool = tool as ITool;
        }

        private void SelectByPointItem_Click(object sender, EventArgs e)
        {
               //点击选择

        }

        private void GeometryNetAnalysis_Click(object sender, EventArgs e)
        {
              //加载分析窗体
            if (netAnalysisFrm == null || netAnalysisFrm.IsDisposed)
            {
                netAnalysisFrm = new NetAnalysisFrm();
                netAnalysisFrm.Mapcontrol = this.axMapcontrol.GetOcx() as IMapControlDefault;
            }  
            netAnalysisFrm.Show();
            netAnalysisFrm.Owner = this;
            netAnalysisFrm.Activate();
        }

    }
}
