using Microsoft.VisualBasic;
using Viagens.TorneSeUmProgramador.Business.Services.Interfaces;
using Viagens.TorneSeUmProgramador.Core.Cache;
using Viagens.TorneSeUmProgramador.Core.Common;
using Viagens.TorneSeUmProgramador.Core.Common.Interfaces;
using Viagens.TorneSeUmProgramador.Core.Constantes;
using Viagens.TorneSeUmProgramador.Core.Dtos;
using Viagens.TorneSeUmProgramador.Core.Enums;
using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.Business.Services;

public class AuthService : IAuthService
{
    private readonly IAuthClient _authClient;
    private readonly IAppCache _appCache;
    private readonly IAppLogger<AuthService> _logger;

    public AuthService(IAuthClient authClient, IAppCache appCache, IAppLogger<AuthService> logger)
    {
        _authClient = authClient;
        _appCache = appCache;
        _logger = logger;
    }

    public async Task<IResultado<ResultadoLoginDto>> RealizarAutenticacaoUsuario(LoginDto loginDto)
    {
        try
        {
            var resultado = await _authClient.Login(loginDto);

            if (resultado is not null)
            {
                var sessaoUsuarioCache = _appCache.Get<SessaoUsuario>(AppConstants.CACHE_SESSAO_USUARIO)?.Dados;

                    sessaoUsuarioCache ??= new SessaoUsuario();    

                    sessaoUsuarioCache.Token = resultado.AccessToken;
                    sessaoUsuarioCache.RefreshToken = resultado.RefreshToken;
                    sessaoUsuarioCache.DataExpiracaoToken = resultado.Expiration;
                    _appCache.AddOrUpdate(AppConstants.CACHE_SESSAO_USUARIO, 
                        new CacheObject<SessaoUsuario>(sessaoUsuarioCache),
                        TimeSpan.FromDays(AppConstants.CACHE_SESSAO_USUARIO_EXPIRACAO_DIAS));
                
                return Resultado.Sucesso(resultado);
            }

            return Resultado.Falha<ResultadoLoginDto>(CodigoErro.ErroNegocio, "Erro ao realizar autenticação do usúário");
        }
        catch (Exception ex)
        {
            _logger.Erro(ex, "Erro ao realizar autenticação do usuário");
            return Resultado.Falha<ResultadoLoginDto>(CodigoErro.ErroInterno,
                    "Erro ao realizar autenticação do usuário");
        }
    }
}
