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

    public Task<DetalheOfertaViagemDto> ObterDetalheOferta(int id)
    {
        try
        {
            return _viagensApiClient.ObterDetalheOferta(id);
        }
        catch (Exception ex)
        {
            _logger.Erro(ex, "Erro ao buscar detalhes ofertas");
            throw;
        }
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

    public async Task<List<OfertaDto>> ObterOfertas()
    {
        try
        {
            if (_appCache.ContainsKey(OFERTAS_KEY))
            {
                var cacheData = _appCache.Get<List<OfertaDto>>(OFERTAS_KEY);

                if (cacheData.DataExpiracao < DateTime.Now)
                    return cacheData.Dados;
            }

            var ofertas = await _viagensApiClient.ObterOfertas();

            _appCache.AddOrUpdate(OFERTAS_KEY, new CacheObject<List<OfertaDto>>(ofertas),
                TimeSpan.FromMinutes(5));

            return ofertas;
        }
        catch (Exception ex)
        {
            _logger.Erro(ex, "Erro ao buscar ofertas");
            throw;
        }
    }

    public async Task<List<OfertaDto>> ObterOfertasPaginadas(BuscaOfertasPaginadaRequest request)
    {
        try
        {
            var ofertas = await _viagensApiClient.ObterOfertasPaginadas(request);

            return ofertas;
        }
        catch (Exception ex)
        {
            _logger.Erro(ex, "Erro ao buscar ofertas paginadas");
            throw;
        }
    }
}
