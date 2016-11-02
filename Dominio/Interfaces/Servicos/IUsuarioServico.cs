using Dominio.Entidades;
using System.Collections;                             
                                                                    
namespace Dominio.Interfaces.Servicos               
{                                                                   
    public interface IUsuarioServico : IServicoBase<Usuario>        
    {
        IEnumerable ObtemUsuariosProfessores();
        Usuario AutenticarUsuario(Usuario pUsuario);
    }                                                               
}                                                                   

