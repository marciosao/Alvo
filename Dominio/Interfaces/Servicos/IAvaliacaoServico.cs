using Dominio.Entidades;
using System.Collections.Generic;                             
                                                                    
namespace Dominio.Interfaces.Servicos               
{                                                                   
    public interface IAvaliacaoServico : IServicoBase<Avaliacao>        
    {
        Avaliacao ObtemAvaliacaoPorCandidatoProcesso(int pCandidatoProcessoSeletivo);
        IEnumerable<Avaliacao> ObtemCandidatosClassificacao(int pIdProcessoSeletivo);

        IEnumerable<Avaliacao> ObtemCandidatosClassificacao(int pIdProcessoSeletivo, int pIdAreaConcentracao);
    }                                                               
}                                                                   

