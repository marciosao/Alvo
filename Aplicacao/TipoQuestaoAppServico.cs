using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class TipoQuestaoAppServico : AppServicoBase<TipoQuestao>, ITipoQuestaoAppServico         
    {                                                                                    
        private readonly ITipoQuestaoServico _tipoQuestaoServico;                                
                                                                                         
        public TipoQuestaoAppServico(ITipoQuestaoServico tipoQuestaoServico)
            : base(tipoQuestaoServico)                                                        
        {
            _tipoQuestaoServico = tipoQuestaoServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

