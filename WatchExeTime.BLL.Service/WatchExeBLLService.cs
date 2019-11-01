using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchExeTime.DAO.Model;
using WatchExeTime.Factory;

namespace WatchExeTime.BLL.Service
{
    public class WatchExeBLLService: Singleton<WatchExeBLLService>
    {
        public ObservableCollection<WatchExeModel> SelectData()
        {
            return SingletonFactory.Instance.GetBaseFactory().CreateWatchExeService().SelectData();
        }

        public int UpdateWathExeTime(WatchExeModel model)
        {
            return SingletonFactory.Instance.GetBaseFactory().CreateWatchExeService().UpdateWathExeTime(model);
        }
    }
}
