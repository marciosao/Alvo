﻿using Dominio.Entidades;
using System.Collections.Generic;                                    
                                                                           
namespace Aplicacao.Interfaces                           
{                                                                          
    public interface IAvaliacaoAppServico : IAppServicoBase<Avaliacao>         
    {
        void GravarRespostasAvaliacao(Avaliacao lAvaliacao);
        void GravarRespostasAvaliacao(Avaliacao lAvaliacao, bool pAvaliacaoFinalizada);

        Avaliacao ObtemAvaliacaoPorCandidatoProcesso(int pCandidatoProcessoSeletivo);

        IEnumerable<Avaliacao> ObtemCandidatosClassificacao(int pIdProcessoSeletivo);

        IEnumerable<Avaliacao> ObtemCandidatosClassificacao(int pIdProcessoSeletivo, int pIdAreaConcentracao);

        decimal CalculoMedias(Avaliacao pAvaliacao, string pTipoMedia);
    }                                                                      
}                                                                          

