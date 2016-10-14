using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class QuestionarioAppServico : AppServicoBase<Questionario>, IQuestionarioAppServico         
    {                                                                                    
        private readonly IQuestionarioServico _questionarioServico;                                
                                                                                         
        public QuestionarioAppServico(IQuestionarioServico questionarioServico)
            : base(questionarioServico)                                                        
        {
            _questionarioServico = questionarioServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

