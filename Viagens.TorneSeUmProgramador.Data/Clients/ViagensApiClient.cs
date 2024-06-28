using Flurl.Http;
using Flurl.Http.Configuration;
using Viagens.TorneSeUmProgramador.Core.Dtos;
using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.Data.Clients;

public sealed class ViagensApiClient : IViagensApiClient
{
    private const string _mais_buscados = "viagens-api-client";

    public readonly IFlurlClient _flurlClient;
    public readonly IAppLogger<ViagensApiClient> _logger;

    public ViagensApiClient(IFlurlClientCache flurlClientCache, IAppLogger<ViagensApiClient> logger)
    {
        _flurlClient = flurlClientCache.Get(_mais_buscados);
        _logger = logger;
    }

    public async Task<List<MaisBuscadosDto>> ObterMaisBuscados()
    {
        try
        {
            return await _flurlClient.Request("viagens/mais-buscadas")
                .GetJsonAsync<List<MaisBuscadosDto>>();
        }
        catch (Exception ex)
        {
            _logger.Erro(ex, "Erro ao buscar viagens mais buscadas");
            throw;
        }
    }
}
