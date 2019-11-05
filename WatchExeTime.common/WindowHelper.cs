using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WatchExeTime.common
{
    public static class WindowHelper
    {

        public static void ShowWindow(Window window)
        {
            if (!window.IsVisible)
            {
                window.ShowDialog();
            }
        }
    }
}
