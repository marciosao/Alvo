using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class PerfilMenuAppServico : AppServicoBase<PerfilMenu>, IPerfilMenuAppServico         
    {                                                                                    
        private readonly IPerfilMenuServico _perfilMenuServico;                                
                                                                                         
        public PerfilMenuAppServico(IPerfilMenuServico perfilMenuServico)
            : base(perfilMenuServico)                                                        
        {
            _perfilMenuServico = perfilMenuServico;                                            
        }                                                                                
    }                                                                                    
}                                                                                        

