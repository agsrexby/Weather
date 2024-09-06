using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace kursach_mvvm.Converter;

public class BitmapConverter : IValueConverter
{
    public static BitmapConverter Instance = new BitmapConverter();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string && targetType == typeof(IImage))
        {
            var uri = new Uri((string)value, UriKind.RelativeOrAbsolute);
            var scheme = uri.IsAbsoluteUri ? uri.Scheme : "file";

            switch (scheme)
            {
                case "file":
                    return new Bitmap((string)value);

                default:
                    return new Bitmap(AssetLoader.Open(uri));
            }
        }

        throw new NotSupportedException();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}