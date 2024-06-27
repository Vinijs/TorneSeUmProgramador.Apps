using System.Diagnostics;
using Viagens.TorneSeUmProgramador.Core.Common.Interfaces;
using Viagens.TorneSeUmProgramador.Core.Enums;

namespace Viagens.TorneSeUmProgramador.Core.Common;

public sealed class Resultado
{
    public static IResultado<T> Falha<T>(CodigoErro codigoErro, string mensagem) 
        => new ResultadoFalha<T>(new DetalheFalha(codigoErro, mensagem));

    public static IResultado<T> Sucesso<T>(T valor)
        => new ResultadoSucesso<T>(valor);
}
