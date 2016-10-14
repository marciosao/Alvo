using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class CandidatoProcessoSeletivoAppServico : AppServicoBase<CandidatoProcessoSeletivo>, ICandidatoProcessoSeletivoAppServico         
    {                                                                                    
        private readonly ICandidatoProcessoSeletivoServico _candidatoProcessoSeletivoServico;                                
                                                                                         
        public CandidatoProcessoSeletivoAppServico(ICandidatoProcessoSeletivoServico candidatoProcessoSeletivoServico)
            : base(candidatoProcessoSeletivoServico)                                                        
        {
            _candidatoProcessoSeletivoServico = candidatoProcessoSeletivoServico;                                            
        }

        public System.Collections.Generic.IEnumerable<CandidatoProcessoSeletivo> ObtemTodosSemAvaliacao()
        {
            return _candidatoProcessoSeletivoServico.ObtemTodosSemAvaliacao();
        }
    }                                                                                    
}                                                                                        

