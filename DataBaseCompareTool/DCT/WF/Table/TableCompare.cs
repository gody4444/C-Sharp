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
using System.Threading;
using System.Windows.Forms;
using WF.Common;

namespace WF.Table
{

    /// <summary>
    /// 打开窗体事件委托
    /// </summary>
    public delegate void OpenDelegate();

    public partial class TableCompare : Form
    {

        //声明委托 和 事件 
        public event OpenDelegate PartEvent;
        public event OpenDelegate AllEvent;

        /// <summary>
        /// 表比对
        /// </summary>
        TableBLL bll = new TableBLL();



        SetBLL setbll = new SetBLL();

        List<WhereModel> wherelist;

        public TableCompare()
        {
            InitializeComponent();
            Init();
        }

        private Boolean SetSettingModel()
        {
            #region 校验
            ListItem liSource = (ListItem)cbSource.SelectedItem;
            ListItem liTarget = (ListItem)cbTarget.SelectedItem;
            if (liSource.Value == "-1")
            {
                MessageBox.Show("请选择源数据库", "提示", MessageBoxButtons.OK);
                return false;
            }
            if (liTarget.Value == "-1")
            {
                MessageBox.Show("请选择目标数据库", "提示", MessageBoxButtons.OK);
                return false;
            }
            string SourceVal = liSource.Value.Split('&')[0];
            string TargetVal = liTarget.Value.Split('&')[0];
            if (SourceVal == TargetVal)
            {
                MessageBox.Show("请不要选择相同的源数据库和目标数据库进行比对", "提示", MessageBoxButtons.OK);
                return false;
            }
            #endregion

            #region 业务类初始化
            DBSettingCompare setmodel = new DBSettingCompare();
            if (liSource.Value.IndexOf("Cache") > -1)
            {
                setmodel.Source.Flag = CommonConfig.DataType.XML;
                DataBaseModel db = setbll.GetDBSetDetail(SourceVal);
                setmodel.Source.XMLPath = db.RealPATH;
            }
            else
            {
                setmodel.Source.Flag = CommonConfig.DataType.DB;
                DataBaseModel db = setbll.GetDBSetDetail(SourceVal);
                setmodel.Source.DBAccount.DB = db.DB;
                setmodel.Source.DBAccount.User = db.USER;
                setmodel.Source.DBAccount.Pwd = db.PWD;
            }

            if (liTarget.Value.IndexOf("Cache") > -1)
            {
                setmodel.Target.Flag = CommonConfig.DataType.XML;
                DataBaseModel db = setbll.GetDBSetDetail(TargetVal);
                setmodel.Target.XMLPath = db.RealPATH;
            }
            else
            {
                setmodel.Target.Flag = CommonConfig.DataType.DB;
                DataBaseModel db = setbll.GetDBSetDetail(TargetVal);
                setmodel.Target.DBAccount.DB = db.DB;
                setmodel.Target.DBAccount.User = db.USER;
                setmodel.Target.DBAccount.Pwd = db.PWD;
            }
            setmodel.Definition = setmodel.Source;
            bll.InitDAL(setmodel);
            #endregion

            return true;
        }



        #region 事件

        /// <summary>
        /// 单元格单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
                for (int i = 0; i < this.dgvList.RowCount; i++)
                {
                    this.dgvList.Rows[i].Cells["SelId"].Value = "true";//如果为true则为选中,false未选中
                }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            wherelist = new List<WhereModel>();
            string sqlwhere = string.Empty;
            string strname = tbName.Text;
            if (!string.IsNullOrEmpty(strname))
            {
                WhereModel model = new WhereModel();
                model.left = "Tablename";
                model.symbol = "LIKE";
                model.right = strname;
                wherelist.Add(model);
            }
            BindDGV(wherelist);
        }

