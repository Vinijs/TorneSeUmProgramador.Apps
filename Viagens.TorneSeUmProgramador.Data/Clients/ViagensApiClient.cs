using Flurl.Http;
using Flurl.Http.Configuration;
using Viagens.TorneSeUmProgramador.Core.Dtos;
using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.Data.Clients;

public sealed class ViagensApiClient : IViagensApiClient
{
    private const string _mais_buscados = "viagens/mais-buscadas";
    private const string _ofertas = "viagens/ofertas";

    public readonly IFlurlClient _flurlClient;
    public readonly IAppLogger<ViagensApiClient> _logger;

    public ViagensApiClient(IFlurlClientCache flurlClientCache, IAppLogger<ViagensApiClient> logger)
    {
        _flurlClient = flurlClientCache.Get("viagens-api-client");
        _logger = logger;
    }

    public async Task<List<MaisBuscadosDto>> ObterMaisBuscados()
    {
        try
        {
            return await _flurlClient.Request(_mais_buscados)
                .GetJsonAsync<List<MaisBuscadosDto>>();
        }
        catch (Exception ex)
        {
            _logger.Erro(ex, "Erro ao buscar viagens mais buscadas");
            throw;
        }
    }

    public async Task<List<OfertaDto>> ObterOfertas()
    {
        try
        {
            return await _flurlClient.Request(_ofertas)
                .GetJsonAsync<List<OfertaDto>>();
        }
        catch (Exception ex)
        {
            _logger.Erro(ex, "Erro ao buscar ofertas");
            throw;
        }
    }
}
