using Viagens.TorneSeUmProgramador.App.ViewModels.Components;

namespace Viagens.TorneSeUmProgramador.App.Views.Components;

public partial class AvatarUsuario : ContentView
{
	public AvatarUsuario()
	{
		InitializeComponent();
		BindingContext = App.Current.Handler.MauiContext.Services.GetRequiredService<AvatarUsuarioViewModel>();
	}

    public static readonly BindableProperty MensagemTelaProperty = BindableProperty.Create(
        propertyName: nameof(MensagemTela),
        returnType: typeof(string),
        declaringType: typeof(AvatarUsuario),
        defaultValue: string.Empty,
        propertyChanged: (BindableObject bindable, object oldValue, object newValue) =>
        {
            {
                if (bindable is AvatarUsuario avatar
                    && avatar.BindingContext is AvatarUsuarioViewModel context)
                {
                    context.MensagemTela = newValue.ToString();
                }
            }
        },
        defaultBindingMode: BindingMode.TwoWay);

    public string MensagemTela
    {
        get => (string)GetValue(MensagemTelaProperty);
        set => SetValue(MensagemTelaProperty, value);
    }

    public static readonly BindableProperty TelaComponenteProperty = BindableProperty.Create(
        propertyName: nameof(TelaComponente),
        returnType: typeof(string),
        declaringType: typeof(AvatarUsuario),
        defaultValue: string.Empty,
        propertyChanged: (BindableObject bindable, object oldValue, object newValue) =>
        {
            {
                if (bindable is AvatarUsuario avatar
                    && avatar.BindingContext is AvatarUsuarioViewModel context)
                {
                    context.TelaComponente = newValue.ToString();
                    context.ExibirIconeTela = newValue.ToString() is "Perfil";
                }
            }
        },
        defaultBindingMode: BindingMode.TwoWay);

    public string TelaComponente
    {
        get => (string)GetValue(TelaComponenteProperty);
        set => SetValue(TelaComponenteProperty, value);
    }
}