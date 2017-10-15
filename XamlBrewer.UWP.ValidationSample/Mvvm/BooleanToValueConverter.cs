using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Mvvm
{
    public class BooleanToValueConverter<T> : IValueConverter
    {
        public T FalseValue { get; set; }
        public T TrueValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return FalseValue;

            return (bool)value ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value != null && value.Equals(TrueValue);
        }
    }

    public class BooleanToBrushConverter : BooleanToValueConverter<Brush>
    { }

    public class BooleanToVisibilityConverter : BooleanToValueConverter<Visibility>
    { }
}
