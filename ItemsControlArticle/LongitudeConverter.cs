using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace ItemsControlArticle
{
    public sealed class LongitudeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(x => !(x is double)))
            {
                return DependencyProperty.UnsetValue;
            }

            var totalWidth = (double)values[0];
            var longitude = (double)values[1];
            var center = totalWidth / 2;

            // adjust for dodgy map image
            center -= 30;

            var pixelsPerDegree = totalWidth / 360;

            return center + (longitude * pixelsPerDegree);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
