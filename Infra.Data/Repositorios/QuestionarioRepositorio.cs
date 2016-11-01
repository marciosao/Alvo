using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System.Linq;

namespace Infra.Data.Repositorios
{
    public class QuestionarioRepositorio : RepositorioBase<Questionario>, IQuestionarioRepositorio
    {
        public Questionario ObtemQuestionarioPorCandidatoProcesso(int pCandidatoProcessoSeletivo)
        {
            var lQuestionario = Db.Questionario.Where(q =>
                                                    q.AvaliacaoQuestionario.Any(a => 
                                                                                a.Avaliacao.IdCandidatoProcessoSeletivo == pCandidatoProcessoSeletivo)).FirstOrDefault();

            return lQuestionario;
        }
    }
}

