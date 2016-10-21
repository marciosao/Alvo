using Dominio.Entidades;
using System.Collections.Generic;

namespace Dominio.Interfaces.Repositorios            
{
    public interface ICandidatoProcessoSeletivoRepositorio : IRepositorioBase<CandidatoProcessoSeletivo>   
    {
        IEnumerable<CandidatoProcessoSeletivo> ObtemTodosSemAvaliacao();

        IEnumerable<CandidatoProcessoSeletivo> ObtemAvaliacoesPorProfessor(int? pIdProfessor);
    }
}                                                                    

