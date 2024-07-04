using System.Text.Json;
using Viagens.TorneSeUmProgramador.Core.Cache;
using Viagens.TorneSeUmProgramador.Core.Interfaces;

namespace Viagens.TorneSeUmProgramador.App.Storages;

public class AppCachePreferencesStorage : IAppCache
{
    public void AddOrUpdate<T>(string key, CacheObject<T> value, TimeSpan expiration)
    {
        if (value is null)
            return;

        value.AdicionarMinutosExpiracao((int)expiration.TotalMinutes);

        if(ContainsKey(key))
            Preferences.Default.Remove(key);

        Preferences.Default.Set(key, JsonSerializer.Serialize(value));
    }

    public void Clear() 
        => Preferences.Default.Clear();

    public bool ContainsKey(string key) 
        => Preferences.Default.ContainsKey(key);

    public CacheObject<T> Get<T>(string key) 
        => ContainsKey(key)
            ? JsonSerializer.Deserialize<CacheObject<T>>(Preferences.Default.Get(key, string.Empty))
            : default;

    public void Remove(string key)
    {
        if (ContainsKey(key))
            Preferences.Default.Remove(key);
    }
}
