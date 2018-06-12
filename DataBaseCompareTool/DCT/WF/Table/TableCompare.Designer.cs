namespace WF.Table
{
    partial class TableCompare
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblname = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblprogress = new System.Windows.Forms.Label();
            this.pgsCompare = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTarget = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSource = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cklist = new System.Windows.Forms.CheckedListBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.btnAllCompare = new System.Windows.Forms.Button();
            this.btnAllResult = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.SelId = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvList);
            this.splitContainer1.Size = new System.Drawing.Size(984, 462);
            this.splitContainer1.SplitterDistance = 135;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cklist);
            this.splitContainer2.Panel2.Controls.Add(this.btnCompare);
            this.splitContainer2.Panel2.Controls.Add(this.btnResult);
            this.splitContainer2.Panel2.Controls.Add(this.btnAllCompare);
            this.splitContainer2.Panel2.Controls.Add(this.btnAllResult);
            this.splitContainer2.Size = new System.Drawing.Size(984, 135);
            this.splitContainer2.SplitterDistance = 646;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.lblname);
            this.panel3.Controls.Add(this.tbName);
            this.panel3.Controls.Add(this.lblType);
            this.panel3.Controls.Add(this.cbType);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(644, 55);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 24;
            this.label3.Text = "源数据库查询";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(489, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(118, 10);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(53, 12);
            this.lblname.TabIndex = 9;
            this.lblname.Text = "表名称：";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(177, 7);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 21);
            this.tbName.TabIndex = 11;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(298, 10);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(41, 12);
            this.lblType.TabIndex = 12;
            this.lblType.Text = "类型：";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(345, 7);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 20);
            this.cbType.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblprogress);
            this.panel2.Controls.Add(this.pgsCompare);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 38);
            this.panel2.TabIndex = 1;
            // 
            // lblprogress
            // 
            this.lblprogress.AutoSize = true;
            this.lblprogress.Location = new System.Drawing.Point(308, 16);
            this.lblprogress.Name = "lblprogress";
            this.lblprogress.Size = new System.Drawing.Size(53, 12);
            this.lblprogress.TabIndex = 19;
            this.lblprogress.Text = "进度提示";
            // 
            // pgsCompare
            // 
            this.pgsCompare.Location = new System.Drawing.Point(5, 5);
            this.pgsCompare.Name = "pgsCompare";
            this.pgsCompare.Size = new System.Drawing.Size(297, 23);
            this.pgsCompare.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbTarget);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbSource);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 40);
            this.panel1.TabIndex = 0;
            // 
            // cbTarget
            // 
            this.cbTarget.FormattingEnabled = true;
            this.cbTarget.Location = new System.Drawing.Point(408, 7);
            this.cbTarget.Name = "cbTarget";
            this.cbTarget.Size = new System.Drawing.Size(225, 20);
            this.cbTarget.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "源数据库：";
            // 
            // cbSource
            // 
            this.cbSource.FormattingEnabled = true;
            this.cbSource.Location = new System.Drawing.Point(74, 7);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(225, 20);
            this.cbSource.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "目标数据库：";
            // 
            // cklist
            // 
            this.cklist.FormattingEnabled = true;
            this.cklist.Items.AddRange(new object[] {
            "字段类型",
            "可为空",
            "默认值",
            "字段存在"});
            this.cklist.Location = new System.Drawing.Point(3, 3);
            this.cklist.Name = "cklist";
            this.cklist.Size = new System.Drawing.Size(120, 116);
            this.cklist.TabIndex = 18;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(129, 26);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 14;
            this.btnCompare.Text = "选择比对";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(223, 26);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(88, 23);
            this.btnResult.TabIndex = 15;
            this.btnResult.Text = "选择比对结果";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // btnAllCompare
            // 
            this.btnAllCompare.Location = new System.Drawing.Point(129, 72);
            this.btnAllCompare.Name = "btnAllCompare";
            this.btnAllCompare.Size = new System.Drawing.Size(75, 23);
            this.btnAllCompare.TabIndex = 16;
            this.btnAllCompare.Text = "全部比对";
            this.btnAllCompare.UseVisualStyleBackColor = true;
            this.btnAllCompare.Click += new System.EventHandler(this.btnAllCompare_Click);
            // 
            // btnAllResult
            // 
            this.btnAllResult.Location = new System.Drawing.Point(223, 72);
            this.btnAllResult.Name = "btnAllResult";
            this.btnAllResult.Size = new System.Drawing.Size(88, 23);
            this.btnAllResult.TabIndex = 17;
            this.btnAllResult.Text = "全部比对结果";
            this.btnAllResult.UseVisualStyleBackColor = true;
            this.btnAllResult.Click += new System.EventHandler(this.btnAllResult_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelId,
            this.SelName,
            this.SelType});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(982, 321);
            this.dgvList.TabIndex = 1;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentClick);
            // 
            // SelId
            // 
            this.SelId.DataPropertyName = "SelId";
            this.SelId.HeaderText = "单击全选";
            this.SelId.Name = "SelId";
            // 
            // SelName
            // 
            this.SelName.DataPropertyName = "SelName";
            this.SelName.HeaderText = "名称";
            this.SelName.Name = "SelName";
            this.SelName.ReadOnly = true;
            this.SelName.Width = 300;
            // 
            // SelType
            // 
            this.SelType.DataPropertyName = "SelType";
            this.SelType.HeaderText = "类型";
            this.SelType.Name = "SelType";
            this.SelType.ReadOnly = true;
            this.SelType.Width = 200;
            // 
            // TableCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TableCompare";
            this.Text = "表比对";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAllResult;
        private System.Windows.Forms.Button btnAllCompare;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.ComboBox cbTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelType;
        private System.Windows.Forms.Label lblprogress;
        private System.Windows.Forms.ProgressBar pgsCompare;
        private System.Windows.Forms.CheckedListBox cklist;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}