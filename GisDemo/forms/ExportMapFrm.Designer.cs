namespace GisDemo.forms
{
    partial class ExportMapFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.heighttxt = new System.Windows.Forms.TextBox();
            this.widthtxt = new System.Windows.Forms.TextBox();
            this.Cmxresolution = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.folderBrowserbtn = new System.Windows.Forms.Button();
            this.pathtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.Exportbtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.heighttxt);
            this.groupBox1.Controls.Add(this.widthtxt);
            this.groupBox1.Controls.Add(this.Cmxresolution);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导出设置";
            // 
            // heighttxt
            // 
            this.heighttxt.Location = new System.Drawing.Point(346, 22);
            this.heighttxt.Name = "heighttxt";
            this.heighttxt.ReadOnly = true;
            this.heighttxt.Size = new System.Drawing.Size(100, 25);
            this.heighttxt.TabIndex = 5;
            // 
            // widthtxt
            // 
            this.widthtxt.Location = new System.Drawing.Point(109, 22);
            this.widthtxt.Name = "widthtxt";
            this.widthtxt.ReadOnly = true;
            this.widthtxt.Size = new System.Drawing.Size(103, 25);
            this.widthtxt.TabIndex = 4;
            // 
            // Cmxresolution
            // 
            this.Cmxresolution.FormattingEnabled = true;
            this.Cmxresolution.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "400",
            "500",
            "600"});
            this.Cmxresolution.Location = new System.Drawing.Point(135, 76);
            this.Cmxresolution.Name = "Cmxresolution";
            this.Cmxresolution.Size = new System.Drawing.Size(146, 23);
            this.Cmxresolution.TabIndex = 3;
            this.Cmxresolution.SelectedIndexChanged += new System.EventHandler(this.Cmxresolution_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "输出分辨率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "输出高度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "输出宽度";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.folderBrowserbtn);
            this.groupBox2.Controls.Add(this.pathtxt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 85);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "导出路径";
            // 
            // folderBrowserbtn
            // 
            this.folderBrowserbtn.Location = new System.Drawing.Point(371, 30);
            this.folderBrowserbtn.Name = "folderBrowserbtn";
            this.folderBrowserbtn.Size = new System.Drawing.Size(75, 33);
            this.folderBrowserbtn.TabIndex = 2;
            this.folderBrowserbtn.Text = "浏览";
            this.folderBrowserbtn.UseVisualStyleBackColor = true;
            this.folderBrowserbtn.Click += new System.EventHandler(this.folderBrowserbtn_Click);
            // 
            // pathtxt
            // 
            this.pathtxt.Location = new System.Drawing.Point(109, 36);
            this.pathtxt.Name = "pathtxt";
            this.pathtxt.Size = new System.Drawing.Size(233, 25);
            this.pathtxt.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "请选择";
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Location = new System.Drawing.Point(358, 257);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(75, 32);
            this.Cancelbtn.TabIndex = 2;
            this.Cancelbtn.Text = "取消";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // Exportbtn
            // 
            this.Exportbtn.Location = new System.Drawing.Point(240, 257);
            this.Exportbtn.Name = "Exportbtn";
            this.Exportbtn.Size = new System.Drawing.Size(75, 32);
            this.Exportbtn.TabIndex = 3;
            this.Exportbtn.Text = "导出";
            this.Exportbtn.UseVisualStyleBackColor = true;
            this.Exportbtn.Click += new System.EventHandler(this.Exportbtn_Click);
            // 
            // ExportMapFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 292);
            this.Controls.Add(this.Exportbtn);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ExportMapFrm";
            this.Text = "地图导出";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExportMapFrm_FormClosed);
            this.Load += new System.EventHandler(this.ExportMap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox heighttxt;
        private System.Windows.Forms.TextBox widthtxt;
        private System.Windows.Forms.ComboBox Cmxresolution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button folderBrowserbtn;
        private System.Windows.Forms.TextBox pathtxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.Button Exportbtn;
    }
}