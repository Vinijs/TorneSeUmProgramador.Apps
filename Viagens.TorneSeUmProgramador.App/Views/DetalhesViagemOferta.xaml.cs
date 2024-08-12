using Viagens.TorneSeUmProgramador.App.ViewModels;

namespace Viagens.TorneSeUmProgramador.App.Views;

public partial class DetalhesViagemOferta : ContentPage
{
	public DetalhesViagemOferta(DetalhesViagemOfertaViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}