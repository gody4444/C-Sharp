using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{

    public class ConnectModel
    {
        /// <summary>
        /// 左过滤条件
        /// </summary>
        public List<ConnectWhereModel> where
        {
            get;
            set;
        }

        /// <summary>
        /// 连接符
        /// </summary>
        public string Connect
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 组合过滤条件
    /// </summary>
    public class ConnectWhereModel
    {
        /// <summary>
        /// 左过滤条件
        /// </summary>
        public WhereModel leftwhere
        {
            get;
            set;
        }

        /// <summary>
        /// 连接符
        /// </summary>
        public string Connect
        {
            get;
            set;
        }

        /// <summary>
        /// 右过滤条件
        /// </summary>
        public WhereModel rightwhere
        {
            get;
            set;
        }


    }

    /// <summary>
    /// 单个过滤条件
    /// </summary>
    public class WhereModel
    {
        /// <summary>
        /// 左边
        /// </summary>
        public string left
        {
            get;
            set;
        }

        /// <summary>
        /// 符号
        /// </summary>
        public string symbol
        {
            get;
            set;
        }

        /// <summary>
        /// 右边
        /// </summary>
        public string right
        {
            get;
            set;
        }

        //public string DBGet()
        //{
        //    switch (this.symbol)
        //    {
        //        case "IN":
        //            return string.Format("{0} IN ({1})", left, right);
        //        case "LIKE":
        //            return string.Format("{0} LIKE '%{1}%'", left, right);
        //        case "=":
        //            return string.Format("{0} {1} '{2}'", left,symbol, right);
        //        case ">":
        //            return string.Format("{0} {1} {2}", Convert.ToInt32(this.left), symbol, Convert.ToInt32(this.right));
        //        case ">=":
        //            return string.Format("{0} {1} {2}", Convert.ToInt32(this.left), symbol, Convert.ToInt32(this.right));
        //        case "<":
        //           return string.Format("{0} {1} {2}", Convert.ToInt32(this.left), symbol, Convert.ToInt32(this.right));
        //        case "<=":
        //           return string.Format("{0} {1} {2}", Convert.ToInt32(this.left), symbol, Convert.ToInt32(this.right));
        //        default:
        //            return string.Format("{0} {1} '{2}'", left,symbol, right);
        //    }
        //}

        //public Boolean XMLGet()
        //{
        //    switch (this.symbol)
        //    {
        //        case "IN":
        //            return (this.right.Split(',')).Contains(left);
        //        case "LIKE":
        //            return left.Contains(right);
        //        case "=":
        //            return left == right;
        //        case ">":
        //            return Convert.ToInt32(this.left) > Convert.ToInt32(this.right);
        //        case ">=":
        //            return Convert.ToInt32(this.left) >= Convert.ToInt32(this.right);
        //        case "<":
        //            return Convert.ToInt32(this.left) < Convert.ToInt32(this.right);
        //        case "<=":
        //            return Convert.ToInt32(this.left) <= Convert.ToInt32(this.right);
        //    }
        //    return false;
        //}

    }

}
