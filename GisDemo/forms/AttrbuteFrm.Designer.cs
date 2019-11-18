namespace GisDemo.forms
{
    partial class AttrbuteFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttrbuteFrm));
            this.AttrmenuStrip = new System.Windows.Forms.MenuStrip();
            this.SelectOperateItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectByAttrItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.propertyGridView = new System.Windows.Forms.DataGridView();
            this.propertyNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblcurpage = new System.Windows.Forms.ToolStripLabel();
            this.pageCountTxt = new System.Windows.Forms.ToolStripTextBox();
            this.AttrmenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyNavigator)).BeginInit();
            this.propertyNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // AttrmenuStrip
            // 
            this.AttrmenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AttrmenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectOperateItem});
            this.AttrmenuStrip.Location = new System.Drawing.Point(0, 0);
            this.AttrmenuStrip.Name = "AttrmenuStrip";
            this.AttrmenuStrip.Size = new System.Drawing.Size(793, 28);
            this.AttrmenuStrip.TabIndex = 0;
            this.AttrmenuStrip.Text = "menuStrip1";
            // 
            // SelectOperateItem
            // 
            this.SelectOperateItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectByAttrItem});
            this.SelectOperateItem.Name = "SelectOperateItem";
            this.SelectOperateItem.Size = new System.Drawing.Size(81, 24);
            this.SelectOperateItem.Text = "选择操作";
            // 
            // SelectByAttrItem
            // 
            this.SelectByAttrItem.Name = "SelectByAttrItem";
            this.SelectByAttrItem.Size = new System.Drawing.Size(159, 26);
            this.SelectByAttrItem.Text = "按属性选择";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.propertyGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyNavigator);
            this.splitContainer1.Size = new System.Drawing.Size(793, 444);
            this.splitContainer1.SplitterDistance = 407;
            this.splitContainer1.TabIndex = 1;
            // 
            // propertyGridView
            // 
            this.propertyGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.propertyGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridView.Location = new System.Drawing.Point(0, 0);
            this.propertyGridView.Name = "propertyGridView";
            this.propertyGridView.RowTemplate.Height = 27;
            this.propertyGridView.Size = new System.Drawing.Size(793, 407);
            this.propertyGridView.TabIndex = 0;
            // 
            // propertyNavigator
            // 
            this.propertyNavigator.AddNewItem = null;
            this.propertyNavigator.CountItem = this.bindingNavigatorCountItem;
            this.propertyNavigator.DeleteItem = null;
            this.propertyNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.propertyNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.lblcurpage,
            this.pageCountTxt});
            this.propertyNavigator.Location = new System.Drawing.Point(0, 0);
            this.propertyNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.propertyNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.propertyNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.propertyNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.propertyNavigator.Name = "propertyNavigator";
            this.propertyNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.propertyNavigator.Size = new System.Drawing.Size(793, 33);
            this.propertyNavigator.TabIndex = 0;
            this.propertyNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 30);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 30);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 30);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 30);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 30);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // lblcurpage
            // 
            this.lblcurpage.Name = "lblcurpage";
            this.lblcurpage.Size = new System.Drawing.Size(122, 30);
            this.lblcurpage.Text = "toolStripLabel1";
            // 
            // pageCountTxt
            // 
            this.pageCountTxt.Name = "pageCountTxt";
            this.pageCountTxt.Size = new System.Drawing.Size(100, 33);
            // 
            // AttrbuteFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 472);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.AttrmenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.AttrmenuStrip;
            this.Name = "AttrbuteFrm";
            this.Text = " 属性表";
            this.Load += new System.EventHandler(this.AttrbuteFrm_Load);
            this.AttrmenuStrip.ResumeLayout(false);
            this.AttrmenuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyNavigator)).EndInit();
            this.propertyNavigator.ResumeLayout(false);
            this.propertyNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip AttrmenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SelectOperateItem;
        private System.Windows.Forms.ToolStripMenuItem SelectByAttrItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView propertyGridView;
        private System.Windows.Forms.BindingNavigator propertyNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripLabel lblcurpage;
        private System.Windows.Forms.ToolStripTextBox pageCountTxt;
    }
}