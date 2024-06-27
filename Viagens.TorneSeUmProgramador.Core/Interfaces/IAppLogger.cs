namespace Viagens.TorneSeUmProgramador.Core.Interfaces;

public interface IAppLogger<out T>
{
    void Debug(string message, params object[] args);
    void Informacao(string message, params object[] args);
    void Aviso(string message, params object[] args);
    void Erro(string message, params object[] args);
    void Erro(Exception ex, string message = null!, params object[] args);
}
