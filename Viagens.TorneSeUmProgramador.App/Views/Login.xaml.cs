namespace Viagens.TorneSeUmProgramador.App.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void OnClickNavegarParaPaginaHome(object sender, EventArgs e)
    {
		//Navega��o absoluta
		Shell.Current.GoToAsync("//home");
    }
}