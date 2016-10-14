using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class MenuServico : ServicoBase<Menu>, IMenuServico            
    {                                                                              
        private readonly IMenuRepositorio _menuRepositorio;                    
                                                                                   
        public MenuServico(IMenuRepositorio menuRepositorio)                
            : base(menuRepositorio)                                              
        {                                                                          
            _menuRepositorio = menuRepositorio;                                
        }                                                                          
                                                                                   
    }                                                                              
}                                                                                  

