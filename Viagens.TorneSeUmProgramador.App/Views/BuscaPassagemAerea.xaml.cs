namespace Viagens.TorneSeUmProgramador.App.Views;

public partial class BuscaPassagemAerea : ContentPage
{
	public BuscaPassagemAerea()
	{
		InitializeComponent();
	}

    private void OnClickVoltar(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }
}