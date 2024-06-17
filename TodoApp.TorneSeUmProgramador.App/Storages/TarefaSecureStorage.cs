using System.Text.Json;
using Todo.TorneSeUmProgramador.Core.Modelos;

namespace TodoApp.TorneSeUmProgramador.App.Storages;

public static class TarefaSecureStorage
{
    private const string TAREFAS = "tarefas";

    public static async Task Salvar(Tarefa tarefa)
    {
        List<Tarefa> tarefas;

        var tarefasJson = await SecureStorage.Default.GetAsync(TAREFAS);

        if (!string.IsNullOrWhiteSpace(tarefasJson))
        {
            tarefas = JsonSerializer.Deserialize<List<Tarefa>>(tarefasJson);
        }
        else
        {
            tarefas = new List<Tarefa>();
        }

        tarefas.Add(tarefa);
        await SecureStorage.Default.SetAsync(TAREFAS, JsonSerializer.Serialize(tarefas));
    }

    public static async Task Atualizar(Tarefa tarefa)
    {
        var tarefasJson = await SecureStorage.Default.GetAsync(TAREFAS);

        if (string.IsNullOrWhiteSpace(tarefasJson))
            return;

        var tarefas = JsonSerializer.Deserialize<List<Tarefa>>(tarefasJson);

        var tarefaAtualizada = tarefas.FirstOrDefault(x => x.Id == tarefa.Id);

        tarefaAtualizada.Nome = tarefa.Nome;
        tarefaAtualizada.Descricao = tarefa.Descricao;
        tarefaAtualizada.DataConclusao = tarefa.DataConclusao;

        await SecureStorage.Default.SetAsync(TAREFAS, JsonSerializer.Serialize(tarefas));
    }

    public static async Task Excluir(Tarefa tarefa)
    {
        var tarefasJson = await SecureStorage.Default.GetAsync(TAREFAS);

        if(string.IsNullOrWhiteSpace(tarefasJson)) 
            return;

        var tarefas = JsonSerializer.Deserialize<List<Tarefa>>(tarefasJson);

        var tarefaExistente = tarefas.FirstOrDefault(x => x.Id == tarefa.Id);

        tarefas.Remove(tarefaExistente);

        await SecureStorage.Default.SetAsync(TAREFAS, JsonSerializer.Serialize(tarefas));
    }

    public static async Task<List<Tarefa>> Listar()
    {
        var tarefasJson = await SecureStorage.Default.GetAsync(TAREFAS);

        if(string.IsNullOrWhiteSpace(tarefasJson))
            return new List<Tarefa>();

        return JsonSerializer.Deserialize<List<Tarefa>>(tarefasJson);
    }

    public static void Limpar() 
        => SecureStorage.Default.Remove(TAREFAS);
}
