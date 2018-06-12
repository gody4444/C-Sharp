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
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace BLL
{

    /// <summary>
    /// Table比对类
    /// </summary>
    public partial class TableBLL : BaseBLL
    {


        #region


        /// <summary>
        /// 源
        /// </summary>
        protected ITableDAL isourcedal;

        /// <summary>
        /// 目标
        /// </summary>
        protected ITableDAL itargetdal;

        public SettingColumnCompare scc = new SettingColumnCompare();



        #endregion


        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="dbtype"></param>
        public void InitDAL(DBSettingCompare setting)
        {
            IninSourceDAL(setting.Source);
            IninTargetDAL(setting.Target);
            IninDefinitionDAL(setting.Definition);
        }

        /// <summary>
        /// 实例化源
        /// </summary>
        /// <param name="setting"></param>
        public void IninSourceDAL(DBSetting setting)
        {
            if (setting.Flag == CommonConfig.DataType.DB)
            {
                isourcedal = DalFactory.CreateTableDAL(CommonConfig.DataType.DB, setting.DBAccount.GetConnStr());
            }
            else
            {
                isourcedal = DalFactory.CreateTableDAL(CommonConfig.DataType.XML, setting.XMLPath);
            }
        }

        /// <summary>
        /// 实例化目标
        /// </summary>
        /// <param name="setting"></param>
        public void IninTargetDAL(DBSetting setting)
        {
            if (setting.Flag == CommonConfig.DataType.DB)
            {
                itargetdal = DalFactory.CreateTableDAL(CommonConfig.DataType.DB, setting.DBAccount.GetConnStr());
            }
            else
            {
                itargetdal = DalFactory.CreateTableDAL(CommonConfig.DataType.XML, setting.XMLPath);
            }
        }




        #region 表比对核心方法

        /// <summary>
        /// 比对流程
        /// </summary>
        public string CompareTable(List<WhereModel> list, string tempfilename, PgsBar pgs)
        {
            try
            {
                string retmsg;
                List<TableCompareModel> source = isourcedal.GetTableListForModel(list);
                pgs.PgsScoroll(10, "源数据读取完成");
                List<TableCompareModel> target = itargetdal.GetTableListForModel(list);
                pgs.PgsScoroll(10, "目标数据读取完成");
                TableCompareList tblist = CompareTableList(source, target);
                pgs.PgsScoroll(10, "缺失表比对完成");
                pgs.SetPgsMax(tblist.tablelist.Count + 41);
                foreach (TableCompareModel model in tblist.tablelist)
                {
                    CompareColumn(model);
                    pgs.PgsScoroll(1, model.Tablename + "比对完成");
                }

                //完全匹配的表去掉
                tblist.tablelist.RemoveAll(x => x.Column.Count == 0);

                pgs.PgsScoroll(1, "正在生成比对结果");
                tblist.tablelist.AddRange(tblist.notablelist);
                if (CreateXmlFile(tblist.tablelist, GetXMLPath(tempfilename), out retmsg))
                {
                    pgs.SetMax("比对完成");
                }
                else
                {
                    pgs.PgsScoroll(0, retmsg);
                }
                return retmsg;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        /// <summary>
        /// 表比对
        /// </summary>
        /// <param name="sourcelist"></param>
        /// <param name="targetlist"></param>
        /// <returns></returns>
        public TableCompareList CompareTableList(List<TableCompareModel> sourcelist, List<TableCompareModel> targetlist)
        {

            TableCompareList tblist = new TableCompareList();

            List<TableCompareModel> outlist = new List<TableCompareModel>();
            List<TableCompareModel> inlist = new List<TableCompareModel>();

            #region 特殊情况(只有一个数据库存在数据)
            if (sourcelist.Count == 0 && targetlist.Count == 0)
            {
                return null;
            }
            else if (sourcelist.Count != 0 && targetlist.Count == 0)
            {
                tblist.Isequal = "10";
                foreach (TableCompareModel tcmodel in sourcelist)
                {
                    tcmodel.Isequal = "10";
                }
                tblist.notablelist = sourcelist;
                return tblist;
            }
            else if (sourcelist.Count == 0 && targetlist.Count != 0)
            {
                tblist.Isequal = "01";
                foreach (TableCompareModel tcmodel in targetlist)
                {
                    tcmodel.Isequal = "01";
                }
                tblist.notablelist = targetlist;
                return tblist;
            }
            #endregion

            tblist.Isequal = "01";
            for (int i = 0; i < 2; i++)//两张表要相互
            {
                #region 表互换比较
                //第一次比较是为了找出源数据库中存在的表而目标数据库中不存在的表，同时对都有的表进行字段的匹配
                //第二次比较是为了找出目标数据库中存在的表而源数据库中不存在的表
                if (i == 0)
                {
                    outlist = sourcelist;
                    inlist = targetlist;
                }
                else
                {
                    outlist = targetlist;
                    inlist = sourcelist;
                }
                #endregion

                bool flag = false;
                foreach (TableCompareModel outmodel in outlist)//比较表名是否匹配
                {
                    flag = false;
                    string tbname = outmodel.Tablename;
                    foreach (TableCompareModel inmodel in inlist)
                    {
                        if (tbname == inmodel.Tablename)//匹配
                        {
                            if (i == 0)
                            {
                                inmodel.Isequal = "11";
                                tblist.tablelist.Add(inmodel);
                            }
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)//表名不匹配
                    {
                        outmodel.Isequal = i == 0 ? "10" : "01";
                        tblist.notablelist.Add(outmodel);
                    }
                }
            }

            return tblist;
        }


        /// <summary>
        /// 表中字段比对
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TableCompareModel CompareColumn(TableCompareModel model)
        {
            model.Isequal = "11";
            TableCompareModel sourcemodel = isourcedal.CreateTableModel(model.Tablename);
            TableCompareModel targetmodel = itargetdal.CreateTableModel(model.Tablename);

            TableCompareModel outmodel;
            TableCompareModel inmodel;

            ColumnModel column = new ColumnModel();
            bool flag = false;

            for (int i = 0; i < 2; i++)
            {
                #region 列互换比较
                if (i == 0)
                {
                    outmodel = sourcemodel;
                    inmodel = targetmodel;
                }
                else
                {
                    outmodel = targetmodel;
                    inmodel = sourcemodel;
                }
                #endregion

                foreach (ColumnModel outcol in outmodel.Column)
                {
                    string colname = outcol.Columnname;
                    flag = false;
                    foreach (ColumnModel incol in inmodel.Column)
                    {
                        #region 列存在
                        if (colname == incol.Columnname)
                        {
                            if (i == 0)
                            {
                                string propertyequal = CompareSingleColumn(incol.Source, outcol.Source);
                                if (propertyequal != "111")//字段类型、是否为空、默认值不匹配
                                {
                                    column = new ColumnModel();
                                    column.Columnname = colname;
                                    column.Isequal = "11";
                                    column.Ispropertyequal = propertyequal;

                                    column.Source.CloneIt(outcol.Source);
                                    column.Target.CloneIt(incol.Source);

                                    model.Column.Add(column);
                                }
                            }
                            flag = true;
                            break;
                        }
                        #endregion
                    }

                    #region 列不存在
                    //列不存在，并且允许比对时
                    if (!flag && scc.ColumnAdd)
                    {
                        column = new ColumnModel();
                        column.Columnname = colname;
                        column.Isequal = i == 0 ? "10" : "01";
                        column.Ispropertyequal = "000";
                        if (i == 0)
                        {
                            column.Source.CloneIt(outcol.Source);
                            column.Target.Clear();
                        }
                        else
                        {
                            column.Source.Clear();
                            column.Target.CloneIt(outcol.Source);
                        }
                        model.Column.Add(column);
                    }
                    #endregion

                }

            }
            return model;
        }

        /// <summary>
        /// 单列比较
        /// 不比对的属性默认匹配，并且属性置空
        /// </summary>
        /// <param name="OneCol"></param>
        /// <param name="OhterCol"></param>
        /// <returns></returns>
        private string CompareSingleColumn(ColumnCompareModel OneCol, ColumnCompareModel OhterCol)
        {
            //scc值为false不比对，不比对时默认匹配
            //匹配为1，不匹配为0
            string colequal = "";
            if (scc.Type)
            {
                colequal += (OneCol.Type == OhterCol.Type ? "1" : "0");
            }
            else
            {
                OneCol.Type = "";
                OhterCol.Type = "";
                colequal += "1";
            }

            if (scc.Isnull)
            {
                colequal += (OneCol.Isnull == OhterCol.Isnull ? "1" : "0");
            }
            else
            {
                OneCol.Isnull = "";
                OhterCol.Isnull = "";
                colequal += "1";
            }

            if (scc.Default)
            {
                colequal += (OneCol.Default == OhterCol.Default ? "1" : "0");
            }
            else
            {
                OneCol.Default = "";
                OhterCol.Default = "";
                colequal += "1";
            }

            return colequal;
        }

        #endregion



    }

    /// <summary>
    /// 表比对结果模板
    /// </summary>
    public class TableCompareList
    {

        public TableCompareList()
        {
            notablelist = new List<TableCompareModel>();
            tablelist = new List<TableCompareModel>();
        }

        /// <summary>
        /// 数据库是否存在
        /// </summary>
        public string Isequal
        {
            get;
            set;
        }

        /// <summary>
        /// 表缺失
        /// </summary>
        public List<TableCompareModel> notablelist
        {
            get;
            set;
        }

        /// <summary>
        /// 表中字段不匹配
        /// </summary>
        public List<TableCompareModel> tablelist
        {
            get;
            set;
        }

    }


    /// <summary>
    /// 控制是否比对模型:True比对，false不必对
    /// </summary>
    public class SettingColumnCompare
    {
        /// <summary>
        /// 默认比对
        /// </summary>
        public SettingColumnCompare()
        {
            this.Type = true;
            this.Isnull = true;
            this.Default = true;
            this.ColumnAdd = true;
        }

        public void SetFalse()
        {
            this.Type = false;
            this.Isnull = false;
            this.Default = false;
            this.ColumnAdd = false;
        }

        /// <summary>
        /// 类型
        /// </summary>
        public Boolean Type
        {
            get;
            set;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        public Boolean Isnull
        {
            get;
            set;
        }

        /// <summary>
        /// 默认值
        /// </summary>
        public Boolean Default
        {
            get;
            set;
        }

        /// <summary>
        /// 列是否存在
        /// </summary>
        public Boolean ColumnAdd
        {
            get;
            set;
        }
    }

}
