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

    public BuscaService(IAppLogger<BuscaService> logger) 
        => _logger = logger;

    public async Task<IResultado<IEnumerable<MaisBuscadosDto>>> ObterViagensMaisBuscadas()
    {

		try
		{
            _logger.Informacao("Buscando viagens mais buscadas");
			var maisBuscados = new List<MaisBuscadosDto>()
            {
                new MaisBuscadosDto
                {
                    Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Titulo = "Nova York",
                    Descricao = "Distância 2500 - mi"
                },
                new MaisBuscadosDto
                {
                    Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Titulo = "Nova York",
                    Descricao = "Distância 2500 - mi"
                },
                new MaisBuscadosDto
                {
                    Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Titulo = "Nova York",
                    Descricao = "Distância 2500 - mi"
                },
                new MaisBuscadosDto
                {
                    Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Titulo = "Nova York",
                    Descricao = "Distância 2500 - mi"
                },
                new MaisBuscadosDto
                {
                    Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                    Titulo = "Nova York",
                    Descricao = "Distância 2500 - mi"
                }
            };

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
