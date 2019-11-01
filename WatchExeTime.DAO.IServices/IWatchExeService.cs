using System.Collections.ObjectModel;
using WatchExeTime.DAO.Model;

namespace WatchExeTime.DAO.IServices
{
    /// <summary>
    /// 监视程序接口
    /// </summary>
    public interface IWatchExeService
    {
        ObservableCollection<WatchExeModel> SelectData();
        int UpdateWathExeTime(WatchExeModel model);
    }
}
