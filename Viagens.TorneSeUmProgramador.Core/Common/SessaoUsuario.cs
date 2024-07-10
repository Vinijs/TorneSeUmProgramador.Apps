namespace Viagens.TorneSeUmProgramador.Core.Common;

public class SessaoUsuario
{
    public string NomeUsuario { get; set; } = "Usuário";
    public string FotoUsuario { get; set; } = "avatar_user.png";
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? DataExpiracaoToken { get; set; }

}
