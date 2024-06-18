using Microsoft.EntityFrameworkCore;
using Todo.TorneSeUmProgramador.Core.Modelos;
using Todo.TorneSeUmProgramador.Data.Contexto;

namespace Todo.TorneSeUmProgramador.Data.DAO;

public class UsuarioDAO
{
    private readonly TodoAppContexto _contexto;

    public UsuarioDAO()
    {
        _contexto = new TodoAppContexto();
    }

    public async Task Adicionar(Usuario usuario)
    {
        await _contexto.Usuarios.AddAsync(usuario);
        await _contexto.SaveChangesAsync();
    }

    public async Task Atualizar(Usuario usuario)
    {
        _contexto.Update(usuario);
        await _contexto.SaveChangesAsync();
    }

    public async Task Remover(Usuario usuario)
    {
        _contexto.Remove(usuario);
        await _contexto.SaveChangesAsync();
    }

    public async Task<Usuario> Obter() 
        => await _contexto.Usuarios.FirstOrDefaultAsync();
}
