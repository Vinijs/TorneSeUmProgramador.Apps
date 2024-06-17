using Microsoft.EntityFrameworkCore;
using Todo.TorneSeUmProgramador.Core.Modelos;
using Todo.TorneSeUmProgramador.Data.Contexto;

namespace Todo.TorneSeUmProgramador.Data.DAO;

public class TarefasDAO
{
    private static readonly TodoAppContexto _contexto;

    static TarefasDAO()
    {
        _contexto = new TodoAppContexto();
    }

    public async Task Adicionar(Tarefa tarefa)
    {
        await _contexto.Tarefas.AddAsync(tarefa);
        await _contexto.SaveChangesAsync();
    }

    public async Task Adicionar(List<Tarefa> tarefas)
    {
        await _contexto.Tarefas.AddRangeAsync(tarefas);
        await _contexto.SaveChangesAsync();
    }

    public async Task Atualizar(Tarefa tarefa)
    {
        _contexto.Update(tarefa);
        await _contexto.SaveChangesAsync();
    }

    public async Task Remover(Tarefa tarefa)
    {
        _contexto.Remove(tarefa);
        await _contexto.SaveChangesAsync();
    }

    public async Task<List<Tarefa>> Listar()
        => await _contexto.Tarefas.ToListAsync();

    public void CriarBancodeDados()
    {
        _contexto.Database.EnsureCreated();
    }

    //public void DeletarBancodeDados()
    //{
    //    _contexto.Database.EnsureDeleted();
    //}

    public void AplicarAtualizacoesBancoDeDados()
    {
        _contexto.Database.Migrate();
    }
}
