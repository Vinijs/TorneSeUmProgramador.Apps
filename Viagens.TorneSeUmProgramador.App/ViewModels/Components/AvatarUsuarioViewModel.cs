using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Viagens.TorneSeUmProgramador.Core.Cache;
using Viagens.TorneSeUmProgramador.Core.Common;
using Viagens.TorneSeUmProgramador.Core.Constantes;
using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.App.ViewModels.Components;

public partial class AvatarUsuarioViewModel : ObservableObject
{
    private readonly IMediaPicker _mediaPicker;
    private readonly IAppLogger<AvatarUsuarioViewModel> _logger;
    private readonly IAppCache _appCache;
    public AvatarUsuarioViewModel(IMediaPicker mediaPicker,
                                  IAppLogger<AvatarUsuarioViewModel> logger,
                                  IAppCache appCache = null)
    {
        _mediaPicker = mediaPicker;
        _logger = logger;
        _appCache = appCache;
        var sessaoUsuario = _appCache.Get<SessaoUsuario>(AppConstants.CACHE_SESSAO_USUARIO)?.Dados;

        if (sessaoUsuario is not null)
        {
            NomeUsuario = sessaoUsuario.NomeUsuario;
            FotoUsuario = sessaoUsuario.FotoUsuario;
        }
    }

    [ObservableProperty]
    private string nomeUsuario;

    [ObservableProperty]
    private string fotoUsuario;

    [ObservableProperty]
    private string mensagemTela;

    [ObservableProperty]
    private string telaComponente;

    [ObservableProperty]
    private bool exibirIconeTela;

    [RelayCommand]
    public async Task AdicionarFotoAvatar()
    {
        try
        {
            FileResult foto = null;
            foto = await EscolhaFoto(foto);

            await SalvarFotoEAtualizarCache(foto);
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Erro", "Erro ao adicionar foto", "Ok");
            _logger.Erro(ex, "Erro ao adicionar foto do avatar");
        }
    }

    private async Task<FileResult> EscolhaFoto(FileResult foto)
    {
        var escolha = await App.Current.MainPage
                        .DisplayActionSheet("De onde deseja carregar a foto", "Cancelar", null, "Abrir Câmera", " Abrir Galeria");

        switch (escolha)
        {
            case "Câmera":
                if (_mediaPicker.IsCaptureSupported)
                {
                    foto = await _mediaPicker.CapturePhotoAsync();
                }
                else
                    await App.Current.MainPage.DisplayAlert("Erro", "Câmera não suportada", "Ok");
                break;
            case "Galeria":
                foto = await _mediaPicker.PickPhotoAsync();
                break;
            default:
                break;
        }

        return foto;
    }

    private async Task SalvarFotoEAtualizarCache(FileResult foto)
    {
        if (foto is not null)
        {
            string localFilePath = Path.Combine(FileSystem.CacheDirectory, foto.FileName);

            using Stream sourceStream = await foto.OpenReadAsync();
            using FileStream localFileStream = File.OpenWrite(localFilePath);

            await sourceStream.CopyToAsync(localFileStream);
            FotoUsuario = localFilePath;

            var sessaoUsuario = _appCache.Get<SessaoUsuario>(AppConstants.CACHE_SESSAO_USUARIO)?.Dados;

            sessaoUsuario ??= new SessaoUsuario();

            sessaoUsuario.FotoUsuario = localFilePath;

            _appCache.AddOrUpdate(AppConstants.CACHE_SESSAO_USUARIO,
                new CacheObject<SessaoUsuario>(sessaoUsuario),
                TimeSpan.FromDays(AppConstants.CACHE_SESSAO_USUARIO_EXPIRACAO_DIAS));

            await App.Current.MainPage.DisplayAlert("Sucesso", "Foto adicionada com sucesso", "Ok");

        }
    }
}
