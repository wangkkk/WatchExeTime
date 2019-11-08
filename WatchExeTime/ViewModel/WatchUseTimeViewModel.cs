using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchExeTime.BLL.Service;
using WatchExeTime.common;

namespace WatchExeTime.ViewModel
{
    public class WatchUseTimeViewModel:ViewModelBase
    {
        private double _TodayTime;

        public double TodayTime
        {
            get { return _TodayTime; }
            set
            {
                _TodayTime = value;
                OnPropertyChanged();
            }
        }

        public void GetTime()
        {
            TodayTime = WatchTimeBLLService.Instance.GetAllTime(GlobalCommon.CurrentExeID??1, 1);

        }
    }
}
