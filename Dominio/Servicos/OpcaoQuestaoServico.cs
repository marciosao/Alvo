using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class OpcaoQuestaoServico : ServicoBase<OpcaoQuestao>, IOpcaoQuestaoServico            
    {                                                                              
        private readonly IOpcaoQuestaoRepositorio _opcaoQuestaoRepositorio;                    
                                                                                   
        public OpcaoQuestaoServico(IOpcaoQuestaoRepositorio opcaoQuestaoRepositorio)                
            : base(opcaoQuestaoRepositorio)                                              
        {                                                                          
            _opcaoQuestaoRepositorio = opcaoQuestaoRepositorio;                                
        }                                                                          
                                                                                   
    }                                                                              
}                                                                                  

