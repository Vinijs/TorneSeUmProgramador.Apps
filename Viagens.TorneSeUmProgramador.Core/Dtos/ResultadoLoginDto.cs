using System.Text.Json.Serialization;

namespace Viagens.TorneSeUmProgramador.Core.Dtos;

public class ResultadoLoginDto
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("expiration")]
    public DateTime Expiration { get; set; }

    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; set; }

    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }

    [JsonPropertyName("user_id")]
    public int UsuarioId { get; set; }

    [JsonPropertyName("user_name")]
    public string? UserName { get; set; }
}
