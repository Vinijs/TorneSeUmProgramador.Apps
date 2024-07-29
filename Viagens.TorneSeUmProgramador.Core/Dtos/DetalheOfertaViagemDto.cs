namespace Viagens.TorneSeUmProgramador.Core.Dtos;

public class DetalheOfertaViagemDto
{
    public int Id { get; set; }
    public string ImagemUrl { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Latitude { get; set; }
    public string Longetude { get; set; }
    public string PrecoAtual { get; set; }
    public string PrecoOriginal { get; set; }
    public string Periodo { get; set; }
    public string TipoPacote { get; set; }
    public string DescricaoDetalhada { get; set; }
    public List<string> Inclusoes { get; set; }
    public List<string> Exclusoes { get; set; }
    public List<string> DatasDisponiveis { get; set; }
    public string PoliticaCancelamento { get; set; }
    public List<AvaliacaoDto> Avaliacoes { get; set; }
    public string InformacoesContato { get; set; }
    public List<string> OpcoesPagamento { get; set; }
    public List<string> Imagens { get; set; }
    public List<string> Videos { get; set; }
    public List<string> Itinerario { get; set; }
    public string SeguroViagem { get; set; }
}
