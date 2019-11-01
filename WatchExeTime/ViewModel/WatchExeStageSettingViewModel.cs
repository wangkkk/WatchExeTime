using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using WatchExeTime.BLL.Service;
using WatchExeTime.common;
using WatchExeTime.DAO;

namespace WatchExeTime.ViewModel
{
    public class WatchExeStageSettingViewModel:ViewModelBase
    {
        private ObservableCollection<ProgramStageConfigModel> _stageLiStageConfigModels;

        public ObservableCollection<ProgramStageConfigModel> StageList
        {
            get { return _stageLiStageConfigModels; }
            set
            {
                _stageLiStageConfigModels = value;
                OnPropertyChanged();
            }
        }
        public ICommand UpdateExeStageCommand { get; set; }
        public WatchExeStageSettingViewModel()
        {
            StageList = ProgramStageConfigServiceBLLService.Instance.SelectData();
            UpdateExeStageCommand=new RelayCommand<int>(UpdateExeStageInvoke);
        }

        private void UpdateExeStageInvoke(int StageConfigID)
        {
            try
            {
                var entity = StageList.Where(m => m.StageConfigID == StageConfigID).FirstOrDefault();
                if (entity != null)
                {
                    string result = string.Format("更新等级{0}!",
                        ProgramStageConfigServiceBLLService.Instance.UpdataData(entity) > 0 ? "成功" : "失败");
                    MessageBox.Show(result + "重启程序后生效");
                }

            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("更新监视程序异常：", ex);
            }
        }
    }
}
