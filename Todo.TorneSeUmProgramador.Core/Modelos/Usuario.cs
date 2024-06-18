using System.Reflection.Metadata.Ecma335;

namespace Todo.TorneSeUmProgramador.Core.Modelos;

public class Usuario
{
    public Guid Id { get; set; } = new Guid();
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
