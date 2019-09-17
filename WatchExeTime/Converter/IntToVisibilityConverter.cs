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
    /// 根据数字控制可见性
    /// </summary>
    public class IntToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;
            else return Visibility.Visible;
            //Int32 v = System.Convert.ToInt32(value);
            //Int32 p = System.Convert.ToInt32(parameter);
            ////p 2对应qq 1对应编程
            //return (v == 2 && p == 2)|| (v == 1 && p == 1)?Visibility.Visible:Visibility.Collapsed;
            

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
