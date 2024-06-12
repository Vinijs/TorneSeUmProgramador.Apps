using Todo.TorneSeUmProgramador.Core.Modelos;
using Todo.TorneSeUmProgramador.Data.DAO;

namespace TodoApp.TorneSeUmProgramador.App.Views;

public partial class AdicionarEditarTarefa : ContentPage
{
    private readonly TarefasDAO _tarefasDAO;

	public AdicionarEditarTarefa()
	{
		InitializeComponent();
	}

    public AdicionarEditarTarefa(TarefasDAO tarefasDAO)
    {
        InitializeComponent();

        _tarefasDAO = tarefasDAO;
    }

    private async void BtnFechar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void BtnSalvar_Clicked(object sender, EventArgs e)
    {
        var tarefa = new Tarefa
        {
            Nome = nomeTarefaEntry.Text,
            Descricao = descricaoTarefaEditor.Text,
            DataConclusao = dataTarefaDatePicker.Date,
            Concluida = false
        };

        _tarefasDAO.Adicionar(tarefa);

        await Navigation.PopModalAsync();
    }
}