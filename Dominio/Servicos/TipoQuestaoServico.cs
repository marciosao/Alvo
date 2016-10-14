using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class TipoQuestaoServico : ServicoBase<TipoQuestao>, ITipoQuestaoServico            
    {                                                                              
        private readonly ITipoQuestaoRepositorio _tipoQuestaoRepositorio;                    
                                                                                   
        public TipoQuestaoServico(ITipoQuestaoRepositorio tipoQuestaoRepositorio)                
            : base(tipoQuestaoRepositorio)                                              
        {                                                                          
            _tipoQuestaoRepositorio = tipoQuestaoRepositorio;                                
        }                                                                          
                                                                                   
    }                                                                              
}                                                                                  

