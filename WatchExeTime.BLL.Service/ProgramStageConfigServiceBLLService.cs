using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchExeTime.DAO;
using WatchExeTime.Factory;

namespace WatchExeTime.BLL.Service
{
    public class ProgramStageConfigServiceBLLService:Singleton<ProgramStageConfigServiceBLLService>
    {
        public int DeleteData(int StageConfigID)
        {
         return SingletonFactory.Instance.GetBaseFactory().CreateProgramStageConfigService().DeleteData(StageConfigID);
        }

        public int InsertData(ProgramStageConfigModel model)
        {
            return SingletonFactory.Instance.GetBaseFactory().CreateProgramStageConfigService().InsertData(model);
        }

        public ObservableCollection<ProgramStageConfigModel> SelectData(string Where = "")
        {
            return SingletonFactory.Instance.GetBaseFactory().CreateProgramStageConfigService().SelectData(Where);
        }

        public int UpdataData(ProgramStageConfigModel model)
        {
            return SingletonFactory.Instance.GetBaseFactory().CreateProgramStageConfigService().UpdataData(model);
        }
        /// <summary>
        /// 得到目前的阶段
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public string GetCurrentState()
        {
           double allDays=WatchTimeBLLService.Instance.GetAllTime(1);
            ObservableCollection<ProgramStageConfigModel> models = SelectData();
            if (models == null || models.Count == 0) return string.Empty;
           return models.Where(m => m.MiniTime <= allDays && m.MaxTime >allDays).FirstOrDefault()?.StageConfigName;
        }
    }
}
