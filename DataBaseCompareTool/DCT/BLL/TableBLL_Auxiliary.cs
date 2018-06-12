using Common;
using DALFactory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace BLL
{

    /// <summary>
    /// 辅助Table比对类
    /// </summary>
    public partial class TableBLL
    {

        /// <summary>
        /// 自定义数据源
        /// </summary>
        protected ITableDAL idefdal;

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="setting"></param>
        public void IninDefinitionDAL(DBSetting setting)
        {
            if (setting.Flag == CommonConfig.DataType.DB)
            {
                idefdal = DalFactory.CreateTableDAL(CommonConfig.DataType.DB, setting.DBAccount.GetConnStr());
            }
            else
            {
                idefdal = DalFactory.CreateTableDAL(CommonConfig.DataType.XML, setting.XMLPath);
            }
        }

        /// <summary>
        /// 获取比对文件路径
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetXMLPath(string fileName)
        {
            return CommonConfig.basepath + fileName;
        }


        /// <summary>
        /// 查询数据库相关列表
        /// </summary>
        /// <param name="sqlwhere"></param>
        /// <returns></returns>
        public DataTable GetDBList(List<WhereModel> list, PgsBar pgs)
        {
            DataTable dt = new DataTable();
            pgs.PgsScoroll(50, "正在查询。。。");
            dt = idefdal.GetDBList(list);
            pgs.SetMax("查询完成");
            return dt;
        }


        #region 生成SQL语句

        /// <summary>
        /// 根据比对结果生成sql语句
        /// </summary>
        /// <param name="tbmodel"></param>
        /// <param name="sourcesql"></param>
        /// <param name="targetsql"></param>
        public void GetSqlbyColumn(TableCompareModel tbmodel, ref List<string> sourcesql, ref List<string> targetsql)
        {
            sourcesql = new List<string>();
            targetsql = new List<string>();
            string Def = "";
            StringBuilder sb = new StringBuilder();
            foreach (ColumnModel item in tbmodel.Column)
            {
                sb = new StringBuilder();
                if (item.Isequal == "11")//字段不相同
                {
                    Def = string.IsNullOrEmpty(item.Target.Default) ? " " : " DEFAULT " + item.Target.Default;
                    if (item.Target.Isnull == "not null")
                    {
                        sb.Append("ALTER TABLE ").Append(tbmodel.Tablename).Append(" MODIFY (").Append(item.Columnname).Append(" ");
                        sb.Append(item.Target.Type).Append(Def).Append(" ").Append(item.Target.Isnull).Append(")");
                    }
                    else
                    {
                        sb.Append("ALTER TABLE ").Append(tbmodel.Tablename).Append(" MODIFY (").Append(item.Columnname).Append(" ");
                        sb.Append(item.Target.Type).Append(Def);
                        if (item.Source.Isnull == "not null")
                        {
                            sb.Append(" null");
                        }
                        sb.Append(")");
                    }
                    sourcesql.Add(sb.ToString());
                    
                    sb = new StringBuilder();
                    Def = string.IsNullOrEmpty(item.Source.Default) ? " " : " DEFAULT " + item.Source.Default;
                    if (item.Source.Isnull == "not null")
                    {
                        sb.Append("ALTER TABLE ").Append(tbmodel.Tablename).Append(" MODIFY (").Append(item.Columnname).Append(" ");
                        sb.Append(item.Source.Type).Append(Def).Append(" ").Append(item.Source.Isnull).Append(")");
                    }
                    else
                    {
                        sb.Append("ALTER TABLE ").Append(tbmodel.Tablename).Append(" MODIFY (").Append(item.Columnname).Append(" ");
                        sb.Append(item.Source.Type).Append(Def);
                        if (item.Target.Isnull == "not null")
                        {
                            sb.Append(" null");
                        }
                        sb.Append(")");
                    }
                    targetsql.Add(sb.ToString());
                }
                else if (item.Isequal == "10")//目标数据库字段不存在
                {
                    Def = string.IsNullOrEmpty(item.Source.Default) ? " " : " DEFAULT " + item.Source.Default;
                    if (item.Source.Isnull == "not null")
                    {
                        sb.Append("ALTER TABLE ").Append(tbmodel.Tablename).Append(" ADD (").Append(item.Columnname).Append(" ");
                        sb.Append(item.Source.Type).Append(Def).Append(" ").Append(item.Source.Isnull).Append(")");
                    }
                    else
                    {
                        sb.Append("ALTER TABLE ").Append(tbmodel.Tablename).Append(" ADD (").Append(item.Columnname).Append(" ");
                        sb.Append(item.Source.Type).Append(Def).Append(")");
                    }
                    targetsql.Add(sb.ToString());
                }
                else if (item.Isequal == "01")//源数据库字段不存在
                {
                    Def = string.IsNullOrEmpty(item.Target.Default) ? " " : " DEFAULT " + item.Target.Default;
                    if (item.Target.Isnull == "not null")
                    {
                        sb.Append("ALTER TABLE ").Append(tbmodel.Tablename).Append(" ADD (").Append(item.Columnname).Append(" ");
                        sb.Append(item.Target.Type).Append(Def).Append(" ").Append(item.Target.Isnull).Append(")");
                    }
                    else
                    {
                        sb.Append("ALTER TABLE ").Append(tbmodel.Tablename).Append(" ADD (").Append(item.Columnname).Append(" ");
                        sb.Append(item.Target.Type).Append(Def).Append(")");
                    }
                    sourcesql.Add(sb.ToString());
                }
            }
        }

        #endregion

        #region 生成xml

        /// <summary>
        /// 生成比对后的xml文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tablelist"></param>
        /// <returns></returns>
        public Boolean CreateXmlFile(List<TableCompareModel> tablelist, string filepath, out string msg)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                //创建类型声明节点    
                XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
                xmlDoc.AppendChild(node);
                //创建根节点    
                XmlNode root = xmlDoc.CreateElement("TableList");
                xmlDoc.AppendChild(root);

                foreach (TableCompareModel table in tablelist)//表
                {
                    XmlElement tableelement = xmlDoc.CreateElement("Table");
                    PropertyInfo[] properties = table.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                    foreach (PropertyInfo pro in properties)//列
                    {
                        if (pro.Name == "Column")
                        {
                            foreach (ColumnModel colmodel in table.Column)
                            {
                                PropertyInfo[] colprolist = colmodel.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                                XmlElement colelement = xmlDoc.CreateElement("Column");
                                foreach (PropertyInfo colpro in colprolist)//列中属性
                                {
                                    if (colpro.Name == "Source")
                                    {
                                        PropertyInfo[] souprolist = colmodel.Source.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                                        XmlElement souelement = xmlDoc.CreateElement(colpro.Name);
                                        foreach (PropertyInfo soupro in souprolist)
                                        {
                                            souelement.SetAttribute(soupro.Name, soupro.GetValue(colmodel.Source, null).ToString());
                                        }
                                        colelement.AppendChild(souelement);
                                    }
                                    else if (colpro.Name == "Target")
                                    {
                                        PropertyInfo[] tarprolist = colmodel.Target.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                                        XmlElement tarelement = xmlDoc.CreateElement(colpro.Name);
                                        foreach (PropertyInfo tarpro in tarprolist)
                                        {
                                            tarelement.SetAttribute(tarpro.Name, tarpro.GetValue(colmodel.Target, null).ToString());
                                        }
                                        colelement.AppendChild(tarelement);
                                    }
                                    else
                                    {
                                        colelement.SetAttribute(colpro.Name, colpro.GetValue(colmodel, null).ToString());
                                    }

                                }
                                tableelement.AppendChild(colelement);//列节点加入到表节点
                            }

                        }
                        else
                        {
                            tableelement.SetAttribute(pro.Name, pro.GetValue(table, null).ToString());
                        }

                    }
                    xmlDoc.DocumentElement.AppendChild(tableelement);
                }
                xmlDoc.Save(filepath);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
            msg = "生成成功";
            return true;
        }

        #endregion

        #region 缓存数据库

        /// <summary>
        /// 缓存数据库
        /// </summary>
        /// <param name="pgs"></param>
        /// <param name="FileName"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public Boolean CacheTable(PgsBar pgs, string FileName, out string msg)
        {
            try
            {
                List<TableCompareModel> tblist = new List<TableCompareModel>();
                TableCompareModel tbmodel = new TableCompareModel();
                DataTable dt = new DataTable();
                string retmsg = "缓存失败";

                dt = idefdal.GetDBList(new List<WhereModel>());
                pgs.PgsScoroll(10, "源数据读取完成");
                if (dt != null)
                {
                    pgs.SetPgsMax(dt.Rows.Count + 20);
                    foreach (DataRow dr in dt.Rows)//表
                    {
                        string tbname = dr["SelName"].ToString();
                        tbmodel = new TableCompareModel();
                        tbmodel = idefdal.CreateTableModel(tbname);
                        tblist.Add(tbmodel);
                        //Thread.Sleep(500);
                        pgs.PgsScoroll(1, tbname + "缓存完成");
                    }
                }
                pgs.PgsScoroll(0, "生成缓存文件。。。");
                if (CreateXmlFile(tblist, CommonConfig.basecachepath + FileName, out retmsg))
                {
                    pgs.PgsScoroll(10, "数据缓存完成");
                }
                else
                {
                    pgs.PgsScoroll(10, "生成缓存文件失败");
                }

                msg = "数据缓存完成";
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                pgs.PgsScoroll(0, ex.Message);
                return false;
            }

        }

        #endregion

        #region 展示xml

        /// <summary>
        /// 获取比对后的相关类型的表
        /// </summary>
        /// <param name="equal"></param>
        /// <returns></returns>
        public List<TableCompareModel> GetRes_TableList(CommonConfig.EqualValue equal, string tempfilename)
        {
            try
            {
                var XmlDoc = new XmlDocument();
                XmlDoc.Load(GetXMLPath(tempfilename));
                var xelem = XElement.Parse(XmlDoc.InnerXml);
                List<TableCompareModel> reslist = (from o in xelem.Descendants("Table")
                                                   where ((string)o.Attribute("Isequal").Value == CommonConfig.GetEqualValue(equal))
                                                   select new TableCompareModel
                                                   {
                                                       Tablename = o.Attribute("Tablename").Value,
                                                       Isequal = o.Attribute("Isequal").Value
                                                   }).ToList();
                return reslist;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 缺失表展示
        /// </summary>
        /// <returns></returns>
        public List<ShowTableCompare> GetShowTable(string tempfilename)
        {
            try
            {
                var XmlDoc = new XmlDocument();
                XmlDoc.Load(GetXMLPath(tempfilename));
                var xelem = XElement.Parse(XmlDoc.InnerXml);
                List<ShowTableCompare> reslist = (from o in xelem.Descendants("Table")
                                                  where ((string)o.Attribute("Isequal").Value != "11")
                                                  select new ShowTableCompare
                                                  {
                                                      SourceTable = o.Attribute("Isequal").Value == "10" ? o.Attribute("Tablename").Value : "缺失",
                                                      TargetTable = o.Attribute("Isequal").Value == "01" ? o.Attribute("Tablename").Value : "缺失",
                                                  }).ToList();
                return reslist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 获取比对后数据库中表的字段信息
        /// </summary>
        /// <param name="tbname"></param>
        /// <returns></returns>
        public List<ShowColumnCompare> GetSingleTable(string tbname, CommonConfig.EqualValue tp, string tempfilename)
        {
            try
            {
                string columnurl = string.Empty;
                if (tp == CommonConfig.EqualValue.Source)
                {
                    columnurl = "//TableList//Table[@Tablename='" + tbname + "']//Column[@Columnname='{0}']//Source";
                }
                else if (tp == CommonConfig.EqualValue.Target)
                {
                    columnurl = "//TableList//Table[@Tablename='" + tbname + "']//Column[@Columnname='{0}']//Target";
                }
                var XmlDoc = new XmlDocument();
                XmlDoc.Load(GetXMLPath(tempfilename));
                var xelem = XElement.Parse(XmlDoc.SelectSingleNode("//TableList//Table[@Tablename='" + tbname + "']").OuterXml);
                List<ShowColumnCompare> restable = (from o in xelem.Descendants("Column")
                                                    //where ((string)o.Attribute("equal").Value == "10" || (string)o.Attribute("equal").Value == "11")
                                                    select new ShowColumnCompare
                                                    {
                                                        Columnname = o.Attribute("Columnname").Value,
                                                        Isequal = o.Attribute("Isequal").Value,
                                                        Ispropertyequal = o.Attribute("Ispropertyequal").Value,
                                                        Type = XmlDoc.SelectSingleNode(string.Format(columnurl, o.Attribute("Columnname").Value)).Attributes["Type"].Value,
                                                        Isnull = XmlDoc.SelectSingleNode(string.Format(columnurl, o.Attribute("Columnname").Value)).Attributes["Isnull"].Value,
                                                        Default = XmlDoc.SelectSingleNode(string.Format(columnurl, o.Attribute("Columnname").Value)).Attributes["Default"].Value

                                                    }).ToList();
                return restable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取某个表比对后的相关字段信息
        /// </summary>
        /// <param name="tbname"></param>
        /// <param name="tempfilename"></param>
        /// <returns></returns>
        public TableCompareModel GetSingleTable(string tbname, string tempfilename)
        {
            List<TableCompareModel> tblist = GetTable(tbname, tempfilename);
            if (tblist != null && tblist.Count > 0)
            {
                return tblist[0];
            }
            return null;
        }

        /// <summary>
        /// 获取比对后数据库中表的字段信息
        /// </summary>
        /// <param name="tbname"></param>
        /// <returns></returns>
        public List<TableCompareModel> GetTable(string tbname, string tempfilename)
        {
            try
            {
                List<TableCompareModel> tblist = new List<TableCompareModel>();
                bool flag = false;
                if (!string.IsNullOrEmpty(tbname))
                {
                    flag = true;
                }
                var XmlDoc = new XmlDocument();
                XmlDoc.Load(GetXMLPath(tempfilename));
                var xelem = XElement.Parse(XmlDoc.SelectSingleNode("//TableList").OuterXml);
                tblist = (from o in xelem.Descendants("Table")
                          where (flag ? ((string)o.Attribute("Tablename").Value == tbname) : (1 == 1))
                          select new TableCompareModel//表
                          {
                              Tablename = o.Attribute("Tablename").Value,
                              Isequal = o.Attribute("Isequal").Value,
                              Column = (from c in o.Descendants("Column")
                                        select new ColumnModel//字段
                                        {
                                            Columnname = c.Attribute("Columnname").Value,
                                            Isequal = c.Attribute("Isequal").Value,
                                            Ispropertyequal = c.Attribute("Ispropertyequal").Value,
                                            Source = (from d in c.Descendants("Source")//源
                                                      select new ColumnCompareModel
                                                      {
                                                          Type = d.Attribute("Type").Value,
                                                          Isnull = d.Attribute("Isnull").Value,
                                                          Default = d.Attribute("Default").Value
                                                      }).ToList()[0],
                                            Target = (from d in c.Descendants("Target")//目标
                                                      select new ColumnCompareModel
                                                      {
                                                          Type = d.Attribute("Type").Value,
                                                          Isnull = d.Attribute("Isnull").Value,
                                                          Default = d.Attribute("Default").Value
                                                      }).ToList()[0]
                                        }).ToList()
                          }).ToList();
                return tblist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }

}
