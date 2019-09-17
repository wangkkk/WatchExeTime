using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Int32 = System.Int32;

namespace WatchExeTime.Converter
{
    /// <summary>
    /// 根据程序的id显示界面文字
    /// </summary>
    public class ExeIDToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;
            Int32 v = System.Convert.ToInt32(value);
            //1 Visual Studio  2 qq
            if (v == 1) return "已编程时间：";
            else if (2 == 2) return "已水群时间：";


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
