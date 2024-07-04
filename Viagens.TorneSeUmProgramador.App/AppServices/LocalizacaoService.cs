using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.App.AppServices;

public sealed class LocalizacaoService : ILocalizacaoService
{
    private Location _localizacaoAtual;
    private readonly IGeolocation _geolocation;
    private readonly IAppLogger<LocalizacaoService> _logger;

    public LocalizacaoService(IGeolocation geolocation, 
                              IAppLogger<LocalizacaoService> logger)
    {
        _geolocation = geolocation;
        _logger = logger;
    }

    public async Task<int> CalcularDistancia((double latitude, double longitude) dadosDestino, string unidadeMedida = "km")
    {
        _localizacaoAtual ??= await ObterLocalizacaoAtual();
        var localizacaoDestino = new Location(dadosDestino.latitude, dadosDestino.longitude);
        var distancia = Location.CalculateDistance(_localizacaoAtual, localizacaoDestino, ObterUnidadeMedida(unidadeMedida));
        return (int)distancia;
    }

    private async Task<Location> ObterLocalizacaoAtual()
    {
        try
        {
            var localizacao = await _geolocation.GetLocationAsync();

            localizacao ??= await _geolocation.GetLastKnownLocationAsync();

            return localizacao ??= new Location(0,0);
        }
        catch (Exception ex)
        {
            _logger.Erro(ex, "Erro ao obter localização atual");
            return new Location(0, 0);
        }      
    }

    private static DistanceUnits ObterUnidadeMedida(string unidadeMedida)
    {
        return unidadeMedida.ToLower() switch
        {
            "km" => DistanceUnits.Kilometers,
            "mi" => DistanceUnits.Miles,
            _ => DistanceUnits.Kilometers
        };
    }
}
