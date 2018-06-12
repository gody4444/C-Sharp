using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BLL
{

    public class PgsBar
    {
        /// <summary>
        /// 进度条
        /// </summary>
        public ProgressBar pgsbar;

        /// <summary>
        /// 进度条提示
        /// </summary>
        public Label lbl;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="label"></param>
        public PgsBar(ProgressBar bar, Label label)
        {
            this.pgsbar = bar;
            this.pgsbar.Value = 0;
            SetPgsMax();
            this.lbl = label;
            //this.lbl.Text = "操作进行中，请稍等";
        }

        /// <summary>
        /// 设置最大值
        /// </summary>
        /// <param name="maxval"></param>
        public void SetPgsMax(int maxval = 100)
        {
            this.pgsbar.Maximum = maxval;
        }

        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <returns></returns>
        public int GetPgsMax()
        {
            return this.pgsbar.Maximum;
        }

        /// <summary>
        /// 进度条滚动
        /// </summary>
        /// <param name="val"></param>
        /// <param name="msg"></param>
        public void PgsScoroll(int val, string msg)
        {
            this.pgsbar.Value += val;
            Application.DoEvents();
            this.lbl.Text = msg;
            this.lbl.Refresh();
        }

        /// <summary>
        /// 结束进度条
        /// </summary>
        /// <param name="msg"></param>
        public void SetMax(string msg)
        {
            this.pgsbar.Value = this.pgsbar.Maximum;
            Application.DoEvents();
            this.lbl.Text = msg;

        }

    }


}
