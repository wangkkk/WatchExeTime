using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchExeTime.DAO.Model;

namespace WatchExeTime.DAO
{
    public class ProgramStageConfigModel: NotifyPropertyChanged
    {
        private int _StageConfigID;
        /// <summary>
        /// 主键
        /// </summary>
        public int StageConfigID
        {
            get { return _StageConfigID; }
            set
            {
                _StageConfigID = value;
                OnPropertyChanged();
            }
        }
        private string _StageConfigName;
        /// <summary>
        /// 修炼阶段名字
        /// </summary>
        public string StageConfigName
        {
            get { return _StageConfigName; }
            set
            {
                _StageConfigName = value;
                OnPropertyChanged();
            }
        }

        private double? _MiniTime;
        /// <summary>
        /// 达到此阶段的最低时间要求
        /// </summary>
        public double? MiniTime
        {
            get { return _MiniTime; }
            set
            {
                _MiniTime = value;
                OnPropertyChanged();
            }
        }
        private double? _MaxTime;

        public double? MaxTime
        {
            get { return _MaxTime; }
            set
            {
                _MaxTime = value;
                OnPropertyChanged();
            }
        }


    }
}
