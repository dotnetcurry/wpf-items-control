namespace ItemsControlArticle
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using Splat;

    public sealed class ToNativeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bitmap = value as IBitmap;

            if (bitmap == null)
            {
                return DependencyProperty.UnsetValue;
            }

            return bitmap.ToNative();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}