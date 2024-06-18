using Microsoft.Extensions.Logging;
using Todo.TorneSeUmProgramador.Core.Modelos;
using Todo.TorneSeUmProgramador.Data.DAO;

namespace TodoApp.TorneSeUmProgramador.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Oswald-Regular.ttf", "OswaldRegular");
                    fonts.AddFont("Oswald-Bold.ttf", "OswaldBold");
                    fonts.AddFont("Oswald-ExtraLight.ttf", "OswaldExtraLight");
                    fonts.AddFont("Oswald-Light.ttf", "OswaldLight");
                    fonts.AddFont("Oswald-Medium.ttf", "OswaldMedium");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            var dao = new TarefasDAO();

            dao.CriarBancodeDados();

            SeedDatabase();


            return builder.Build();
        }

        private static void SeedDatabase()
        {
            var dao = new UsuarioDAO();

            var usuario = dao.Obter().Result;

            if (usuario is not null)
                return;

            var usuarioPadrao = new Usuario
            {
                Nome = "user",
                Email = "user@user.com",
                Senha = "user"
            };

            dao.Adicionar(usuarioPadrao).Wait();
        }
    }
}
