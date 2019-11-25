namespace GisDemo.forms
{
    partial class AttrQueryFrm
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
            this.lblLyr = new System.Windows.Forms.Label();
            this.LyrCmbx = new System.Windows.Forms.ComboBox();
            this.fieldslistBox = new System.Windows.Forms.ListBox();
            this.equalbtn = new System.Windows.Forms.Button();
            this.likebtn = new System.Windows.Forms.Button();
            this.smallerbtn = new System.Windows.Forms.Button();
            this.greaterbtn = new System.Windows.Forms.Button();
            this.andbtn = new System.Windows.Forms.Button();
            this.orbtn = new System.Windows.Forms.Button();
            this.ValueList = new System.Windows.Forms.ListBox();
            this.uniquevalueBtn = new System.Windows.Forms.Button();
            this.exptxtBox = new System.Windows.Forms.TextBox();
            this.surebtn = new System.Windows.Forms.Button();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.CancleBtn = new System.Windows.Forms.Button();
            this.Clearbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLyr
            // 
            this.lblLyr.AutoSize = true;
            this.lblLyr.Location = new System.Drawing.Point(32, 33);
            this.lblLyr.Name = "lblLyr";
            this.lblLyr.Size = new System.Drawing.Size(37, 15);
            this.lblLyr.TabIndex = 0;
            this.lblLyr.Text = "图层";
            // 
            // LyrCmbx
            // 
            this.LyrCmbx.FormattingEnabled = true;
            this.LyrCmbx.Location = new System.Drawing.Point(101, 25);
            this.LyrCmbx.Name = "LyrCmbx";
            this.LyrCmbx.Size = new System.Drawing.Size(328, 23);
            this.LyrCmbx.TabIndex = 1;
            this.LyrCmbx.SelectedIndexChanged += new System.EventHandler(this.LyrCmbx_SelectedIndexChanged);
            // 
            // fieldslistBox
            // 
            this.fieldslistBox.FormattingEnabled = true;
            this.fieldslistBox.ItemHeight = 15;
            this.fieldslistBox.Location = new System.Drawing.Point(22, 67);
            this.fieldslistBox.Name = "fieldslistBox";
            this.fieldslistBox.Size = new System.Drawing.Size(407, 94);
            this.fieldslistBox.TabIndex = 2;
            this.fieldslistBox.SelectedIndexChanged += new System.EventHandler(this.fieldslistBox_SelectedIndexChanged);
            this.fieldslistBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fieldslistBox_MouseDoubleClick);
            // 
            // equalbtn
            // 
            this.equalbtn.Location = new System.Drawing.Point(22, 167);
            this.equalbtn.Name = "equalbtn";
            this.equalbtn.Size = new System.Drawing.Size(75, 34);
            this.equalbtn.TabIndex = 3;
            this.equalbtn.Text = "=";
            this.equalbtn.UseVisualStyleBackColor = true;
            this.equalbtn.Click += new System.EventHandler(this.equalbtn_Click);
            // 
            // likebtn
            // 
            this.likebtn.Location = new System.Drawing.Point(122, 167);
            this.likebtn.Name = "likebtn";
            this.likebtn.Size = new System.Drawing.Size(75, 34);
            this.likebtn.TabIndex = 4;
            this.likebtn.Text = "like(%)";
            this.likebtn.UseVisualStyleBackColor = true;
            this.likebtn.Click += new System.EventHandler(this.likebtn_Click);
            // 
            // smallerbtn
            // 
            this.smallerbtn.Location = new System.Drawing.Point(22, 271);
            this.smallerbtn.Name = "smallerbtn";
            this.smallerbtn.Size = new System.Drawing.Size(75, 34);
            this.smallerbtn.TabIndex = 5;
            this.smallerbtn.Text = "<";
            this.smallerbtn.UseVisualStyleBackColor = true;
            this.smallerbtn.Click += new System.EventHandler(this.smallerbtn_Click);
            // 
            // greaterbtn
            // 
            this.greaterbtn.Location = new System.Drawing.Point(22, 217);
            this.greaterbtn.Name = "greaterbtn";
            this.greaterbtn.Size = new System.Drawing.Size(75, 34);
            this.greaterbtn.TabIndex = 6;
            this.greaterbtn.Text = ">";
            this.greaterbtn.UseVisualStyleBackColor = true;
            this.greaterbtn.Click += new System.EventHandler(this.greaterbtn_Click);
            // 
            // andbtn
            // 
            this.andbtn.Location = new System.Drawing.Point(122, 217);
            this.andbtn.Name = "andbtn";
            this.andbtn.Size = new System.Drawing.Size(75, 34);
            this.andbtn.TabIndex = 7;
            this.andbtn.Text = "and";
            this.andbtn.UseVisualStyleBackColor = true;
            this.andbtn.Click += new System.EventHandler(this.andbtn_Click);
            // 
            // orbtn
            // 
            this.orbtn.Location = new System.Drawing.Point(122, 271);
            this.orbtn.Name = "orbtn";
            this.orbtn.Size = new System.Drawing.Size(75, 34);
            this.orbtn.TabIndex = 8;
            this.orbtn.Text = "or";
            this.orbtn.UseVisualStyleBackColor = true;
            this.orbtn.Click += new System.EventHandler(this.orbtn_Click);
            // 
            // ValueList
            // 
            this.ValueList.FormattingEnabled = true;
            this.ValueList.ItemHeight = 15;
            this.ValueList.Location = new System.Drawing.Point(210, 167);
            this.ValueList.Name = "ValueList";
            this.ValueList.Size = new System.Drawing.Size(219, 94);
            this.ValueList.TabIndex = 9;
            this.ValueList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ValueList_MouseDoubleClick);
            // 
            // uniquevalueBtn
            // 
            this.uniquevalueBtn.Location = new System.Drawing.Point(210, 276);
            this.uniquevalueBtn.Name = "uniquevalueBtn";
            this.uniquevalueBtn.Size = new System.Drawing.Size(219, 29);
            this.uniquevalueBtn.TabIndex = 8;
            this.uniquevalueBtn.Text = "获取唯一值";
            this.uniquevalueBtn.UseVisualStyleBackColor = true;
            this.uniquevalueBtn.Click += new System.EventHandler(this.uniquevalueBtn_Click);
            // 
            // exptxtBox
            // 
            this.exptxtBox.Location = new System.Drawing.Point(22, 314);
            this.exptxtBox.Multiline = true;
            this.exptxtBox.Name = "exptxtBox";
            this.exptxtBox.Size = new System.Drawing.Size(407, 88);
            this.exptxtBox.TabIndex = 12;
            // 
            // surebtn
            // 
            this.surebtn.Location = new System.Drawing.Point(144, 416);
            this.surebtn.Name = "surebtn";
            this.surebtn.Size = new System.Drawing.Size(75, 33);
            this.surebtn.TabIndex = 13;
            this.surebtn.Text = "确定";
            this.surebtn.UseVisualStyleBackColor = true;
            this.surebtn.Click += new System.EventHandler(this.surebtn_Click);
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Location = new System.Drawing.Point(253, 416);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(75, 33);
            this.ApplyBtn.TabIndex = 14;
            this.ApplyBtn.Text = "应用";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // CancleBtn
            // 
            this.CancleBtn.Location = new System.Drawing.Point(354, 416);
            this.CancleBtn.Name = "CancleBtn";
            this.CancleBtn.Size = new System.Drawing.Size(75, 33);
            this.CancleBtn.TabIndex = 15;
            this.CancleBtn.Text = "取消";
            this.CancleBtn.UseVisualStyleBackColor = true;
            this.CancleBtn.Click += new System.EventHandler(this.CancleBtn_Click);
            // 
            // Clearbtn
            // 
            this.Clearbtn.Location = new System.Drawing.Point(22, 416);
            this.Clearbtn.Name = "Clearbtn";
            this.Clearbtn.Size = new System.Drawing.Size(90, 33);
            this.Clearbtn.TabIndex = 16;
            this.Clearbtn.Text = "清除表达式";
            this.Clearbtn.UseVisualStyleBackColor = true;
            this.Clearbtn.Click += new System.EventHandler(this.Clearbtn_Click);
            // 
            // AttrQueryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 457);
            this.Controls.Add(this.Clearbtn);
            this.Controls.Add(this.CancleBtn);
            this.Controls.Add(this.ApplyBtn);
            this.Controls.Add(this.surebtn);
            this.Controls.Add(this.exptxtBox);
            this.Controls.Add(this.ValueList);
            this.Controls.Add(this.uniquevalueBtn);
            this.Controls.Add(this.orbtn);
            this.Controls.Add(this.andbtn);
            this.Controls.Add(this.greaterbtn);
            this.Controls.Add(this.smallerbtn);
            this.Controls.Add(this.likebtn);
            this.Controls.Add(this.equalbtn);
            this.Controls.Add(this.fieldslistBox);
            this.Controls.Add(this.LyrCmbx);
            this.Controls.Add(this.lblLyr);
            this.Name = "AttrQueryFrm";
            this.Text = "属性查询";
            this.Load += new System.EventHandler(this.AttrQueryFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLyr;
        private System.Windows.Forms.ComboBox LyrCmbx;
        private System.Windows.Forms.ListBox fieldslistBox;
        private System.Windows.Forms.Button equalbtn;
        private System.Windows.Forms.Button likebtn;
        private System.Windows.Forms.Button smallerbtn;
        private System.Windows.Forms.Button greaterbtn;
        private System.Windows.Forms.Button andbtn;
        private System.Windows.Forms.Button orbtn;
        private System.Windows.Forms.ListBox ValueList;
        private System.Windows.Forms.Button uniquevalueBtn;
        private System.Windows.Forms.TextBox exptxtBox;
        private System.Windows.Forms.Button surebtn;
        private System.Windows.Forms.Button ApplyBtn;
        private System.Windows.Forms.Button CancleBtn;
        private System.Windows.Forms.Button Clearbtn;
    }
}