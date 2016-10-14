using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class CandidatoProcessoSeletivoServico : ServicoBase<CandidatoProcessoSeletivo>, ICandidatoProcessoSeletivoServico            
    {                                                                              
        private readonly ICandidatoProcessoSeletivoRepositorio _candidatoProcessoSeletivoRepositorio;                    
                                                                                   
        public CandidatoProcessoSeletivoServico(ICandidatoProcessoSeletivoRepositorio candidatoProcessoSeletivoRepositorio)                
            : base(candidatoProcessoSeletivoRepositorio)                                              
        {                                                                          
            _candidatoProcessoSeletivoRepositorio = candidatoProcessoSeletivoRepositorio;                                
        }


        public System.Collections.Generic.IEnumerable<CandidatoProcessoSeletivo> ObtemTodosSemAvaliacao()
        {
            return _candidatoProcessoSeletivoRepositorio.ObtemTodosSemAvaliacao();
        }
    }                                                                              
}                                                                                  

