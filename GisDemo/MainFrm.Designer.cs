namespace GisDemo
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.VerticalSplit = new System.Windows.Forms.SplitContainer();
            this.levelSplit = new System.Windows.Forms.SplitContainer();
            this.axToolbarControl = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.barCoortxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.axTOOControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapcontrol = new ESRI.ArcGIS.Controls.AxMapControl();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadMxdItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportMapItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegionExportItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToMapItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuerystatisticsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AttrQueryItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectByPointItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectByRecItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NetAnalysisItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathAnalysisItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PipeAnalysisItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GeometryNetAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LengthCalbtn = new System.Windows.Forms.ToolStripButton();
            this.AreaCalbtn = new System.Windows.Forms.ToolStripButton();
            this.ZoomInTool = new System.Windows.Forms.ToolStripButton();
            this.ZoomOutTool = new System.Windows.Forms.ToolStripButton();
            this.PanToolbtn = new System.Windows.Forms.ToolStripButton();
            this.FullExtentbtn = new System.Windows.Forms.ToolStripButton();
            this.Clearselectionbtn = new System.Windows.Forms.ToolStripButton();
            this.LyrContxtMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AttributeFrmItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LyrExtentItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LyrToPicItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportDataItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToCADItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标注要素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MapMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddDataItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExpandLyrItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FoldLyrsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenLyrsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseLyrsItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.VerticalSplit)).BeginInit();
            this.VerticalSplit.Panel1.SuspendLayout();
            this.VerticalSplit.Panel2.SuspendLayout();
            this.VerticalSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelSplit)).BeginInit();
            this.levelSplit.Panel1.SuspendLayout();
            this.levelSplit.Panel2.SuspendLayout();
            this.levelSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOOControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapcontrol)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.LyrContxtMenuStrip.SuspendLayout();
            this.MapMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // VerticalSplit
            // 
            this.VerticalSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerticalSplit.Location = new System.Drawing.Point(0, 28);
            this.VerticalSplit.Name = "VerticalSplit";
            // 
            // VerticalSplit.Panel1
            // 
            this.VerticalSplit.Panel1.Controls.Add(this.levelSplit);
            // 
            // VerticalSplit.Panel2
            // 
            this.VerticalSplit.Panel2.Controls.Add(this.axLicenseControl1);
            this.VerticalSplit.Panel2.Controls.Add(this.axMapcontrol);
            this.VerticalSplit.Size = new System.Drawing.Size(1030, 584);
            this.VerticalSplit.SplitterDistance = 379;
            this.VerticalSplit.TabIndex = 0;
            // 
            // levelSplit
            // 
            this.levelSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelSplit.Location = new System.Drawing.Point(0, 0);
            this.levelSplit.Name = "levelSplit";
            this.levelSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // levelSplit.Panel1
            // 
            this.levelSplit.Panel1.Controls.Add(this.axToolbarControl);
            // 
            // levelSplit.Panel2
            // 
            this.levelSplit.Panel2.Controls.Add(this.statusStrip1);
            this.levelSplit.Panel2.Controls.Add(this.axTOOControl);
            this.levelSplit.Size = new System.Drawing.Size(379, 584);
            this.levelSplit.SplitterDistance = 26;
            this.levelSplit.TabIndex = 1;
            // 
            // axToolbarControl
            // 
            this.axToolbarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axToolbarControl.Location = new System.Drawing.Point(0, 0);
            this.axToolbarControl.Name = "axToolbarControl";
            this.axToolbarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl.OcxState")));
            this.axToolbarControl.Size = new System.Drawing.Size(379, 28);
            this.axToolbarControl.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barCoortxt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(379, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // barCoortxt
            // 
            this.barCoortxt.Name = "barCoortxt";
            this.barCoortxt.Size = new System.Drawing.Size(99, 20);
            this.barCoortxt.Text = "当前坐标为：";
            // 
            // axTOOControl
            // 
            this.axTOOControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOOControl.Location = new System.Drawing.Point(0, 0);
            this.axTOOControl.Name = "axTOOControl";
            this.axTOOControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOOControl.OcxState")));
            this.axTOOControl.Size = new System.Drawing.Size(379, 554);
            this.axTOOControl.TabIndex = 0;
            this.axTOOControl.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOOControl_OnMouseDown);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(262, 152);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 2;
            // 
            // axMapcontrol
            // 
            this.axMapcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapcontrol.Location = new System.Drawing.Point(0, 0);
            this.axMapcontrol.Name = "axMapcontrol";
            this.axMapcontrol.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapcontrol.OcxState")));
            this.axMapcontrol.Size = new System.Drawing.Size(647, 584);
            this.axMapcontrol.TabIndex = 1;
            this.axMapcontrol.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapcontrol_OnMouseDown);
            this.axMapcontrol.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapcontrol_OnMouseMove);
            this.axMapcontrol.OnDoubleClick += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnDoubleClickEventHandler(this.axMapcontrol_OnDoubleClick);
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.QuerystatisticsItem,
            this.NetAnalysisItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1030, 28);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadMxdItem,
            this.DataAddItem,
            this.SaveItem,
            this.SaveAsItem,
            this.ExportMapItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // LoadMxdItem
            // 
            this.LoadMxdItem.Image = global::GisDemo.Properties.Resources.GenericOpen_B_16;
            this.LoadMxdItem.Name = "LoadMxdItem";
            this.LoadMxdItem.Size = new System.Drawing.Size(174, 26);
            this.LoadMxdItem.Text = "打开地图文档";
            this.LoadMxdItem.Click += new System.EventHandler(this.LoadMxdItem_Click);
            // 
            // DataAddItem
            // 
            this.DataAddItem.Image = global::GisDemo.Properties.Resources.DataAdd_B_16;
            this.DataAddItem.Name = "DataAddItem";
            this.DataAddItem.Size = new System.Drawing.Size(174, 26);
            this.DataAddItem.Text = "添加数据";
            this.DataAddItem.Click += new System.EventHandler(this.DataAddItem_Click);
            // 
            // SaveItem
            // 
            this.SaveItem.Image = global::GisDemo.Properties.Resources.GenericSave16;
            this.SaveItem.Name = "SaveItem";
            this.SaveItem.Size = new System.Drawing.Size(174, 26);
            this.SaveItem.Text = "保存";
            this.SaveItem.Click += new System.EventHandler(this.SaveItem_Click);
            // 
            // SaveAsItem
            // 
            this.SaveAsItem.Name = "SaveAsItem";
            this.SaveAsItem.Size = new System.Drawing.Size(174, 26);
            this.SaveAsItem.Text = "另存为";
            this.SaveAsItem.Click += new System.EventHandler(this.SaveAsItem_Click);
            // 
            // ExportMapItem
            // 
            this.ExportMapItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RegionExportItem,
            this.ExportToMapItem});
            this.ExportMapItem.Name = "ExportMapItem";
            this.ExportMapItem.Size = new System.Drawing.Size(174, 26);
            this.ExportMapItem.Text = "导出地图";
            this.ExportMapItem.Click += new System.EventHandler(this.ExportMapItem_Click);
            // 
            // RegionExportItem
            // 
            this.RegionExportItem.Name = "RegionExportItem";
            this.RegionExportItem.Size = new System.Drawing.Size(144, 26);
            this.RegionExportItem.Text = "区域导出";
            this.RegionExportItem.Click += new System.EventHandler(this.RegionExportItem_Click);
            // 
            // ExportToMapItem
            // 
            this.ExportToMapItem.Name = "ExportToMapItem";
            this.ExportToMapItem.Size = new System.Drawing.Size(144, 26);
            this.ExportToMapItem.Text = "全图导出";
            this.ExportToMapItem.Click += new System.EventHandler(this.ExportToMapItem_Click);
            // 
            // QuerystatisticsItem
            // 
            this.QuerystatisticsItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AttrQueryItem,
            this.SelectByPointItem,
            this.SelectByRecItem});
            this.QuerystatisticsItem.Name = "QuerystatisticsItem";
            this.QuerystatisticsItem.Size = new System.Drawing.Size(81, 24);
            this.QuerystatisticsItem.Text = "查询统计";
            this.QuerystatisticsItem.Click += new System.EventHandler(this.QuerystatisticsItem_Click);
            // 
            // AttrQueryItem
            // 
            this.AttrQueryItem.Image = global::GisDemo.Properties.Resources.TableStandaloneSmall161;
            this.AttrQueryItem.Name = "AttrQueryItem";
            this.AttrQueryItem.Size = new System.Drawing.Size(144, 26);
            this.AttrQueryItem.Text = "属性查询";
            this.AttrQueryItem.Click += new System.EventHandler(this.AttrQueryItem_Click);
            // 
            // SelectByPointItem
            // 
            this.SelectByPointItem.Name = "SelectByPointItem";
            this.SelectByPointItem.Size = new System.Drawing.Size(144, 26);
            this.SelectByPointItem.Text = "点选";
            this.SelectByPointItem.Click += new System.EventHandler(this.SelectByPointItem_Click);
            // 
            // SelectByRecItem
            // 
            this.SelectByRecItem.Name = "SelectByRecItem";
            this.SelectByRecItem.Size = new System.Drawing.Size(144, 26);
            this.SelectByRecItem.Text = "框选";
            // 
            // NetAnalysisItem
            // 
            this.NetAnalysisItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pathAnalysisItem,
            this.PipeAnalysisItem,
            this.GeometryNetAnalysis});
            this.NetAnalysisItem.Name = "NetAnalysisItem";
            this.NetAnalysisItem.Size = new System.Drawing.Size(81, 24);
            this.NetAnalysisItem.Text = "网络分析";
            // 
            // pathAnalysisItem
            // 
            this.pathAnalysisItem.Name = "pathAnalysisItem";
            this.pathAnalysisItem.Size = new System.Drawing.Size(174, 26);
            this.pathAnalysisItem.Text = "最短路径分析";
            // 
            // PipeAnalysisItem
            // 
            this.PipeAnalysisItem.Name = "PipeAnalysisItem";
            this.PipeAnalysisItem.Size = new System.Drawing.Size(174, 26);
            this.PipeAnalysisItem.Text = "爆管分析";
            // 
            // GeometryNetAnalysis
            // 
            this.GeometryNetAnalysis.Name = "GeometryNetAnalysis";
            this.GeometryNetAnalysis.Size = new System.Drawing.Size(174, 26);
            this.GeometryNetAnalysis.Text = "几何网络分析";
            this.GeometryNetAnalysis.Click += new System.EventHandler(this.GeometryNetAnalysis_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LengthCalbtn,
            this.AreaCalbtn,
            this.ZoomInTool,
            this.ZoomOutTool,
            this.PanToolbtn,
            this.FullExtentbtn,
            this.Clearselectionbtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1030, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // LengthCalbtn
            // 
            this.LengthCalbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LengthCalbtn.Image = global::GisDemo.Properties.Resources.MeasureTool16;
            this.LengthCalbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LengthCalbtn.Name = "LengthCalbtn";
            this.LengthCalbtn.Size = new System.Drawing.Size(73, 24);
            this.LengthCalbtn.Text = "长度测量";
            this.LengthCalbtn.Click += new System.EventHandler(this.Calculatebtn_Click);
            // 
            // AreaCalbtn
            // 
            this.AreaCalbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AreaCalbtn.Image = ((System.Drawing.Image)(resources.GetObject("AreaCalbtn.Image")));
            this.AreaCalbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AreaCalbtn.Name = "AreaCalbtn";
            this.AreaCalbtn.Size = new System.Drawing.Size(73, 24);
            this.AreaCalbtn.Text = "面积测量";
            this.AreaCalbtn.Click += new System.EventHandler(this.AreaCalbtn_Click);
            // 
            // ZoomInTool
            // 
            this.ZoomInTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomInTool.Image = global::GisDemo.Properties.Resources.ZoomInTool_B_16;
            this.ZoomInTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomInTool.Name = "ZoomInTool";
            this.ZoomInTool.Size = new System.Drawing.Size(24, 24);
            this.ZoomInTool.Text = "地图放大";
            this.ZoomInTool.Click += new System.EventHandler(this.ZoomInTool_Click);
            // 
            // ZoomOutTool
            // 
            this.ZoomOutTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOutTool.Image = global::GisDemo.Properties.Resources.ZoomOutTool_B_16;
            this.ZoomOutTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOutTool.Name = "ZoomOutTool";
            this.ZoomOutTool.Size = new System.Drawing.Size(24, 24);
            this.ZoomOutTool.Text = "toolStripButton1";
            this.ZoomOutTool.Click += new System.EventHandler(this.ZoomOutTool_Click);
            // 
            // PanToolbtn
            // 
            this.PanToolbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PanToolbtn.Image = global::GisDemo.Properties.Resources.PanTool_B_16;
            this.PanToolbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PanToolbtn.Name = "PanToolbtn";
            this.PanToolbtn.Size = new System.Drawing.Size(24, 24);
            this.PanToolbtn.Text = "漫游";
            this.PanToolbtn.Click += new System.EventHandler(this.PanToolbtn_Click);
            // 
            // FullExtentbtn
            // 
            this.FullExtentbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FullExtentbtn.Image = global::GisDemo.Properties.Resources.GenericGlobe24;
            this.FullExtentbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FullExtentbtn.Name = "FullExtentbtn";
            this.FullExtentbtn.Size = new System.Drawing.Size(24, 24);
            this.FullExtentbtn.Text = "缩放至全图";
            this.FullExtentbtn.Click += new System.EventHandler(this.FullExtentbtn_Click);
            // 
            // Clearselectionbtn
            // 
            this.Clearselectionbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Clearselectionbtn.Image = global::GisDemo.Properties.Resources.SelectionClearSelected16;
            this.Clearselectionbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Clearselectionbtn.Name = "Clearselectionbtn";
            this.Clearselectionbtn.Size = new System.Drawing.Size(24, 24);
            this.Clearselectionbtn.Text = "清除所选要素";
            this.Clearselectionbtn.Click += new System.EventHandler(this.Clearselectionbtn_Click);
            // 
            // LyrContxtMenuStrip
            // 
            this.LyrContxtMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.LyrContxtMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AttributeFrmItem,
            this.LyrExtentItem,
            this.LyrToPicItem,
            this.DataItem,
            this.标注要素ToolStripMenuItem});
            this.LyrContxtMenuStrip.Name = "LyrContxtMenuStrip";
            this.LyrContxtMenuStrip.Size = new System.Drawing.Size(158, 134);
            // 
            // AttributeFrmItem
            // 
            this.AttributeFrmItem.Image = global::GisDemo.Properties.Resources.TableStandaloneSmall_B_16;
            this.AttributeFrmItem.Name = "AttributeFrmItem";
            this.AttributeFrmItem.Size = new System.Drawing.Size(157, 26);
            this.AttributeFrmItem.Text = "打开属性表";
            this.AttributeFrmItem.Click += new System.EventHandler(this.AttributeFrmItem_Click);
            // 
            // LyrExtentItem
            // 
            this.LyrExtentItem.Image = global::GisDemo.Properties.Resources.LayerZoomTo16;
            this.LyrExtentItem.Name = "LyrExtentItem";
            this.LyrExtentItem.Size = new System.Drawing.Size(157, 26);
            this.LyrExtentItem.Text = "缩放至图层";
            this.LyrExtentItem.Click += new System.EventHandler(this.LyrExtentItem_Click);
            // 
            // LyrToPicItem
            // 
            this.LyrToPicItem.Image = global::GisDemo.Properties.Resources.LayerConvertToGraphics16;
            this.LyrToPicItem.Name = "LyrToPicItem";
            this.LyrToPicItem.Size = new System.Drawing.Size(157, 26);
            this.LyrToPicItem.Text = "要素转图形";
            this.LyrToPicItem.Click += new System.EventHandler(this.LyrToPicItem_Click);
            // 
            // DataItem
            // 
            this.DataItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportDataItem,
            this.ExportToCADItem});
            this.DataItem.Name = "DataItem";
            this.DataItem.Size = new System.Drawing.Size(157, 26);
            this.DataItem.Text = "数据";
            // 
            // ExportDataItem
            // 
            this.ExportDataItem.Image = global::GisDemo.Properties.Resources.LayerExportData16;
            this.ExportDataItem.Name = "ExportDataItem";
            this.ExportDataItem.Size = new System.Drawing.Size(146, 26);
            this.ExportDataItem.Text = "导出数据";
            // 
            // ExportToCADItem
            // 
            this.ExportToCADItem.Name = "ExportToCADItem";
            this.ExportToCADItem.Size = new System.Drawing.Size(146, 26);
            this.ExportToCADItem.Text = "导出CAD";
            this.ExportToCADItem.Click += new System.EventHandler(this.ExportToCADItem_Click);
            // 
            // 标注要素ToolStripMenuItem
            // 
            this.标注要素ToolStripMenuItem.Name = "标注要素ToolStripMenuItem";
            this.标注要素ToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.标注要素ToolStripMenuItem.Text = "标注要素";
            // 
            // MapMenuStrip
            // 
            this.MapMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MapMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDataItem,
            this.ExpandLyrItem,
            this.FoldLyrsItem,
            this.OpenLyrsItem,
            this.CloseLyrsItem});
            this.MapMenuStrip.Name = "MapMenuStrip";
            this.MapMenuStrip.Size = new System.Drawing.Size(173, 134);
            // 
            // AddDataItem
            // 
            this.AddDataItem.Image = global::GisDemo.Properties.Resources.DataAdd_B_16;
            this.AddDataItem.Name = "AddDataItem";
            this.AddDataItem.Size = new System.Drawing.Size(172, 26);
            this.AddDataItem.Text = "添加数据";
            this.AddDataItem.Click += new System.EventHandler(this.AddDataItem_Click);
            // 
            // ExpandLyrItem
            // 
            this.ExpandLyrItem.Image = global::GisDemo.Properties.Resources.GenericTreeExpand16;
            this.ExpandLyrItem.Name = "ExpandLyrItem";
            this.ExpandLyrItem.Size = new System.Drawing.Size(172, 26);
            this.ExpandLyrItem.Text = "展开所有图层";
            this.ExpandLyrItem.Click += new System.EventHandler(this.ExpandLyrItem_Click);
            // 
            // FoldLyrsItem
            // 
            this.FoldLyrsItem.Image = global::GisDemo.Properties.Resources.GenericTreeContract16;
            this.FoldLyrsItem.Name = "FoldLyrsItem";
            this.FoldLyrsItem.Size = new System.Drawing.Size(172, 26);
            this.FoldLyrsItem.Text = "折叠所有图层";
            this.FoldLyrsItem.Click += new System.EventHandler(this.FoldLyrsItem_Click);
            // 
            // OpenLyrsItem
            // 
            this.OpenLyrsItem.Name = "OpenLyrsItem";
            this.OpenLyrsItem.Size = new System.Drawing.Size(172, 26);
            this.OpenLyrsItem.Text = "打开所有图层";
            this.OpenLyrsItem.Click += new System.EventHandler(this.OpenLyrsItem_Click);
            // 
            // CloseLyrsItem
            // 
            this.CloseLyrsItem.Name = "CloseLyrsItem";
            this.CloseLyrsItem.Size = new System.Drawing.Size(172, 26);
            this.CloseLyrsItem.Text = "关闭所有图层";
            this.CloseLyrsItem.Click += new System.EventHandler(this.CloseLyrsItem_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 612);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.VerticalSplit);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainFrm";
            this.Text = "主窗体";
            this.VerticalSplit.Panel1.ResumeLayout(false);
            this.VerticalSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VerticalSplit)).EndInit();
            this.VerticalSplit.ResumeLayout(false);
            this.levelSplit.Panel1.ResumeLayout(false);
            this.levelSplit.Panel2.ResumeLayout(false);
            this.levelSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.levelSplit)).EndInit();
            this.levelSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOOControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapcontrol)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.LyrContxtMenuStrip.ResumeLayout(false);
            this.MapMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer VerticalSplit;
        private System.Windows.Forms.SplitContainer levelSplit;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOOControl;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapcontrol;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadMxdItem;
        private System.Windows.Forms.ToolStripMenuItem DataAddItem;
        private System.Windows.Forms.ToolStripMenuItem SaveItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsItem;
        private System.Windows.Forms.ToolStripMenuItem ExportMapItem;
        private System.Windows.Forms.ToolStripMenuItem RegionExportItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToMapItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel barCoortxt;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton LengthCalbtn;
        private System.Windows.Forms.ToolStripButton AreaCalbtn;
        private System.Windows.Forms.ToolStripButton ZoomInTool;
        private System.Windows.Forms.ToolStripButton ZoomOutTool;
        private System.Windows.Forms.ToolStripButton PanToolbtn;
        private System.Windows.Forms.ToolStripButton FullExtentbtn;
        private System.Windows.Forms.ContextMenuStrip LyrContxtMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AttributeFrmItem;
        private System.Windows.Forms.ToolStripMenuItem LyrExtentItem;
        private System.Windows.Forms.ToolStripMenuItem LyrToPicItem;
        private System.Windows.Forms.ToolStripMenuItem DataItem;
        private System.Windows.Forms.ToolStripMenuItem ExportDataItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToCADItem;
        private System.Windows.Forms.ContextMenuStrip MapMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddDataItem;
        private System.Windows.Forms.ToolStripMenuItem ExpandLyrItem;
        private System.Windows.Forms.ToolStripMenuItem FoldLyrsItem;
        private System.Windows.Forms.ToolStripMenuItem OpenLyrsItem;
        private System.Windows.Forms.ToolStripMenuItem CloseLyrsItem;
        private System.Windows.Forms.ToolStripMenuItem QuerystatisticsItem;
        private System.Windows.Forms.ToolStripMenuItem AttrQueryItem;
        private System.Windows.Forms.ToolStripButton Clearselectionbtn;
        private System.Windows.Forms.ToolStripMenuItem SelectByPointItem;
        private System.Windows.Forms.ToolStripMenuItem SelectByRecItem;
        private System.Windows.Forms.ToolStripMenuItem NetAnalysisItem;
        private System.Windows.Forms.ToolStripMenuItem pathAnalysisItem;
        private System.Windows.Forms.ToolStripMenuItem PipeAnalysisItem;
        private System.Windows.Forms.ToolStripMenuItem 标注要素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GeometryNetAnalysis;
    }
}

