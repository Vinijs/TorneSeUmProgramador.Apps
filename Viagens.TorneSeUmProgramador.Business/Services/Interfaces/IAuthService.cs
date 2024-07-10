using Viagens.TorneSeUmProgramador.Core.Common.Interfaces;
using Viagens.TorneSeUmProgramador.Core.Dtos;

namespace Viagens.TorneSeUmProgramador.Business.Services.Interfaces;

public interface IAuthService
{
    Task<IResultado<ResultadoLoginDto>> RealizarAutenticacaoUsuario(LoginDto loginDto);
}
