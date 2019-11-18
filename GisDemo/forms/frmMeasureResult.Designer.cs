namespace GisDemo.forms
{
    partial class frmMeasureResult
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
            this.lblresult = new System.Windows.Forms.Label();
            this.lblMeasureResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblresult
            // 
            this.lblresult.AutoSize = true;
            this.lblresult.Location = new System.Drawing.Point(39, 34);
            this.lblresult.Name = "lblresult";
            this.lblresult.Size = new System.Drawing.Size(67, 15);
            this.lblresult.TabIndex = 0;
            this.lblresult.Text = "量测结果";
            // 
            // lblMeasureResult
            // 
            this.lblMeasureResult.Location = new System.Drawing.Point(126, 26);
            this.lblMeasureResult.Name = "lblMeasureResult";
            this.lblMeasureResult.Size = new System.Drawing.Size(213, 48);
            this.lblMeasureResult.TabIndex = 1;
            this.lblMeasureResult.Text = "lblMeasureResult";
            // 
            // frmMeasureResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 83);
            this.Controls.Add(this.lblMeasureResult);
            this.Controls.Add(this.lblresult);
            this.Name = "frmMeasureResult";
            this.Text = "测量结果";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblresult;
        private System.Windows.Forms.Label lblMeasureResult;
    }
}