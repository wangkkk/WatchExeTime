using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WatchExeTime.DAO.IServices;
using WatchExeTime.DAO.Model;

namespace WatchExeTime.DAO.Services
{
    public class m
    {
       
    }
    public class WatchTimeService:IWatchTimeService
    {
        public int InsertWathExeTime(WatchTimeModel model)
        {
            
            string insert = "Insert into WatchTime(StartTime,ExeID)values(@StartTime,@ExeID); SELECT last_insert_rowid();";
            var resultExecute = (long)SQLiteHelper.CreateConnection().ExecuteScalar(insert, model);
            return Convert.ToInt32(resultExecute);
        }

        public List<WatchTimeModel> SelectData(string where="")
        {
            string strSql = "select * from WatchTime";
            if (!string.IsNullOrEmpty(where))
                strSql += $" where {where}";
            var queryResult = SQLiteHelper.CreateConnection().Query<WatchTimeModel>(strSql)?.ToList();
            return queryResult;
        }
        /// <summary>
        /// 更新程序监视表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateWathExeTime(WatchTimeModel model)
        {
            string strsql = "UPDATE WatchTime SET  EndTime=@EndTime WHERE TimeID =@TimeID";
            var resultExecute = SQLiteHelper.CreateConnection().Execute(strsql, model);
            return resultExecute;
        }
    }
}
