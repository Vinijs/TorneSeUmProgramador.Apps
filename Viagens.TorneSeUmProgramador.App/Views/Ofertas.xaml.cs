using Viagens.TorneSeUmProgramador.Core.Enums;

namespace Viagens.TorneSeUmProgramador.App.Views;

public partial class Ofertas : ContentPage
{
	public Ofertas()
	{
		InitializeComponent();

		OfertasCollection.ItemsSource = new List<object>
        {
            new
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Nova York",
                Local = "Nova York, EUA",
                Preco = "R$ 1500,00",
                PrecoAnterior = "R$ 2000,00",
                Tipo = "Pacote Completo",
                Data = "Fev - Mar 2024",
                TipoPacote = TipoPacote.PassagemAerea
            },
            new
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Africa",
                Local = "Nova Deli, AFR",
                Preco = "R$ 1500,00",
                PrecoAnterior = "R$ 2000,00",
                Data = "Fev - Mar 2024",
                TipoPacote = TipoPacote.Hospedagem
            },
            new
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Canadá",
                Local = "Van Couver, CAN",
                Preco = "R$ 1500,00",
                PrecoAnterior = "R$ 2000,00",
                Data = "Fev - Mar 2024",
                TipoPacote = TipoPacote.PassagemTerrestre
            },
            new
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "China",
                Local = "Hong Kong, CH",
                Preco = "R$ 1500,00",
                PrecoAnterior = "R$ 2000,00",
                Data = "Fev - Mar 2024",
                TipoPacote = TipoPacote.Completo
            },
            new
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Brasil",
                Local = "São Paulo, BR",
                Preco = "R$ 1500,00",
                PrecoAnterior = "R$ 2000,00",
                Data = "Fev - Mar 2024",
                TipoPacote = TipoPacote.PassagemAerea
            },
            new
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Argentina",
                Local = "Buenos Aires, ARG",
                Preco = "R$ 1500,00",
                PrecoAnterior = "R$ 2000,00",
                Data = "Fev - Mar 2024",
                TipoPacote = TipoPacote.Hospedagem
            }
        };
    }
}