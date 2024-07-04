using Viagens.TorneSeUmProgramador.Core.Cache;
using Viagens.TorneSeUmProgramador.Core.Dtos;
using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.Data.Proxies;

public class ViagensProxy : IViagensProxy
{
    private const string MAIS_BUSCADOS = "mais-buscados";
    private const string OFERTAS_KEY = "ofertas";

    private readonly IAppCache _appCache;
    private readonly IViagensApiClient _viagensApiClient;
    private readonly IAppLogger<ViagensProxy> _logger;

    public ViagensProxy(IAppCache appCache, 
                        IViagensApiClient viagensApiClient,
                        IAppLogger<ViagensProxy> logger)
    {
        _appCache = appCache;
        _viagensApiClient = viagensApiClient;
        _logger = logger;
    }

    public async Task<List<MaisBuscadosDto>> ObterMaisBuscados()
    {
        try
        {
            if (_appCache.ContainsKey(MAIS_BUSCADOS))
            {
                var cachedData = _appCache.Get<List<MaisBuscadosDto>>(MAIS_BUSCADOS);

                if (cachedData.DataExpiracao < DateTime.Now)
                    return cachedData.Dados;
            }

            var maisBuscados = await _viagensApiClient.ObterMaisBuscados();

            _appCache.AddOrUpdate(MAIS_BUSCADOS, new CacheObject<List<MaisBuscadosDto>>(maisBuscados), 
                                                 TimeSpan.FromMinutes(5));

            return maisBuscados;
        }
        catch (Exception ex)
        {
            _logger.Erro(ex, "Erro ao buscar viagens mais buscadas");
            throw;
        }
    }
}
