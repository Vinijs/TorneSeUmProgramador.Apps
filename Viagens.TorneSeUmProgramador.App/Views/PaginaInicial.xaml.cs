namespace Viagens.TorneSeUmProgramador.App.Views;

public partial class PaginaInicial : ContentPage
{
	public PaginaInicial()
	{
		InitializeComponent();
	}

    private void OnClickNavegarParaPassagensAereas(object sender, EventArgs e)
    {
		//Navegação relativa
		Shell.Current.GoToAsync("/busca-passagem-aerea");
    }
}