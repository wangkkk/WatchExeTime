using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace WatchExeTime.DAO
{
    public static class SQLiteHelper
    {

        /// <summary>
        /// 
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return "Data Source="+Environment.CurrentDirectory+ConfigurationManager.ConnectionStrings["SQLiteconnectionString"].ToString();

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="pName"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>

        public static DbParameter CreateParameter(DbCommand cmd, String pName, Object value, System.Data.DbType type)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = pName;
            p.Value = (value == null ? DBNull.Value : value);
            p.DbType = type;
            return p;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DbCommand CreateCommand()
        {
            return new System.Data.SqlClient.SqlCommand();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DbConnection CreateConnection()
        {
            DbConnection conn = new SQLiteConnection();
            conn.ConnectionString = ConnectionString;
            return conn;
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        public static List<T> Select<T>(string sql, Object paramObject = null)
        {
            DbConnection conn = null;
            try
            {
                conn = CreateConnection();
                conn.Open();
                var list = Dapper.SqlMapper.Query<T>(conn, sql, paramObject);
                return list.ToList<T>();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        public static List<dynamic> Select(string sql, Object paramObject = null)
        {
            DbConnection conn = null;
            try
            {
                conn = CreateConnection();
                conn.Open();
                var list = Dapper.SqlMapper.Query(conn, sql, paramObject);
                return list.ToList<dynamic>();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        public static dynamic Single(string sql, Object paramObject = null)
        {
            DbConnection conn = null;
            try
            {
                conn = CreateConnection();
                conn.Open();
                var list = Dapper.SqlMapper.Query<dynamic>(conn, sql, paramObject)?.FirstOrDefault();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        public static T Single<T>(string sql, Object paramObject = null)
        {

            DbConnection conn = null;
            try
            {
                conn = CreateConnection();
                conn.Open();
                var list = Dapper.SqlMapper.Query<T>(conn, sql, paramObject).FirstOrDefault();
                return list;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return default(T);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        /// <summary>
        /// 获取一行一列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        public static T ExecuteScalar<T>(string sql, Object paramObject = null)
        {

            DbConnection conn = null;
            try
            {
                conn = CreateConnection();
                conn.Open();
                T t = Dapper.SqlMapper.ExecuteScalar<T>(conn, sql, paramObject);
                return t;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return default(T);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        /// <summary>
        /// 返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        public static int Execute(string sql, Object paramObject = null)
        {
            DbConnection conn = null;
            try
            {
                conn = CreateConnection();
                conn.Open();
                int count = Dapper.SqlMapper.Execute(conn, sql, paramObject);
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        /// <summary>
        /// ExecuteNonQueryReturnId
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        public static int ExecuteNonQueryReturnId(string sql, Object paramObject = null)
        {
            DbConnection conn = null;
            try
            {
                conn = CreateConnection();
                conn.Open();
                int count = Convert.ToInt32(Dapper.SqlMapper.ExecuteScalar(conn, sql, paramObject));
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        /// <summary>
        /// 自行维护事务和连接
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="paramObject"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static int ExecuteTran(DbConnection conn, string sql, Object paramObject, DbTransaction transaction)
        {
            int count = Dapper.SqlMapper.Execute(conn, sql, paramObject, transaction);
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="paramObject"></param>
        /// <returns></returns>
        public static List<T> ExecuteStoredProcedure<T>(string sql, Object paramObject)
        {

            DbConnection conn = null;
            try
            {
                conn = CreateConnection();
                conn.Open();
                var list = Dapper.SqlMapper.Query<T>(conn, sql, paramObject, null, true, null, System.Data.CommandType.StoredProcedure);
                return list.ToList<T>();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

    }
}
