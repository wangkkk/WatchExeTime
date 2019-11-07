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
            int result = 0;
            if (model?.IsUsing == 1)
            {
                result = SingletonFactory.Instance.GetBaseFactory().CreateWatchExeService().UpdateAllUsing();
            }
            result = SingletonFactory.Instance.GetBaseFactory().CreateWatchExeService().UpdateWathExeTime(model);
            return result;
        }
    }
}
