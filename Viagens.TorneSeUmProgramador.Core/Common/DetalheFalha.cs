using Viagens.TorneSeUmProgramador.Core.Enums;

namespace Viagens.TorneSeUmProgramador.Core.Common;

public class DetalheFalha
{

    public CodigoErro Codigo { get; }
    public List<Mensagem> Mensagens { get; }

    public DetalheFalha(CodigoErro codigo, string mensagens)
    {
        Codigo = codigo;
        Mensagens = new List<Mensagem>()
        {
            new(mensagens)
        };
    }

    public DetalheFalha(CodigoErro codigo, List<Mensagem> mensagens)
    {
        Codigo = codigo;
        Mensagens = mensagens;
    }
}
