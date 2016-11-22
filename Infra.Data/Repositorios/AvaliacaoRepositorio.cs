﻿using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System.Collections.Generic;
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

        public IEnumerable<Avaliacao> ObtemCandidatosClassificacao(int pIdProcessoSeletivo)
        {
            int? lIdProcessoSeletivo = null;

            if (pIdProcessoSeletivo > 0)
            {
                lIdProcessoSeletivo = pIdProcessoSeletivo;
            }

            var lAvaliacoes = Db.Avaliacao.ToList().Where(x =>
                                                              (lIdProcessoSeletivo == null || x.CandidatoProcessoSeletivo.IdProcessoSeletivo == lIdProcessoSeletivo) &&
                                                               x.Concluida == true)
                                                               .OrderByDescending(o => o.CandidatoProcessoSeletivo.IdProcessoSeletivo)
                                                                .OrderByDescending(o=>o.NotaFinal)
                                                                .ThenByDescending(t => t.NotaEntrevista)
                                                                .ThenByDescending(t => t.NotaProposta)
                                                                .ThenByDescending(t => t.NotaLattes)
                                                                .ThenByDescending(t=>t.CandidatoProcessoSeletivo.IdProcessoSeletivo).ToList();
                                                    //.GroupBy(g=> g.CandidatoProcessoSeletivo.IdProcessoSeletivo).;

            return lAvaliacoes;
        }

        public IEnumerable<Avaliacao> ObtemCandidatosClassificacao(int pIdProcessoSeletivo, int pIdAreaConcentracao)
        {
            int? lIdProcessoSeletivo = null;
            int? lIdAreaConcentracao = null;

            if (pIdProcessoSeletivo > 0)
            {
                lIdProcessoSeletivo = pIdProcessoSeletivo;
            }

            if (pIdAreaConcentracao > 0)
            {
                lIdAreaConcentracao = pIdAreaConcentracao;
            }

            var lAvaliacoes = Db.Avaliacao.ToList().Where(x =>
                                                              (lIdProcessoSeletivo == null || x.CandidatoProcessoSeletivo.IdProcessoSeletivo == lIdProcessoSeletivo) &&
                                                              (lIdAreaConcentracao == null || x.CandidatoProcessoSeletivo.IdAreaConcentracao == lIdAreaConcentracao) &&
                                                               x.Concluida == true)
                                                                .OrderByDescending(o => o.CandidatoProcessoSeletivo.IdProcessoSeletivo)
                                                                .OrderByDescending(o => o.NotaFinal)
                                                                .ThenByDescending(t => t.NotaEntrevista)
                                                                .ThenByDescending(t => t.NotaProposta)
                                                                .ThenByDescending(t => t.NotaLattes)
                                                                .ThenByDescending(t => t.CandidatoProcessoSeletivo.IdProcessoSeletivo).ToList();
            //.GroupBy(g=> g.CandidatoProcessoSeletivo.IdProcessoSeletivo).;

            return lAvaliacoes;
        }
    }
}

