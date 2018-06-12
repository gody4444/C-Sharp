using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{


    public interface ITableDAL
    {

        /// <summary>
        /// 查询数据库相关列表
        /// </summary>
        /// <param name="sqlwhere"></param>
        /// <returns></returns>
        DataTable GetDBList(List<WhereModel> list);

        /// <summary>
        /// 查询表并转化为表的模型
        /// </summary>
        /// <param name="sqlwhere"></param>
        /// <returns></returns>
        List<TableCompareModel> GetTableListForModel(List<WhereModel> list);


        /// <summary>
        /// 生成单个表的完整模型
        /// </summary>
        /// <param name="tbname"></param>
        /// <returns></returns>
        TableCompareModel CreateTableModel(string tbname);


    }


}
