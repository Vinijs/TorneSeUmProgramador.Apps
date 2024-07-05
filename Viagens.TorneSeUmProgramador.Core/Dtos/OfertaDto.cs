using Viagens.TorneSeUmProgramador.Core.Enums;

namespace Viagens.TorneSeUmProgramador.Core.Dtos;

public class OfertaDto
{
    public string? Imagem { get; set; }
    public string? Titulo { get; set; }
    public string? Local { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public string? Preco { get; set; }
    public string? PrecoAnterior { get; set; }
    public string? Data { get; set; }
    public string? TipoPacote { get; set; }
}
