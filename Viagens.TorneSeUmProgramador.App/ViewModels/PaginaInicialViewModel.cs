using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Viagens.TorneSeUmProgramador.Business.Services.Interfaces;
using Viagens.TorneSeUmProgramador.Core.Common;
using Viagens.TorneSeUmProgramador.Core.Dtos;

namespace Viagens.TorneSeUmProgramador.App.ViewModels;

public sealed partial class PaginaInicialViewModel : ObservableObject
{
    private readonly IBuscaService _buscaService;
    private readonly IConnectivity _connectivity;

    [ObservableProperty]
    private ObservableCollection<MaisBuscadosDto> maisBuscados;
    public PaginaInicialViewModel(IBuscaService buscaService, IConnectivity connectivity)
    {
        _buscaService = buscaService;
        _connectivity = connectivity;
        MaisBuscados = new ObservableCollection<MaisBuscadosDto>();
        _connectivity.ConnectivityChanged += EventoMudancaEstadoConexao;
    }

    public async Task ObterMaisBuscados()
    {
        if(_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await App.Current.MainPage.DisplayAlert("Erro", "Sem conexão com a internet", "Ok");
            MaisBuscados = new ObservableCollection<MaisBuscadosDto>();
            return;
        }

        await ObterResultadoMaisBuscados();
    }

    public async void EventoMudancaEstadoConexao(object sender, ConnectivityChangedEventArgs eventArgs)
    {
        if (eventArgs.NetworkAccess == NetworkAccess.Internet)
        {
            await App.Current.MainPage.DisplayAlert("Aviso", $"Recuperamos conexão com internet", "Ok");
            await ObterResultadoMaisBuscados();
        }
    }

    private async Task ObterResultadoMaisBuscados()
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

    ~PaginaInicialViewModel()
    {
        _connectivity.ConnectivityChanged -= EventoMudancaEstadoConexao;
    }
}
