using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using Todo.TorneSeUmProgramador.Core.Modelos;
using Todo.TorneSeUmProgramador.Data.DAO;
using TodoApp.TorneSeUmProgramador.App.Messages;

namespace TodoApp.TorneSeUmProgramador.App.Views;

public partial class PaginaInicial : ContentPage
{
	private bool _isDarkTheme = true;
	private bool _tarefasCarregadas = false;
	private TarefasDAO _tarefasDAO;
	private ObservableCollection<Tarefa> _tarefas;

	public PaginaInicial()
	{
		InitializeComponent();
        _tarefasDAO = new TarefasDAO();

        WeakReferenceMessenger.Default.Register<NovaTarefaMessage>(this, async (x, y) =>
		{
			_tarefas.Add(y.Value);
			await _tarefasDAO.Adicionar(y.Value);
		});

		WeakReferenceMessenger.Default.Register<EditarTarefaMessage>(this, async (x,y) =>
		{
			var tarefas = _tarefas.Where(x => x.Id != y.Value.Id).ToList();

			_tarefas = new ObservableCollection<Tarefa>(tarefas)
            {
                y.Value
            };

            TarefasCollectionView.ItemsSource = null;

            TarefasCollectionView.ItemsSource = _tarefas;

			await _tarefasDAO.Atualizar(y.Value);
		});
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

		if (!_tarefasCarregadas)
		{            
			var tarefasSalvas = await _tarefasDAO.Listar();

			_tarefas = new ObservableCollection<Tarefa>(tarefasSalvas);

			TarefasCollectionView.ItemsSource = _tarefas; 
			
			_tarefasCarregadas = true;
		}

    }

    private void pesquisaEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
		if (string.IsNullOrWhiteSpace(e.NewTextValue))
		{
			TarefasCollectionView.ItemsSource = _tarefas;
		}
		else
		{
			TarefasCollectionView.ItemsSource = _tarefas.Where(x => x.Nome.Contains(e.NewTextValue));
		}
    }

    private async void AdicionarTarefa_ButtonClicked(object sender, EventArgs e)
    {
		var modal = new AdicionarEditarTarefa();
		//modal.Disappearing += (s, args) =>
		//{
		//	TarefasCollectionView.ItemsSource = new ObservableCollection<Tarefa>(_tarefasDAO.Listar());
		//};


		await Navigation.PushModalAsync(modal);
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

    private async void AoTocarTarefaIrParaEditar(object sender, TappedEventArgs e)
    {
		var tarefa = (Tarefa)e.Parameter;
		var modal = new AdicionarEditarTarefa(tarefa);

		await Navigation.PushModalAsync(modal);
    }

    private async void DeletarTarefaSwipeInvoke(object sender, EventArgs e)
    {
		var swipeItem = (SwipeItem)sender;
		var tarefa = (Tarefa)swipeItem.CommandParameter;
		
		_tarefas.Remove(tarefa);
		await _tarefasDAO.Remover(tarefa);
    }
}