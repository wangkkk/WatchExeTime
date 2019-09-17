using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchExeTime.DAO.IServices
{
    public interface IWatchTimeService
    {
        List<WatchTimeModel> SelectData(string where = "");
        int UpdateWathExeTime(WatchTimeModel model);
        int InsertWathExeTime(WatchTimeModel model);
    }
}
