using Plugin.Fingerprint.Abstractions;
using Viagens.TorneSeUmProgramador.Core.Common;
using Viagens.TorneSeUmProgramador.Core.Constantes;
using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //App.Current.UserAppTheme = AppTheme.Dark;

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            var cache = App.Current.Handler.MauiContext.Services.GetRequiredService<IAppCache>();
            var fingerPrint = App.Current.Handler.MauiContext.Services.GetRequiredService<IFingerprint>();

            var sessao = cache.Get<SessaoUsuario>(AppConstants.CACHE_SESSAO_USUARIO)?.Dados;

            if (sessao is not null
                && sessao.DataExpiracaoToken > DateTime.Now)
            {
                if(await fingerPrint.IsAvailableAsync())
                {
                    var result = await fingerPrint.AuthenticateAsync(
                    new AuthenticationRequestConfiguration("Acesso com biometria", 
                    "Para facilitar o seu acesso ao app utilize a biometria"));

                    if (result.Authenticated)
                    {
                        await Shell.Current.GoToAsync("//home");
                    }
                }

                await Shell.Current.GoToAsync("//home");
            }
        }
    }
}
