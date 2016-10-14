using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class GrupoQuestaoAppServico : AppServicoBase<GrupoQuestao>, IGrupoQuestaoAppServico         
    {                                                                                    
        private readonly IGrupoQuestaoServico _grupoQuestaoServico;                                
                                                                                         
        public GrupoQuestaoAppServico(IGrupoQuestaoServico grupoQuestaoServico)
            : base(grupoQuestaoServico)                                                        
        {
            _grupoQuestaoServico = grupoQuestaoServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

