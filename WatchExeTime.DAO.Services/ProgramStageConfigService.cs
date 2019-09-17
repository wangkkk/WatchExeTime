using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WatchExeTime.DAO.IServices;

namespace WatchExeTime.DAO.Services
{
    public class ProgramStageConfigService : IProgramStageConfigService
    {
        public int DeleteData(int StageConfigID)
        {
            string strSql = "delete from ProgramStageConfig where StageConfigID=@StageConfigID";
            var resultExecute = SQLiteHelper.CreateConnection().Execute(strSql, new { StageConfigID= StageConfigID });
            return resultExecute;
        }

        public int InsertData(ProgramStageConfigModel model)
        {
            string strSql = "Insert into ProgramStageConfig(StageConfigID,StageConfigName,MiniTime,MaxTime)values(@StageConfigID,@StageConfigName,@MiniTime,@MaxTime); SELECT last_insert_rowid();";
            var resultExecute = (long)SQLiteHelper.CreateConnection().ExecuteScalar(strSql, model);
            return Convert.ToInt32(resultExecute);
        }

        public ObservableCollection<ProgramStageConfigModel> SelectData(string Where="")
        {
            string strSql="select * from ProgramStageConfig";
            if (!string.IsNullOrEmpty(Where))
                strSql += " where " + Where;
            var queryResult = SQLiteHelper.CreateConnection().Query<ProgramStageConfigModel>(strSql);
            return new ObservableCollection<ProgramStageConfigModel>(queryResult);
        }

        public int UpdataData(ProgramStageConfigModel model)
        {
            string strsql = "UPDATE ProgramStageConfig SET  StageConfigName=@StageConfigName,MiniTime=@MiniTime,MaxTime=@MaxTime WHERE StageConfigID =@StageConfigID";
            var resultExecute = SQLiteHelper.CreateConnection().Execute(strsql, model);
            return resultExecute;
        }
    }
}
