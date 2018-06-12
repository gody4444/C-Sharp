using Common;
using DCT.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OracleDAL
{
    public class BaseDAL
    {

        protected OracleHelper helper;

        /// <summary>
        /// 创建数据库访问实例
        /// </summary>
        /// <param name="dbtype"></param>
        public void Init(string connstr)
        {
            helper = new OracleHelper(connstr);
        }



    }
}
