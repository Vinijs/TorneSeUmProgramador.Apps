using Viagens.TorneSeUmProgramador.Core.Dtos;

namespace Viagens.TorneSeUmProgramador.Core.Interfaces;

public interface IViagensApiClient
{
    Task<List<MaisBuscadosDto>> ObterMaisBuscados();
    Task<List<OfertaDto>> ObterOfertas();
}
