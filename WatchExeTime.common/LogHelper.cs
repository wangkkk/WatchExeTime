using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WatchExeTime.common
{
    /// <summary>
    /// 异常日志
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 写测试日志
        /// </summary>
        /// <param name="errMsg">错误信息</param>
        /// <param name="path">写入路径</param>

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void WriteLog(string errMsg, string path)
        {
            WriteLog(errMsg, null, path);
        }

        /// <summary>
        /// 写测试日志
        /// </summary>
        /// <param name="errMsg">错误信息</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void WriteLog(string errMsg)
        {
            WriteLog(errMsg, null, "/Logs/");
        }

        /// <summary>
        /// 写测试日志
        /// </summary>
        /// <param name="errMsg">错误信息</param>
        /// <param name="ex">异常类型</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void WriteLog(string errMsg, Exception ex)
        {
            WriteLog(errMsg, ex, "Logs\\");
        }

        /// <summary>
        /// 写测试日志
        /// </summary>
        /// <param name="errMsg">错误信息</param>
        /// <param name="ex">异常类型</param>
        /// <param name="path">写入路径</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void WriteLog(string errMsg, Exception ex, string path)
        {
            StreamWriter sw = null;
            try
            {
                path = System.AppDomain.CurrentDomain.BaseDirectory + path;
                //如果目录不存在,将创建目录
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                path = string.Format("{0}{1}{2}", path, DateTime.Now.ToString("yyyyMMdd"), ".txt");
                if (File.Exists(path))
                    sw = File.AppendText(path);
                else
                    sw = File.CreateText(path);

                sw.WriteLine("当前时间：[" + DateTime.Now.ToString() + "] Msg:" + errMsg);
                //异常为空只写入消息
                if (ex != null)
                {
                    //写入异常详细
                    sw.WriteLine("异常信息：" + ex.Message);
                    sw.WriteLine("异常对象：" + ex.Source);
                    sw.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
                    sw.WriteLine("触发方法：" + ex.TargetSite);
                    sw.WriteLine();
                }
                sw.Close();
                sw.Dispose();
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}
