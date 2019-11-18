using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            //WriteLog("ModelList.Count：" + ModelList.Count);
            if (ModelList != null && ModelList.Count > 0)
            {
                ModelList.ForEach(m=> {
                    if (m.EndTime != null && m.StartTime != null)
                        totalTime += type == 0 ? ((TimeSpan)(m.EndTime - m.StartTime)).Minutes: ((TimeSpan)(m.EndTime - m.StartTime)).Seconds;
                });

               
            }

            double time = type == 0 ? totalTime != 0 ? totalTime/(double) 86400  : 0 : totalTime;
            //WriteLog($"type:{type},totalTime:{totalTime}运算公式结果：{time}");
            return time;
        }

        //public void WriteLog(string value)
        //{
        //   string path = System.AppDomain.CurrentDomain.BaseDirectory + "/Logs/";
        //    //如果目录不存在,将创建目录
        //    if (!Directory.Exists(path))
        //        Directory.CreateDirectory(path);
        //    path = string.Format("{0}{1}{2}", path, DateTime.Now.ToString("yyyyMMdd"), "-.txt");
        //    using (StreamWriter sw = new StreamWriter(path,true))
        //    {
        //        sw.WriteLine("当前时间：[" + DateTime.Now.ToString() + "] Msg:" + value);
        //        sw.Close();
        //        sw.Dispose();
        //    }
        //}
    }
}
