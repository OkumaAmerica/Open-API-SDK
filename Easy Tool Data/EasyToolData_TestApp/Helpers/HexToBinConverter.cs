
namespace EasyToolData_TestApp.Helpers
{
    using System;
    using System.Windows.Data;

    [ValueConversion(typeof(string), typeof(string))]
    public class HexToBinConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string castedString = (string)value;
            UInt32 theByte = System.Convert.ToUInt32(castedString, 16);
            return System.Convert.ToString(theByte, 2).PadLeft(8, '0');
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}