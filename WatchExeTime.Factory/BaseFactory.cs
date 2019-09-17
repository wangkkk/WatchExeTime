using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchExeTime.DAO.IServices;

namespace WatchExeTime.Factory
{
    public abstract class BaseFactory
    {

        public abstract IWatchExeService CreateWatchExeService();
        /// <summary>
        /// 监视时间
        /// </summary>
        /// <returns></returns>
        public abstract IWatchTimeService CreateWatchTimeService();
        /// <summary>
        /// 监视类型
        /// </summary>
        /// <returns></returns>
        public abstract IWatchTypeService CreateWatchTypeService();
        /// <summary>
        /// 修炼阶段配置
        /// </summary>
        /// <returns></returns>
        public abstract IProgramStageConfigService CreateProgramStageConfigService();

    }
}
