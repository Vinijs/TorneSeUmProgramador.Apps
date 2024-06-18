using TodoApp.TorneSeUmProgramador.App.Views;

namespace TodoApp.TorneSeUmProgramador.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Login();

            //App.Current.UserAppTheme = AppTheme.Light;
        }

        protected override void OnStart()
        {
            base.OnStart();

            var usuarioSession = Storages.UsuarioPreferencesStorage.Obter();

            if (usuarioSession is not null 
                && usuarioSession.DataExpiracaoSessao > DateTime.Now)
            {
                App.Current.MainPage = new PaginaInicial();
            }
        }
    }
}
