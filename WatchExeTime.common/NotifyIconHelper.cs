using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchExeTime.BLL.Service;
using WatchExeTime.DAO;

namespace WatchExeTime.common
{
   
    public static class NotifyIconHelper
    {
        //托盘
        static NotifyIcon notifyIcon;
        public  delegate void  OpenDialog(object sender, EventArgs e);
        /// <summary>
        /// 显示时间模式
        /// </summary>
        static WatchTypeModel WatchType { get; set; }
        static MenuItem WatchTypeSubItemOne = new MenuItem("按次显示");
        static MenuItem WatchTypeSubItemTwo = new MenuItem("按日显示");
        public static void SetNotifycation(OpenDialog oepnStageItem,OpenDialog openWatchExeType)
        {

            notifyIcon = new NotifyIcon();
            //notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
            notifyIcon.Icon = new Icon($"{Environment.CurrentDirectory}/Images/Logo.ico");  // 设置图标
            notifyIcon.Text = "监视程序";  // 设置鼠标放到上面时显示的文字
            notifyIcon.Visible = true;

            WatchTypeSubItemOne.Click += WatchTypeSubItem_Click;
            WatchTypeSubItemOne.RadioCheck = true;
            WatchTypeSubItemOne.Name = "InternalItem";
            WatchTypeSubItemTwo.Click += WatchTypeSubItem_Click;
            WatchTypeSubItemTwo.RadioCheck = true;
            MenuItem WatchTypeItem = new MenuItem("显示时间模式")
            {
                MenuItems = { WatchTypeSubItemOne, WatchTypeSubItemTwo }
            };
            InitWatchType();
            MenuItem WatchExeTypeItem = new MenuItem("监视程序设置");
            MenuItem StageItem = new MenuItem("等级设置");
            StageItem.Click +=new EventHandler(oepnStageItem);
            MenuItem ExitItem = new MenuItem("退出");
            ExitItem.Click += (object sender, EventArgs e) =>
            {
                RemoveNotifycation();
                Environment.Exit(0);
            };
            WatchExeTypeItem.Click += new EventHandler(openWatchExeType);
            notifyIcon.ContextMenu = new ContextMenu()
            {
                MenuItems = { WatchTypeItem, WatchExeTypeItem, StageItem, ExitItem }
            }; // 设置右键菜单
        }

        public static void RemoveNotifycation()
        {
            notifyIcon.Visible = false;
            notifyIcon = null;
        }
        /// <summary>
        /// 初始化显示时间模式
        /// </summary>
        public static void InitWatchType()
        {
            WatchType = WatchTypeBLLService.Instance.SelectData();
            WatchTypeSubItemOne.RadioCheck = true;
            if (WatchType?.IntervalType == true) WatchTypeSubItemOne.Checked = true;
            else if (WatchType?.OneDayType == true) WatchTypeSubItemTwo.Checked = true;
        }

        /// <summary>
        /// 切换时间显示模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void WatchTypeSubItem_Click(object sender, EventArgs e)
        {
            try
            {
                if ((sender as MenuItem)?.Name == "InternalItem")
                {
                    UpdateWatchType(true);
                    WatchTypeSubItemOne.Checked = true;
                    WatchTypeSubItemTwo.Checked = false;
                }
                else
                {
                    UpdateWatchType(false);
                    WatchTypeSubItemOne.Checked = false;
                    WatchTypeSubItemTwo.Checked = true;
                }
            }
            catch (Exception exception)
            {
                LogHelper.WriteLog("切换时间显示模式出现异常：", exception);
            }

        }

        /// <summary>
        /// 更新数据库
        /// </summary>
        /// <param name="type">true为以次显示</param>
        public static void UpdateWatchType(bool type)
        {
            if (WatchType != null)
            {
                WatchType.IntervalType = type;
                WatchType.OneDayType = !type;
                LogHelper.WriteLog(string.Format("更新表WatchType{0}！", WatchTypeBLLService.Instance.Update(WatchType) > 0 ? "成功" : "失败"));

            }
        }

    }
}
