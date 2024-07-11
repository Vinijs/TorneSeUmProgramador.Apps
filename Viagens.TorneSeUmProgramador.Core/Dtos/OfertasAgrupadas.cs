using System.Collections.ObjectModel;

namespace Viagens.TorneSeUmProgramador.Core.Dtos;

public class OfertasAgrupadas : ObservableCollection<OfertaDto>
{
    public string TipoPacote { get; set; }

    public OfertasAgrupadas(string tipopacote, IEnumerable<OfertaDto> ofertaDtos) 
        : base(ofertaDtos)
    {
        TipoPacote = tipopacote;
    }
}
