using CommunityToolkit.Mvvm.ComponentModel;
using Viagens.TorneSeUmProgramador.Core.Dtos;

namespace Viagens.TorneSeUmProgramador.App.ViewModels;

[QueryProperty(nameof(Oferta), "detalheOferta")]
public partial class DetalhesViagemOfertaViewModel : ObservableObject
{
    [ObservableProperty]
    public DetalheOfertaViagemDto oferta;
}
