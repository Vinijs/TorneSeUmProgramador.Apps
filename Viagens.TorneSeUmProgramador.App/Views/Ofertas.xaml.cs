using Viagens.TorneSeUmProgramador.App.ViewModels;

namespace Viagens.TorneSeUmProgramador.App.Views;

public partial class Ofertas : ContentPage
{
	public Ofertas(OfertasViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (BindingContext is OfertasViewModel vm)
            await vm.ObterOfertas();

        base.OnNavigatedTo(args);
    }
}