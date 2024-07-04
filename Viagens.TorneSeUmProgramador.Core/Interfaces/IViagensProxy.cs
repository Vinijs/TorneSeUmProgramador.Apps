using Viagens.TorneSeUmProgramador.Core.Dtos;

namespace Viagens.TorneSeUmProgramador.Core.Interfaces;

public interface IViagensProxy
{
    Task<List<MaisBuscadosDto>> ObterMaisBuscados();
}
