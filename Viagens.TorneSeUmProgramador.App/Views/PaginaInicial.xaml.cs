namespace Viagens.TorneSeUmProgramador.App.Views;

public partial class PaginaInicial : ContentPage
{
	public PaginaInicial()
	{
		InitializeComponent();

		CarouselViewPrincipal.ItemsSource = new List<object>
		{
			new
			{
				Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
				Titulo = "Nova York",
				Descricao = "Distância 2500 - mi"
			},
            new
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Nova York",
                Descricao = "Distância 2500 - mi"
            },
            new
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Nova York",
                Descricao = "Distância 2500 - mi"
            },
            new
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Nova York",
                Descricao = "Distância 2500 - mi"
            },
            new
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Nova York",
                Descricao = "Distância 2500 - mi"
            }
        };
	}
}