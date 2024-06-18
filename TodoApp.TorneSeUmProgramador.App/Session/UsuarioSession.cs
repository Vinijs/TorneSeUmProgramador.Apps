using Todo.TorneSeUmProgramador.Core.Modelos;

namespace TodoApp.TorneSeUmProgramador.App.Session;

public class UsuarioSession
{
    private const int _tempoSessaoEmHoras = 8;

    public static UsuarioSession Instance = new();

    public Usuario Usuario { get; set; }
    public DateTime DataExpiracaoSessao { get; set; }

    public UsuarioSession()
    {
        DataExpiracaoSessao = DateTime.Now.AddHours(_tempoSessaoEmHoras);
    }
}
