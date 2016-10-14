using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class AvaliacaoQuestionarioServico : ServicoBase<AvaliacaoQuestionario>, IAvaliacaoQuestionarioServico            
    {                                                                              
        private readonly IAvaliacaoQuestionarioRepositorio _avaliacaoQuestionarioRepositorio;                    
                                                                                   
        public AvaliacaoQuestionarioServico(IAvaliacaoQuestionarioRepositorio avaliacaoQuestionarioRepositorio)                
            : base(avaliacaoQuestionarioRepositorio)                                              
        {                                                                          
            _avaliacaoQuestionarioRepositorio = avaliacaoQuestionarioRepositorio;                                
        }                                                                          
                                                                                   
    }                                                                              
}                                                                                  

