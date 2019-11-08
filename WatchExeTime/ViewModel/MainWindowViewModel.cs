using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WatchExeTime.BLL;
using WatchExeTime.BLL.Service;
using WatchExeTime.common;
using WatchExeTime.DAO;
using WatchExeTime.DAO.Model;

namespace WatchExeTime.ViewModel
{
    [Export("MainWindowViewModel",typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MainWindowViewModel: ViewModelBase
    {
        #region 
        private string _StageName;

        public string StageName
        {
            get { return _StageName; }
            set
            {
                _StageName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 当前监视时间
        /// </summary>
        public WatchTimeModel CurrentWatchTimeModel { get; set; }
        /// <summary>
        /// 监视类型
        /// </summary>
        private WatchTypeModel WatchType { get; set; }
        #endregion
        public MainWindowViewModel()
        {
            //取正在使用的，要监视的程序
            GlobalCommon.UsingModel = WatchExeBLLService.Instance.SelectData()?.Where(m => m.IsUsing == 1)?.ToList().FirstOrDefault();
            Init();
            DispatcherTimer timer=new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,0,1);
            timer.Tick += GetWindowStr;
            timer.Start();
        }

        private void Init()
        {
            MainVisible = Visibility.Visible;//主窗口为可见
            CurrentWatchTimeModel = new WatchTimeModel();//初始化当前监视时间
           
        }


        private void GetWindowStr(object sender, EventArgs e)
        {
            ExeTitle = CurrentWindow.GetTopWindowText();
            ExePath=CurrentWindow.GetTopWindowName();
            if (GlobalCommon.UsingModel != null)
            {
                //如果名字匹配
                if (ExeTitle.Contains(GlobalCommon.UsingModel.ExeTitleName))
                {
                    //如果已设置程序路径，程序名字和路径双重匹配
                    if ((!string.IsNullOrWhiteSpace(GlobalCommon.UsingModel.ExePathName)&&ExePath.Contains(GlobalCommon.UsingModel.ExePathName))|| 
                        string.IsNullOrWhiteSpace(GlobalCommon.UsingModel.ExePathName))
                    {
                        CurrentID=GlobalCommon.CurrentExeID = GlobalCommon.UsingModel.ExeID;//当前ID
                        LeaveExeSecond = 0;//重置离开程序时间
                        if (WatchExeSecond == 0)
                        {
                            StageName = ProgramStageConfigServiceBLLService.Instance.GetCurrentState();
                            //插入时间到时间表中
                            CurrentWatchTimeModel.StartTime = System.DateTime.Now;
                            CurrentWatchTimeModel.ExeID = Convert.ToInt32(GlobalCommon.CurrentExeID);

                            int resultID=WatchTimeBLLService.Instance.InsertWathExeTime(CurrentWatchTimeModel);
                            CurrentWatchTimeModel.TimeID = resultID;
                        }
                         WatchExeSecond += 1;
                       
                    }
                }
                else//离开要监视的程序
                {
                    
                    //更新时间
                    if (LeaveExeSecond == 0&& WatchExeSecond != 0)
                    {
                        CurrentWatchTimeModel.EndTime = System.DateTime.Now;
                        int resultID = WatchTimeBLLService.Instance.UpdateWathExeTime(CurrentWatchTimeModel);
                    }
                    LeaveExeSecond++;
                    CurrentID = GlobalCommon.CurrentExeID = null;
                    //监视类型
                    WatchType = WatchTypeBLLService.Instance.SelectData();
                    //当为间隔时间模式时，重置时间
                    if (WatchExeSecond != 0&& true==WatchType?.IntervalType) WatchExeSecond = 0;

                }
            }
        }

        

    }
}
