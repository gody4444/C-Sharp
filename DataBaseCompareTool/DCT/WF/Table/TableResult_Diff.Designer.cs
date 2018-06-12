namespace WF.Table
{
    partial class TableResult_Diff
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbTargetSql = new System.Windows.Forms.TextBox();
            this.TarIsnull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TarType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TarIsequal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TarIspropertyequal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTarget = new System.Windows.Forms.DataGridView();
            this.TarDefault = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbSourceSql = new System.Windows.Forms.TextBox();
            this.ColDefault = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsNull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsequal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIspropertyequal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSource = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbTargetSql
            // 
            this.tbTargetSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTargetSql.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbTargetSql.Location = new System.Drawing.Point(3, 51);
            this.tbTargetSql.Multiline = true;
            this.tbTargetSql.Name = "tbTargetSql";
            this.tbTargetSql.ReadOnly = true;
            this.tbTargetSql.Size = new System.Drawing.Size(476, 73);
            this.tbTargetSql.TabIndex = 2;
            // 
            // TarIsnull
            // 
            this.TarIsnull.DataPropertyName = "Isnull";
            this.TarIsnull.HeaderText = "是否为空";
            this.TarIsnull.Name = "TarIsnull";
            // 
            // TarType
            // 
            this.TarType.DataPropertyName = "Type";
            this.TarType.HeaderText = "类型";
            this.TarType.Name = "TarType";
            this.TarType.Width = 115;
            // 
            // TarIsequal
            // 
            this.TarIsequal.DataPropertyName = "Isequal";
            this.TarIsequal.HeaderText = "Isequal";
            this.TarIsequal.Name = "TarIsequal";
            this.TarIsequal.Visible = false;
            // 
            // TarIspropertyequal
            // 
            this.TarIspropertyequal.DataPropertyName = "Ispropertyequal";
            this.TarIspropertyequal.HeaderText = "Ispropertyequal";
            this.TarIspropertyequal.Name = "TarIspropertyequal";
            this.TarIspropertyequal.Visible = false;
            // 
            // TarName
            // 
            this.TarName.DataPropertyName = "Columnname";
            this.TarName.HeaderText = "列名";
            this.TarName.Name = "TarName";
            this.TarName.Width = 110;
            // 
            // dgvTarget
            // 
            this.dgvTarget.AllowUserToAddRows = false;
            this.dgvTarget.AllowUserToDeleteRows = false;
            this.dgvTarget.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvTarget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarget.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TarName,
            this.TarIspropertyequal,
            this.TarIsequal,
            this.TarType,
            this.TarIsnull,
            this.TarDefault});
            this.dgvTarget.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTarget.Location = new System.Drawing.Point(3, 3);
            this.dgvTarget.Name = "dgvTarget";
            this.dgvTarget.RowTemplate.Height = 23;
            this.dgvTarget.Size = new System.Drawing.Size(476, 42);
            this.dgvTarget.TabIndex = 1;
            this.dgvTarget.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvTarget_RowPrePaint);
            // 
            // TarDefault
            // 
            this.TarDefault.DataPropertyName = "Default";
            this.TarDefault.HeaderText = "默认值";
            this.TarDefault.Name = "TarDefault";
            // 
            // tbSourceSql
            // 
            this.tbSourceSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSourceSql.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbSourceSql.Location = new System.Drawing.Point(3, 51);
            this.tbSourceSql.Multiline = true;
            this.tbSourceSql.Name = "tbSourceSql";
            this.tbSourceSql.ReadOnly = true;
            this.tbSourceSql.Size = new System.Drawing.Size(476, 73);
            this.tbSourceSql.TabIndex = 1;
            // 
            // ColDefault
            // 
            this.ColDefault.DataPropertyName = "Default";
            this.ColDefault.HeaderText = "默认值";
            this.ColDefault.Name = "ColDefault";
            // 
            // ColIsNull
            // 
            this.ColIsNull.DataPropertyName = "Isnull";
            this.ColIsNull.HeaderText = "是否为空";
            this.ColIsNull.Name = "ColIsNull";
            // 
            // ColType
            // 
            this.ColType.DataPropertyName = "Type";
            this.ColType.HeaderText = "类型";
            this.ColType.Name = "ColType";
            this.ColType.Width = 115;
            // 
            // ColIsequal
            // 
            this.ColIsequal.DataPropertyName = "Isequal";
            this.ColIsequal.HeaderText = "Isequal";
            this.ColIsequal.Name = "ColIsequal";
            this.ColIsequal.Visible = false;
            // 
            // ColIspropertyequal
            // 
            this.ColIspropertyequal.DataPropertyName = "Ispropertyequal";
            this.ColIspropertyequal.HeaderText = "Ispropertyequal";
            this.ColIspropertyequal.Name = "ColIspropertyequal";
            this.ColIspropertyequal.Visible = false;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "Columnname";
            this.ColName.HeaderText = "列名";
            this.ColName.Name = "ColName";
            this.ColName.Width = 110;
            // 
            // dgvSource
            // 
            this.dgvSource.AllowUserToAddRows = false;
            this.dgvSource.AllowUserToDeleteRows = false;
            this.dgvSource.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColIspropertyequal,
            this.ColIsequal,
            this.ColType,
            this.ColIsNull,
            this.ColDefault});
            this.dgvSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSource.Location = new System.Drawing.Point(3, 3);
            this.dgvSource.Name = "dgvSource";
            this.dgvSource.RowTemplate.Height = 23;
            this.dgvSource.Size = new System.Drawing.Size(476, 42);
            this.dgvSource.TabIndex = 0;
            this.dgvSource.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvSource_RowPrePaint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.dgvSource);
            this.flowLayoutPanel1.Controls.Add(this.tbSourceSql);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(482, 437);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(968, 437);
            this.splitContainer1.SplitterDistance = 482;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Add(this.dgvTarget);
            this.flowLayoutPanel2.Controls.Add(this.tbTargetSql);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(482, 437);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Controls.Add(this.splitContainer1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 41);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(970, 439);
            this.pnlContent.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(702, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "目标数据库";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(219, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "源数据库";
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.BackColor = System.Drawing.Color.Silver;
            this.lblTableName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTableName.Location = new System.Drawing.Point(22, 13);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(31, 14);
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "表名";
            // 
            // pnlTop
            // 
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.lblTableName);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(970, 41);
            this.pnlTop.TabIndex = 2;
            // 
            // TableResult_Diff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);
            this.Name = "TableResult_Diff";
            this.Size = new System.Drawing.Size(970, 480);
            this.Load += new System.EventHandler(this.TableResult_Diff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbTargetSql;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarIsnull;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarIsequal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarIspropertyequal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarName;
        public System.Windows.Forms.DataGridView dgvTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn TarDefault;
        private System.Windows.Forms.TextBox tbSourceSql;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIsNull;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIsequal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIspropertyequal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        public System.Windows.Forms.DataGridView dgvSource;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Panel pnlTop;

    }
}
