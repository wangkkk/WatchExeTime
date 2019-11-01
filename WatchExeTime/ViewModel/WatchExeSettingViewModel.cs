using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WatchExeTime.BLL.Service;
using WatchExeTime.common;
using WatchExeTime.DAO.Model;

namespace WatchExeTime.ViewModel
{
    public class WatchExeSettingViewModel:ViewModelBase
    {
        private ObservableCollection<WatchExeModel> _watchExeListCollection;

        public ObservableCollection<WatchExeModel> WatchExeList
        {
            get { return _watchExeListCollection; }
            set
            {
                _watchExeListCollection = value;
                OnPropertyChanged();
            }
        }
        private WatchExeModel _selectWatchExeModel;

        public WatchExeModel SelectWatchExe
        {
            get { return _selectWatchExeModel; }
            set
            {
                _selectWatchExeModel = value;
                OnPropertyChanged();
            }
        }


        public System.Windows.Input.ICommand UpdateWatchExeCommand { get; set; }
        
        public WatchExeSettingViewModel()
        {
            WatchExeList = WatchExeBLLService.Instance.SelectData();
            UpdateWatchExeCommand=new RelayCommand<int>(UpdateWatchExeInvoke);
        }

        private void UpdateWatchExeInvoke(int ExeID)
        {
            try
            {
                var entity= WatchExeList.Where(m => m.ExeID == ExeID).FirstOrDefault();
                if (entity != null)
                {
                    string result = string.Format("更新监视程序{0}!",
                        WatchExeBLLService.Instance.UpdateWathExeTime(entity) > 0 ? "成功" : "失败");
                    MessageBox.Show(result+"重启程序后生效");}
               
            }
            catch (Exception ex)
            {
               LogHelper.WriteLog("更新监视程序异常：",ex);
            }
            
        }
    }
}
