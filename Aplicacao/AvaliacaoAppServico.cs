using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;


namespace Aplicacao
{
    public class AvaliacaoAppServico : AppServicoBase<Avaliacao>, IAvaliacaoAppServico
    {
        private readonly IAvaliacaoServico _avaliacaoServico;
        private readonly IRespostaQuestaoServico _respostaQuestaoServico;
        private readonly IQuestaoServico _questaoServico;

        private decimal gTotalEntrevista = 0;
        private decimal gTotalPropostaTrabalho = 0;
        private decimal gTotalCurriculoLattes = 0;

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
            decimal lNotaParcial = 0;

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
                }
                else
                {
                    lAvavaliacaoConcluida = false;
                }
            }
            
            lIdAvaliacao.ParecerAvaliador = lAvaliacao.ParecerAvaliador;
            lIdAvaliacao.DataAvaliacao = DateTime.Now.Date;

            //calculando a média parcial
            lNotaParcial = this.CalculoMedias(lAvaliacao,"P");
            lIdAvaliacao.NotaParcial = lNotaParcial;

            //calculando a Média final
            lNotaFinal = this.CalculoMedias(lAvaliacao, "F");

            //Definindo a próxima Situação
            if (lIdAvaliacao.SituacaoAvaliacao.Id == (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIISecretaria)
            {
                lIdAvaliacao.IdSituacaoAvaliacao = (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIIProfessor;
            }
            else if (lIdAvaliacao.SituacaoAvaliacao.Id == (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIIProfessor)
            {
                //Se for a avaliação do professor e o candidato não obteve a média suficiente para a entrevista, que é maior ou igual à 7, 
                //a avaliação deve ser concluída e o candidato estará reprovado. Caso contrário o candidato passará pela próxima etapa que é a entrevista
                if (lNotaParcial >= 7)
                {
                    lIdAvaliacao.IdSituacaoAvaliacao = (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIII;
                }
                else
                {
                    lIdAvaliacao.IdSituacaoAvaliacao = (int)Dominio.Enums.SiuacaoAvaliacao.Concluida;
                    lIdAvaliacao.Concluida = true;
                    lIdAvaliacao.Aprovado = false;
                    lAvavaliacaoConcluida = true;
                    lIdAvaliacao.NotaFinal = lNotaFinal;
                }

            }
            else if (lIdAvaliacao.SituacaoAvaliacao.Id == (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIII)
            {
                lIdAvaliacao.IdSituacaoAvaliacao = (int)Dominio.Enums.SiuacaoAvaliacao.Concluida;
                lIdAvaliacao.Concluida = true;
                lAvavaliacaoConcluida = true;

                lIdAvaliacao.NotaFinal = lNotaFinal;

                if (lNotaFinal >= 7)
                {
                    lIdAvaliacao.Aprovado = true;
                }
                else
                {
                    lIdAvaliacao.Aprovado = false;
                }
            }

            lIdAvaliacao.NotaEntrevista = gTotalEntrevista;
            lIdAvaliacao.NotaLattes = gTotalCurriculoLattes;
            lIdAvaliacao.NotaProposta = gTotalPropostaTrabalho;

            _avaliacaoServico.Update(lIdAvaliacao);
        }

        public void GravarRespostasAvaliacao(Avaliacao lAvaliacao, bool pAvaliacaoFinalizada)
        {
            var lIdAvaliacao = _avaliacaoServico.ObtemPorId(lAvaliacao.Id);
            decimal lNotaFinal = 0;
            decimal lNotaParcial = 0;

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
                }
                else
                {
                    lAvavaliacaoConcluida = false;
                }
            }

            lIdAvaliacao.ParecerAvaliador = lAvaliacao.ParecerAvaliador;
            lIdAvaliacao.DataAvaliacao = DateTime.Now.Date;

            //calculando a média parcial
            lNotaParcial = this.CalculoMedias(lAvaliacao, "P");
            lIdAvaliacao.NotaParcial = lNotaParcial;

            //calculando a Média final
            lNotaFinal = this.CalculoMedias(lAvaliacao, "F");

            //Definindo a próxima Situação
            if (lIdAvaliacao.SituacaoAvaliacao.Id == (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIISecretaria)
            {
                lIdAvaliacao.IdSituacaoAvaliacao = (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIIProfessor;
            }
            else if (lIdAvaliacao.SituacaoAvaliacao.Id == (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIIProfessor)
            {
                //Se for a avaliação do professor e o candidato não obteve a média suficiente para a entrevista, que é maior ou igual à 7, 
                //a avaliação deve ser concluída e o candidato estará reprovado. Caso contrário o candidato passará pela próxima etapa que é a entrevista
                if (lNotaParcial >= 7)
                {
                    if (pAvaliacaoFinalizada)
                    {
                        lIdAvaliacao.IdSituacaoAvaliacao = (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIII;
                    }
                }
                else
                {
                    if (pAvaliacaoFinalizada)
                    {
                        lIdAvaliacao.IdSituacaoAvaliacao = (int)Dominio.Enums.SiuacaoAvaliacao.Concluida;
                        lIdAvaliacao.Concluida = true;
                        lIdAvaliacao.Aprovado = false;
                        lAvavaliacaoConcluida = true;
                        lIdAvaliacao.NotaFinal = lNotaFinal;
                    }
                }

            }
            else if (lIdAvaliacao.SituacaoAvaliacao.Id == (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIII)
            {
                if (pAvaliacaoFinalizada)
                {
                    lIdAvaliacao.IdSituacaoAvaliacao = (int)Dominio.Enums.SiuacaoAvaliacao.Concluida;
                    lIdAvaliacao.Concluida = true;
                    lAvavaliacaoConcluida = true;
                }

                lIdAvaliacao.NotaFinal = lNotaFinal;

                if (lNotaFinal >= 7)
                {
                    lIdAvaliacao.Aprovado = true;
                }
                else
                {
                    lIdAvaliacao.Aprovado = false;
                }
            }

            lIdAvaliacao.NotaEntrevista = gTotalEntrevista;
            lIdAvaliacao.NotaLattes = gTotalCurriculoLattes;
            lIdAvaliacao.NotaProposta = gTotalPropostaTrabalho;

            _avaliacaoServico.Update(lIdAvaliacao);

        }
        public Avaliacao ObtemAvaliacaoPorCandidatoProcesso(int pCandidatoProcessoSeletivo)
        {
            return _avaliacaoServico.ObtemAvaliacaoPorCandidatoProcesso(pCandidatoProcessoSeletivo);
        }

        public IEnumerable<Avaliacao> ObtemCandidatosClassificacao(int pIdProcessoSeletivo)
        {
            return _avaliacaoServico.ObtemCandidatosClassificacao(pIdProcessoSeletivo);
        }

        public decimal CalculoMedias(Avaliacao pAvaliacao, string pTipoMedia)
        {
            decimal lResultado = 0;

            decimal lTotalEntrevista = 0;
            decimal lTotalPropostaTrabalho = 0;
            decimal lTotalCurriculoLattes = 0;

            pAvaliacao = _avaliacaoServico.ObtemPorId(pAvaliacao.Id);

            foreach (var lRowResposta in pAvaliacao.RespostaQuestao)
            {
                if (!string.IsNullOrEmpty(lRowResposta.ValorResposta))
                {
                    if (lRowResposta.Questao.CategoriaQuestao.IdGrupoQuestao == 1)//Grupo Proposta de Trabalho
                    {
                        lTotalPropostaTrabalho += decimal.Parse(lRowResposta.ValorResposta);
                        gTotalPropostaTrabalho += decimal.Parse(lRowResposta.ValorResposta);
                    }
                    else if (lRowResposta.Questao.CategoriaQuestao.IdGrupoQuestao == 2)//Grupo Avaliação Curriculo Lates
                    {
                        lTotalCurriculoLattes += decimal.Parse(lRowResposta.ValorResposta);
                        gTotalCurriculoLattes += decimal.Parse(lRowResposta.ValorResposta);
                    }
                    else if (lRowResposta.Questao.CategoriaQuestao.IdGrupoQuestao == 3)//Grupo Entrevista
                    {
                        lTotalEntrevista += decimal.Parse(lRowResposta.ValorResposta);
                        gTotalEntrevista += decimal.Parse(lRowResposta.ValorResposta);
                    }
                }
            }

            if (pTipoMedia.Equals("P")) //Cálculo Média Parcial
            {
                lResultado = ((lTotalPropostaTrabalho * 7) + (lTotalCurriculoLattes * 3)) / 10;
            }
            else if (pTipoMedia.Equals("F"))//Cálculo Média Parcial
            {
                lResultado = ((lTotalEntrevista * 5) + (lTotalPropostaTrabalho * 3) + (lTotalCurriculoLattes * 2)) / 10;
            }

            return lResultado;
        }

        public IEnumerable<Avaliacao> ObtemCandidatosClassificacao(int pIdProcessoSeletivo, int pIdAreaConcentracao)
        {
            return _avaliacaoServico.ObtemCandidatosClassificacao(pIdProcessoSeletivo, pIdAreaConcentracao);
        }
    }
}

