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
        //var maisBuscados = _buscaService.ObterViagensMaisBuscadas().Result as ResultadoSucesso<IEnumerable<MaisBuscadosDto>>;
        MaisBuscados = new ObservableCollection<MaisBuscadosDto>();
    }

    public async Task ObterMaisBuscados()
    {
        var resultado = await _buscaService.ObterViagensMaisBuscadas();
        if (resultado is ResultadoSucesso<IEnumerable<MaisBuscadosDto>> maisBuscados)
        {
            MaisBuscados = new ObservableCollection<MaisBuscadosDto>(maisBuscados.Dados);
            return;
        }

        var falha = resultado as ResultadoFalha<IEnumerable<MaisBuscadosDto>>;
        await App.Current.MainPage.DisplayAlert("Erro", string.Join(" ", falha.Detalhe.Mensagens.Select(x => x.Texto)), "Ok");
    }
}
