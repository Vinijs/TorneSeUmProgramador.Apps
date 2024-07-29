using Viagens.TorneSeUmProgramador.Core.Common.Interfaces;
using Viagens.TorneSeUmProgramador.Core.Dtos;

namespace Viagens.TorneSeUmProgramador.Business.Services.Interfaces;

public interface IBuscaService
{
    Task<IResultado<IEnumerable<MaisBuscadosDto>>> ObterViagensMaisBuscadas();
    Task<IResultado<IEnumerable<OfertaDto>>> ObterOfertas();
    Task<IResultado<IEnumerable<OfertaDto>>> ObterOfertasPaginadas(BuscaOfertasPaginadaRequest request);
}
