using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Brushes = System.Windows.Media.Brushes;
using MessageBox = System.Windows.MessageBox;

namespace WatchExeTime.BLL
{
    public static class SetWindow
    {
        #region 初始化窗体
        public static Window SetCustomWindow(Window window)
        {
            //定制窗体
            window.AllowsTransparency = true;
            window.WindowStyle = WindowStyle.None;
            window.Background = Brushes.Transparent;
            window.OpacityMask = Brushes.White;
            //Windows位置
            window.WindowStartupLocation = WindowStartupLocation.Manual;
            double width = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double height = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            window.Left = width - 330;
            window.Top = height - 330;
            window.ShowInTaskbar = false;//不在任务栏中显示
            return window;
        }
        #endregion

        
       

        /// <summary>
        /// 拖动窗体
        /// </summary>
        /// <param name="window">需要拖动的窗体</param>
        public static void DragWindow(Window window)
        {
            window.MouseDown += (sender, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    window.DragMove();
                }
            };


        }
    }
}
