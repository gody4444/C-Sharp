using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 表比对模型
    /// </summary>
    public class TableCompareModel
    {

        /// <summary>
        /// 初始化
        /// </summary>
        public TableCompareModel()
        {
            Column = new List<ColumnModel>();
        }

        /// <summary>
        /// 表名
        /// </summary>
        public string Tablename
        {
            get;
            set;
        }

        /// <summary>
        /// 表是否存在
        /// </summary>
        public string Isequal
        {
            get;
            set;
        }

        /// <summary>
        /// 表中列
        /// </summary>
        public List<ColumnModel> Column
        {
            get;
            set;
        }

    }


    /// <summary>
    /// 列比对模型
    /// </summary>
    public class ColumnModel
    {

        /// <summary>
        /// 初始化
        /// </summary>
        public ColumnModel()
        {
            Source = new ColumnCompareModel();
            Target = new ColumnCompareModel();
        }

        /// <summary>
        /// 列名
        /// </summary>
        public string Columnname
        {
            get;
            set;
        }

        /// <summary>
        /// 列是否存在
        /// </summary>
        public string Isequal
        {
            get;
            set;
        }

        /// <summary>
        /// 列中属性是否相同
        /// </summary>
        public string Ispropertyequal
        {
            get;
            set;
        }

        /// <summary>
        /// 源表中列
        /// </summary>
        public ColumnCompareModel Source
        {
            get;
            set;
        }

        /// <summary>
        /// 目标表中列
        /// </summary>
        public ColumnCompareModel Target
        {
            get;
            set;
        }
    }


    /// <summary>
    /// 列中属性差异模型
    /// </summary>
    public class ColumnCompareModel
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Type
        {
            get;
            set;
        }

        /// <summary>
        /// 是否必填
        /// </summary>
        public string Isnull
        {
            get;
            set;
        }

        /// <summary>
        /// 默认值
        /// </summary>
        public string Default
        {
            get;
            set;
        }

        #region 方法

        /// <summary>
        /// 克隆值
        /// </summary>
        /// <param name="other"></param>
        public void CloneIt(ColumnCompareModel other)
        {
            this.Type = other.Type;
            this.Isnull = other.Isnull;
            this.Default = other.Default;
        }

        /// <summary>
        /// 将值置为空
        /// </summary>
        public void Clear()
        {
            this.Type = "";
            this.Isnull = "";
            this.Default = "";
        }

        #endregion

    }

}
