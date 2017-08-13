using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFDemo
{
    public class StringToByteValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!byte.TryParse(((value as string) ?? value?.ToString() ?? string.Empty), out var temp))
                return new ValidationResult(false, "Must be an integer from 0 to 255");

            return new ValidationResult(true, string.Empty);
        }
    }
}
