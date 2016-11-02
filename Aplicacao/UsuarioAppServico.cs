using Aplicacao.Interfaces;
using Aplicacao.Util;
using Dominio.Entidades;                                                  
using Dominio.Interfaces.Servicos;                                       
                                                                                         
                                                                                         
namespace Aplicacao                                                   
{                                                                                        
    public class UsuarioAppServico : AppServicoBase<Usuario>, IUsuarioAppServico         
    {                                                                                    
        private readonly IUsuarioServico _usuarioServico;  
        private CriarMD5 criptMd5 = new CriarMD5();
                                                                                         
        public UsuarioAppServico(IUsuarioServico usuarioServico)
            : base(usuarioServico)                                                        
        {
            _usuarioServico = usuarioServico;                                            
        }

        public System.Collections.IEnumerable ObtemUsuariosProfessores()
        {
            return _usuarioServico.ObtemUsuariosProfessores();
        }

        public Usuario AutenticarUsuario(Usuario pUsuario)
        {
            pUsuario.Senha = criptMd5.RetornarMD5(pUsuario.Senha);
            return _usuarioServico.AutenticarUsuario(pUsuario);
        }

        public Usuario AlterarSenha(Usuario lUsuario, string novaSenha)
        {
            lUsuario.Senha = criptMd5.RetornarMD5(lUsuario.Senha);
            var usuario = this.AutenticarUsuario(lUsuario);

            if (usuario != null)
            {
                novaSenha = criptMd5.RetornarMD5(novaSenha);
                if (!usuario.Senha.Equals(novaSenha))
                {
                    usuario.Senha = novaSenha;
                    _usuarioServico.Update(usuario);
                    return usuario;
                }
            }
           
            return null;
        }
    }                                                                                    
}                                                                                        

