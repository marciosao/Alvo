using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class ProcessoSeletivoAppServico : AppServicoBase<ProcessoSeletivo>, IProcessoSeletivoAppServico         
    {                                                                                    
        private readonly IProcessoSeletivoServico _processoSeletivoServico;                                
                                                                                         
        public ProcessoSeletivoAppServico(IProcessoSeletivoServico processoSeletivoServico)
            : base(processoSeletivoServico)                                                        
        {
            _processoSeletivoServico = processoSeletivoServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

