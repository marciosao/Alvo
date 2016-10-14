using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class PerfilServico : ServicoBase<Perfil>, IPerfilServico            
    {                                                                              
        private readonly IPerfilRepositorio _perfilRepositorio;                    
                                                                                   
        public PerfilServico(IPerfilRepositorio perfilRepositorio)                
            : base(perfilRepositorio)                                              
        {                                                                          
            _perfilRepositorio = perfilRepositorio;                                
        }                                                                          
                                                                                   
    }                                                                              
}                                                                                  

