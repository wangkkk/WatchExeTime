using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WatchExeTime.BLL
{
    public static class PropgramManager
    {
        /// <summary>
        /// 只能有一个程序打开
        /// </summary>
        /// <param name="App"></param>
        public static void OnlyOneExeOpen(Application App)
        {
            bool isCanCreateNew;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, "OnlyRunOneInstance", out isCanCreateNew);
            if (!isCanCreateNew)
            {
                App.Shutdown(1);
                return;
            }
        }
    }
}
