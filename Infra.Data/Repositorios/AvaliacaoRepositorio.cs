using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System.Linq;

namespace Infra.Data.Repositorios
{
    public class AvaliacaoRepositorio : RepositorioBase<Avaliacao>, IAvaliacaoRepositorio
    {
        public Avaliacao ObtemAvaliacaoPorCandidatoProcesso(int pCandidatoProcessoSeletivo)
        {
            var lAvaliacao = Db.Avaliacao.FirstOrDefault(x => x.IdCandidatoProcessoSeletivo == pCandidatoProcessoSeletivo);

            return lAvaliacao;
        }

        ////////public Avaliacao ObtemAvaliacaoPorCandidatoProcesso2(int pCandidatoProcessoSeletivo)
        ////////{
        ////////    var lAvaliacao = Db.Questionario.Where(q=>
        ////////                                            q.AvaliacaoQuestionario.Any(a=>a.Avaliacao.Id == 1) &&
        ////////                                            q.ques  )

        ////////    return lAvaliacao;
        ////////}
    }
}

