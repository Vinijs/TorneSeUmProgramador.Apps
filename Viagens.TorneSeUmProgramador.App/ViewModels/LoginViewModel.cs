using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Viagens.TorneSeUmProgramador.App.ViewModels;

public sealed partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private bool senhaVisivel = false;

    [RelayCommand]
    public void OnTapSenhaImage(StackLayout stackLayout)
    {
        if (SenhaVisivel)
        {
            ((Entry)stackLayout.Children[0]).IsPassword = true;
            ((Image)stackLayout.Children[1]).Source = ImageSource.FromFile("eyeclosed.png");
            SenhaVisivel = false;
        }
        else
        {
            ((Entry)stackLayout.Children[0]).IsPassword = false;
            ((Image)stackLayout.Children[1]).Source = ImageSource.FromFile("eyeopen.png");
            SenhaVisivel = true;
        }
    }
}
