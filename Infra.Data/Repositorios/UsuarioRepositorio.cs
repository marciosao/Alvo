using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System.Collections;
using System.Linq;                         
                                                                                 
namespace Infra.Data.Repositorios                               
{                                                                                
   public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio  
    {

        public IEnumerable ObtemUsuariosProfessores()
        {
            var lProfessores = Db.Usuario.Where(x=>x.Perfil.Id == 2);

            return lProfessores;
        }

       public Usuario AutenticarUsuario(Usuario pUsuario)
       {
           return this.Entidade().FirstOrDefault(usr => usr.CPF.Equals(pUsuario.CPF) && usr.Senha.Equals(pUsuario.Senha));
       }
    }                                                                            
}                                                                                

