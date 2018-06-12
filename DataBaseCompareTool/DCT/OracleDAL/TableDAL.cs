using Model;
using Common;
using IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OracleDAL
{

    /// <summary>
    /// 将数据转换为模型
    /// </summary>
    public partial class TableDAL : BaseDAL, ITableDAL
    {

        /// <summary>
        /// 查询数据库相关列表
        /// </summary>
        /// <param name="sqlwhere"></param>
        /// <returns></returns>
        public DataTable GetDBList(List<WhereModel> list)
        {
            try
            {
                string sqlwhere = GetSqlwhere(list);
                string sql = string.Format(@"SELECT TABLE_NAME SelName,'Table' SelType FROM USER_TABLES WHERE 1=1 {0}", sqlwhere);
                DataTable dt = helper.QueryDt(sql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询列信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetColumnList(string sqlwhere = "")
        {
            try
            {
                //DATA_LENGTH CHAR_COL_DECL_LENGTH
                string sql = string.Format(@"SELECT A.TABLE_NAME,A.COLUMN_NAME,A.DATA_TYPE,A.CHAR_COL_DECL_LENGTH DATA_LENGTH,A.DATA_PRECISION,A.DATA_SCALE,A.DATA_DEFAULT,A.NULLABLE 
                            FROM USER_TAB_COLUMNS A WHERE 1=1 {0}", sqlwhere);
                DataTable dt = helper.QueryDt(sql);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询表并转化为表的模型
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<TableCompareModel> GetTableListForModel(List<WhereModel> list)
        {
            try
            {
                List<TableCompareModel> tblist = new List<TableCompareModel>();
                TableCompareModel tbmodel = new TableCompareModel();
                DataTable dt = GetDBList(list);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tbmodel = new TableCompareModel();
                        tbmodel.Tablename = dr["SelName"].ToString();
                        tblist.Add(tbmodel);
                    }
                }

                return tblist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 生成单个表的完整模型
        /// </summary>
        /// <param name="tbname"></param>
        /// <returns></returns>
        public TableCompareModel CreateTableModel(string tbname)
        {
            try
            {
                TableCompareModel tbmodel = new TableCompareModel();
                tbmodel.Tablename = tbname;//表
                tbmodel.Isequal = "10";
                DataTable dt = GetColumnList(string.Format(" AND TABLE_NAME = '{0}'", tbname));
                if (dt != null)//列
                {
                    ColumnModel colmodel = new ColumnModel();
                    foreach (DataRow dr in dt.Rows)//列中属性
                    {
                        colmodel = new ColumnModel();
                        colmodel.Columnname = dr["COLUMN_NAME"].ToString();
                        colmodel.Isequal = "10";
                        colmodel.Ispropertyequal = "000";
                        colmodel.Source.Type = SplicingType(dr);
                        colmodel.Source.Isnull = dr["NULLABLE"].ToString() == "N" ? "not null" : "null";
                        colmodel.Source.Default = dr["DATA_DEFAULT"].ToString().TrimEnd('\n');
                        colmodel.Target.Clear();
                        tbmodel.Column.Add(colmodel);
                    }
                }
                return tbmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 拼接条件
        /// </summary>
        /// <param name="left">字段名称</param>
        /// <param name="right">字段值</param>
        /// <returns></returns>
        private string GetSqlwhere(List<WhereModel> list)
        {
            string left = string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (WhereModel item in list)
            {
                switch (item.left)
                {
                    case "Tablename":
                        left = "TABLE_NAME";
                        break;
                    default:
                        left = item.left;
                        break;
                }

                switch (item.symbol)
                {
                    case "IN":
                        sb.Append(" AND ").Append(left).Append(" IN (").Append(item.right).Append(")");
                        break;
                    case "LIKE":
                        sb.Append(" AND ").Append(left).Append(" LIKE '").Append(item.right).Append("%'");
                        break;
                    case "=":
                        sb.Append(" AND ").Append(left).Append(" = '").Append(item.right).Append("'");
                        break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 字段类型拼接
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private string SplicingType(DataRow dr)
        {
            string type = string.Empty;
            string coltype = dr["DATA_TYPE"].ToString();
            switch (coltype)
            {
                case "NVARCHAR2":
                case "VARCHAR2":
                case "CHAR":
                    type = string.Format("{0}({1})", coltype, dr["DATA_LENGTH"].ToString());
                    break;
                case "TIMESTAMP(6)":

                    break;
                case "NUMBER":
                    if (string.IsNullOrEmpty(dr["DATA_PRECISION"].ToString()))
                    {
                        type = string.Format("{0}", coltype);
                    }
                    else
                    {
                        type = string.Format("{0}({1},{2})", coltype, dr["DATA_PRECISION"].ToString(), dr["DATA_SCALE"].ToString());
                    }
                    break;
                case "DATE":
                case "BLOB":
                    type = string.Format("{0}", coltype);
                    break;
            }

            return type;
        }



    }

}
