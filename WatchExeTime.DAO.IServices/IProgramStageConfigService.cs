using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchExeTime.DAO.IServices
{
    /// <summary>
    /// 修炼阶段配置
    /// </summary>
    public interface IProgramStageConfigService
    {
        ObservableCollection<ProgramStageConfigModel> SelectData(string Where = "");
        int InsertData(ProgramStageConfigModel model);
        int UpdataData(ProgramStageConfigModel model);
        int DeleteData(int modelID);
    }
}
