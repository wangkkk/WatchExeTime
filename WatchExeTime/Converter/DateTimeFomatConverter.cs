using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WatchExeTime.Converter
{
    /// <summary>
    /// 时间显示控制
    /// </summary>
    public class DateTimeFomatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;
            Int32 v = System.Convert.ToInt32(value);
            if(v<60)
                    return $"{v}秒";
            else if(v>=60&&v<3600)
                    return $"{v / 60}分";
            else if(v<3600*12)
            {
                TimeSpan time = TimeSpan.FromSeconds(v);
                return v.ToString(@"hh\:mm\:ss");
            }
            else
            {
                TimeSpan time = TimeSpan.FromSeconds(v);
                return v.ToString(@"DD hh\:mm\:ss");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
