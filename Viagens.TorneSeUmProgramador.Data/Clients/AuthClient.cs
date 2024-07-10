using Flurl.Http;
using Flurl.Http.Configuration;
using Viagens.TorneSeUmProgramador.Core.Dtos;
using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.Data.Clients;

public sealed class AuthClient : IAuthClient
{
    private const string _login = "usuarios/login";

    private readonly IFlurlClient _flurlClient;
    private readonly IAppLogger<AuthClient> _logger;

    public AuthClient(IFlurlClientCache flurlClientCache, IAppLogger<AuthClient> logger)
    {
        _flurlClient = flurlClientCache.Get("auth-api-client");
        _logger = logger;
    }

    public async Task<ResultadoLoginDto> Login(LoginDto loginDto)
    {
        try
        {
            return await _flurlClient.Request(_login)
                .PostJsonAsync(loginDto)
                .ReceiveJson<ResultadoLoginDto>();
        }
        catch (FlurlHttpException ex)
        {
            _logger.Erro(ex, "Erro ao realizar login");
            throw;
        }
    }
}
