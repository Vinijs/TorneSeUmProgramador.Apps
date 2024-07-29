using Viagens.TorneSeUmProgramador.App.Views;

namespace Viagens.TorneSeUmProgramador.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("home/busca-passagem-aerea", typeof(BuscaPassagemAerea));
            Routing.RegisterRoute("ofertas/detalhes-viagem-oferta", typeof(DetalhesViagemOferta));
        }
    }
}
