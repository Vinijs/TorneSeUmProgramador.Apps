using System.Text.Json;
using Todo.TorneSeUmProgramador.Core.Modelos;

namespace TodoApp.TorneSeUmProgramador.App.Storages;

public static class TarefaPreferencesStorage
{
    private const string TAREFAS = "tarefas";

    public static void Salvar(Tarefa tarefa)
    {
        List<Tarefa> tarefas;

        if (Preferences.Default.ContainsKey(TAREFAS))
        {
            tarefas = JsonSerializer.
                Deserialize<List<Tarefa>>(Preferences.Default.Get(TAREFAS, string.Empty));
        }
        else
        {
            tarefas = new List<Tarefa>();
        }

        tarefas.Add(tarefa);

        Preferences.Default.Set(TAREFAS, JsonSerializer.Serialize(tarefas));
    }

    public static void Atualizar(Tarefa tarefa)
    {
        if (!Preferences.Default.ContainsKey(TAREFAS))
            return;

        var tarefas = JsonSerializer
            .Deserialize<List<Tarefa>>(Preferences.Default.Get(TAREFAS, string.Empty));

        var tarefaAtualizada = tarefas.FirstOrDefault(x => x.Id == tarefa.Id);

        tarefaAtualizada.Nome = tarefa.Nome;
        tarefaAtualizada.Descricao = tarefa.Descricao;
        tarefaAtualizada.DataConclusao = tarefa.DataConclusao;

        Preferences.Default.Set(TAREFAS, JsonSerializer.Serialize(tarefas));
    }

    public static void Excluir(Tarefa tarefa)
    {
        if (!Preferences.Default.ContainsKey(TAREFAS))
            return;

        var tarefas = JsonSerializer
            .Deserialize<List<Tarefa>>(Preferences.Default.Get(TAREFAS, string.Empty));

        var tarefaExistente = tarefas.FirstOrDefault(x => x.Id == tarefa.Id);

        tarefas.Remove(tarefaExistente);

        Preferences.Default.Get(TAREFAS, JsonSerializer.Serialize(tarefas));
    }

    public static List<Tarefa> Listar()
    {
        if(!Preferences.Default.ContainsKey(TAREFAS)) 
            return new List<Tarefa>();

        return JsonSerializer
            .Deserialize<List<Tarefa>>(Preferences.Default.Get(TAREFAS, string.Empty));
    }

    public static void Limpar()
    {
        if (!Preferences.Default.ContainsKey(TAREFAS))
            return;

        Preferences.Default.Remove(TAREFAS);
    }

    //public static void Reset()
    //{
    //    Preferences.Default.Clear();
    //}
}
