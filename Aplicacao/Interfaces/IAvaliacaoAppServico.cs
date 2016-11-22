using Dominio.Entidades;
using System.Collections.Generic;                                    
                                                                           
namespace Aplicacao.Interfaces                           
{                                                                          
    public interface IAvaliacaoAppServico : IAppServicoBase<Avaliacao>         
    {
        void GravarRespostasAvaliacao(Avaliacao lAvaliacao);

        Avaliacao ObtemAvaliacaoPorCandidatoProcesso(int pCandidatoProcessoSeletivo);

        IEnumerable<Avaliacao> ObtemCandidatosClassificacao(int pIdProcessoSeletivo);

        IEnumerable<Avaliacao> ObtemCandidatosClassificacao(int pIdProcessoSeletivo, int pIdAreaConcentracao);
    }                                                                      
}                                                                          

