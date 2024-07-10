using Viagens.TorneSeUmProgramador.App.ViewModels;

namespace Viagens.TorneSeUmProgramador.App.Views;

public partial class Login : ContentPage
{
	public Login(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}