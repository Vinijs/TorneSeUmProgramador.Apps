namespace Todo.TorneSeUmProgramador.Core.Modelos;

public class Tarefa
{
    public string Nome  { get; set; }
    public string Descricao { get; set; }
    public DateTime DataConclusao { get; set; }
    public bool Concluida { get; set; }
}
