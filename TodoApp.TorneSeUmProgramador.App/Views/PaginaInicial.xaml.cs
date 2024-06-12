using Todo.TorneSeUmProgramador.Data.DAO;

namespace TodoApp.TorneSeUmProgramador.App.Views;

public partial class PaginaInicial : ContentPage
{
	private bool _isDarkTheme = true;
	private readonly TarefasDAO _tarefasDAO;

	public PaginaInicial()
	{
		InitializeComponent();

		_tarefasDAO = new TarefasDAO();

		TarefasCollectionView.ItemsSource = _tarefasDAO.Listar(); 
	}

    private void pesquisaEntry_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private async void AdicionarTarefa_ButtonClicked(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new AdicionarEditarTarefa(_tarefasDAO));
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

    private void SwitchTheme_Toggled(object sender, ToggledEventArgs e)
    {
		if (_isDarkTheme)
		{
			App.Current.UserAppTheme = AppTheme.Dark;
			_isDarkTheme = !_isDarkTheme;
		}
		else
		{
			App.Current.UserAppTheme = AppTheme.Light;
			_isDarkTheme = !_isDarkTheme;
		}
    }
}