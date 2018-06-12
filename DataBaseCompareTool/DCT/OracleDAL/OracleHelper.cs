//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;
using System.Data.OracleClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using System.Xml;

namespace DCT.DAL
{
    public class OracleHelper
    {

        /// <summary>
        /// 当前的数据库链接
        /// </summary>
        private string ConnectionString;

        /// <summary>
        /// 超时时间
        /// </summary>
        public int TimeOut { get; set; }

        public OracleHelper(string connstr = "")
        {
            ConnectionString = connstr;
        }

        #region 执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string sqlString)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();
                using (OracleCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sqlString;
                    if (TimeOut > 0)
                    {
                        cmd.CommandTimeout = TimeOut;
                    }
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回IDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <returns>IDataReader</returns>
        public IDataReader ExecuteReader(string sqlString)
        {
            OracleConnection connection = new OracleConnection(ConnectionString);
            try
            {
                connection.Open();
                OracleCommand cmd = connection.CreateCommand();
                cmd.CommandText = sqlString;
                if (TimeOut > 0)
                {
                    cmd.CommandTimeout = TimeOut;
                }
                IDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (OracleException ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                throw ex;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string sqlString)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                try
                {
                    DataSet ds = new DataSet();
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    OracleDataAdapter command = new OracleDataAdapter(sqlString, connection);
                    command.Fill(ds, "ds");
                    return ds;
                }
                catch (OracleException ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

        }

        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataTable QueryDt(string sqlString)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                try
                {
                    DataSet ds = new DataSet();
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    OracleDataAdapter command = new OracleDataAdapter(sqlString, connection);
                    command.Fill(ds, "ds");
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (OracleException ex)
                {
                    throw ex;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

        }



        #endregion


        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string sqlString, params IDataParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回IDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <returns>IDataReader</returns>
        public IDataReader ExecuteReader(string sqlString, params IDataParameter[] cmdParms)
        {
            OracleConnection connection = new OracleConnection(ConnectionString);
            OracleCommand cmd = new OracleCommand();
            try
            {
                PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                IDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (OracleException ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                throw ex;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string sqlString, params IDataParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                DataSet ds = new DataSet();
                using (OracleCommand cmd = new OracleCommand())
                {
                    PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                    using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    return ds;
                }
            }
        }


        private void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, string cmdText, IDataParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            if (TimeOut > 0)
            {
                cmd.CommandTimeout = TimeOut;
            }
            cmd.CommandText = cmdText;
            if (trans == null)
            {
                conn.BeginTransaction();
            }
            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        #endregion


        #region 存储过程操作

        /// <summary>
        /// 执行存储过程 返回IDataReader ( 注意：调用该方法后，一定要对IDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>IDataReader</returns>
        public IDataReader RunProcedure(string storedProcName, List<IDataParameter> parameters)
        {
            OracleConnection connection = new OracleConnection(ConnectionString);
            IDataReader returnReader;
            try
            {
                OracleCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                command.Parameters.Clear();
                return returnReader;
            }
            catch (OracleException ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                throw ex;
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedure(string storedProcName, List<IDataParameter> parameters, string tableName)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    using (OracleDataAdapter sqlDA = new OracleDataAdapter())
                    {
                        sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                        sqlDA.Fill(dataSet, tableName);
                        sqlDA.SelectCommand.Parameters.Clear();
                        return dataSet;
                    }
                }
                catch (OracleException ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns></returns>
        public int RunProcedure(string storedProcName, List<IDataParameter> parameters, Action<List<IDataParameter>> callback)
        {

            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                using (OracleCommand command = BuildQueryCommand(connection, storedProcName, parameters))
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }
                        int result = command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        callback(parameters);
                        return result;
                    }
                    catch (OracleException ex)
                    {
                        connection.Close();
                        command.Parameters.Clear();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 构建 OracleCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>OracleCommand</returns>
        private OracleCommand BuildQueryCommand(OracleConnection connection, string storedProcName, List<IDataParameter> parameters)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            OracleCommand command = connection.CreateCommand();
            try
            {
                //command.BindByName = true;
                command.CommandText = storedProcName;
                command.CommandType = CommandType.StoredProcedure;
                if (TimeOut > 0)
                {
                    command.CommandTimeout = TimeOut;
                }
                foreach (OracleParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                return command;
            }
            catch (OracleException ex)
            {
                connection.Close();
                command.Parameters.Clear();
                throw ex;
            }
        }

        #endregion


        #region  执行事务

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="sqlStringList">多条SQL语句</param>		
        public int ExecuteSqlTran(List<String> sqlStringList)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();
                using (OracleTransaction trans = connection.BeginTransaction())
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        int count = 0;
                        foreach (string sqlString in sqlStringList)
                        {
                            if (!string.IsNullOrEmpty(sqlString) && sqlString.Trim().Trim('\n').Trim('\r').Length > 0)
                            {
                                cmd.CommandText = sqlString;
                                count += cmd.ExecuteNonQuery();
                            }
                        }
                        trans.Commit();
                        return count;
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLKeyParamList">SQL语句的哈希表（key为sql语句，value是该语句的IDataParameter[]）</param>
        public int ExecuteSqlTran(List<KeyValuePair<string, IDataParameter[]>> SQLKeyParamList)
        {
            int result = ExecuteSqlTran(SQLKeyParamList, CommandType.Text);
            return result;
        }
        public int ExecuteSqlTran(List<KeyValuePair<string, IDataParameter[]>> SQLKeyParamList, CommandType cmdType)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();
                using (OracleTransaction trans = connection.BeginTransaction())
                {
                    using (OracleCommand cmd = connection.CreateCommand())
                    {
                        int count = 0;
                        foreach (KeyValuePair<string, IDataParameter[]> item in SQLKeyParamList)
                        {
                            try
                            {
                                PrepareCommand(cmd, connection, trans, item.Key, item.Value);
                                cmd.CommandType = cmdType;
                                count += cmd.ExecuteNonQuery();
                                Check(cmd.Parameters);
                                cmd.Parameters.Clear();
                            }
                            catch (OracleException ex)
                            {
                                throw ex;
                            }
                        }
                        trans.Commit();
                        return count;
                    }
                }
            }
        }
        private void Check(OracleParameterCollection parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                int? ret = null;
                string msg = null;
                foreach (OracleParameter item in parameters)
                {
                    if (item.ParameterName == "APPCODE_OUT")
                    {
                        ret = Convert.ToInt32(item.Value);
                    }
                    else if (item.ParameterName == "DATABUFFER_OUT")
                    {
                        msg = item.Value.ToString().Trim();
                    }
                    if (ret != null && msg != null)
                    {
                        break;
                    }
                }
                if (ret != 0 && msg.Length > 0)
                {
                    throw new Exception(msg);
                }
            }
        }

        #endregion



    }
}
