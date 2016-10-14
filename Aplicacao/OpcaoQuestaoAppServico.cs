using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class OpcaoQuestaoAppServico : AppServicoBase<OpcaoQuestao>, IOpcaoQuestaoAppServico         
    {                                                                                    
        private readonly IOpcaoQuestaoServico _opcaoQuestaoServico;                                
                                                                                         
        public OpcaoQuestaoAppServico(IOpcaoQuestaoServico opcaoQuestaoServico)
            : base(opcaoQuestaoServico)                                                        
        {
            _opcaoQuestaoServico = opcaoQuestaoServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

