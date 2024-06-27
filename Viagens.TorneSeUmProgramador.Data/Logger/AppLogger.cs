using Microsoft.Extensions.Logging;
using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.Data.Logger;

public class AppLogger<T> : IAppLogger<T>
{
    private readonly ILogger<T> _logger;

    public AppLogger(ILogger<T> logger) 
        => _logger = logger;

    public void Aviso(string message, params object[] args) 
        => _logger.LogWarning(message, args);

    public void Debug(string message, params object[] args) 
        => _logger.LogDebug(message,args);

    public void Erro(string message, params object[] args) 
        => _logger.LogError(message,args);

    public void Erro(Exception exception, string message = null!, params object[] args) 
        => _logger.LogError(exception, message, args);

    public void Informacao(string message, params object[] args) 
        => _logger.LogInformation(message,args);
}
