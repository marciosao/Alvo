using Dominio.Entidades;
using System.Collections.Generic;

namespace Aplicacao.Interfaces
{
    public interface ICandidatoProcessoSeletivoAppServico : IAppServicoBase<CandidatoProcessoSeletivo>         
    {
        IEnumerable<CandidatoProcessoSeletivo> ObtemTodosSemAvaliacao();
    }
}

