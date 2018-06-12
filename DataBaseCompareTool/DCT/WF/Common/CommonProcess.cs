using BLL;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WF.Common
{

    public partial class CommonProcess : Form
    {


        private Form parentform;

        /// <summary>
        /// 表比对
        /// </summary>
        TableBLL bll = new TableBLL();

        public CommonProcess(Form parent)
        {
            this.parentform = parent;
            InitializeComponent();
            lblTitle.Text = "缓存数据库";

        }


        //public void CacheTable(string connstr)
        //{
        //    this.parentform.Enabled = false;
        //    PgsBar pgs = new PgsBar(pbCommon, lblCommon);
        //    bll.InitDAL(CommonConfig.DataBaseType.Definition, connstr);
        //    string retmsg = bll.CacheTable(pgs);
        //    this.parentform.Enabled = true;
        //    MessageBox.Show(retmsg, "提示", MessageBoxButtons.OK);
        //}


    }
}
