using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchExeTime.DAO.IServices;
using WatchExeTime.DAO.Service;
using WatchExeTime.DAO.Services;

namespace WatchExeTime.Factory
{
    public class SQLiteServiceFactory : BaseFactory
    {
        public override IWatchExeService CreateWatchExeService()
        {
            return new WatchExeService();
        }

        public override IWatchTimeService CreateWatchTimeService()
        {
            return new WatchTimeService();
        }

        public override IWatchTypeService CreateWatchTypeService()
        {
            return new WatchTypeService();
        }

        public override IProgramStageConfigService CreateProgramStageConfigService()
        {
            return new ProgramStageConfigService();
        }
    }
}
