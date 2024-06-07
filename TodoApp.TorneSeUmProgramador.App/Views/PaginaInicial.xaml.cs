namespace TodoApp.TorneSeUmProgramador.App.Views;

public partial class PaginaInicial : ContentPage
{
	public PaginaInicial()
	{
		InitializeComponent();

		TarefasCollectionView.ItemsSource = new List<object>
		{
			new
			{
				Nome = "Tarefa 1",
				Descricao = "Descricao da tarefa 1"
			},
			new
			{
				Nome = "Tarefa 2",
				Descricao = "Descricao da tarefa 2"
			}
		};
	}

    private void pesquisaEntry_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void AdicionarTarefa_ButtonClicked(object sender, EventArgs e)
    {

    }
}