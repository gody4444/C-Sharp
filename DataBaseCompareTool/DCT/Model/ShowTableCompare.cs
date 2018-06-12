using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    /// <summary>
    /// 缺失表展示模型
    /// </summary>
    public class ShowTableCompare
    {
        /// <summary>
        /// 源表
        /// </summary>
        public string SourceTable
        {
            get;
            set;
        }

        /// <summary>
        /// 目标表
        /// </summary>
        public string TargetTable
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 缺失列展示模型
    /// </summary>
    public class ShowColumnCompare
    {

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
    }

}
