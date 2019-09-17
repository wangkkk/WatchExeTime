using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchExeTime.DAO;
using WatchExeTime.Factory;

namespace WatchExeTime.BLL.Service
{
    public class WatchTypeBLLService:Singleton<WatchTypeBLLService>
    {
        public int Update(WatchTypeModel model)
        {
            return SingletonFactory.Instance.GetBaseFactory().CreateWatchTypeService().Update(model);
        }

        public WatchTypeModel SelectData()
        {
            return SingletonFactory.Instance.GetBaseFactory().CreateWatchTypeService().SelectData();
        }
    }
}
