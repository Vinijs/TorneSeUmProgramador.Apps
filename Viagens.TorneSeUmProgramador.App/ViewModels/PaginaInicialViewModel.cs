using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Viagens.TorneSeUmProgramador.Business.Services.Interfaces;
using Viagens.TorneSeUmProgramador.Core.Common;
using Viagens.TorneSeUmProgramador.Core.Dtos;

namespace Viagens.TorneSeUmProgramador.App.ViewModels;

public sealed partial class PaginaInicialViewModel : ObservableObject
{
    private readonly IBuscaService _buscaService;

    [ObservableProperty]
    private ObservableCollection<MaisBuscadosDto> maisBuscados;
    public PaginaInicialViewModel(IBuscaService buscaService)
    {
        _buscaService = buscaService;
        var maisBuscados = _buscaService.ObterViagensMaisBuscadas().Result as ResultadoSucesso<IEnumerable<MaisBuscadosDto>>;
        MaisBuscados = new ObservableCollection<MaisBuscadosDto>(maisBuscados.Dados);
    }
}
