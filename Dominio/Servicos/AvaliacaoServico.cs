using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;
using System.Collections.Generic;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class AvaliacaoServico : ServicoBase<Avaliacao>, IAvaliacaoServico            
    {                                                                              
        private readonly IAvaliacaoRepositorio _avaliacaoRepositorio;                    
                                                                                   
        public AvaliacaoServico(IAvaliacaoRepositorio avaliacaoRepositorio)                
            : base(avaliacaoRepositorio)                                              
        {                                                                          
            _avaliacaoRepositorio = avaliacaoRepositorio;                                
        }

        public Avaliacao ObtemAvaliacaoPorCandidatoProcesso(int pCandidatoProcessoSeletivo)
        {
            return _avaliacaoRepositorio.ObtemAvaliacaoPorCandidatoProcesso(pCandidatoProcessoSeletivo);
        }


        public IEnumerable<Avaliacao> ObtemCandidatosClassificacao(int pIdProcessoSeletivo)
        {
            return _avaliacaoRepositorio.ObtemCandidatosClassificacao(pIdProcessoSeletivo);
        }
    }                                                                              
}                                                                                  

