using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WatchExeTime.BLL;
using WatchExeTime.BLL.Service;
using WatchExeTime.common;
using WatchExeTime.DAO;
using WatchExeTime.Factory;
using WatchExeTime.Views;
using Application = System.Windows.Application;

namespace WatchExeTime
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        #region Property
      
        
        /// <summary>
        /// 监视程序设置界面
        /// </summary>
        private WatchExeSetting ExeSetting { get; set; }

        public WatchExeStageSetting WatchExeStageSetting { get; set; }
        #endregion

        public App()
        {
            //初始化数据库
            SingletonFactory.Instance.CreateJDBC(string.Empty);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            PropgramManager.OnlyOneExeOpen(this);
            NotifyIconHelper.SetNotifycation(ShowStageItemWindow, ShowWatchExeTypeWindow);
        }

        #region Method
        /// <summary>
        /// 打开等级设置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowStageItemWindow(object sender, EventArgs e)
        {
            if (WatchExeStageSetting == null)
                WatchExeStageSetting = new WatchExeStageSetting();
            if (!WatchExeStageSetting.IsVisible)
            {
                WatchExeStageSetting.ShowDialog();
            }
        }
        /// <summary>
        /// 打开监视程序设置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowWatchExeTypeWindow(object sender, EventArgs e)
        {
            if (ExeSetting == null)
                ExeSetting = new WatchExeSetting();
            if (!ExeSetting.IsVisible)
            { 
                ExeSetting.ShowDialog();
            }
        }
        #endregion
    }
}
