using System.Windows.Forms;
namespace GisDemo.forms
{
    partial class NetAnalysisFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetAnalysisFrm));
            this.NetlistCmbx = new System.Windows.Forms.ToolStripComboBox();
            this.FlowDiretionBtn = new System.Windows.Forms.ToolStripButton();
            this.AnalysisItemBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.ClearMarkItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearBarrierItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearResultItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddJunctionBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.AddJunctionFlagBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AddEdgeFlagBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AddJunctionBarrierBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AddEdgeBarrierBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.AnalysisCategoryCmbx = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ResultBtn = new System.Windows.Forms.ToolStripButton();
            this.ClearFlowItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NetlistCmbx
            // 
            this.NetlistCmbx.Name = "NetlistCmbx";
            this.NetlistCmbx.Size = new System.Drawing.Size(200, 42);
            // 
            // FlowDiretionBtn
            // 
            this.FlowDiretionBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FlowDiretionBtn.Image = ((System.Drawing.Image)(resources.GetObject("FlowDiretionBtn.Image")));
            this.FlowDiretionBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FlowDiretionBtn.Name = "FlowDiretionBtn";
            this.FlowDiretionBtn.Size = new System.Drawing.Size(43, 39);
            this.FlowDiretionBtn.Text = "流向";
            this.FlowDiretionBtn.Click += new System.EventHandler(this.FlowDiretionBtn_Click);
            // 
            // AnalysisItemBtn
            // 
            this.AnalysisItemBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AnalysisItemBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearMarkItem,
            this.ClearBarrierItem,
            this.ClearResultItem,
            this.ClearFlowItem});
            this.AnalysisItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("AnalysisItemBtn.Image")));
            this.AnalysisItemBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AnalysisItemBtn.Name = "AnalysisItemBtn";
            this.AnalysisItemBtn.Size = new System.Drawing.Size(53, 39);
            this.AnalysisItemBtn.Text = "分析";
            // 
            // ClearMarkItem
            // 
            this.ClearMarkItem.Name = "ClearMarkItem";
            this.ClearMarkItem.Size = new System.Drawing.Size(181, 26);
            this.ClearMarkItem.Text = "清除标记";
            this.ClearMarkItem.Click += new System.EventHandler(this.ClearMarkItem_Click);
            // 
            // ClearBarrierItem
            // 
            this.ClearBarrierItem.Name = "ClearBarrierItem";
            this.ClearBarrierItem.Size = new System.Drawing.Size(181, 26);
            this.ClearBarrierItem.Text = "清除障碍";
            this.ClearBarrierItem.Click += new System.EventHandler(this.ClearBarrierItem_Click);
            // 
            // ClearResultItem
            // 
            this.ClearResultItem.Name = "ClearResultItem";
            this.ClearResultItem.Size = new System.Drawing.Size(181, 26);
            this.ClearResultItem.Text = "清除结果";
            this.ClearResultItem.Click += new System.EventHandler(this.ClearResultItem_Click);
            // 
            // AddJunctionBtn
            // 
            this.AddJunctionBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddJunctionBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddJunctionFlagBtn,
            this.AddEdgeFlagBtn,
            this.AddJunctionBarrierBtn,
            this.AddEdgeBarrierBtn});
            this.AddJunctionBtn.Image = global::GisDemo.Properties.Resources.UtilityNetworkJunctionAddTool16;
            this.AddJunctionBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddJunctionBtn.Name = "AddJunctionBtn";
            this.AddJunctionBtn.Size = new System.Drawing.Size(34, 39);
            this.AddJunctionBtn.Text = "添加交汇点";
            // 
            // AddJunctionFlagBtn
            // 
            this.AddJunctionFlagBtn.Image = global::GisDemo.Properties.Resources.UtilityNetworkJunctionAddTool161;
            this.AddJunctionFlagBtn.Name = "AddJunctionFlagBtn";
            this.AddJunctionFlagBtn.Size = new System.Drawing.Size(189, 26);
            this.AddJunctionFlagBtn.Text = "添加交汇点工具";
            this.AddJunctionFlagBtn.Click += new System.EventHandler(this.AddJunctionFlagBtn_Click);
            // 
            // AddEdgeFlagBtn
            // 
            this.AddEdgeFlagBtn.Image = global::GisDemo.Properties.Resources.UtilityNetworkEdgeAddTool16;
            this.AddEdgeFlagBtn.Name = "AddEdgeFlagBtn";
            this.AddEdgeFlagBtn.Size = new System.Drawing.Size(189, 26);
            this.AddEdgeFlagBtn.Text = "添加交汇边工具";
            this.AddEdgeFlagBtn.Click += new System.EventHandler(this.AddEdgeFlagBtn_Click);
            // 
            // AddJunctionBarrierBtn
            // 
            this.AddJunctionBarrierBtn.Image = global::GisDemo.Properties.Resources.UtilityNetworkBarrierJunctionAddTool16;
            this.AddJunctionBarrierBtn.Name = "AddJunctionBarrierBtn";
            this.AddJunctionBarrierBtn.Size = new System.Drawing.Size(189, 26);
            this.AddJunctionBarrierBtn.Text = "添加障碍点工具";
            this.AddJunctionBarrierBtn.Click += new System.EventHandler(this.AddJunctionBarrierBtn_Click);
            // 
            // AddEdgeBarrierBtn
            // 
            this.AddEdgeBarrierBtn.Image = global::GisDemo.Properties.Resources.UtilityNetworkBarrierEdgeAddTool16;
            this.AddEdgeBarrierBtn.Name = "AddEdgeBarrierBtn";
            this.AddEdgeBarrierBtn.Size = new System.Drawing.Size(189, 26);
            this.AddEdgeBarrierBtn.Text = "添加障碍边工具";
            this.AddEdgeBarrierBtn.Click += new System.EventHandler(this.AddEdgeBarrierBtn_Click);
            // 
            // AnalysisCategoryCmbx
            // 
            this.AnalysisCategoryCmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AnalysisCategoryCmbx.Items.AddRange(new object[] {
            "公共祖先追踪分析",
            "网络连接要素分析",
            "网络环路分析",
            "网络中断要素分析",
            "网络上溯路径分析",
            "网络路径分析",
            "网络下溯追踪",
            "网络上溯累计追踪",
            "网络上溯追踪"});
            this.AnalysisCategoryCmbx.Name = "AnalysisCategoryCmbx";
            this.AnalysisCategoryCmbx.Size = new System.Drawing.Size(200, 42);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NetlistCmbx,
            this.FlowDiretionBtn,
            this.AnalysisItemBtn,
            this.AddJunctionBtn,
            this.AnalysisCategoryCmbx,
            this.ResultBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(700, 42);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ResultBtn
            // 
            this.ResultBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ResultBtn.Image = global::GisDemo.Properties.Resources.UtilityNetworkSolve16;
            this.ResultBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResultBtn.Name = "ResultBtn";
            this.ResultBtn.Size = new System.Drawing.Size(24, 39);
            this.ResultBtn.Text = "toolStripButton1";
            this.ResultBtn.Click += new System.EventHandler(this.ResultBtn_Click);
            // 
            // ClearFlowItem
            // 
            this.ClearFlowItem.Name = "ClearFlowItem";
            this.ClearFlowItem.Size = new System.Drawing.Size(181, 26);
            this.ClearFlowItem.Text = "清除流向";
            this.ClearFlowItem.Click += new System.EventHandler(this.ClearFlowItem_Click);
            // 
            // NetAnalysisFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 42);
            this.Controls.Add(this.toolStrip1);
            this.Name = "NetAnalysisFrm";
            this.Text = "几何网络分析";
            this.Load += new System.EventHandler(this.NetAnalysisFrm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripComboBox NetlistCmbx;
        private System.Windows.Forms.ToolStripButton FlowDiretionBtn;
        private System.Windows.Forms.ToolStripDropDownButton AnalysisItemBtn;
        private System.Windows.Forms.ToolStripMenuItem ClearMarkItem;
        private System.Windows.Forms.ToolStripMenuItem ClearBarrierItem;
        private System.Windows.Forms.ToolStripMenuItem ClearResultItem;
        private System.Windows.Forms.ToolStripDropDownButton AddJunctionBtn;
        private System.Windows.Forms.ToolStripMenuItem AddJunctionFlagBtn;
        private System.Windows.Forms.ToolStripMenuItem AddEdgeFlagBtn;
        private System.Windows.Forms.ToolStripMenuItem AddJunctionBarrierBtn;
        private System.Windows.Forms.ToolStripMenuItem AddEdgeBarrierBtn;
        private System.Windows.Forms.ToolStripComboBox AnalysisCategoryCmbx;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ResultBtn;
        private ToolStripMenuItem ClearFlowItem;

    }
}