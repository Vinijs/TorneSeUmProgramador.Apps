namespace Viagens.TorneSeUmProgramador.Core.Interfaces;

public interface ILocalizacaoService
{
    Task<int> CalcularDistancia((double latitude, double longitude) dadosDestino, string unidadeMedida = "km");
}
