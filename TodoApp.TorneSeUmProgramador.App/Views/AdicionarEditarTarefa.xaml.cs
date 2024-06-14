using CommunityToolkit.Mvvm.Messaging;
using Todo.TorneSeUmProgramador.Core.Modelos;
using TodoApp.TorneSeUmProgramador.App.Messages;

namespace TodoApp.TorneSeUmProgramador.App.Views;

public partial class AdicionarEditarTarefa : ContentPage
{
    private Tarefa _tarefa;
	public AdicionarEditarTarefa()
	{
		InitializeComponent();
	}

    public AdicionarEditarTarefa(Tarefa tarefa)
    {
        InitializeComponent();

        nomeTarefaEntry.Text = tarefa.Nome;
        descricaoTarefaEditor.Text = tarefa.Descricao;
        dataTarefaDatePicker.Date = tarefa.DataConclusao;
        _tarefa = tarefa;
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

        if(_tarefa is not null)
        {
            _tarefa.Nome = tarefa.Nome;
            _tarefa.Descricao = tarefa.Descricao;
            _tarefa.DataConclusao = tarefa.DataConclusao;

            WeakReferenceMessenger.Default.Send(new EditarTarefaMessage(_tarefa));
        }
        else
        {
            _tarefa = tarefa;
            WeakReferenceMessenger.Default.Send(new NovaTarefaMessage(_tarefa));
        }


        await Navigation.PopModalAsync();
    }
}