        /// <summary>
        /// 部分比对
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (!SetSettingModel())
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            DataGridViewCheckBoxCell checkCell;
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                checkCell = (DataGridViewCheckBoxCell)row.Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);

                if (flag)//选中
                {
                    sb.Append("'").Append(row.Cells[1].Value).Append("',");
                }
            }

            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                wherelist = new List<WhereModel>();
                WhereModel model = new WhereModel();
                model.left = "Tablename";
                model.symbol = "IN";
                model.right = sb.ToString().TrimEnd(',');
                wherelist.Add(model);
                this.Enabled = false;
                PgsBar pgs = new PgsBar(pgsCompare, lblprogress);
                bll.scc = SetSCC();
                string retmsg = bll.CompareTable(wherelist, CommonConfig.ComparePartTable, pgs);
                this.Enabled = true;
                MessageBox.Show(retmsg, "提示", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("请先选择要比对的表", "提示", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 部分比对结果展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResult_Click(object sender, EventArgs e)
        {
            PartEvent();
        }

        /// <summary>
        /// 全部比对
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllCompare_Click(object sender, EventArgs e)
        {
            if (!SetSettingModel())
            {
                return;
            }
            DialogResult dr = MessageBox.Show("是否比对数据库中所有表？", "提示", MessageBoxButtons.OKCancel);

            if (dr == DialogResult.OK)
            {
                this.Enabled = false;
                PgsBar pgs = new PgsBar(pgsCompare, lblprogress);
                bll.scc = SetSCC();
                string retmsg = bll.CompareTable(new List<WhereModel>(), CommonConfig.CompareAllTable, pgs);
                this.Enabled = true;
                MessageBox.Show(retmsg, "提示", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 全部结果展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllResult_Click(object sender, EventArgs e)
        {
            AllEvent();
        }

        #endregion

        #region 内部方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {

            #region 下拉列表框
            cbType.Items.Add(new ListItem("请选择", "-1"));
            cbType.Items.Add(new ListItem("表", "1"));
            cbType.SelectedItem = ListItem.FindByValue(cbType, "-1");
            #endregion

            //数据源下拉列表框绑定
            List<DataBaseModel> dblist = setbll.GetDBSetList();
            cbSource.Items.Add(new ListItem("请选择", "-1"));
            cbTarget.Items.Add(new ListItem("请选择", "-1"));
            foreach (DataBaseModel dbmodel in dblist)
            {
                cbSource.Items.Add(new ListItem(dbmodel.NAME, dbmodel.ID));
                cbTarget.Items.Add(new ListItem(dbmodel.NAME, dbmodel.ID));
                if (dbmodel.ISCACHED == "已缓存")
                {
                    cbSource.Items.Add(new ListItem("(缓存文件)" + dbmodel.NAME, dbmodel.ID + "&Cache"));
                    cbTarget.Items.Add(new ListItem("(缓存文件)" + dbmodel.NAME, dbmodel.ID + "&Cache"));
                }
            }
            cbSource.SelectedItem = ListItem.FindByValue(cbSource, "-1");
            cbTarget.SelectedItem = ListItem.FindByValue(cbTarget, "-1");

            for (int i = 0; i < cklist.Items.Count; i++)
                cklist.SetItemChecked(i, true);

            //dgvList.ClearSelection();//取消选中
        }

        private SettingColumnCompare SetSCC()
        {
            SettingColumnCompare sccmodel = new SettingColumnCompare();
            sccmodel.SetFalse();
            for (int i = 0; i < cklist.CheckedItems.Count; i++)
            {
                switch (cklist.CheckedItems[i].ToString())
                {
                    case "字段类型": sccmodel.Type = true; break;
                    case "可为空": sccmodel.Isnull = true; break;
                    case "默认值": sccmodel.Default = true; break;
                    case "字段存在": sccmodel.ColumnAdd = true; break;
                }
            }
            return sccmodel;
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        /// <param name="list"></param>
        private void BindDGV(List<WhereModel> list)
        {
            if (!SetSettingModel())
            {
                return;
            }
            this.Enabled = false;
            PgsBar pgs = new PgsBar(pgsCompare, lblprogress);
            DataTable dt = bll.GetDBList(list, pgs);
            this.Enabled = true;
            dgvList.DataSource = dt;

        }
        #endregion




    }
}
