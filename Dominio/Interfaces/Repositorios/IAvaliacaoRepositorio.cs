using Dominio.Entidades;
using System.Collections.Generic;                              
                                                                     
namespace Dominio.Interfaces.Repositorios            
{                                                                    
    public interface IAvaliacaoRepositorio : IRepositorioBase<Avaliacao>   
    {
        Avaliacao ObtemAvaliacaoPorCandidatoProcesso(int pCandidatoProcessoSeletivo);
        IEnumerable<Avaliacao> ObtemCandidatosClassificacao(int pIdProcessoSeletivo);
        IEnumerable<Avaliacao> ObtemCandidatosClassificacao(int pIdProcessoSeletivo, int pIdAreaConcentracao);
    }                                                                
}                                                                    

