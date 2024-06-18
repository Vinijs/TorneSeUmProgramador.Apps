using System.Text.Json;
using TodoApp.TorneSeUmProgramador.App.Session;

namespace TodoApp.TorneSeUmProgramador.App.Storages;

public static class UsuarioPreferencesStorage
{
    private const string SESSION = "session";

    public static void Salvar(UsuarioSession session)
    {
        Preferences.Set(SESSION, JsonSerializer.Serialize(session));
    }

    public static UsuarioSession Obter()
    {
        if(!Preferences.ContainsKey(SESSION))
            return null;

        return JsonSerializer.Deserialize<UsuarioSession>(Preferences.Get(SESSION, string.Empty));
    }
}
