using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFDemo
{
    public class ByteToStringValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (!(value is byte))
                throw new ArgumentException($"Cannot convert from {value.GetType()} to {typeof(byte)}", nameof(value));

            if (!targetType.IsAssignableFrom(typeof(string)))
                throw new ArgumentException($"Cannot convert from {typeof(string)} to {targetType}", nameof(targetType));

            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!targetType.IsAssignableFrom(typeof(double)))
                throw new ArgumentException($"Cannot convert from {typeof(double)} to {targetType}", nameof(targetType));

            return byte.Parse((value as string) ?? value?.ToString() ?? string.Empty);
        }

    }
}
