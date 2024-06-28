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
    private readonly IViagensApiClient _viagensApiClient;

    public BuscaService(IAppLogger<BuscaService> logger, 
                        IViagensApiClient viagensApiClient)
    {
        _logger = logger;
        _viagensApiClient = viagensApiClient;
    }

    public async Task<IResultado<IEnumerable<MaisBuscadosDto>>> ObterViagensMaisBuscadas()
    {

		try
		{
            _logger.Informacao("Buscando viagens mais buscadas");

            var maisBuscados = await _viagensApiClient.ObterMaisBuscados();
 
            return Resultado.Sucesso<IEnumerable<MaisBuscadosDto>>(maisBuscados);
        }
		catch (Exception ex)
		{
            _logger.Erro(ex, "Erro ao buscar viagens mais buscadas");
			return Resultado.Falha<IEnumerable<MaisBuscadosDto>>
                (CodigoErro.ErroInterno, "Ocorreu um erro ao buscar viagens! Tente mais tarde");
		}
    }
}
