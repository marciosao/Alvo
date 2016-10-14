using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System.Linq;

namespace Infra.Data.Repositorios
{
    public class CandidatoRepositorio : RepositorioBase<Candidato>, ICandidatoRepositorio
    {
        public Candidato ObtemCandidatoPorProcessoCPF(int pIdProcessoSeletivo, string pCPF)
        {
            var lCandidato = Db.Candidato.Where(x=>x.CPF == pCPF && x.CandidatoProcessoSeletivo.Any(c=>c.IdProcessoSeletivo == pIdProcessoSeletivo)).FirstOrDefault();

            return lCandidato;
        }
    }
}

