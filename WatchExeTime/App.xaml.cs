using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WatchExeTime.BLL;
using WatchExeTime.Factory;

namespace WatchExeTime
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //初始化数据库
            SingletonFactory.Instance.CreateJDBC(string.Empty);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            PropgramManager.OnlyOneExeOpen(this);
        }
    }
}
