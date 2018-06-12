using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class CommonConfig
    {


        #region XML文件

        /// <summary>
        /// 基础路径
        /// </summary>
        public static string basepath = System.AppDomain.CurrentDomain.BaseDirectory + "CompareResult\\";

        /// <summary>
        /// 缓存基础路径
        /// </summary>
        public static string basecachepath = System.AppDomain.CurrentDomain.BaseDirectory + "CacheFile\\";

        /// <summary>
        /// 所有表比对结果后保存的xml名称
        /// </summary>
        public const string CompareAllTable = "AllTable.xml";

        public static string CompareAllTablePath
        {
            get
            {
                return basepath + CompareAllTable;
            }
        }

        /// <summary>
        /// 部分表比对结果后保存的xml名称
        /// </summary>
        public const string ComparePartTable = "PartTable.xml";

        public static string ComparePartTablePath
        {
            get
            {
                return basepath + ComparePartTable;
            }
        }

        /// <summary>
        /// 缓存目标数据库表的xml名称
        /// </summary>
        public const string Setting = "Setting.xml";

        public static string SettingPath
        {
            get
            {
                return basepath + Setting;
            }
        }

        #endregion

        /// <summary>
        /// 数据库类别
        /// </summary>
        public enum DataType
        {
            DB = 1, //数据库
            XML = 2 //XML
        }


        /// <summary>
        /// 数据库类别
        /// </summary>
        public enum DataBaseType
        {
            /// <summary>
            /// 源数据库
            /// </summary>
            DBSource = 1,

            /// <summary>
            /// 目标数据库
            /// </summary>
            DBTarget = 2,

            /// <summary>
            /// XML源数据库
            /// </summary>
            XMLSource = 3,

            /// <summary>
            /// XML目标数据库
            /// </summary>
            XMLTarget = 4,

            /// <summary>
            /// 自定义数据来源
            /// </summary>
            Definition = 5
        }

        public enum EqualValue
        {
            /// <summary>
            /// 源存在
            /// </summary>
            Source = 1,

            /// <summary>
            /// 目标存在
            /// </summary>
            Target = 2,

            /// <summary>
            /// 都存在
            /// </summary>
            Column = 3
        }

        /// <summary>
        /// 表缺失字典：10表示源存在；01表示目标存在；11表示都存在
        /// </summary>
        /// <param name="equal"></param>
        /// <returns></returns>
        public static string GetEqualValue(EqualValue equal)
        {
            switch (equal)
            {
                case EqualValue.Source: return "10";
                case EqualValue.Target: return "01";
                case EqualValue.Column: return "11";
                default: return "11";
            }
        }

        public static DataType GetDataType(DataBaseType dbtype)
        {
            switch (dbtype)
            {
                case DataBaseType.DBSource: return DataType.DB;
                case DataBaseType.DBTarget: return DataType.DB;
                case DataBaseType.XMLSource: return DataType.XML;
                case DataBaseType.XMLTarget: return DataType.XML;
                default: return DataType.DB;
            }
        }

    }
}
