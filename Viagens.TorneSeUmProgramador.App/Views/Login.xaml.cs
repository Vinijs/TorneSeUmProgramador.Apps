using Viagens.TorneSeUmProgramador.App.ViewModels;

namespace Viagens.TorneSeUmProgramador.App.Views;

public partial class Login : ContentPage
{
	private readonly LoginViewModel _viewModel;
	public Login()
	{
		InitializeComponent();
		_viewModel = BindingContext as LoginViewModel;
	}

}