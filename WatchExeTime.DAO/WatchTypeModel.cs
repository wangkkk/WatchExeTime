using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchExeTime.DAO.Model;

namespace WatchExeTime.DAO
{
    /// <summary>
    /// 监视程序类型
    /// </summary>
    public class WatchTypeModel: NotifyPropertyChanged
    {
        private int _TypeID;
        /// <summary>
        /// 主键
        /// </summary>
        public int TypeID
        {
            get { return _TypeID; }
            set
            {
                _TypeID = value;
                OnPropertyChanged();
            }
        }
        private bool? _OneDayType;
        /// <summary>
        /// 时间按日计算
        /// </summary>
        public bool? OneDayType
        {
            get { return _OneDayType; }
            set
            {
                _OneDayType = value;
                OnPropertyChanged();
            }
        }

        private bool? _IntervalType;
        /// <summary>
        /// 时间按次计算
        /// </summary>
        public bool? IntervalType
        {
            get { return _IntervalType; }
            set
            {
                _IntervalType = value;
                OnPropertyChanged();
            }
        }

    }
}
