using Dominio.Entidades;
using System.Collections;                                 
                                                                           
namespace Aplicacao.Interfaces                           
{                                                                          
    public interface IUsuarioAppServico : IAppServicoBase<Usuario>         
    {
        IEnumerable ObtemUsuariosProfessores();
    }                                                                      
}                                                                          

