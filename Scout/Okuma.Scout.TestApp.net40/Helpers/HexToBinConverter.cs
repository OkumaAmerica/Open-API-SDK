using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma.Scout.TestApp.net40.Helpers
{
    using System;
    using System.Windows.Data;

    public class HexToBinConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            string castedString = (string)value;

            UInt32 theByte = System.Convert.ToUInt32(castedString, 16);

            return System.Convert.ToString(theByte, 2).PadLeft(8, '0');
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}


