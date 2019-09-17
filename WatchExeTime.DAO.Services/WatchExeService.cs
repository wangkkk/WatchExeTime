using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WatchExeTime.DAO.IServices;
using WatchExeTime.DAO.Model;

namespace WatchExeTime.DAO.Service
{
    /// <summary>
    /// 监视程序操作数据库实现类
    /// </summary>
    public class WatchExeService: IWatchExeService
    {
        public List<WatchExeModel> SelectData()
        {
            var queryResult = SQLiteHelper.CreateConnection().Query<WatchExeModel>("select * from WatchExe")?.ToList();
            return queryResult;
        }
        /// <summary>
        /// 更新程序监视表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateWathExeTime(WatchExeModel model)
        {
            string strsql = "UPDATE WatchExe SET  ExeName=@ExeName,ExeTitleName=@ExeTitleName,IsUsing=@IsUsing," +
                           "ParentExeID=@ParentExeID,ExePathName=@ExePathName WHERE ExeID =@ExeID";
            var resultExecute = SQLiteHelper.CreateConnection().Execute(strsql, model);
            return resultExecute;
        }

    }
}
