using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using WF.Common;

namespace WF.Setting
{
    public partial class DataBaseList : Form
    {
        SetBLL bll = new SetBLL();


        public DataBaseList()
        {
            InitializeComponent();
        }

        private void DataBaseList_Load(object sender, EventArgs e)
        {
            BindDBList();
        }


        #region 事件

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSource_Click(object sender, EventArgs e)
        {
            OpenDetailWin();
        }

        /// <summary>
        /// 单击单元格(编辑、删除、缓存)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            string id = this.dgvSource.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            if (e.ColumnIndex == 0)//修改
            {
                OpenDetailWin(id);
            }
            else if (e.ColumnIndex == 1)//删除
            {
                DialogResult dr = MessageBox.Show("是否确定删除？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    string msg;
                    bll.DeleteDBSet(id, out msg);
                    MessageBox.Show(msg, "提示", MessageBoxButtons.OK);
                    BindDBList();
                }

            }
            else if (e.ColumnIndex == 2)//缓存
            {
                DialogResult dr = MessageBox.Show("是否确定缓存数据源？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    this.Enabled = false;
                    PgsBar pgs = new PgsBar(pgsDBList, lblShow);
                    TableBLL auxbll = new TableBLL();

                    string filename = bll.GetFilePath(id, this.dgvSource.Rows[e.RowIndex].Cells["NAME"].Value.ToString());
                    DBSetting setmodel = new DBSetting();
                    setmodel.Flag = CommonConfig.DataType.DB;
                    setmodel.DBAccount.DB = this.dgvSource.Rows[e.RowIndex].Cells["DB"].Value.ToString();
                    setmodel.DBAccount.User = this.dgvSource.Rows[e.RowIndex].Cells["USER"].Value.ToString();
                    setmodel.DBAccount.Pwd = this.dgvSource.Rows[e.RowIndex].Cells["PWD"].Value.ToString();

                    auxbll.IninDefinitionDAL(setmodel);
                    string retmsg;
                    if (auxbll.CacheTable(pgs, filename, out retmsg))
                    {
                        DataBaseModel model = new DataBaseModel();
                        model.ID = id;
                        model.PATH = filename;
                        if (!bll.SetCache(model, out retmsg))
                        {
                            MessageBox.Show(retmsg, "提示", MessageBoxButtons.OK);
                        }
                    }
                    this.Enabled = true;
                    BindDBList();
                }

            }

        }

        #endregion


        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDBList()
        {
            dgvSource.DataSource = bll.GetDBSetList();
        }

        /// <summary>
        /// 打开详情
        /// </summary>
        /// <param name="id"></param>
        private void OpenDetailWin(string id = "")
        {
            DataBaseDetail dbdetail = new DataBaseDetail();
            dbdetail.ParentEvent += BindDBList;
            dbdetail.StartPosition = FormStartPosition.CenterScreen;

            if (!string.IsNullOrEmpty(id))
            {
                dbdetail.id = id;
            }
            dbdetail.Show();
        }

    }
}
