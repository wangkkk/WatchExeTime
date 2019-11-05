using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WatchExeTime.Converter
{
    public class SeCondTimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str =string.Empty;
            if (Int32.TryParse(value.ToString(), out Int32 v))
            {
                TimeSpan ts = new TimeSpan(0,0, 0, v);
               
                if (ts.Days > 0)
                {
                    str =ts.Days.ToString()+"天"+ ts.Hours.ToString() + "小时 " + ts.Minutes.ToString() + "分钟 " + ts.Seconds + "秒";
                }
                if (ts.Hours > 0)
                {
                    str = ts.Hours.ToString() + "小时 " + ts.Minutes.ToString() + "分钟 " + ts.Seconds + "秒";
                }
                if (ts.Hours == 0 && ts.Minutes > 0)
                {
                    str = ts.Minutes.ToString() + "分钟 " + ts.Seconds + "秒";
                }
                if (ts.Hours == 0 && ts.Minutes == 0)
                {
                    str = ts.Seconds + "秒";
                }
               
            }
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
