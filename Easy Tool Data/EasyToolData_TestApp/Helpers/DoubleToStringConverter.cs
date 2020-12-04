
namespace EasyToolData_TestApp.Helpers
{
    using System;
    using System.Windows.Data;

    [ValueConversion(typeof(double), typeof(string))]
    public class DoubleToStringConverter : IValueConverter
    {   
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                try
                {
                    double castedValue = (double)value;
                    return castedValue.ToString(Global.NumberFormat);
                }
                catch { }

                return value;
                
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}