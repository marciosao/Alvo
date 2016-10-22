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
            var lProfessores = Db.Usuario.Where(x=>x.perfil.Id == 2);

            return lProfessores;
        }
    }                                                                            
}                                                                                

