using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WatchExeTime.DAO.Model;

namespace WatchExeTime.ViewModel
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        #region Property

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        //private string _WatchQQTime;
        ///// <summary>
        ///// 水群时间字符串
        ///// </summary>
        //public string WatchQQTime
        //{
        //    get { return _WatchQQTime; }
        //    set
        //    {
        //        _WatchQQTime = value;
        //        OnPropertyChanged();
        //    }
        //}
        private int _WatchExeSecond;
        /// <summary>
        /// 监视程序的时间
        /// </summary>
        public int WatchExeSecond
        {
            get { return _WatchExeSecond; }
            set
            {
                _WatchExeSecond = value;
                OnPropertyChanged();
            }
        }

        private Visibility _mainVisibleVisibility;
        /// <summary>
        /// 窗口是否可见
        /// </summary>
        public Visibility MainVisible
        {
            get { return _mainVisibleVisibility; }
            set
            {
                _mainVisibleVisibility = value;
                OnPropertyChanged();
            }
        }

        private int _LeaveExeSecond;
        /// <summary>
        /// 是否第一次离开监视程序
        /// </summary>
        public int LeaveExeSecond
        {
            get { return _LeaveExeSecond; }
            set
            {
                _LeaveExeSecond = value;
                OnPropertyChanged();
            }
        }

        private Window _window;

        public Window window
        {
            get { return _window; }
            set
            {
                _window = value;
                OnPropertyChanged();
            }
        }
        private int? _CurrentID;

        public int? CurrentID
        {
            get { return _CurrentID; }
            set
            {
                _CurrentID = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// 程序路径
        /// </summary>
        public string ExePath { get; set; }
        /// <summary>
        /// 程序标题
        /// </summary>
        public string ExeTitle { get; set; }

        public WatchExeModel UsingModel { get; set; }
        private string _BackGroundImg;
        /// <summary>
        /// 背景图片
        /// </summary>
        public string BackGroundImg
        {
            get { return _BackGroundImg; }
            set
            {
                _BackGroundImg = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
