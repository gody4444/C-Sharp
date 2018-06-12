using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    /// <summary>
    /// 设置展示模型
    /// </summary>
    public class DataBaseModel
    {

        /// <summary>
        /// 主键
        /// </summary>
        public string ID
        {
            get;
            set;
        }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string NAME
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库
        /// </summary>
        public string DB
        {
            get;
            set;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string USER
        {
            get;
            set;
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string PWD
        {
            get;
            set;
        }

        /// <summary>
        /// 是否缓存
        /// </summary>
        public string ISCACHED
        {
            get;
            set;
        }

        private string _path;
        /// <summary>
        /// 缓存文件路径
        /// </summary>
        public string PATH
        {
            get
            {
                return CommonConfig.basecachepath + this._path;
            }
            set
            {
                this._path = value;
            }
        }
    }


    #region 设置模型

    /// <summary>
    /// 设置比对数据来源模型
    /// </summary>
    public class DBSettingCompare
    {

        public DBSettingCompare()
        {
            Source = new DBSetting();
            Target = new DBSetting();
            Definition = new DBSetting();
        }

        /// <summary>
        /// 源数据来源
        /// </summary>
        public DBSetting Source
        {
            get;
            set;
        }

        /// <summary>
        /// 目标数据来源
        /// </summary>
        public DBSetting Target
        {
            get;
            set;
        }

        /// <summary>
        /// 自定义数据来源
        /// </summary>
        public DBSetting Definition
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 设置数据来源模型
    /// </summary>
    public class DBSetting
    {
        public DBSetting()
        {
            DBAccount = new DataBaseAccount();
        }

        /// <summary>
        /// 数据来源类别
        /// </summary>
        public CommonConfig.DataType Flag
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库
        /// </summary>
        public DataBaseAccount DBAccount
        {
            get;
            set;
        }

        //private string _xmlpath;
        /// <summary>
        /// xml文件路径（缓存）
        /// </summary>
        public string XMLPath
        {
            get;
            set;
            //get
            //{
            //    return CommonConfig.basecachepath + this._xmlpath;
            //}
            //set
            //{
            //    this._xmlpath = value;
            //}
        }

    }

    /// <summary>
    /// 数据库登陆模型
    /// </summary>
    public class DataBaseAccount
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DB
        {
            get;
            set;
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string User
        {
            get;
            set;
        }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd
        {
            get;
            set;
        }

        /// <summary>
        /// 数据库连接串拼接
        /// </summary>
        /// <returns></returns>
        public string GetConnStr()
        {
            return string.Format("DATA SOURCE={0};USER ID={2};PASSWORD={1}", this.DB, this.User, this.Pwd);
        }
    }

    #endregion

}

