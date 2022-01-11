using System;
using System.Globalization;
using System.Windows.Data;

namespace StudentGrades.Converters
{
    public class GradeAverageToWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var newValue = (double)value;
            return newValue * double.Parse((string)parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
