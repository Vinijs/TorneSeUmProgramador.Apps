using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Viagens.TorneSeUmProgramador.Business.Services.Interfaces;
using Viagens.TorneSeUmProgramador.Core.Common;
using Viagens.TorneSeUmProgramador.Core.Dtos;
using Viagens.TorneSeUmProgramador.Core.Enums;
using Viagens.TorneSeUmProgramador.Core.Extensions;

namespace Viagens.TorneSeUmProgramador.App.ViewModels;

public sealed partial class OfertasViewModel : ObservableObject
{
    private readonly IBuscaService _buscaService;
    private readonly IConnectivity _connectivity;

    [ObservableProperty]
    private ObservableCollection<OfertaDto> ofertasPacoteCompleto;

    [ObservableProperty]
    private ObservableCollection<OfertaDto> ofertasPacoteAereo;

    [ObservableProperty]
    private ObservableCollection<OfertaDto> ofertasPacoteTerrestre;

    [ObservableProperty]
    private ObservableCollection<OfertaDto> ofertasPacoteHospedagem;

    [ObservableProperty]
    private bool conexaoInterrompida;

    [ObservableProperty]
    private bool carregando;

    public OfertasViewModel(IBuscaService buscaService, 
                            IConnectivity connectivity)
    {
        _buscaService = buscaService;
        _connectivity = connectivity;
        OfertasPacoteCompleto = new ObservableCollection<OfertaDto>();
        OfertasPacoteAereo = new ObservableCollection<OfertaDto>();
        OfertasPacoteTerrestre = new ObservableCollection<OfertaDto>();
        OfertasPacoteHospedagem = new ObservableCollection<OfertaDto>();
        _connectivity.ConnectivityChanged += EventoMudancaEstadoConexao;
    }

    public async Task ObterOfertas()
    {
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await App.Current.MainPage.DisplayAlert("Erro", "Sem conexão com a internet", "OK");
            OfertasPacoteCompleto = new ObservableCollection<OfertaDto>();
            OfertasPacoteHospedagem = new ObservableCollection<OfertaDto>();
            OfertasPacoteAereo = new ObservableCollection<OfertaDto>();
            OfertasPacoteTerrestre = new ObservableCollection<OfertaDto>();
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
            var ofertasDados = ofertas.Dados.ToList();
            OfertasPacoteCompleto = new ObservableCollection<OfertaDto>(ofertasDados.Where
                (x => x.TipoPacote == TipoPacote.Completo.ToString()).ToList());

            OfertasPacoteTerrestre = new ObservableCollection<OfertaDto>(ofertasDados.Where
                (x => x.TipoPacote == TipoPacote.PassagemTerrestre.ToString()).ToList());

            OfertasPacoteHospedagem = new ObservableCollection<OfertaDto>(ofertasDados.Where
                (x => x.TipoPacote == TipoPacote.Hospedagem.ToString()).ToList());

            OfertasPacoteAereo = new ObservableCollection<OfertaDto>(ofertasDados.Where
                (x => x.TipoPacote == TipoPacote.PassagemAerea.ToString()).ToList());
            return;
        }

        var falha = resultado as ResultadoFalha<IEnumerable<OfertaDto>>;
        await App.Current.MainPage.DisplayAlert("Erro", string.Join(" ", falha.Detalhe.Mensagens.Select(x => x.Texto)), "Ok");
    }

    [RelayCommand]
    public async Task OnRefresh()
    {
        Carregando = true;

        var resultado = await _buscaService.ObterOfertas();

        if (resultado is ResultadoSucesso<IEnumerable<OfertaDto>> ofertas)
        {
            var ofertasDados = ofertas.Dados.ToList();
            var ofertaPacoteCompleto = ofertasDados.
                Where(x => x.TipoPacote == TipoPacote.Completo.ToString()).ToList();
            
            OfertasPacoteCompleto.AddRange(ofertaPacoteCompleto);

            var ofertasPacoteTerrestre = ofertasDados.
                Where(x => x.TipoPacote == TipoPacote.PassagemTerrestre.ToString()).ToList();

            OfertasPacoteTerrestre.AddRange(ofertasPacoteTerrestre);
            

            var ofertaPacoteHospedagem = ofertasDados.
                Where(x => x.TipoPacote == TipoPacote.Hospedagem.ToString()).ToList();

            OfertasPacoteHospedagem.AddRange(ofertaPacoteHospedagem);

            var ofertaPacoteAereo = ofertasDados.
                Where(x => x.TipoPacote == TipoPacote.PassagemAerea.ToString()).ToList();

            OfertasPacoteAereo.AddRange(ofertaPacoteAereo);

            Carregando = false;
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
