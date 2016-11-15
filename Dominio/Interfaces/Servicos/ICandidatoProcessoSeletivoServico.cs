using Dominio.Entidades;
using System.Collections.Generic;                             
                                                                    
namespace Dominio.Interfaces.Servicos               
{                                                                   
    public interface ICandidatoProcessoSeletivoServico : IServicoBase<CandidatoProcessoSeletivo>        
    {
        IEnumerable<CandidatoProcessoSeletivo> ObtemTodosSemAvaliacao();
        IEnumerable<CandidatoProcessoSeletivo> ObtemAvaliacoesPorProfessor(int? pIdProfessor, int pIdProcessoSeletivo, int pIdSituacaoAvaliacao, int pIdProfessorPesquisa);
        IEnumerable<CandidatoProcessoSeletivo> ObtemCandidatosClassificacao(int pIdProcessoSeletivo);
    }                                                               
}                                                                   

