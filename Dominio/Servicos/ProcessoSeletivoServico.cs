using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class ProcessoSeletivoServico : ServicoBase<ProcessoSeletivo>, IProcessoSeletivoServico            
    {                                                                              
        private readonly IProcessoSeletivoRepositorio _processoSeletivoRepositorio;                    
                                                                                   
        public ProcessoSeletivoServico(IProcessoSeletivoRepositorio processoSeletivoRepositorio)                
            : base(processoSeletivoRepositorio)                                              
        {                                                                          
            _processoSeletivoRepositorio = processoSeletivoRepositorio;                                
        }                                                                          
                                                                                   
    }                                                                              
}                                                                                  

