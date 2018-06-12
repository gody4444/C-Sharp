using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using WF.Common;

namespace WF.Setting
{



    public partial class SetDatabase : Form
    {

        /// <summary>
        /// 打开窗体事件委托
        /// </summary>
        public delegate void OpenDelegate();

        //声明委托 和 事件 
        public event OpenDelegate ClearEvent;

        /// <summary>
        /// 需要显示的文件后缀
        /// </summary>
        string[] ShowExtension = new string[] { ".xml" };

        public SetDatabase()
        {
            InitializeComponent();
            #region 下拉列表框
            cbSource.Items.Add(new ListItem("源数据库", ((int)CommonConfig.DataBaseType.DBSource).ToString()));
            cbSource.Items.Add(new ListItem("源缓存文件", ((int)CommonConfig.DataBaseType.XMLSource).ToString()));

            cbTarget.Items.Add(new ListItem("目标数据库", ((int)CommonConfig.DataBaseType.DBTarget).ToString()));
            cbTarget.Items.Add(new ListItem("目标缓存文件", ((int)CommonConfig.DataBaseType.XMLTarget).ToString())); ;
            #endregion
        }


        /// <summary>
        /// 加载设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDatabase_Load(object sender, EventArgs e)
        {
            var XmlDoc = new XmlDocument();
            XmlDoc.Load(CommonConfig.SettingPath);
            SourceDB.Text = XmlDoc.SelectSingleNode("Settings//DataBase//SourceDB").InnerText;
            SourceUser.Text = XmlDoc.SelectSingleNode("Settings//DataBase//SourceUser").InnerText;
            SourcePassword.Text = XmlDoc.SelectSingleNode("Settings//DataBase//SourcePassword").InnerText;
            TargetDB.Text = XmlDoc.SelectSingleNode("Settings//DataBase//TargetDB").InnerText;
            TargetUser.Text = XmlDoc.SelectSingleNode("Settings//DataBase//TargetUser").InnerText;
            TargetPassword.Text = XmlDoc.SelectSingleNode("Settings//DataBase//TargetPassword").InnerText;

            lblSourceCache.Text = XmlDoc.SelectSingleNode("Settings//XMLFile//SourceXML").InnerText;
            lblTargetCache.Text = XmlDoc.SelectSingleNode("Settings//XMLFile//TargetXML").InnerText;

            //tbSourceFile.Text = XmlDoc.SelectSingleNode("Settings//XMLFile//SourceXML").InnerText;
            //tbTargetFile.Text = XmlDoc.SelectSingleNode("Settings//XMLFile//TargetXML").InnerText;

            string val = XmlDoc.SelectSingleNode("Settings//Choice//Source").InnerText;
            cbSource.SelectedItem = ListItem.FindByValue(cbSource, val);
            val = XmlDoc.SelectSingleNode("Settings//Choice//Target").InnerText;
            cbTarget.SelectedItem = ListItem.FindByValue(cbTarget, val);
        }

        #region 事件

        /// <summary>
        /// 提交设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var XmlDoc = new XmlDocument();

                //保存源数据库缓存文件
                if (!string.IsNullOrEmpty(tbSourceFile.Text))
                {
                    XmlDoc.Load(tbSourceFile.Text);
                    XmlDoc.Save(CommonConfig.CacheSourceTablePath);
                }

                //保存目标数据库缓存文件
                if (!string.IsNullOrEmpty(tbTargetFile.Text))
                {
                    XmlDoc.Load(tbTargetFile.Text);
                    XmlDoc.Save(CommonConfig.CacheTargetTablePath);
                }

                //保存配置文件
                XmlDoc.Load(CommonConfig.SettingPath);
                XmlDoc.SelectSingleNode("Settings//DataBase//SourceDB").InnerText = SourceDB.Text;
                XmlDoc.SelectSingleNode("Settings//DataBase//SourceUser").InnerText = SourceUser.Text;
                XmlDoc.SelectSingleNode("Settings//DataBase//SourcePassword").InnerText = SourcePassword.Text;
                XmlDoc.SelectSingleNode("Settings//DataBase//TargetDB").InnerText = TargetDB.Text;
                XmlDoc.SelectSingleNode("Settings//DataBase//TargetUser").InnerText = TargetUser.Text;
                XmlDoc.SelectSingleNode("Settings//DataBase//TargetPassword").InnerText = TargetPassword.Text;

                XmlDoc.SelectSingleNode("Settings//XMLFile//SourceXML").InnerText = CommonConfig.CacheSourceTablePath;
                XmlDoc.SelectSingleNode("Settings//XMLFile//TargetXML").InnerText = CommonConfig.CacheTargetTablePath;

                ListItem li = (ListItem)cbSource.SelectedItem;
                XmlDoc.SelectSingleNode("Settings//Choice//Source").InnerText = li.Value;
                li = (ListItem)cbTarget.SelectedItem;
                XmlDoc.SelectSingleNode("Settings//Choice//Target").InnerText = li.Value;

                XmlDoc.Save(CommonConfig.SettingPath);
                ClearEvent();

                MessageBox.Show("设置成功", "提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK);
            }

        }


        private void btnChange_Click(object sender, EventArgs e)
        {
            string DB = SourceDB.Text;
            string User = SourceUser.Text;
            string Password = SourcePassword.Text;

            SourceDB.Text = TargetDB.Text;
            SourceUser.Text = TargetUser.Text;
            SourcePassword.Text = TargetPassword.Text;
            TargetDB.Text = DB;
            TargetUser.Text = User;
            TargetPassword.Text = Password;
        }

        /// <summary>
        /// 选择XML文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoiceSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (ChoiceFile(fileDialog))
            {
                tbSourceFile.Text = fileDialog.FileName;
            }
        }

        /// <summary>
        /// 选择XML文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoiceTarget_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (ChoiceFile(fileDialog))
            {
                tbTargetFile.Text = fileDialog.FileName;
            }
        }

        #endregion

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="filecontrol"></param>
        /// <returns></returns>
        private Boolean ChoiceFile(OpenFileDialog filecontrol)
        {

            if (filecontrol.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(filecontrol.FileName);//获取用户选择文件的后缀名
                if (!((IList)ShowExtension).Contains(extension))
                {
                    MessageBox.Show("目前仅能上传xml文件！");
                }
                else
                {
                    FileInfo fileInfo = new FileInfo(filecontrol.FileName);//获取用户选择的文件，并判断文件大小不能超过20K，fileInfo.Length是以字节为单位的
                    if (fileInfo.Length > 2 * 1024 * 1000)
                    {
                        MessageBox.Show("上传xml文件不能大于2M");
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }


    }
}
