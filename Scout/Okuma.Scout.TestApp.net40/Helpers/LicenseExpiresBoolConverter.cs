
namespace Okuma.Scout.TestApp.net40.Helpers
{
    using System;
    using System.Windows.Data;

    public class LicenseExpiresBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            Nullable<bool> castedBool = (bool?)value;
            return castedBool.HasValue ? castedBool.Value.ToString() : "N/A";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}

