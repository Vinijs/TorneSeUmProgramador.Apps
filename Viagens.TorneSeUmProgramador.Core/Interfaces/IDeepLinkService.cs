namespace Viagens.TorneSeUmProgramador.Core.Interfaces;

public interface IDeepLinkService
{
    Task<bool> AbrirWhatsappComMensagem(string? mensagem = null);
}
