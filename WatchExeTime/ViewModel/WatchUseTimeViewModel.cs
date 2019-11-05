using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchExeTime.BLL.Service;

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

        public WatchUseTimeViewModel()
        {
            TodayTime = WatchTimeBLLService.Instance.GetAllTime(0,1);

        }
    }
}
