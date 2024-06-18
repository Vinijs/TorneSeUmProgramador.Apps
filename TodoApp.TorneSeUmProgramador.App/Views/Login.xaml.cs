using Todo.TorneSeUmProgramador.Data.DAO;
using TodoApp.TorneSeUmProgramador.App.Session;
using TodoApp.TorneSeUmProgramador.App.Storages;

namespace TodoApp.TorneSeUmProgramador.App.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
		var usuarioDAO = new UsuarioDAO();
		var email = EmailEntry.Text;
		var senha = SenhaEntry.Text;

		if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
		{
			await DisplayAlert("Erro", "Email e senha devem ser informados", "Ok");
			return;
		}

		var usuarioSalvo = await usuarioDAO.Obter();

		if(!usuarioSalvo.Senha.Equals(senha) || !usuarioSalvo.Email.Equals(email))
		{
			await DisplayAlert("Erro", "Usuário ou senha inválidos", "Ok");
		}

		UsuarioPreferencesStorage.Salvar(new UsuarioSession
		{
			Usuario = usuarioSalvo
		});

		//await Navigation.PushModalAsync(new PaginaInicial());
		App.Current.MainPage = new PaginaInicial();
    }
}