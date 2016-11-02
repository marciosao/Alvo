using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using System;


namespace Aplicacao
{
    public class AvaliacaoAppServico : AppServicoBase<Avaliacao>, IAvaliacaoAppServico
    {
        private readonly IAvaliacaoServico _avaliacaoServico;
        private readonly IRespostaQuestaoServico _respostaQuestaoServico;

        public AvaliacaoAppServico(IAvaliacaoServico avaliacaoServico, IRespostaQuestaoServico respostaQuestaoServico)
            : base(avaliacaoServico)
        {
            _avaliacaoServico = avaliacaoServico;
            _respostaQuestaoServico = respostaQuestaoServico;
        }


        public void GravarRespostasAvaliacao(Avaliacao lAvaliacao)
        {
            var lIdAvaliacao = _avaliacaoServico.ObtemPorId(lAvaliacao.Id);
            decimal lNotaFinal = 0;

            decimal lTotalEntrevista = 0;
            decimal lTotalPropostaTrabalho = 0;
            decimal lTotalCurriculoLattes = 0;

            bool lAvavaliacaoConcluida = true;

            foreach (var lRowResposta in lAvaliacao.RespostaQuestao)
            {
                if (!string.IsNullOrEmpty(lRowResposta.ValorResposta))
                {
                    RespostaQuestao lResposta = _respostaQuestaoServico.ObtemPorQuestaoAvaliacao(lRowResposta.IdQuestao, lRowResposta.IdAvaliacao);

                    if (lResposta == null || lResposta.Id == 0)
                    {
                        _respostaQuestaoServico.Add(lRowResposta);
                    }
                    else
                    {
                        lResposta.ValorResposta = lRowResposta.ValorResposta;
                        _respostaQuestaoServico.Update(lResposta);
                    }

                    lNotaFinal += Decimal.Parse(lRowResposta.ValorResposta);
                }
                else
                {
                    lAvavaliacaoConcluida = false;
                }
            }

            lIdAvaliacao.NotaFinal = lNotaFinal;
            lIdAvaliacao.ParecerAvaliador = lAvaliacao.ParecerAvaliador;

            if (lAvavaliacaoConcluida)
            {
                lIdAvaliacao.Concluida = true;
            }
            lIdAvaliacao.DataAvaliacao = DateTime.Now.Date;

            _avaliacaoServico.Update(lIdAvaliacao);
        }


        public Avaliacao ObtemAvaliacaoPorCandidatoProcesso(int pCandidatoProcessoSeletivo)
        {
            return _avaliacaoServico.ObtemAvaliacaoPorCandidatoProcesso(pCandidatoProcessoSeletivo);
        }
    }
}

