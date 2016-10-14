using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class MenuAppServico : AppServicoBase<Menu>, IMenuAppServico         
    {                                                                                    
        private readonly IMenuServico _menuServico;                                
                                                                                         
        public MenuAppServico(IMenuServico menuServico)
            : base(menuServico)                                                        
        {
            _menuServico = menuServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

