﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// WatchExeStageSetting.xaml 的交互逻辑
    /// </summary>
    public partial class WatchExeStageSetting : Window
    {
        private WatchExeStageSettingViewModel vm = new WatchExeStageSettingViewModel();

        public WatchExeStageSetting()
        {
            InitializeComponent();
            this.DataContext = vm;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;  // cancels the window close    
            this.Hide();      // Programmatically hides the window
        }
    }
}
