using Dominio.Entidades;
using System.Collections.Generic;

namespace Aplicacao.Interfaces
{
    public interface ICandidatoProcessoSeletivoAppServico : IAppServicoBase<CandidatoProcessoSeletivo>         
    {
        IEnumerable<CandidatoProcessoSeletivo> ObtemTodosSemAvaliacao();

        void DistribuiAvaliacaoResponsavel(int pCandidatoProcessoSeletivo, int lIdProfessor);

        IEnumerable<CandidatoProcessoSeletivo> ObtemAvaliacoesPorProfessor(int pIdProfessor, int pIdProcessoSeletivo, int pIdSituacaoAvaliacao, int pIdProfessorPesquisa);

        IEnumerable<CandidatoProcessoSeletivo> ObtemCandidatosClassificacao(int pIdProcessoSeletivo);
    }
}

