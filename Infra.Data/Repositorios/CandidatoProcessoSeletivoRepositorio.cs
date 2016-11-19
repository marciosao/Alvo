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
        public IEnumerable<CandidatoProcessoSeletivo> ObtemAvaliacoesPorProfessor(int? pIdProfessor, int pIdProcessoSeletivo, int pIdSituacaoAvaliacao, int pIdProfessorPesquisa)
        {
            int? lIdProfessor = null;
            int? lIdProcessoSeletivo = null;
            int? lIdSituacaoAvaliacao = null;
            int? lIdProfessorPesquisa = null;

            if (pIdProfessor > 0)
            {
                lIdProfessor = pIdProfessor;
            }

            if (pIdProfessorPesquisa > 0)
            {
                lIdProfessorPesquisa = pIdProfessorPesquisa;
            }

            if (pIdProcessoSeletivo > 0)
            {
                lIdProcessoSeletivo = pIdProcessoSeletivo;
            }

            if (pIdSituacaoAvaliacao > 0)
            {
                lIdSituacaoAvaliacao = pIdSituacaoAvaliacao;
            }

            var lCandidatoProcessoSeletivo = Db.CandidatoProcessoSeletivo.ToList().Where(x =>
                                                                             (lIdProcessoSeletivo == null || x.IdProcessoSeletivo == lIdProcessoSeletivo) &&
                                                                             x.Avaliacao.Any(a =>
                                                                                             a.IdProfessor != null &&
                                                                                             (lIdProfessor == null || a.IdProfessor == lIdProfessor) &&
                                                                                             (lIdProfessorPesquisa == null || a.IdProfessor == lIdProfessorPesquisa) &&
                                                                                             (lIdSituacaoAvaliacao == null || a.IdSituacaoAvaliacao == lIdSituacaoAvaliacao))
                                                                                             );
            ////////if (pIdProfessor > 0)
            ////////{
            ////////    lCandidatoProcessoSeletivo = lCandidatoProcessoSeletivo.ToList().Where(x =>
            ////////                                                                           x.Avaliacao.Any(a =>
            ////////                                                                                           a.IdSituacaoAvaliacao != (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIISecretaria));
            ////////}

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

