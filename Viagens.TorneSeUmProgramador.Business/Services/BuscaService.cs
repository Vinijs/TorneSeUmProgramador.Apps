using Viagens.TorneSeUmProgramador.Business.Services.Interfaces;
using Viagens.TorneSeUmProgramador.Core.Common;
using Viagens.TorneSeUmProgramador.Core.Common.Interfaces;
using Viagens.TorneSeUmProgramador.Core.Dtos;
using Viagens.TorneSeUmProgramador.Core.Enums;
using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.Business.Services;

public class BuscaService : IBuscaService
{
    private readonly IAppLogger<BuscaService> _logger;
    private readonly IViagensProxy _viagensProxy;
    private readonly ILocalizacaoService _localizacaoService;

    public BuscaService(IAppLogger<BuscaService> logger,
                        IViagensProxy viagensProxy,
                        ILocalizacaoService localizacaoService)
    {
        _logger = logger;
        _viagensProxy = viagensProxy;
        _localizacaoService = localizacaoService;
    }

    public async Task<IResultado<IEnumerable<MaisBuscadosDto>>> ObterViagensMaisBuscadas()
    {

		try
		{
            _logger.Informacao("Buscando viagens mais buscadas");

            var maisBuscados = await _viagensProxy.ObterMaisBuscados();

            foreach (var viagem in maisBuscados)
            {
                _ = double.TryParse(viagem.Latitude, out double latitude);
                _ = double.TryParse(viagem.Longitude, out double longitude);
                var dadosDestino = (latitude,  longitude);
                var distancia = await _localizacaoService.CalcularDistancia(dadosDestino);
                viagem.Distancia = $"{distancia} km";
            }

            return Resultado.Sucesso<IEnumerable<MaisBuscadosDto>>(maisBuscados);
        }
		catch (Exception ex)
		{
            _logger.Erro(ex, "Erro ao buscar viagens mais buscadas");
			return Resultado.Falha<IEnumerable<MaisBuscadosDto>>
                (CodigoErro.ErroInterno, "Ocorreu um erro ao buscar viagens! Tente mais tarde");
		}
    }

    public async Task<IResultado<IEnumerable<OfertaDto>>> ObterOfertas()
    {
        try
        {
            _logger.Informacao("Iniciando buscas ofertas ");

            var ofertas = await _viagensProxy.ObterOfertas();

            return Resultado.Sucesso<IEnumerable<OfertaDto>>(ofertas);
        }
        catch (Exception ex)
        {
            _logger.Erro(ex, "Erro ao buscar ofertas");
            return Resultado.Falha<IEnumerable<OfertaDto>>
                (CodigoErro.ErroInterno, "Ocorreu um erro ao buscar ofertas! Tente mais tarde");
        }
    }

    public async Task<IResultado<IEnumerable<OfertaDto>>> ObterOfertasPaginadas(BuscaOfertasPaginadaRequest request)
    {
        try
        {
            _logger.Informacao("Iniciando buscas ofertas paginadas");

            var ofertas = await _viagensProxy.ObterOfertasPaginadas(request);

            return Resultado.Sucesso<IEnumerable<OfertaDto>>(ofertas);
        }
        catch (Exception ex)
        {
            _logger.Erro(ex, "Erro ao buscar ofertas paginadas");
            return Resultado.Falha<IEnumerable<OfertaDto>>
                (CodigoErro.ErroInterno, "Ocorreu um erro ao buscar ofertas paginadas! Tente mais tarde");
        }
    }
}
