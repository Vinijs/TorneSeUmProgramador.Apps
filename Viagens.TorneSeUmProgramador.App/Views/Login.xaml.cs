namespace Viagens.TorneSeUmProgramador.App.Views;

public partial class Login : ContentPage
{
	private bool senhaVisivel = false;

	public Login()
	{
		InitializeComponent();
	}

    private void SenhaImage_Tapped(object sender, TappedEventArgs e)
    {
		if (senhaVisivel)
		{
            SenhaEntry.IsPassword = true;
            SenhaImage.Source = ImageSource.FromFile("eyeclosed.png");
            senhaVisivel = false;
        }
		else
		{
            SenhaEntry.IsPassword = false;
            SenhaImage.Source = ImageSource.FromFile("eyeopen.png");
            senhaVisivel = true;
        }
    }
}