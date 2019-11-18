namespace GisDemo.forms
{
    partial class ExportCADfrm
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
            this.pathlbl = new System.Windows.Forms.Label();
            this.pathtxt = new System.Windows.Forms.TextBox();
            this.Filebrowserbtn = new System.Windows.Forms.Button();
            this.Lyrlist = new System.Windows.Forms.ListBox();
            this.Exportbtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.TypeCmbx = new System.Windows.Forms.ComboBox();
            this.Typelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pathlbl
            // 
            this.pathlbl.AutoSize = true;
            this.pathlbl.Location = new System.Drawing.Point(12, 272);
            this.pathlbl.Name = "pathlbl";
            this.pathlbl.Size = new System.Drawing.Size(67, 15);
            this.pathlbl.TabIndex = 0;
            this.pathlbl.Text = "导出路径";
            // 
            // pathtxt
            // 
            this.pathtxt.Location = new System.Drawing.Point(95, 269);
            this.pathtxt.Name = "pathtxt";
            this.pathtxt.Size = new System.Drawing.Size(258, 25);
            this.pathtxt.TabIndex = 1;
            // 
            // Filebrowserbtn
            // 
            this.Filebrowserbtn.Location = new System.Drawing.Point(377, 260);
            this.Filebrowserbtn.Name = "Filebrowserbtn";
            this.Filebrowserbtn.Size = new System.Drawing.Size(85, 38);
            this.Filebrowserbtn.TabIndex = 2;
            this.Filebrowserbtn.Text = "请选择";
            this.Filebrowserbtn.UseVisualStyleBackColor = true;
            this.Filebrowserbtn.Click += new System.EventHandler(this.Filebrowserbtn_Click);
            // 
            // Lyrlist
            // 
            this.Lyrlist.FormattingEnabled = true;
            this.Lyrlist.ItemHeight = 15;
            this.Lyrlist.Location = new System.Drawing.Point(15, 12);
            this.Lyrlist.Name = "Lyrlist";
            this.Lyrlist.Size = new System.Drawing.Size(447, 229);
            this.Lyrlist.TabIndex = 3;
            this.Lyrlist.SelectedIndexChanged += new System.EventHandler(this.Lyrlist_SelectedIndexChanged);
            // 
            // Exportbtn
            // 
            this.Exportbtn.Location = new System.Drawing.Point(231, 378);
            this.Exportbtn.Name = "Exportbtn";
            this.Exportbtn.Size = new System.Drawing.Size(75, 36);
            this.Exportbtn.TabIndex = 7;
            this.Exportbtn.Text = "导出";
            this.Exportbtn.UseVisualStyleBackColor = true;
            this.Exportbtn.Click += new System.EventHandler(this.Exportbtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(368, 378);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 36);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // TypeCmbx
            // 
            this.TypeCmbx.FormattingEnabled = true;
            this.TypeCmbx.Items.AddRange(new object[] {
            "DWG_R2000",
            "DWG_R2005",
            "DWG_R2007",
            "DWG_R2010"});
            this.TypeCmbx.Location = new System.Drawing.Point(160, 323);
            this.TypeCmbx.Name = "TypeCmbx";
            this.TypeCmbx.Size = new System.Drawing.Size(302, 23);
            this.TypeCmbx.TabIndex = 9;
            // 
            // Typelbl
            // 
            this.Typelbl.AutoSize = true;
            this.Typelbl.Location = new System.Drawing.Point(12, 331);
            this.Typelbl.Name = "Typelbl";
            this.Typelbl.Size = new System.Drawing.Size(142, 15);
            this.Typelbl.TabIndex = 10;
            this.Typelbl.Text = "请输入导出数据类型";
            // 
            // ExportCADfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 426);
            this.Controls.Add(this.Typelbl);
            this.Controls.Add(this.TypeCmbx);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.Exportbtn);
            this.Controls.Add(this.Lyrlist);
            this.Controls.Add(this.Filebrowserbtn);
            this.Controls.Add(this.pathtxt);
            this.Controls.Add(this.pathlbl);
            this.Name = "ExportCADfrm";
            this.Text = "导出CAD";
            this.Load += new System.EventHandler(this.ExportCADfrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pathlbl;
        private System.Windows.Forms.TextBox pathtxt;
        private System.Windows.Forms.Button Filebrowserbtn;
        private System.Windows.Forms.ListBox Lyrlist;
        private System.Windows.Forms.Button Exportbtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ComboBox TypeCmbx;
        private System.Windows.Forms.Label Typelbl;
    }
}