namespace WF
{
    partial class Main
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.SettingMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DBSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.TableMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CompareTable = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.MainMenu.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingMenu,
            this.TableMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(984, 25);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // SettingMenu
            // 
            this.SettingMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DBSetting});
            this.SettingMenu.Name = "SettingMenu";
            this.SettingMenu.Size = new System.Drawing.Size(44, 21);
            this.SettingMenu.Text = "设置";
            // 
            // DBSetting
            // 
            this.DBSetting.Name = "DBSetting";
            this.DBSetting.Size = new System.Drawing.Size(152, 22);
            this.DBSetting.Text = "数据库设置";
            this.DBSetting.Click += new System.EventHandler(this.DBSetting_Click);
            // 
            // TableMenu
            // 
            this.TableMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CompareTable});
            this.TableMenu.Name = "TableMenu";
            this.TableMenu.Size = new System.Drawing.Size(32, 21);
            this.TableMenu.Text = "表";
            // 
            // CompareTable
            // 
            this.CompareTable.Name = "CompareTable";
            this.CompareTable.Size = new System.Drawing.Size(112, 22);
            this.CompareTable.Text = "表比对";
            this.CompareTable.Click += new System.EventHandler(this.CompareTable_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tcMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(984, 437);
            this.pnlMain.TabIndex = 1;
            // 
            // tcMain
            // 
            this.tcMain.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(984, 437);
            this.tcMain.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "Main";
            this.Text = "Main";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem TableMenu;
        private System.Windows.Forms.ToolStripMenuItem CompareTable;
        private System.Windows.Forms.ToolStripMenuItem SettingMenu;
        private System.Windows.Forms.ToolStripMenuItem DBSetting;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TabControl tcMain;
    }
}