using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchExeTime.DAO.Model;

namespace WatchExeTime.DAO.IServices
{
    /// <summary>
    /// 监视程序接口
    /// </summary>
    public interface IWatchExeService
    {
        List<WatchExeModel> SelectData();
        int UpdateWathExeTime(WatchExeModel model);
    }
}
