using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchExeTime.DAO.Model;

namespace WatchExeTime.common
{
    public static  class  GlobalCommon
    {
        /// <summary>
        /// 当前监视程序id
        /// </summary>
        public static int? CurrentExeID { get; set; }
        public static WatchExeModel UsingModel { get; set; }

        /// <summary>
        /// 程序当前显示状态 1隐藏 0显示
        /// </summary>
        public static int ProgramVisibleState { get; set; } = 0;
    }
}
