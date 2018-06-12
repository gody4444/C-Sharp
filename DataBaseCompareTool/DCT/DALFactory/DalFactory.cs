using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OracleDAL;
using IDAL;
using System.Reflection;
using Common;

namespace DALFactory
{
    public class DalFactory
    {
        /// <summary>
        /// 反射获取类（同时实例化数据库访问类）
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="className"></param>
        /// <param name="dbtype"></param>
        /// <returns></returns>
        public static object CreateInstance(string assembly, string className, CommonConfig.DataType dbtype, string connstr = "")
        {
            className = string.Format("{0}.{1}", assembly, className);
            Assembly ass = Assembly.Load(assembly);
            object objclass = ass.CreateInstance(className, true);
            //调用方法(实例化OracleHelper)
            MethodInfo methodinfo = ass.GetType(className).GetMethod("Init");//得到Init方法
            methodinfo.Invoke(objclass, new object[] { connstr });//调用BaseDAL类的Init方法，给参数，得到结果
            return objclass;
        }


        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="dbtype"></param>
        /// <returns></returns>
        public static ITableDAL CreateTableDAL(CommonConfig.DataType dbtype, string connstr = "")
        {
            if (dbtype == CommonConfig.DataType.DB)
            {
                string assembly = "OracleDAL";
                object obj = CreateInstance(assembly, "TableDAL", dbtype, connstr);
                return obj as ITableDAL;
            }
            else if (dbtype == CommonConfig.DataType.XML)
            {
                string assembly = "XMLDAL";
                object obj = CreateInstance(assembly, "TableXML", dbtype, connstr);
                return obj as ITableDAL;
            }
            return null;
        }




    }
}
