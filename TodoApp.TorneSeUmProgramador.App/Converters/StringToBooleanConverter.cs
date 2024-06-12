using System.Globalization;

namespace TodoApp.TorneSeUmProgramador.App.Converters;

public class StringToBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is string texto)
        {
            return texto.Equals("xpto", StringComparison.InvariantCultureIgnoreCase);
        }

        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}
