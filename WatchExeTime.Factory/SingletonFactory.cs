using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchExeTime.Factory
{
    public class SingletonFactory
    {
        private string confSqlType = ConfigurationManager.AppSettings["SqlType"];
        private BaseFactory baseFactory = null;
        private static SingletonFactory instance;
        private static readonly object obj = new object();
        private SingletonFactory() { }

        public static SingletonFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonFactory();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="sqlType"></param>
        public void CreateJDBC(string sqlType)
        {
            if (!string.IsNullOrEmpty(sqlType))
            {
                confSqlType = sqlType;
            }
            if (confSqlType == "SQLite")
            {
                baseFactory = new SQLiteServiceFactory();
            }
        }

        public BaseFactory GetBaseFactory()
        {
            return baseFactory;
        }

        /// <summary>
        /// 切换数据库
        /// </summary>
        /// <param name="sqlType"></param>
        public void ChangeJDBC(string sqlType)
        {
            CreateJDBC(sqlType);
        }
    }
}
