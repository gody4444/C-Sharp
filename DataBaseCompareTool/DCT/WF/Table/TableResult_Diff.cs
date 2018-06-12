using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;
using Common;

namespace WF.Table
{
    public partial class TableResult_Diff : UserControl
    {

        /// <summary>
        /// 要加载的比对文件名称
        /// </summary>
        public string xmlname = "";

        /// <summary>
        /// 表名
        /// </summary>
        public string tbname = string.Empty;

        /// <summary>
        /// 表比对业务
        /// </summary>
        TableBLL bll = new TableBLL();

        public TableResult_Diff()
        {
            InitializeComponent();
        }

        private void TableResult_Diff_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbname))
            {
                lblTableName.Text = string.Format("表{0}比对结果", tbname);
                lblTableName.Height *= 2;
                BindDate(tbname);
            }
        }

        private void BindDate(string tbname)
        {
            #region 表格显示比对结果
            List<ShowColumnCompare> sourcelist = bll.GetSingleTable(tbname, CommonConfig.EqualValue.Source, this.xmlname);
            List<ShowColumnCompare> targetlist = bll.GetSingleTable(tbname, CommonConfig.EqualValue.Target, this.xmlname);
            //设置行高
            dgvSource.DataSource = sourcelist;
            dgvSource.Size = new Size(dgvSource.Size.Width, 25 * (sourcelist.Count + 1));
            dgvTarget.DataSource = targetlist;
            dgvTarget.Size = new Size(dgvTarget.Size.Width, 25 * (targetlist.Count + 1));
            #endregion

            #region 生成对应的缺失sql语句
            TableCompareModel tbmodel = bll.GetSingleTable(tbname, this.xmlname);

            List<string> sourcesql = new List<string>();
            List<string> targetsql = new List<string>();
            bll.GetSqlbyColumn(tbmodel, ref sourcesql, ref targetsql);

            foreach (string item in sourcesql)
            {
                tbSourceSql.Text += item + ";\r\n";
                tbSourceSql.BackColor = Color.Silver;
            }
            tbSourceSql.Size = new Size(tbSourceSql.Size.Width, 15 * sourcesql.Count + 15);
            foreach (string item in targetsql)
            {
                tbTargetSql.Text += item + ";\r\n";
                tbTargetSql.BackColor = Color.Silver;
            }
            tbTargetSql.Size = new Size(tbTargetSql.Size.Width, 15 * targetsql.Count + 15);
            #endregion
        }

        #region 样式
        private void dgvSource_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow dgvRow = dgvSource.Rows[e.RowIndex];
            //equal中1表示表中字段存在，0表示表中字段不存在
            int equal = Convert.ToInt32(dgvRow.Cells["ColIsequal"].Value);
            if ((equal & 11) == 11)
            {
                //propertyequal中的位为1表示字段属性匹配，为0表示字段属性不匹配
                int propertyequal = Convert.ToInt32(dgvRow.Cells["ColIspropertyequal"].Value);
                if ((propertyequal & 100) == 000)//Type字段不匹配
                {
                    dgvRow.Cells["ColType"].Style.BackColor = Color.Red;
                }
                if ((propertyequal & 010) == 000)//Isnull字段不匹配
                {
                    dgvRow.Cells["ColIsnull"].Style.BackColor = Color.Red;
                }
                if ((propertyequal & 001) == 000)//Default字段不匹配
                {
                    dgvRow.Cells["ColDefault"].Style.BackColor = Color.Red;
                }
            }
            else//表示源数据库表的字段和目标数据库表的字段至少一个不存在
            {
                dgvRow.DefaultCellStyle.BackColor = Color.Gray;
            }
        }

        private void dgvTarget_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow dgvRow = dgvTarget.Rows[e.RowIndex];
            int equal = Convert.ToInt32(dgvRow.Cells["TarIsequal"].Value);
            if ((equal & 11) == 11)
            {
                int propertyequal = Convert.ToInt32(dgvRow.Cells["TarIspropertyequal"].Value);
                if ((propertyequal & 100) == 000)//Type字段不匹配
                {
                    dgvRow.Cells["TarType"].Style.BackColor = Color.Red;
                }
                if ((propertyequal & 010) == 000)//Isnull字段不匹配
                {
                    dgvRow.Cells["TarIsnull"].Style.BackColor = Color.Red;
                }
                if ((propertyequal & 001) == 000)//Default字段不匹配
                {
                    dgvRow.Cells["TarDefault"].Style.BackColor = Color.Red;
                }
            }
            else
            {
                dgvRow.DefaultCellStyle.BackColor = Color.Gray;
            }
        }

        #endregion

    }
}
