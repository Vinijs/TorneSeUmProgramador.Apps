using Viagens.TorneSeUmProgramador.Core.Common.Interfaces;

namespace Viagens.TorneSeUmProgramador.Core.Common;

public class ResultadoFalha<T> : IResultado<T>
{
    public DetalheFalha Detalhe { get;  }
    public ResultadoFalha(DetalheFalha detalhe) => Detalhe = detalhe;
}
