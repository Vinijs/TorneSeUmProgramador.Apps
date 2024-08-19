using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.App.AppServices;

public class DeepLinkService : IDeepLinkService
{
    private readonly ILauncher _launcher;
    private readonly IAppLogger<DeepLinkService> _logger;

    private const string NUMERO_WHATSAPP = "5516991364223";
    private const string MENSAGEM_WHATSAPP = "Olá, gostaria de saber mais sobre as viagens oferecidas pela empresa";
    private const string URL_WHATSAPP = "https://wa.me/{0}?text?{1}";

    public DeepLinkService(ILauncher launcher, IAppLogger<DeepLinkService> logger)
    {
        _launcher = launcher;
        _logger = logger;
    }

    public async Task<bool> AbrirWhatsappComMensagem(string mensagem = null)
    {
        try
        {
            string mensagemParaEnvio = mensagem;
            if (string.IsNullOrWhiteSpace(mensagemParaEnvio))
            {
                mensagemParaEnvio = MENSAGEM_WHATSAPP;
            }
            var mensagemFormatada = Uri.EscapeDataString(mensagemParaEnvio);
            var url = string.Format(URL_WHATSAPP, NUMERO_WHATSAPP, mensagemFormatada);
            var uri = new Uri(url);

            return await _launcher.OpenAsync(uri);
        }
        catch (Exception ex)
        {
            _logger.Erro(ex, "Erro ao abrir o Whatsapp");
            return false;
        }
    }
}
