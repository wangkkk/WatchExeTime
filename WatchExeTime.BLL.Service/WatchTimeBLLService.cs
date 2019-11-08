using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchExeTime.DAO;
using WatchExeTime.DAO.Model;
using WatchExeTime.Factory;

namespace WatchExeTime.BLL.Service
{
    public class WatchTimeBLLService:Singleton<WatchTimeBLLService>
    {
        public List<WatchTimeModel> SelectData(string where = "")
        {
            return SingletonFactory.Instance.GetBaseFactory().CreateWatchTimeService().SelectData(where);
        }

        public int UpdateWathExeTime(WatchTimeModel model)
        {
            return SingletonFactory.Instance.GetBaseFactory().CreateWatchTimeService().UpdateWathExeTime(model);
        }

        public int InsertWathExeTime(WatchTimeModel model)
        {
            return SingletonFactory.Instance.GetBaseFactory().CreateWatchTimeService().InsertWathExeTime(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exeID"></param>
        /// <param name="type">type默认返回天数 其它对应秒数</param>
        /// <returns></returns>
        public double GetAllTime(int exeID,int type=0)
        {
            double totalTime = 0;
            List<WatchTimeModel>  ModelList=SingletonFactory.Instance.GetBaseFactory().CreateWatchTimeService().SelectData($"ExeID={exeID}");
            if (ModelList != null && ModelList.Count > 0)
            {
                ModelList.ForEach(m=> {
                    if (m.EndTime != null && m.StartTime != null)
                        totalTime += type == 0 ? ((TimeSpan)(m.EndTime - m.StartTime)).Minutes: ((TimeSpan)(m.EndTime - m.StartTime)).Seconds;
                });

               
            }
            return type==0?totalTime!=0? (double)86400/totalTime:0: totalTime;
        }
    }
}
