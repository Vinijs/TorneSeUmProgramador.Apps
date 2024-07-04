namespace Viagens.TorneSeUmProgramador.Core.Cache;

public class CacheObject<TDados>
{
    public CacheObject(TDados dados)
    {
        Dados = dados;
    }

    public TDados Dados { get; }
    public int TimeToLive { get; private set; }
    public DateTime DataExpiracao { get; private set; }

    public void AdicionarMinutosExpiracao(int minutos)
    {
        TimeToLive = minutos;
        DataExpiracao = DateTime.Now.AddMinutes(minutos);
    }
}
