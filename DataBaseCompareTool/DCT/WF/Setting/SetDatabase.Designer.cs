namespace WF.Setting
{
    partial class SetDatabase
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
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SourceDB = new System.Windows.Forms.TextBox();
            this.lblLTitle = new System.Windows.Forms.Label();
            this.SourceUser = new System.Windows.Forms.TextBox();
            this.SourcePassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSourceCache = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnChoiceSource = new System.Windows.Forms.Button();
            this.tbSourceFile = new System.Windows.Forms.TextBox();
            this.pnlLTop = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.cbSource = new System.Windows.Forms.ComboBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.TargetPassword = new System.Windows.Forms.TextBox();
            this.TargetUser = new System.Windows.Forms.TextBox();
            this.lblRTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TargetDB = new System.Windows.Forms.TextBox();
            this.lblTargetCache = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnChoiceTarget = new System.Windows.Forms.Button();
            this.tbTargetFile = new System.Windows.Forms.TextBox();
            this.pnlRTop = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTarget = new System.Windows.Forms.ComboBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlLTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.pnlRTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.splitContainer1);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(984, 401);
            this.pnlCenter.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.pnlLTop);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel2.Controls.Add(this.pnlRTop);
            this.splitContainer1.Size = new System.Drawing.Size(984, 401);
            this.splitContainer1.SplitterDistance = 463;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 33);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.SourceDB);
            this.splitContainer2.Panel1.Controls.Add(this.lblLTitle);
            this.splitContainer2.Panel1.Controls.Add(this.SourceUser);
            this.splitContainer2.Panel1.Controls.Add(this.SourcePassword);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblSourceCache);
            this.splitContainer2.Panel2.Controls.Add(this.label10);
            this.splitContainer2.Panel2.Controls.Add(this.btnChoiceSource);
            this.splitContainer2.Panel2.Controls.Add(this.tbSourceFile);
            this.splitContainer2.Size = new System.Drawing.Size(463, 368);
            this.splitContainer2.SplitterDistance = 218;
            this.splitContainer2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(95, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "用户名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(95, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据库";
            // 
            // SourceDB
            // 
            this.SourceDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SourceDB.Location = new System.Drawing.Point(151, 52);
            this.SourceDB.Name = "SourceDB";
            this.SourceDB.Size = new System.Drawing.Size(184, 21);
            this.SourceDB.TabIndex = 2;
            // 
            // lblLTitle
            // 
            this.lblLTitle.AutoSize = true;
            this.lblLTitle.BackColor = System.Drawing.Color.Silver;
            this.lblLTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLTitle.Location = new System.Drawing.Point(191, 11);
            this.lblLTitle.Name = "lblLTitle";
            this.lblLTitle.Size = new System.Drawing.Size(67, 14);
            this.lblLTitle.TabIndex = 0;
            this.lblLTitle.Text = "源数据库库";
            // 
            // SourceUser
            // 
            this.SourceUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SourceUser.Location = new System.Drawing.Point(151, 93);
            this.SourceUser.Name = "SourceUser";
            this.SourceUser.Size = new System.Drawing.Size(184, 21);
            this.SourceUser.TabIndex = 4;
            // 
            // SourcePassword
            // 
            this.SourcePassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SourcePassword.Location = new System.Drawing.Point(151, 136);
            this.SourcePassword.Name = "SourcePassword";
            this.SourcePassword.Size = new System.Drawing.Size(184, 21);
            this.SourcePassword.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(95, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "密码";
            // 
            // lblSourceCache
            // 
            this.lblSourceCache.AutoSize = true;
            this.lblSourceCache.BackColor = System.Drawing.Color.Silver;
            this.lblSourceCache.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSourceCache.Location = new System.Drawing.Point(11, 39);
            this.lblSourceCache.Name = "lblSourceCache";
            this.lblSourceCache.Size = new System.Drawing.Size(31, 14);
            this.lblSourceCache.TabIndex = 7;
            this.lblSourceCache.Text = "路径";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Silver;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(191, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 14);
            this.label10.TabIndex = 8;
            this.label10.Text = "源缓存文件";
            // 
            // btnChoiceSource
            // 
            this.btnChoiceSource.Location = new System.Drawing.Point(302, 77);
            this.btnChoiceSource.Name = "btnChoiceSource";
            this.btnChoiceSource.Size = new System.Drawing.Size(87, 23);
            this.btnChoiceSource.TabIndex = 8;
            this.btnChoiceSource.Text = "加载XML文件";
            this.btnChoiceSource.UseVisualStyleBackColor = true;
            this.btnChoiceSource.Click += new System.EventHandler(this.btnChoiceSource_Click);
            // 
            // tbSourceFile
            // 
            this.tbSourceFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSourceFile.Enabled = false;
            this.tbSourceFile.Location = new System.Drawing.Point(10, 77);
            this.tbSourceFile.Name = "tbSourceFile";
            this.tbSourceFile.Size = new System.Drawing.Size(279, 21);
            this.tbSourceFile.TabIndex = 7;
            // 
            // pnlLTop
            // 
            this.pnlLTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLTop.Controls.Add(this.label7);
            this.pnlLTop.Controls.Add(this.btnChange);
            this.pnlLTop.Controls.Add(this.cbSource);
            this.pnlLTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLTop.Location = new System.Drawing.Point(0, 0);
            this.pnlLTop.Name = "pnlLTop";
            this.pnlLTop.Size = new System.Drawing.Size(463, 33);
            this.pnlLTop.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "选择数据来源：";
            // 
            // btnChange
            // 
            this.btnChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChange.Location = new System.Drawing.Point(392, 2);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(61, 23);
            this.btnChange.TabIndex = 1;
            this.btnChange.Text = "互换";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Visible = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // cbSource
            // 
            this.cbSource.FormattingEnabled = true;
            this.cbSource.Location = new System.Drawing.Point(95, 6);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(121, 20);
            this.cbSource.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 33);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.TargetPassword);
            this.splitContainer3.Panel1.Controls.Add(this.TargetUser);
            this.splitContainer3.Panel1.Controls.Add(this.lblRTitle);
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            this.splitContainer3.Panel1.Controls.Add(this.label6);
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            this.splitContainer3.Panel1.Controls.Add(this.TargetDB);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lblTargetCache);
            this.splitContainer3.Panel2.Controls.Add(this.label9);
            this.splitContainer3.Panel2.Controls.Add(this.btnChoiceTarget);
            this.splitContainer3.Panel2.Controls.Add(this.tbTargetFile);
            this.splitContainer3.Size = new System.Drawing.Size(517, 368);
            this.splitContainer3.SplitterDistance = 218;
            this.splitContainer3.TabIndex = 1;
            // 
            // TargetPassword
            // 
            this.TargetPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TargetPassword.Location = new System.Drawing.Point(187, 137);
            this.TargetPassword.Name = "TargetPassword";
            this.TargetPassword.Size = new System.Drawing.Size(184, 21);
            this.TargetPassword.TabIndex = 12;
            // 
            // TargetUser
            // 
            this.TargetUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TargetUser.Location = new System.Drawing.Point(187, 93);
            this.TargetUser.Name = "TargetUser";
            this.TargetUser.Size = new System.Drawing.Size(184, 21);
            this.TargetUser.TabIndex = 10;
            // 
            // lblRTitle
            // 
            this.lblRTitle.AutoSize = true;
            this.lblRTitle.BackColor = System.Drawing.Color.Silver;
            this.lblRTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRTitle.Location = new System.Drawing.Point(231, 11);
            this.lblRTitle.Name = "lblRTitle";
            this.lblRTitle.Size = new System.Drawing.Size(67, 14);
            this.lblRTitle.TabIndex = 0;
            this.lblRTitle.Text = "目标数据库";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(131, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "用户名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(131, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "数据库";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(131, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "密码";
            // 
            // TargetDB
            // 
            this.TargetDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TargetDB.Location = new System.Drawing.Point(187, 53);
            this.TargetDB.Name = "TargetDB";
            this.TargetDB.Size = new System.Drawing.Size(184, 21);
            this.TargetDB.TabIndex = 8;
            // 
            // lblTargetCache
            // 
            this.lblTargetCache.AutoSize = true;
            this.lblTargetCache.BackColor = System.Drawing.Color.Silver;
            this.lblTargetCache.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTargetCache.Location = new System.Drawing.Point(5, 39);
            this.lblTargetCache.Name = "lblTargetCache";
            this.lblTargetCache.Size = new System.Drawing.Size(31, 14);
            this.lblTargetCache.TabIndex = 13;
            this.lblTargetCache.Text = "路径";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Silver;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(231, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 14);
            this.label9.TabIndex = 7;
            this.label9.Text = "目标缓存文件";
            // 
            // btnChoiceTarget
            // 
            this.btnChoiceTarget.Location = new System.Drawing.Point(332, 80);
            this.btnChoiceTarget.Name = "btnChoiceTarget";
            this.btnChoiceTarget.Size = new System.Drawing.Size(87, 23);
            this.btnChoiceTarget.TabIndex = 10;
            this.btnChoiceTarget.Text = "加载XML文件";
            this.btnChoiceTarget.UseVisualStyleBackColor = true;
            this.btnChoiceTarget.Click += new System.EventHandler(this.btnChoiceTarget_Click);
            // 
            // tbTargetFile
            // 
            this.tbTargetFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTargetFile.Enabled = false;
            this.tbTargetFile.Location = new System.Drawing.Point(5, 80);
            this.tbTargetFile.Name = "tbTargetFile";
            this.tbTargetFile.Size = new System.Drawing.Size(321, 21);
            this.tbTargetFile.TabIndex = 9;
            // 
            // pnlRTop
            // 
            this.pnlRTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRTop.Controls.Add(this.label8);
            this.pnlRTop.Controls.Add(this.cbTarget);
            this.pnlRTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRTop.Location = new System.Drawing.Point(0, 0);
            this.pnlRTop.Name = "pnlRTop";
            this.pnlRTop.Size = new System.Drawing.Size(517, 33);
            this.pnlRTop.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "选择数据来源：";
            // 
            // cbTarget
            // 
            this.cbTarget.FormattingEnabled = true;
            this.cbTarget.Location = new System.Drawing.Point(98, 6);
            this.cbTarget.Name = "cbTarget";
            this.cbTarget.Size = new System.Drawing.Size(121, 20);
            this.cbTarget.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.btnSubmit);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 401);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(984, 61);
            this.pnlBottom.TabIndex = 3;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSubmit.Location = new System.Drawing.Point(428, 25);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "提交设置";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // SetDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.ControlBox = false;
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Name = "SetDatabase";
            this.Text = "数据库设置";
            this.Load += new System.EventHandler(this.SetDatabase_Load);
            this.pnlCenter.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pnlLTop.ResumeLayout(false);
            this.pnlLTop.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.pnlRTop.ResumeLayout(false);
            this.pnlRTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox SourcePassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SourceUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SourceDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlLTop;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label lblLTitle;
        private System.Windows.Forms.TextBox TargetPassword;
        private System.Windows.Forms.Panel pnlRTop;
        private System.Windows.Forms.Label lblRTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TargetDB;
        private System.Windows.Forms.TextBox TargetUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnChoiceSource;
        private System.Windows.Forms.TextBox tbSourceFile;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnChoiceTarget;
        private System.Windows.Forms.TextBox tbTargetFile;
        private System.Windows.Forms.ComboBox cbSource;
        private System.Windows.Forms.ComboBox cbTarget;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSourceCache;
        private System.Windows.Forms.Label lblTargetCache;
    }
}