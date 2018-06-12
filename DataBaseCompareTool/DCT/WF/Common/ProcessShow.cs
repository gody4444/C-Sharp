using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WF.Common
{
    public class ProcessShow
    {
        //public delegate Boolean OpenProgress(int val, string msg);

        //private OpenProgress progress = null;//声明代理，用于后面的实例化代理

        /// <summary>
        /// 进度条
        /// </summary>
        public delegate Boolean ProcessDelegate(int val, string msg);

        public delegate void ProcessCloseDelegate();

        public ProcessDelegate SetProcess = null;

        public ProcessCloseDelegate CloseProcess = null;


        public Form ParentForm = null;

        public Boolean IsStart = false;

        public Boolean IsFinish = false;

        public ProcessShow(Form pform)
        {
            ParentForm = pform;
            Thread thdSub = new Thread(new ThreadStart(ThreadFun));
            thdSub.Start();
        }

        private void ThreadFun()
        {
            MethodInvoker mi = new MethodInvoker(ShowProcessBar);
            ParentForm.BeginInvoke(mi);
            //Thread.Sleep(100);
            object objReturn = null;
            for (int i = 0; i < 55; i++)
            {
                if (!IsFinish)
                {
                    objReturn = ParentForm.Invoke(this.SetProcess, new object[] { 1, "操作进行中，请稍等" });
                    Thread.Sleep(500);
                }
                else
                {
                    objReturn = ParentForm.Invoke(this.CloseProcess);
                }
            }
        }

        private void ShowProcessBar()
        {
            CommonProcess process = new CommonProcess(55);
            SetProcess = new ProcessDelegate(process.SetCurrentStatus);
            CloseProcess = new ProcessCloseDelegate(process.CloseProcess);
            IsStart = true;
            process.ShowDialog();
            process = null;

        }

    }
}
