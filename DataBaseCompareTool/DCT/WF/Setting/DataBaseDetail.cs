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

namespace WF.Setting
{



    public partial class DataBaseDetail : Form
    {

        /// <summary>
        /// 打开窗体事件委托
        /// </summary>
        public delegate void OpenDelegate();

        /// <summary>
        /// 执行父窗体方法
        /// </summary>
        public event OpenDelegate ParentEvent;

        public string id;

        public string dbtype;

        private DataBaseModel dbinfo;

        SetBLL bll = new SetBLL();

        public DataBaseDetail()
        {
            InitializeComponent();
        }

        private void DataBaseDetail_Load(object sender, EventArgs e)
        {
            dbinfo = new DataBaseModel();

            if (!string.IsNullOrEmpty(id))//编辑
            {
                //dbinfo = new DataBase();
                dbinfo = bll.GetDBSetDetail(id);
                labelName.Text = dbinfo.NAME;
                DB.Text = dbinfo.DB;
                User.Text = dbinfo.USER;
                Password.Text = dbinfo.PWD;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string msg;
            dbinfo = new DataBaseModel();
            dbinfo.ID = id;
            dbinfo.NAME = labelName.Text;
            dbinfo.DB = DB.Text;
            dbinfo.USER = User.Text;
            dbinfo.PWD = Password.Text;
            if (string.IsNullOrEmpty(dbinfo.NAME) || string.IsNullOrEmpty(dbinfo.DB) || string.IsNullOrEmpty(dbinfo.USER) || string.IsNullOrEmpty(dbinfo.PWD))
            {
                MessageBox.Show("请填写相关信息", "提示", MessageBoxButtons.OK);
                return;
            }
            if (bll.SaveDBSet(dbinfo, out msg))
            {
                DialogResult dr = MessageBox.Show(msg, "提示", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    ParentEvent();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK);
            }
        }


    }
}
