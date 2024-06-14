using Todo.TorneSeUmProgramador.Core.Modelos;
using Todo.TorneSeUmProgramador.Data.Contexto;

namespace Todo.TorneSeUmProgramador.Data.DAO;

public class TarefasDAO
{
    private static readonly TodoAppContextoFake _contexto;

    static TarefasDAO()
    {
        _contexto = new TodoAppContextoFake();
    }

    public void Adicionar(Tarefa tarefa)
    {
        _contexto.Tarefas.Add(tarefa);
    }

    public void Adicionar(List<Tarefa> tarefas)
    {
        _contexto.Tarefas.AddRange(tarefas);
    }

    public void Atualizar(Tarefa tarefa)
    {
        var tarefaExistente = _contexto.Tarefas.FirstOrDefault(x => x.Nome.Equals(tarefa.Nome, StringComparison.InvariantCultureIgnoreCase));

        if (tarefaExistente != null)
        {
            tarefaExistente.Descricao = tarefa.Descricao;
            tarefaExistente.DataConclusao = tarefa.DataConclusao;
            tarefaExistente.Concluida = tarefa.Concluida;
        }
    }

    public void Remover(Tarefa tarefa)
    {
        var tarefaExistente = _contexto.Tarefas.FirstOrDefault(x => x.Nome.Equals(tarefa.Nome, StringComparison.InvariantCultureIgnoreCase));

        if (tarefaExistente != null)
        {
            _contexto.Tarefas.Remove(tarefaExistente);
        }
    }

    public List<Tarefa> Listar()
        => _contexto.Tarefas;
}
