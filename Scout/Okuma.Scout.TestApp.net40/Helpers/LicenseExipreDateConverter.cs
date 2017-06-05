
namespace Okuma.Scout.TestApp.net40.Helpers
{
    using System;
    using System.Windows.Data;

    public class LicenseExipreDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            Nullable<DateTime> castedDateTime = (DateTime?)value;
            return castedDateTime.HasValue ? castedDateTime.Value.ToString("dd/MM/yyyy") : "N/A";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}

