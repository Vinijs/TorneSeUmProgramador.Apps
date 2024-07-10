using Viagens.TorneSeUmProgramador.Core.Dtos;

namespace Viagens.TorneSeUmProgramador.Core.Interfaces;

public interface IAuthClient
{
    Task<ResultadoLoginDto> Login(LoginDto loginDto);
}
