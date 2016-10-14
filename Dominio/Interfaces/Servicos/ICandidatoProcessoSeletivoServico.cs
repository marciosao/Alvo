using Dominio.Entidades;
using System.Collections.Generic;                             
                                                                    
namespace Dominio.Interfaces.Servicos               
{                                                                   
    public interface ICandidatoProcessoSeletivoServico : IServicoBase<CandidatoProcessoSeletivo>        
    {
        IEnumerable<CandidatoProcessoSeletivo> ObtemTodosSemAvaliacao();
    }                                                               
}                                                                   

