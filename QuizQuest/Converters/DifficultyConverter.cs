using QuizQuest.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace QuizQuest.Converters;

class DifficultyConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string enumString && Enum.TryParse(typeof(Difficulty), enumString, out var result))
        {
            return result; 
        }
        return DependencyProperty.UnsetValue; // Returns Unset if conversion fails
    }
}
