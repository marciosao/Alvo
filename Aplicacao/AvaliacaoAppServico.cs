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
        private readonly IQuestaoServico _questaoServico;

        public AvaliacaoAppServico(IAvaliacaoServico avaliacaoServico, IRespostaQuestaoServico respostaQuestaoServico, IQuestaoServico questaoServico)
            : base(avaliacaoServico)
        {
            _avaliacaoServico = avaliacaoServico;
            _respostaQuestaoServico = respostaQuestaoServico;
            _questaoServico = questaoServico;
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

                    if (lResposta == null)
                    {
                        lRowResposta.Questao = _questaoServico.ObtemQuestaoPorId(lRowResposta.IdQuestao);
                    }
                    else
                    {
                        lRowResposta.Questao = lResposta.Questao;
                    }

                    if (!string.IsNullOrEmpty(lRowResposta.ValorResposta))
                    {
                        if (lRowResposta.Questao.CategoriaQuestao.IdGrupoQuestao == 1)//Grupo Proposta de Trabalho
                        {
                            lTotalPropostaTrabalho += decimal.Parse(lRowResposta.ValorResposta);
                        }
                        else if (lRowResposta.Questao.CategoriaQuestao.IdGrupoQuestao == 2)//Grupo Avaliação Curriculo Lates
                        {
                            lTotalCurriculoLattes += decimal.Parse(lRowResposta.ValorResposta);
                        }
                        else if (lRowResposta.Questao.CategoriaQuestao.IdGrupoQuestao == 3)//Grupo Entrevista
                        {
                            lTotalEntrevista += decimal.Parse(lRowResposta.ValorResposta);
                        }
                    }


                    //descartando a Questão da resposta
                    lRowResposta.Questao = null;

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
            
            lIdAvaliacao.ParecerAvaliador = lAvaliacao.ParecerAvaliador;
            lIdAvaliacao.DataAvaliacao = DateTime.Now.Date;

            //calculando a Média final
            lNotaFinal = ((lTotalEntrevista*4 ) + (lTotalPropostaTrabalho*3) + (lTotalCurriculoLattes*2)) / 10;

            if (lNotaFinal >= 7)
            {
                lIdAvaliacao.Aprovado = true;
            }
            else
            {
                lIdAvaliacao.Aprovado = false;
            }

            

            if (lAvavaliacaoConcluida)
            {
                lIdAvaliacao.NotaFinal = lNotaFinal;
                lIdAvaliacao.Concluida = true;
            }
            else
            {
                lIdAvaliacao.NotaFinal = 0;
                lIdAvaliacao.Concluida = false;
            }


            _avaliacaoServico.Update(lIdAvaliacao);
        }


        public Avaliacao ObtemAvaliacaoPorCandidatoProcesso(int pCandidatoProcessoSeletivo)
        {
            return _avaliacaoServico.ObtemAvaliacaoPorCandidatoProcesso(pCandidatoProcessoSeletivo);
        }
    }
}

