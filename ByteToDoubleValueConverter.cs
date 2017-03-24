using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFDemo
{
    public class ByteToDoubleValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (!(value is byte))
                throw new ArgumentException($"Cannot convert from {value.GetType()} to {typeof(byte)}", nameof(value));

            if (!targetType.IsAssignableFrom(typeof(double)))
                throw new ArgumentException($"Cannot convert from {typeof(byte)} to {targetType}", nameof(targetType));

            return System.Convert.ToDouble((byte)value, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (!(value is double))
                throw new ArgumentException($"Cannot convert from {value.GetType()} to {typeof(double)}", nameof(value));

            if (!targetType.IsAssignableFrom(typeof(byte)))
                throw new ArgumentException($"Cannot convert from {typeof(double)} to {targetType}", nameof(targetType));

            return System.Convert.ToByte((double)value, culture);
        }

    }
}
