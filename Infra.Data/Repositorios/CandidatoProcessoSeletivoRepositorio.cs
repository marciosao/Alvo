using Dominio.Entidades;                                          
using Dominio.Interfaces.Repositorios;
using System.Collections.Generic;
using System.Linq;                        
                                                                                 
namespace Infra.Data.Repositorios                               
{                                                                                
   public class CandidatoProcessoSeletivoRepositorio : RepositorioBase<CandidatoProcessoSeletivo>, ICandidatoProcessoSeletivoRepositorio  
    {
        public IEnumerable<CandidatoProcessoSeletivo> ObtemTodosSemAvaliacao()
        {
            var lCandidatoProcessoSeletivo = Db.CandidatoProcessoSeletivo.ToList().Where(x=>x.Avaliacao.Any(a=>a.IdProfessor == null));

            return lCandidatoProcessoSeletivo;
        }

       /// <summary>
       /// Obtem as avaliações por professor com a situação disponível para professor.
       /// </summary>
       /// <param name="pIdProfessor">Identificador do Professor (Id)</param>
       /// <returns>Lista de Candidatos</returns>
        public IEnumerable<CandidatoProcessoSeletivo> ObtemAvaliacoesPorProfessor(int? pIdProfessor)
        {
            int? lIdProfessor = null;

            if (pIdProfessor > 0)
            {
                lIdProfessor = pIdProfessor;
            }

            ////////var lCandidatoProcessoSeletivo = Db.CandidatoProcessoSeletivo.ToList().Where(x => 
            ////////                                                                             x.Avaliacao.Any(a => 
            ////////                                                                                             a.IdProfessor != null  && 
            ////////                                                                                             (lIdProfessor == null || a.IdProfessor == lIdProfessor) &&
            ////////                                                                                             a.IdSituacaoAvaliacao != (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIISecretaria)
            ////////                                                                             );

            var lCandidatoProcessoSeletivo = Db.CandidatoProcessoSeletivo.ToList().Where(x =>
                                                                             x.Avaliacao.Any(a =>
                                                                                             a.IdProfessor != null &&
                                                                                             (lIdProfessor == null || a.IdProfessor == lIdProfessor)));
            if (pIdProfessor > 0)
            {
                lCandidatoProcessoSeletivo = lCandidatoProcessoSeletivo.ToList().Where(x =>
                                                                                       x.Avaliacao.Any(a =>
                                                                                                       a.IdSituacaoAvaliacao != (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIISecretaria));
            }

            return lCandidatoProcessoSeletivo;
        }

        public IEnumerable<CandidatoProcessoSeletivo> ObtemCandidatosClassificacao(int pIdProcessoSeletivo)
        {
            int? lIdProcessoSeletivo = null;

            if (pIdProcessoSeletivo > 0)
            {
                lIdProcessoSeletivo = pIdProcessoSeletivo;
            }

            var lCandidatoProcessoSeletivo = Db.CandidatoProcessoSeletivo.ToList().Where(x => 
                                                                                            (lIdProcessoSeletivo == null || x.IdProcessoSeletivo == lIdProcessoSeletivo) &&
                                                                                            x.Avaliacao.Any(a => a.Concluida == true)).OrderBy(o=>o.IdProcessoSeletivo);

            Avaliacao lavalia = new Avaliacao();

            return lCandidatoProcessoSeletivo;
        }
    }                                                                            
}                                                                                

