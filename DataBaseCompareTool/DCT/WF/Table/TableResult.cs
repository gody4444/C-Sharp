using BLL;
using Model;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WF.Common;

namespace WF.Table
{
    public partial class TableResult : Form
    {

        private TabControl_Comm commtc;

        /// <summary>
        /// 要加载的比对文件名称
        /// </summary>
        public string xmlname = "";

        /// <summary>
        /// 表比对业务
        /// </summary>
        TableBLL bll = new TableBLL();

        public TableResult()
        {
            InitializeComponent();

            commtc = new TabControl_Comm(this, tc_Comp_Result);
        }

        /// <summary>
        /// 单击后加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tree.SelectedNode != null)
            {
                string nodetext = tree.SelectedNode.Text;
                if (nodetext.IndexOf('[') < 0)
                {
                    TableResult_Diff table = new TableResult_Diff();
                    table.xmlname = this.xmlname;
                    table.tbname = nodetext;
                    commtc.OpenTabPageUC(table, nodetext);
                }
                else if (nodetext == "[表缺失]")
                {
                    TableResult_Loss form = new TableResult_Loss();
                    form.xmlname = this.xmlname;
                    form.Text = "[表缺失]";
                    form.TopLevel = false;
                    form.Dock = DockStyle.Fill;
                    form.FormBorderStyle = FormBorderStyle.None;
                    commtc.OpenTabPage(form);
                }


            }
        }


        private void CreateTree()
        {
            TreeNode root = new TreeNode("[数据库]");
            TreeNode table = new TreeNode("[表]");
            //TreeNode view = new TreeNode("[视图]");
            //TreeNode procedure = new TreeNode("[存储过程]");
            root.Nodes.Add(table);
            //root.Nodes.Add(view);
            //root.Nodes.Add(procedure);

            TreeNode losetable = new TreeNode("[表缺失]");
            TreeNode losecolumn = new TreeNode("[列缺失]");

            table.Nodes.Add(losetable);
            table.Nodes.Add(losecolumn);

            List<TableCompareModel> reslist = bll.GetRes_TableList(CommonConfig.EqualValue.Column, this.xmlname);
            foreach (TableCompareModel item in reslist)
            {
                string nodename = item.Tablename;
                TreeNode nodetable = new TreeNode(nodename);
                losecolumn.Nodes.Add(nodetable);
            }

            tree.Nodes.Add(root);
            tree.ExpandAll();
        }

        private void TableResult_Load(object sender, EventArgs e)
        {
            CreateTree();
        }


    }
}
