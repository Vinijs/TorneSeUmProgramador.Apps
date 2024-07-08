using Viagens.TorneSeUmProgramador.App.ViewModels.Components;

namespace Viagens.TorneSeUmProgramador.App.Views.Components;

public partial class AvatarUsuario : ContentView
{
	public AvatarUsuario()
	{
		InitializeComponent();
		BindingContext = App.Current.Handler.MauiContext.Services.GetRequiredService<AvatarUsuarioViewModel>();
	}

    public static readonly BindableProperty NomeUsuarioProperty = BindableProperty.Create(
        propertyName: nameof(NomeUsuario),
        returnType: typeof(string),
        declaringType: typeof(AvatarUsuario),
        defaultValue: string.Empty,
        propertyChanged: (BindableObject bindable, object oldValue, object newValue) =>
        {
            if (bindable is AvatarUsuario avatar &&
                avatar.BindingContext is AvatarUsuarioViewModel context)
            {
                context.NomeUsuario = newValue.ToString();
            }
        }, defaultBindingMode: BindingMode.TwoWay);

    public string NomeUsuario 
    {
        get => (string)GetValue(NomeUsuarioProperty);
        set => SetValue(NomeUsuarioProperty, value); 
    }

    public static readonly BindableProperty FotoUsuarioProperty = BindableProperty.Create(
        propertyName: nameof(FotoUsuario),
        returnType: typeof(string),
        declaringType: typeof(AvatarUsuario),
        defaultValue: string.Empty,
        propertyChanged: (BindableObject bindable, object oldValue, object newValue) =>
        {
            if (bindable is AvatarUsuario avatar
                && avatar.BindingContext is AvatarUsuarioViewModel context)
            {
                context.FotoUsuario = newValue.ToString();
            }
        },
        defaultBindingMode: BindingMode.TwoWay);

    public string FotoUsuario
    {
        get => (string)GetValue(FotoUsuarioProperty);
        set => SetValue(FotoUsuarioProperty, value);
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