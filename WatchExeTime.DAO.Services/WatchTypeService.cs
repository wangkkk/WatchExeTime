using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WatchExeTime.DAO.IServices;

namespace WatchExeTime.DAO.Services
{
    public class WatchTypeService:IWatchTypeService
    {
        public int Update(WatchTypeModel model)
        {
            string strsql = "UPDATE WatchType SET  OneDayType=@OneDayType,IntervalType=@IntervalType WHERE TypeID =@TypeID";
            var resultExecute = SQLiteHelper.CreateConnection().Execute(strsql, model);
            return resultExecute;
        }

        public WatchTypeModel SelectData()
        {
            var queryResult = SQLiteHelper.CreateConnection().Query<WatchTypeModel>("select * from WatchType")?.ToList()?.FirstOrDefault();
            return queryResult;
        }
    }
}
