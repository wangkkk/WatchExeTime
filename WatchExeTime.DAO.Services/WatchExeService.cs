using Dapper;
using System.Collections.ObjectModel;
using System.Linq;
using WatchExeTime.DAO.IServices;
using WatchExeTime.DAO.Model;

namespace WatchExeTime.DAO.Service
{
    /// <summary>
    /// 监视程序操作数据库实现类
    /// </summary>
    public class WatchExeService: IWatchExeService
    {
        public ObservableCollection<WatchExeModel> SelectData()
        {
            var queryResult =new ObservableCollection<WatchExeModel>(SQLiteHelper.CreateConnection().Query<WatchExeModel>("select * from WatchExe"));
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
