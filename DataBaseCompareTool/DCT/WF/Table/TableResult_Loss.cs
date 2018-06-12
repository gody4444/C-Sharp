using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WF.Table
{
    public partial class TableResult_Loss : Form
    {
        /// <summary>
        /// 要加载的比对文件名称
        /// </summary>
        public string xmlname = "";

        /// <summary>
        /// 表比对业务
        /// </summary>
        TableBLL bll = new TableBLL();

        public TableResult_Loss()
        {
            InitializeComponent();
        }

        private void TableResult_Loss_Load(object sender, EventArgs e)
        {
            List<ShowTableCompare> list = bll.GetShowTable(this.xmlname);
            dgvTable.DataSource = list;
        }
    }
}
