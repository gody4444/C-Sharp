namespace WF.Table
{
    partial class TableResult_Loss
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
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.SourceTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTable
            // 
            this.dgvTable.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SourceTable,
            this.TargetTable});
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.Location = new System.Drawing.Point(0, 0);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowTemplate.Height = 23;
            this.dgvTable.Size = new System.Drawing.Size(984, 462);
            this.dgvTable.TabIndex = 1;
            // 
            // SourceTable
            // 
            this.SourceTable.DataPropertyName = "SourceTable";
            this.SourceTable.HeaderText = "源数据库表";
            this.SourceTable.Name = "SourceTable";
            this.SourceTable.Width = 300;
            // 
            // TargetTable
            // 
            this.TargetTable.DataPropertyName = "TargetTable";
            this.TargetTable.HeaderText = "目标数据库表";
            this.TargetTable.Name = "TargetTable";
            this.TargetTable.Width = 300;
            // 
            // TableResult_Loss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.ControlBox = false;
            this.Controls.Add(this.dgvTable);
            this.Name = "TableResult_Loss";
            this.Text = "表缺失";
            this.Load += new System.EventHandler(this.TableResult_Loss_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetTable;

    }
}