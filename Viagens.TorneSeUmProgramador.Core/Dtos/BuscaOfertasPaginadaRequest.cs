namespace Viagens.TorneSeUmProgramador.Core.Dtos;

public class BuscaOfertasPaginadaRequest
{
    public int Pagina { get; set; }
    public int QuantidadePorPagina { get; set; }
    public string TipoOferta { get; set; } = string.Empty;
}
