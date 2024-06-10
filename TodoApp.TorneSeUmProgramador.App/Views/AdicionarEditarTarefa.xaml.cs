using Todo.TorneSeUmProgramador.Core.Modelos;

namespace TodoApp.TorneSeUmProgramador.App.Views;

public partial class AdicionarEditarTarefa : ContentPage
{
	public AdicionarEditarTarefa()
	{
		InitializeComponent();
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

        await Navigation.PopModalAsync();
    }
}