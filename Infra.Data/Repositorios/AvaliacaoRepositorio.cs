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
    }
}

