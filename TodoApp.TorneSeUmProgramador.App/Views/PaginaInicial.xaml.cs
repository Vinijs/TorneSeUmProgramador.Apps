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
				Descricao = "Descricao da tarefa 1",
				Concluida = false
			},
			new
			{
				Nome = "Tarefa 2",
				Descricao = "Descricao da tarefa 2",
				Concluida = true,
			}
		};
	}

    private void pesquisaEntry_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private async void AdicionarTarefa_ButtonClicked(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new AdicionarEditarTarefa());
	}

    #region Exemplos de código
    private void ExemplosCompilacaoCondicional()
	{
#if ANDROID
		DisplayAlert("Android", "Adiciona Tarefa", "OK");
#endif

#if WINDOWS
		DisplayAlert("Windows","Adicionar tarefa","OK");
#endif
    }

    //  protected override void OnSizeAllocated(double width, double height)
    //  {
    //pesquisaEntry.WidthRequest = width - 100;
    //pesquisaEntry.HorizontalOptions = LayoutOptions.Center;

    //      base.OnSizeAllocated(width, height);
    //  }

    #endregion


}