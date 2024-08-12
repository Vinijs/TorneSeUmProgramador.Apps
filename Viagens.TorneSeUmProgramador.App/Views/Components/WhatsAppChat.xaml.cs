using Viagens.TorneSeUmProgramador.App.ViewModels.Components;

namespace Viagens.TorneSeUmProgramador.App.Views.Components;

public partial class WhatsAppChat : ContentView
{
	public WhatsAppChat()
	{
		InitializeComponent();
		BindingContext = App.Current.Handler.MauiContext.Services
			.GetRequiredService<WhatsAppChatViewModel>();
	}
}