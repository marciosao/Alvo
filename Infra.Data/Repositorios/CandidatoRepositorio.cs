using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System.Collections.Generic;
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

        public IEnumerable<Candidato> ObtemCandidatoPorProcesso(int pIdProcessoSeletivo)
        {
            int? lIdProcessoSeletivo = null;

            if (pIdProcessoSeletivo > 0)
            {
                lIdProcessoSeletivo = pIdProcessoSeletivo;
            }

            var lCandidato = Db.Candidato.Where(x =>x.CandidatoProcessoSeletivo.Any(c => (lIdProcessoSeletivo == null || c.IdProcessoSeletivo == lIdProcessoSeletivo)));

            return lCandidato;
        }

    }
}

