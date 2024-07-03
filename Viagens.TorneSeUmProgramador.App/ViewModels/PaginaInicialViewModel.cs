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
    private readonly IGeolocation _geolocation;

    [ObservableProperty]
    private ObservableCollection<MaisBuscadosDto> maisBuscados;

    [ObservableProperty]
    private bool conexaoInterrompida;
    public PaginaInicialViewModel(IBuscaService buscaService, IConnectivity connectivity, IGeolocation geolocation)
    {
        _buscaService = buscaService;
        _connectivity = connectivity;
        _geolocation = geolocation;
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
        ConexaoInterrompida = eventArgs.NetworkAccess != NetworkAccess.Internet;
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

        Location paris = new(48.8566100, 2.3514999);
        Location madrid = new(40.4165000, -3.7025600);

        var distancia = Location.CalculateDistance(madrid, paris, DistanceUnits.Kilometers);

        var minhaLocalizacao = await _geolocation.GetLocationAsync();

        await Launcher.OpenAsync($"https://www.google.com/maps/dir/{minhaLocalizacao.Latitude}, { minhaLocalizacao.Longitude}");

        var falha = resultado as ResultadoFalha<IEnumerable<MaisBuscadosDto>>;
        await App.Current.MainPage.DisplayAlert("Erro", string.Join(" ", falha.Detalhe.Mensagens.Select(x => x.Texto)), "Ok");
    }

    ~PaginaInicialViewModel()
    {
        _connectivity.ConnectivityChanged -= EventoMudancaEstadoConexao;
    }
}
