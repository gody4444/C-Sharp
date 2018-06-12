using Model;
using Common;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Data;

namespace XMLDAL
{
    public class TableXML : BaseXML, ITableDAL
    {

        /// <summary>
        /// 查询数据库相关列表
        /// </summary>
        /// <param name="sqlwhere"></param>
        /// <returns></returns>
        public DataTable GetDBList(List<WhereModel> wherelist)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SelName", typeof(string));
            dt.Columns.Add("SelType", typeof(string));

            var XmlDoc = LoadXML();
            var xelem = XElement.Parse(XmlDoc.SelectSingleNode("//TableList").OuterXml);
            var query = (from o in xelem.Descendants("Table")
                         where GetSqlwhere(o, wherelist)
                         select new
                         {
                             SelName = o.Attribute("Tablename").Value,
                             SelType = "Table"
                         }).AsEnumerable();
            foreach (var item in query)
            {
                DataRow dr = dt.NewRow();
                dr["SelName"] = item.SelName;
                dr["SelType"] = item.SelType;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 拼接条件
        /// </summary>
        /// <param name="left">字段名称</param>
        /// <param name="right">字段值</param>
        /// <returns></returns>
        private Boolean GetSqlwhere(XElement ele, List<WhereModel> list)
        {
            foreach (WhereModel item in list)
            {

                switch (item.symbol)
                {
                    case "IN":
                        if (!(item.right.Replace("'","").Split(',')).Contains(ele.Attribute(item.left).Value))
                        {
                            return false;
                        }
                        break;
                    case "LIKE":
                        if (!(ele.Attribute(item.left).Value).Contains(item.right))
                        {
                            return false;
                        }
                        break;
                    case "=":
                        if (ele.Attribute(item.left).Value != item.right)
                        {
                            return false;
                        }
                        break;
                }


            }

            return true;
        }



        /// <summary>
        /// 查询表并转化为表的模型
        /// </summary>
        /// <param name="sqlwhere"></param>
        /// <returns></returns>
        public List<TableCompareModel> GetTableListForModel(List<WhereModel> list)
        {
            var XmlDoc = LoadXML();
            var xelem = XElement.Parse(XmlDoc.SelectSingleNode("//TableList").OuterXml);
            List<TableCompareModel> tblist = (from o in xelem.Descendants("Table")
                                              where GetSqlwhere(o, list)
                                              select new TableCompareModel
                                              {
                                                  Tablename = o.Attribute("Tablename").Value,
                                                  Isequal = o.Attribute("Isequal").Value
                                              }).ToList();
            return tblist;
        }


        /// <summary>
        /// 生成单个表的完整模型
        /// </summary>
        /// <param name="tbname"></param>
        /// <returns></returns>
        public TableCompareModel CreateTableModel(string tbname)
        {
            var XmlDoc = LoadXML();
            var xelem = XElement.Parse(XmlDoc.SelectSingleNode("//TableList//Table[@Tablename='" + tbname + "']").OuterXml);
            List<ColumnModel> collist = (from o in xelem.Descendants("Column")
                                         select new ColumnModel
                                              {
                                                  Columnname = o.Attribute("Columnname").Value,
                                                  Isequal = o.Attribute("Isequal").Value,
                                                  Ispropertyequal = o.Attribute("Ispropertyequal").Value,
                                                  Source = (from d in o.Descendants("Source")//源
                                                            select new ColumnCompareModel
                                                            {
                                                                Type = d.Attribute("Type").Value,
                                                                Isnull = d.Attribute("Isnull").Value,
                                                                Default = d.Attribute("Default").Value
                                                            }).ToList()[0],
                                                  Target = (from d in o.Descendants("Target")//目标
                                                            select new ColumnCompareModel
                                                            {
                                                                Type = d.Attribute("Type").Value,
                                                                Isnull = d.Attribute("Isnull").Value,
                                                                Default = d.Attribute("Default").Value
                                                            }).ToList()[0]
                                              }).ToList();

            TableCompareModel tbmodel = new TableCompareModel();
            tbmodel.Tablename = tbname;
            tbmodel.Isequal = "10";
            tbmodel.Column = collist;
            return tbmodel;
        }



    }
}
