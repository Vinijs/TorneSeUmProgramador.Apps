using Viagens.TorneSeUmProgramador.App.ViewModels;

namespace Viagens.TorneSeUmProgramador.App.Views;

public partial class PaginaInicial : ContentPage
{
	public PaginaInicial(PaginaInicialViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}