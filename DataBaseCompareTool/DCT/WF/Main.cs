using BLL;
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
using WF.Setting;
using WF.Table;

namespace WF
{
    public partial class Main : Form
    {
        /// <summary>
        /// 选项卡
        /// </summary>
        private TabControl_Comm commtc;

        public Main()
        {
            InitializeComponent();
            commtc = new TabControl_Comm(this, tcMain);
            //BindTableCompare();

            DataBaseList dblist = new DataBaseList();
            commtc.OpenTabPage(dblist);
        }

        #region 事件

        /// <summary>
        /// 比对表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompareTable_Click(object sender, EventArgs e)
        {
            BindTableCompare();
        }

        /// <summary>
        /// 设置表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBSetting_Click(object sender, EventArgs e)
        {
            DataBaseList dblist = new DataBaseList();
            commtc.OpenTabPage(dblist);
        }

        #endregion



        #region 子窗体方法

        private void BindTableCompare()
        {
            TableCompare comp_table = new TableCompare();
            //子窗体绑定父窗体事件
            comp_table.PartEvent += Open_Part_Compare;
            comp_table.AllEvent += Open_All_Compare;
            commtc.OpenTabPage(comp_table);
        }

        /// <summary>
        /// 打开所有比对结果页签
        /// </summary>
        void Open_All_Compare()
        {
            TableResult tableresult = new TableResult();
            tableresult.xmlname = CommonConfig.CompareAllTable;
            commtc.OpenTabPage(tableresult);
        }

        /// <summary>
        /// 打开部分比对结果页签
        /// </summary>
        void Open_Part_Compare()
        {
            TableResult comp_result = new TableResult();
            comp_result.Text = "部分表比对结果";
            comp_result.xmlname = CommonConfig.ComparePartTable;
            comp_result.ControlBox = true;
            commtc.OpenTabPage(comp_result);
        }

        #endregion






    }
}
