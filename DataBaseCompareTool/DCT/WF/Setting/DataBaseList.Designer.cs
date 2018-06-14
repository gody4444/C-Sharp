namespace WF.Setting
{
    partial class DataBaseList
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnAddSource = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pgsDBList = new System.Windows.Forms.ProgressBar();
            this.lblShow = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSource = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cache = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PWD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCached = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealPATH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnAddSource);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(984, 462);
            this.splitContainer2.SplitterDistance = 54;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnAddSource
            // 
            this.btnAddSource.Location = new System.Drawing.Point(11, 14);
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(75, 23);
            this.btnAddSource.TabIndex = 10;
            this.btnAddSource.Text = "新增";
            this.btnAddSource.UseVisualStyleBackColor = true;
            this.btnAddSource.Click += new System.EventHandler(this.btnAddSource_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pgsDBList);
            this.panel2.Controls.Add(this.lblShow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 348);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 54);
            this.panel2.TabIndex = 1;
            // 
            // pgsDBList
            // 
            this.pgsDBList.Location = new System.Drawing.Point(12, 3);
            this.pgsDBList.Name = "pgsDBList";
            this.pgsDBList.Size = new System.Drawing.Size(284, 23);
            this.pgsDBList.TabIndex = 11;
            // 
            // lblShow
            // 
            this.lblShow.AutoSize = true;
            this.lblShow.Location = new System.Drawing.Point(10, 29);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(65, 12);
            this.lblShow.TabIndex = 12;
            this.lblShow.Text = "进度条详情";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvSource);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 402);
            this.panel1.TabIndex = 0;
            // 
            // dgvSource
            // 
            this.dgvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Del,
            this.cache,
            this.ID,
            this.NAME,
            this.DB,
            this.USER,
            this.PWD,
            this.IsCached,
            this.RealPATH,
            this.PATH});
            this.dgvSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSource.Location = new System.Drawing.Point(0, 0);
            this.dgvSource.Name = "dgvSource";
            this.dgvSource.RowTemplate.Height = 23;
            this.dgvSource.Size = new System.Drawing.Size(980, 400);
            this.dgvSource.TabIndex = 0;
            this.dgvSource.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSource_CellContentClick);
            // 
            // Edit
            // 
            this.Edit.Frozen = true;
            this.Edit.HeaderText = "编辑";
            this.Edit.Name = "Edit";
            this.Edit.Text = "编辑";
            this.Edit.ToolTipText = "编辑";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 40;
            // 
            // Del
            // 
            this.Del.Frozen = true;
            this.Del.HeaderText = "删除";
            this.Del.Name = "Del";
            this.Del.Text = "删除";
            this.Del.ToolTipText = "删除";
            this.Del.UseColumnTextForButtonValue = true;
            this.Del.Width = 40;
            // 
            // cache
            // 
            this.cache.Frozen = true;
            this.cache.HeaderText = "缓存";
            this.cache.Name = "cache";
            this.cache.Text = "缓存";
            this.cache.ToolTipText = "缓存";
            this.cache.UseColumnTextForButtonValue = true;
            this.cache.Width = 40;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "序号";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 35;
            // 
            // NAME
            // 
            this.NAME.DataPropertyName = "NAME";
            this.NAME.HeaderText = "名称";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            // 
            // DB
            // 
            this.DB.DataPropertyName = "DB";
            this.DB.HeaderText = "数据库";
            this.DB.Name = "DB";
            this.DB.ReadOnly = true;
            // 
            // USER
            // 
            this.USER.DataPropertyName = "USER";
            this.USER.HeaderText = "用户名";
            this.USER.Name = "USER";
            this.USER.ReadOnly = true;
            // 
            // PWD
            // 
            this.PWD.DataPropertyName = "PWD";
            this.PWD.HeaderText = "密码";
            this.PWD.Name = "PWD";
            this.PWD.ReadOnly = true;
            // 
            // IsCached
            // 
            this.IsCached.DataPropertyName = "IsCached";
            this.IsCached.HeaderText = "缓存";
            this.IsCached.Name = "IsCached";
            this.IsCached.ReadOnly = true;
            this.IsCached.ToolTipText = "缓存";
            // 
            // RealPATH
            // 
            this.RealPATH.DataPropertyName = "RealPATH";
            this.RealPATH.HeaderText = "缓存路径";
            this.RealPATH.Name = "RealPATH";
            this.RealPATH.ReadOnly = true;
            this.RealPATH.Width = 350;
            // 
            // PATH
            // 
            this.PATH.DataPropertyName = "PATH";
            this.PATH.HeaderText = "PATH";
            this.PATH.Name = "PATH";
            this.PATH.ReadOnly = true;
            this.PATH.Visible = false;
            // 
            // DataBaseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.splitContainer2);
            this.Name = "DataBaseList";
            this.Text = "数据库列表";
            this.Load += new System.EventHandler(this.DataBaseList_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnAddSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar pgsDBList;
        private System.Windows.Forms.Label lblShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvSource;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Del;
        private System.Windows.Forms.DataGridViewButtonColumn cache;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn PWD;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsCached;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealPATH;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATH;
    }
}