using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Viagens.TorneSeUmProgramador.Business.Services.Interfaces;
using Viagens.TorneSeUmProgramador.Core.Common;
using Viagens.TorneSeUmProgramador.Core.Dtos;

namespace Viagens.TorneSeUmProgramador.App.ViewModels;

public sealed partial class OfertasViewModel : ObservableObject
{
    private readonly IBuscaService _buscaService;
    private readonly IConnectivity _connectivity;

    [ObservableProperty]
    private ObservableCollection<OfertaDto> ofertas;

    [ObservableProperty]
    private bool conexaoInterrompida;

    public OfertasViewModel(IBuscaService buscaService, 
                            IConnectivity connectivity)
    {
        _buscaService = buscaService;
        _connectivity = connectivity;
        Ofertas = new ObservableCollection<OfertaDto>();
        _connectivity.ConnectivityChanged += EventoMudancaEstadoConexao;
    }

    public async Task ObterOfertas()
    {
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await App.Current.MainPage.DisplayAlert("Erro", "Sem conexão com a internet", "OK");
            Ofertas = new ObservableCollection<OfertaDto>();
            return;
        }

        await ObterResultadoOfertas();
    }

    public async void EventoMudancaEstadoConexao(object sender, ConnectivityChangedEventArgs eventArgs)
    {
        ConexaoInterrompida = eventArgs.NetworkAccess != NetworkAccess.Internet;

        if (eventArgs.NetworkAccess == NetworkAccess.Internet)
        {
            await App.Current.MainPage.DisplayAlert("Aviso", $"Recuperamos conexão com a internet", "Ok");
            await ObterResultadoOfertas();
        }
    }

    private async Task ObterResultadoOfertas()
    {
        var resultado = await _buscaService.ObterOfertas();
        if (resultado is ResultadoSucesso<IEnumerable<OfertaDto>> ofertas)
        {
            Ofertas = new ObservableCollection<OfertaDto>(ofertas.Dados);
            return;
        }

        var falha = resultado as ResultadoFalha<IEnumerable<OfertaDto>>;
        await App.Current.MainPage.DisplayAlert("Erro", string.Join(" ", falha.Detalhe.Mensagens.Select(x => x.Texto)), "Ok");
    }

    ~OfertasViewModel()
    {
        _connectivity.ConnectivityChanged -= EventoMudancaEstadoConexao;
    }
}
