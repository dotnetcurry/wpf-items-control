using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace ItemsControlArticle
{
    public sealed class LatitudeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(x => !(x is double)))
            {
                return DependencyProperty.UnsetValue;
            }

            var totalWidth = (double)values[0];
            var totalHeight = (double)values[1];
            var latitude = (double)values[2];
            var center = totalHeight / 2;

            // adjust for dodgy map image
            center -= 5;

            var latitudeRadians = (latitude * Math.PI) / 180;
            var mercatorN = Math.Log(Math.Tan((Math.PI / 4) + (latitudeRadians / 2)));
            var y = center - (totalWidth * mercatorN / (2 * Math.PI));
            return y;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
