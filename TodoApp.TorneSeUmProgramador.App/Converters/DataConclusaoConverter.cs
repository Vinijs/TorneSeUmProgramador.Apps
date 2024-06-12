using System.Globalization;

namespace TodoApp.TorneSeUmProgramador.App.Converters;

public class DataConclusaoConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTime data)
        {
            return data.ToString("dd/MM/yyyy");
        }

        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
