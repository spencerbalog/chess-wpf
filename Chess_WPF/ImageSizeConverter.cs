using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Chess_WPF
{
    public class ImageSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double size && parameter is FrameworkElement element)
            {
                // Calculate the image size based on the element dimensions
                double ratio = Math.Min(element.ActualWidth, element.ActualHeight) / 8.0; // Assuming 8x8 grid
                return size * ratio;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
