﻿using Viagens.TorneSeUmProgramador.Core.Dtos;

namespace Viagens.TorneSeUmProgramador.Core.Interfaces;

public interface IViagensProxy
{
    Task<List<MaisBuscadosDto>> ObterMaisBuscados();
    Task<List<OfertaDto>> ObterOfertas();
    Task<List<OfertaDto>> ObterOfertasPaginadas(BuscaOfertasPaginadaRequest request);
    Task<DetalheOfertaViagemDto> ObterDetalheOferta(int id);
}
