using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class AvaliacaoServico : ServicoBase<Avaliacao>, IAvaliacaoServico            
    {                                                                              
        private readonly IAvaliacaoRepositorio _avaliacaoRepositorio;                    
                                                                                   
        public AvaliacaoServico(IAvaliacaoRepositorio avaliacaoRepositorio)                
            : base(avaliacaoRepositorio)                                              
        {                                                                          
            _avaliacaoRepositorio = avaliacaoRepositorio;                                
        }                                                                          
                                                                                   
    }                                                                              
}                                                                                  

