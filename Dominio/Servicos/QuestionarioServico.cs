using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class QuestionarioServico : ServicoBase<Questionario>, IQuestionarioServico            
    {                                                                              
        private readonly IQuestionarioRepositorio _questionarioRepositorio;                    
                                                                                   
        public QuestionarioServico(IQuestionarioRepositorio questionarioRepositorio)                
            : base(questionarioRepositorio)                                              
        {                                                                          
            _questionarioRepositorio = questionarioRepositorio;                                
        }                                                                          
                                                                                   
    }                                                                              
}                                                                                  

