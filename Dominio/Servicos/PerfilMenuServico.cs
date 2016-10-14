using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class PerfilMenuServico : ServicoBase<PerfilMenu>, IPerfilMenuServico            
    {                                                                              
        private readonly IPerfilMenuRepositorio _perfilMenuRepositorio;                    
                                                                                   
        public PerfilMenuServico(IPerfilMenuRepositorio perfilMenuRepositorio)                
            : base(perfilMenuRepositorio)                                              
        {                                                                          
            _perfilMenuRepositorio = perfilMenuRepositorio;                                
        }                                                                          
                                                                                   
    }                                                                              
}                                                                                  

