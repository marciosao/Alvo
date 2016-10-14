using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class PerfilAppServico : AppServicoBase<Perfil>, IPerfilAppServico         
    {                                                                                    
        private readonly IPerfilServico _perfilServico;                                
                                                                                         
        public PerfilAppServico(IPerfilServico perfilServico)
            : base(perfilServico)                                                        
        {
            _perfilServico = perfilServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

