using Dominio.Entidades;                                            
using Dominio.Interfaces.Repositorios;                             
using Dominio.Interfaces.Servicos;                                 
                                                                                   
namespace Dominio.Servicos                                         
{                                                                                  
    public class UsuarioServico : ServicoBase<Usuario>, IUsuarioServico            
    {                                                                              
        private readonly IUsuarioRepositorio _usuarioRepositorio;                    
                                                                                   
        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)                
            : base(usuarioRepositorio)                                              
        {                                                                          
            _usuarioRepositorio = usuarioRepositorio;                                
        }


        public System.Collections.IEnumerable ObtemUsuariosProfessores()
        {
            return _usuarioRepositorio.ObtemUsuariosProfessores();
        }

        public Usuario AutenticarUsuario(Usuario pUsuario)
        {
            return _usuarioRepositorio.AutenticarUsuario(pUsuario);
        }

        public Usuario RecuperarSenha(Usuario usuario)
        {
            return _usuarioRepositorio.RecuperarSenha(usuario);
        }
    }                                                                              
}                                                                                  

