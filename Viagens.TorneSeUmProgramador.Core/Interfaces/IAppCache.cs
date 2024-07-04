using Viagens.TorneSeUmProgramador.Core.Cache;

namespace Viagens.TorneSeUmProgramador.Core.Interfaces;

public interface IAppCache
{
    void AddOrUpdate<T>(string key, CacheObject<T> value, TimeSpan expiration);
    CacheObject<T> Get<T>(string key);
    void Remove(string key);
    void Clear();
    bool ContainsKey(string key);
}
