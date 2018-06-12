namespace WF.Common
{
    partial class CommonProcess
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
            this.pbCommon = new System.Windows.Forms.ProgressBar();
            this.lblCommon = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCommon
            // 
            this.pbCommon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbCommon.Location = new System.Drawing.Point(0, 0);
            this.pbCommon.Name = "pbCommon";
            this.pbCommon.Size = new System.Drawing.Size(662, 23);
            this.pbCommon.TabIndex = 0;
            // 
            // lblCommon
            // 
            this.lblCommon.AutoSize = true;
            this.lblCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCommon.Location = new System.Drawing.Point(0, 23);
            this.lblCommon.Name = "lblCommon";
            this.lblCommon.Size = new System.Drawing.Size(113, 12);
            this.lblCommon.TabIndex = 1;
            this.lblCommon.Text = "操作进行中，请稍等";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 100);
            this.panel1.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTitle.Location = new System.Drawing.Point(0, 88);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(29, 12);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "标题";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblCommon);
            this.panel2.Controls.Add(this.pbCommon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(662, 236);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 189);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(662, 147);
            this.panel3.TabIndex = 4;
            // 
            // CommonProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 336);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CommonProcess";
            this.Text = "进度条";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbCommon;
        private System.Windows.Forms.Label lblCommon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTitle;
    }
}