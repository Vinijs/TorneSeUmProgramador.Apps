using System.Globalization;
using Viagens.TorneSeUmProgramador.Core.Enums;

namespace Viagens.TorneSeUmProgramador.App.Utils.Converters;

public sealed class TipoPacoteParaCorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var tipo = Enum.Parse(typeof(TipoPacote), value.ToString());
        
        if(tipo is not null)
        {
            Application.Current.Resources.TryGetValue(tipo.ToString() , out var color);

            if(color is Color cor)
            {
                return cor;
            }
        }

        return Color.FromArgb("#FFD700");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
        => Enum.Parse(typeof(TipoPacote), value.ToString());
}
