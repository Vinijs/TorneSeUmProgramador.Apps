using Viagens.TorneSeUmProgramador.App.ViewModels;

namespace Viagens.TorneSeUmProgramador.App.Views;

public partial class PaginaInicial : ContentPage
{
	public PaginaInicial(PaginaInicialViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
		var vm = BindingContext as PaginaInicialViewModel;

		if (vm != null) 
		{
			await vm.ObterMaisBuscados();
		}
        base.OnNavigatedTo(args);
    }
}