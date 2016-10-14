using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class AvaliacaoQuestionarioAppServico : AppServicoBase<AvaliacaoQuestionario>, IAvaliacaoQuestionarioAppServico         
    {                                                                                    
        private readonly IAvaliacaoQuestionarioServico _avaliacaoQuestionarioServico;                                
                                                                                         
        public AvaliacaoQuestionarioAppServico(IAvaliacaoQuestionarioServico avaliacaoQuestionarioServico)
            : base(avaliacaoQuestionarioServico)                                                        
        {
            _avaliacaoQuestionarioServico = avaliacaoQuestionarioServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

