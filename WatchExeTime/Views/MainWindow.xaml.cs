using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WatchExeTime.BLL;
using WatchExeTime.BLL.Service;
using WatchExeTime.common;
using WatchExeTime.ViewModel;

namespace WatchExeTime
{
   
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //[Import("MainWindowViewModel", typeof(ViewModelBase))]
        //private MainWindowViewModel vm;
        MainWindowViewModel vm=new MainWindowViewModel();

        #region 热键字段
        uint hotKey1, hotKey2;
        private HotKeyService _hotKeys { get; set; }
        #endregion

        public MainWindow()
        {
            SetWindow.SetCustomWindow(this);
         
            InitializeComponent();
            this.Loaded += (sender, e) =>
            {
                this.DataContext = vm;
                SetWindow.DragWindow(this);
            };

        }

        #region 热键控制窗口可见性
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            _hotKeys = new HotKeyService(this, HandleHotKey);
            hotKey1 = _hotKeys.ListenForHotKey(System.Windows.Forms.Keys.F8, HotKeyModifiers.Control);
            hotKey2 = _hotKeys.ListenForHotKey(System.Windows.Forms.Keys.F9, HotKeyModifiers.Shift);
        }
        void HandleHotKey(int keyId)
        {
            if (keyId == hotKey1)
            {
                this.Visibility = Visibility.Hidden;//隐藏窗口
                GlobalCommon.ProgramVisibleState = 1;
            }
            else if (keyId == hotKey2)
            {
                this.Visibility = Visibility.Visible;//显示窗口
                GlobalCommon.ProgramVisibleState = 0;
            }
        }
        #endregion
    }
}
