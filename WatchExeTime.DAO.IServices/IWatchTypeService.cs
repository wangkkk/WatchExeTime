using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchExeTime.DAO.IServices
{
    public interface IWatchTypeService
    {
        int Update(WatchTypeModel model);
        WatchTypeModel SelectData();
    }
}
