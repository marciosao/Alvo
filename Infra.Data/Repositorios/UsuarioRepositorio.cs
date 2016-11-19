using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System;
using System.Collections;
using System.Linq;

namespace Infra.Data.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public IEnumerable ObtemUsuariosProfessores()
        {
            var lProfessores = Db.Usuario.Where(x => x.Perfil.Id == 2);

            return lProfessores;
        }

        public Usuario AutenticarUsuario(Usuario pUsuario)
        {
            Usuario teste = new Usuario();
            var resultado = this.Entidade().FirstOrDefault(usr => usr.CPF.Equals(pUsuario.CPF) && usr.Senha.Equals(pUsuario.Senha));
            return resultado;
        }

        public Usuario RecuperarSenha(Usuario usuario)
        {
            var usrAlter = Db.Usuario.FirstOrDefault(usr => usr.CPF.Trim().Equals(usuario.CPF.Trim())
                                                         && usr.Matricula.Trim() == (usuario.Matricula.Trim())
                                                         && usr.Email.Trim().Equals(usuario.Email.Trim()));

            return usrAlter;
        }
    }
}

