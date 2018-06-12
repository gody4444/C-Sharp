using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WF.Common
{
    /// <summary>
    /// 选项卡
    /// </summary>
    public class TabControl_Comm
    {

        /// <summary>
        /// 选项卡
        /// </summary>
        private TabControl tabcontrol;

        /// <summary>
        /// 当前窗体
        /// </summary>
        private Form currentform;

        /// <summary>
        /// 关闭图标大小
        /// </summary>
        private const int CLOSE_SIZE = 12;

        /// <summary>
        /// tabPage标签图片
        /// </summary>
        Bitmap image = new Bitmap(System.AppDomain.CurrentDomain.BaseDirectory + "image\\ico_close.png");

        /// <summary>
        /// 初始化选项卡
        /// </summary>
        public TabControl_Comm(Form fm, TabControl tc)
        {
            tabcontrol = tc;
            currentform = fm;

            //绘制的方式OwnerDrawFixed表示由窗体绘制大小也一样
            tabcontrol.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabcontrol.Padding = new System.Drawing.Point(CLOSE_SIZE, CLOSE_SIZE / 2);
            tabcontrol.DrawItem += new DrawItemEventHandler(this.currentform_DrawItem);
            tabcontrol.MouseDown += new System.Windows.Forms.MouseEventHandler(this.currentform_MouseDown);
        }

        #region 打开页签

        /// <summary>
        /// 打开一个页签(窗体)
        /// </summary>
        /// <param name="page"></param>
        public void OpenTabPage(Form page)
        {
            string tpname = page.Text;
            if (IsUse(tpname))
            {
                TabPage tpg = new TabPage(tpname);
                page.TopLevel = false;
                //currentform.IsMdiContainer = true;
                //page.MdiParent = currentform;
                page.Dock = DockStyle.Fill;
                page.FormBorderStyle = FormBorderStyle.None;
                tpg.Controls.Add(page);
                tabcontrol.Controls.Add(tpg);
                tabcontrol.SelectedTab = tpg;
                page.Show();

            }
        }

        /// <summary>
        /// 打开一个页签(用户控件)
        /// </summary>
        /// <param name="usercontrol"></param>
        public void OpenTabPageUC(UserControl usercontrol, string tabname)
        {
            if (IsUse(tabname))
            {
                TabPage tpg = new TabPage(tabname);
                usercontrol.Dock = DockStyle.Fill;
                tpg.Controls.Add(usercontrol);
                tabcontrol.Controls.Add(tpg);
                tabcontrol.SelectedTab = tpg;
                usercontrol.Show();

            }
        }

        /// <summary>
        /// 判断TabPage是否已经打开
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsUse(string name)
        {
            foreach (TabPage item in tabcontrol.TabPages)
            {
                if (item.Text == name)
                {
                    tabcontrol.SelectedTab = item;//已经打开，则设置为当前选项卡
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region 关闭页签

        public void CloseAllTab()
        {
            tabcontrol.TabPages.Clear();
        }

        /// <summary>
        /// 绘制关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void currentform_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Rectangle myTabRect = tabcontrol.GetTabRect(e.Index);

                //先添加TabPage属性   
                e.Graphics.DrawString(tabcontrol.TabPages[e.Index].Text, currentform.Font, SystemBrushes.ControlText, myTabRect.X + 2, myTabRect.Y + 2);

                //再画一个矩形框
                using (Pen p = new Pen(Color.White))
                {
                    myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 5), 2);
                    myTabRect.Width = CLOSE_SIZE;
                    myTabRect.Height = CLOSE_SIZE;
                    e.Graphics.DrawRectangle(p, myTabRect);
                }

                //填充矩形框
                Color recColor = e.State == DrawItemState.Selected ? Color.White : Color.White;
                using (Brush b = new SolidBrush(recColor))
                {
                    e.Graphics.FillRectangle(b, myTabRect);
                }

                //画关闭符号
                using (Pen objpen = new Pen(Color.Black))
                {
                    //使用图片
                    Bitmap bt = new Bitmap(image);
                    Point p5 = new Point(myTabRect.X, 4);
                    e.Graphics.DrawImage(bt, p5);
                }
                e.Graphics.Dispose();
            }
            catch (Exception)
            { }
        }


        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void currentform_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X, y = e.Y;
                //计算关闭区域   
                Rectangle myTabRect = tabcontrol.GetTabRect(tabcontrol.SelectedIndex);

                myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 5), 2);
                myTabRect.Width = CLOSE_SIZE;
                myTabRect.Height = CLOSE_SIZE;

                //如果鼠标在区域内就关闭选项卡   
                bool isClose = x > myTabRect.X && x < myTabRect.Right && y > myTabRect.Y && y < myTabRect.Bottom;
                if (isClose == true)
                {
                    tabcontrol.TabPages.Remove(tabcontrol.SelectedTab);
                }
            }
        }

        #endregion

    }
}
