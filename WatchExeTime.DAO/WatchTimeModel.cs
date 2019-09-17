using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchExeTime.DAO.Model;

namespace WatchExeTime.DAO
{
    /// <summary>
    /// 监视时间
    /// </summary>
    public class WatchTimeModel : NotifyPropertyChanged
    {
        private int _TimeID;
        /// <summary>
        /// 主键，监视时间编号
        /// </summary>
        public int TimeID
        {
            get { return _TimeID; }
            set
            {
                _TimeID = value;
                OnPropertyChanged();
            }
        }
        private DateTime? _StartTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime
        {
            get { return _StartTime; }
            set
            {
                _StartTime = value;
                OnPropertyChanged();
            }
        }
        private DateTime? _EndTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime
        {
            get { return _EndTime; }
            set
            {
                _EndTime = value;
                OnPropertyChanged();
            }
        }

        private int _ExeID;
        /// <summary>
        /// 监视的应用编号
        /// </summary>
        public int ExeID
        {
            get { return _ExeID; }
            set
            {
                _ExeID = value;
                OnPropertyChanged();
            }
        }

    }
}
