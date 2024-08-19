using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.App.ViewModels.Components;

public partial class WhatsAppChatViewModel : ObservableObject
{
    private readonly IDeepLinkService _deepLinkService;

    public WhatsAppChatViewModel(IDeepLinkService deepLinkService)
    {
        _deepLinkService = deepLinkService;
    }

    [RelayCommand]
    public async Task EnviarMensagem(string url)
    {
        var sucesso = await _deepLinkService.AbrirWhatsappComMensagem();

        if (!sucesso)
        {
            await App.Current.MainPage.DisplayAlert("Erro", "Não foi possível abrir o Whatsapp", "Ok");
        }
    }
}
