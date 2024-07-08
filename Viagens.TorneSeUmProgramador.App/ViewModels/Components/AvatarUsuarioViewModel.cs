using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.App.ViewModels.Components;

public partial class AvatarUsuarioViewModel : ObservableObject
{
    private readonly IMediaPicker _mediaPicker;
    private readonly IAppLogger<AvatarUsuarioViewModel> _logger;
    public AvatarUsuarioViewModel(IMediaPicker mediaPicker, 
                                  IAppLogger<AvatarUsuarioViewModel> logger)
    {
        _mediaPicker = mediaPicker;
        _logger = logger;
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
        //Verificar se o dispositivo tem câmera
        //Se tiver, abrir câmera
        //Se não, abrir a galeria
        //Copiar a foto para a pasta de cache
        //Exibir a foto na tela
        try
        {
            FileResult foto = null;

            if (_mediaPicker.IsCaptureSupported)
            {
                foto = await _mediaPicker.CapturePhotoAsync();
            }

            foto ??= await _mediaPicker.PickPhotoAsync();

            if (foto is not null)
            {
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, foto.FileName);

                using Stream sourceStream = await foto.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);
                FotoUsuario = localFilePath;
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Erro", "Erro ao adicionar foto", "Ok");
            _logger.Erro(ex, "Erro ao adicionar foto do avatar");
        }
    }
}
