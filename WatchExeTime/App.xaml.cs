using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

        public WatchUseTime WatchUseTime { get; set; }
        #endregion

        public App()
        {
            //初始化数据库
            SingletonFactory.Instance.CreateJDBC(string.Empty);

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            PropgramManager.OnlyOneExeOpen(this);
            NotifyIconHelper.SetNotifycation(ShowItemWindow);
            ExeSetting = new WatchExeSetting();
            WatchExeStageSetting = new WatchExeStageSetting();
            WatchUseTime = new WatchUseTime();
        }

        #region Method
        /// <summary>
        /// 显示点击菜单后的界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowItemWindow(object sender, EventArgs e)
        {
            switch ((sender as MenuItem)?.Name)
            {
                case "watchExeTypeItem":
                    WindowHelper.ShowWindow(ExeSetting);
                    break;
                case "stageItem":
                    WindowHelper.ShowWindow(WatchExeStageSetting);
                    break;
                case "timeItem":
                    WindowHelper.ShowWindow(WatchUseTime);
                    break;
            }

        }
        #endregion
    }
}
