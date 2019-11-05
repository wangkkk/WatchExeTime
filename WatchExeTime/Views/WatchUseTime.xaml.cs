using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WatchExeTime.ViewModel;

namespace WatchExeTime.Views
{
    /// <summary>
    /// WatchUseTime.xaml 的交互逻辑
    /// </summary>
    public partial class WatchUseTime : Window
    {
        private WatchUseTimeViewModel vm = new WatchUseTimeViewModel();

        public WatchUseTime()
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
