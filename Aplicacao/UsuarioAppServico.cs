using Aplicacao.Interfaces;                                            
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class UsuarioAppServico : AppServicoBase<Usuario>, IUsuarioAppServico         
    {                                                                                    
        private readonly IUsuarioServico _usuarioServico;                                
                                                                                         
        public UsuarioAppServico(IUsuarioServico usuarioServico)
            : base(usuarioServico)                                                        
        {
            _usuarioServico = usuarioServico;                                            
        }

        public System.Collections.IEnumerable ObtemUsuariosProfessores()
        {
            return _usuarioServico.ObtemUsuariosProfessores();
        }
    }                                                                                    
}                                                                                        

