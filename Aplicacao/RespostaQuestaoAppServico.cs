using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class RespostaQuestaoAppServico : AppServicoBase<RespostaQuestao>, IRespostaQuestaoAppServico         
    {                                                                                    
        private readonly IRespostaQuestaoServico _respostaQuestaoServico;                                
                                                                                         
        public RespostaQuestaoAppServico(IRespostaQuestaoServico respostaQuestaoServico)
            : base(respostaQuestaoServico)                                                        
        {
            _respostaQuestaoServico = respostaQuestaoServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

