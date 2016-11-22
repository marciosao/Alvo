﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao.Interfaces;
using Dominio.Entidades;
using Alvo.ViewModels;
using AutoMapper;
using System.Collections;

namespace Alvo.Controllers
{
    public class AvaliacaoController : BaseController
    {
        private readonly IAvaliacaoAppServico _avaliacaoAppServico;
        private readonly IUsuarioAppServico _usuarioAppServico;
        private readonly ICandidatoProcessoSeletivoAppServico _candidatoProcessoSeletivoAppServico;
        private readonly IAreaConcentracaoAppServico _areaConcentracaoAppServico;
        private readonly IQuestionarioAppServico _questionarioAppServico;
        private readonly IProcessoSeletivoAppServico _processoSeletivoAppServico;
        private readonly ISituacaoAvaliacaoAppServico _situacaoAvaliacaoAppServico;

        public AvaliacaoController(IAvaliacaoAppServico avaliacaoAppServico, IUsuarioAppServico usuarioAppServico, ICandidatoProcessoSeletivoAppServico candidatoProcessoSeletivoAppServico, IAreaConcentracaoAppServico areaConcentracaoAppServico, IQuestionarioAppServico questionarioAppServico, IProcessoSeletivoAppServico processoSeletivoAppServico, ISituacaoAvaliacaoAppServico situacaoAvaliacaoAppServico)
        {
            _avaliacaoAppServico = avaliacaoAppServico;
            _usuarioAppServico = usuarioAppServico;
            _candidatoProcessoSeletivoAppServico = candidatoProcessoSeletivoAppServico;
            _areaConcentracaoAppServico = areaConcentracaoAppServico;
            _questionarioAppServico = questionarioAppServico;
            _processoSeletivoAppServico = processoSeletivoAppServico;
            _situacaoAvaliacaoAppServico = situacaoAvaliacaoAppServico;
        }

        // GET: Avaliacao
        public ActionResult Index()
        {
            UsuarioViewModel lUsuario = GetUsuarioLogado();
            ViewBag.IdUsuario = lUsuario;

            var lIdProfessorPesquisa = 0;
            if (lUsuario.Perfil.Id != (int)Dominio.Enums.Perfil.Secretaria)
            {
                lIdProfessorPesquisa = lUsuario.Id;
            }

            var candidatoProcessoSeletivoViewModel = Mapper.Map<IEnumerable<CandidatoProcessoSeletivo>, IEnumerable<CandidatoProcessoSeletivoViewModel>>(_candidatoProcessoSeletivoAppServico.ObtemAvaliacoesPorProfessor(lUsuario.Id, 0, 0, lIdProfessorPesquisa));

            ViewBag.IdProcessoSeletivo = new SelectList(_processoSeletivoAppServico.ObtemTodos(), "Id", "Titulo");
            ViewBag.IdSituacaoAvaliacao = new SelectList(_situacaoAvaliacaoAppServico.ObtemTodos(), "Id", "Situacao");
            ViewBag.IdProfessor = new SelectList(_usuarioAppServico.ObtemUsuariosProfessores(), "Id", "Nome");//Usuario com perfil de Professor

            return View(candidatoProcessoSeletivoViewModel);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            UsuarioViewModel lUsuario = GetUsuarioLogado();
            ViewBag.IdUsuario = lUsuario;

            int lIdProcessoSeletivo = (!string.IsNullOrEmpty(form["IdProcessoSeletivo"])) ? int.Parse(form["IdProcessoSeletivo"]) : 0;
            int lIdSituacaoAvaliacao = (!string.IsNullOrEmpty(form["IdSituacaoAvaliacao"])) ? int.Parse(form["IdSituacaoAvaliacao"]) : 0;
            int lIdProfessor = (!string.IsNullOrEmpty(form["IdProfessor"])) ? int.Parse(form["IdProfessor"]) : 0;

            var candidatoProcessoSeletivoViewModel = Mapper.Map<IEnumerable<CandidatoProcessoSeletivo>, IEnumerable<CandidatoProcessoSeletivoViewModel>>(_candidatoProcessoSeletivoAppServico.ObtemAvaliacoesPorProfessor(lUsuario.Id, lIdProcessoSeletivo, lIdSituacaoAvaliacao, lIdProfessor));

            ViewBag.IdProcessoSeletivo = new SelectList(_processoSeletivoAppServico.ObtemTodos(), "Id", "Titulo", lIdProcessoSeletivo);
            ViewBag.IdSituacaoAvaliacao = new SelectList(_situacaoAvaliacaoAppServico.ObtemTodos(), "Id", "Situacao", lIdSituacaoAvaliacao);
            ViewBag.IdProfessor = new SelectList(_usuarioAppServico.ObtemUsuariosProfessores(), "Id", "Nome", lIdProfessor);//Usuario com perfil de Professor

            return View(candidatoProcessoSeletivoViewModel);
        }

        public ActionResult Classificacao()
        {
            var avaliacaoViewModel = Mapper.Map<IEnumerable<Avaliacao>, IEnumerable<AvaliacaoViewModel>>(_avaliacaoAppServico.ObtemCandidatosClassificacao(0));

            ViewBag.IdProcessoSeletivo = new SelectList(_processoSeletivoAppServico.ObtemTodos(), "Id", "Titulo");
            ViewBag.IdAreaConcentracao = new SelectList(_areaConcentracaoAppServico.ObtemTodos(), "Id", "Nome");

            return View(avaliacaoViewModel);
        }

        [HttpPost]
        public ActionResult Classificacao(FormCollection form)
        {
            int lIdProcessoSeletivo = 0;
            if (!string.IsNullOrEmpty(form["IdProcessoSeletivo"]))
            {
                lIdProcessoSeletivo = int.Parse(form["IdProcessoSeletivo"]);
            }

            int lIdAreaConcentracao = 0;
            if (!string.IsNullOrEmpty(form["IdAreaConcentracao"]))
            {
                lIdAreaConcentracao = int.Parse(form["IdAreaConcentracao"]);
            }

            var avaliacaoViewModel = Mapper.Map<IEnumerable<Avaliacao>, IEnumerable<AvaliacaoViewModel>>(_avaliacaoAppServico.ObtemCandidatosClassificacao(lIdProcessoSeletivo, lIdAreaConcentracao));

            ViewBag.IdProcessoSeletivo = new SelectList(_processoSeletivoAppServico.ObtemTodos(), "Id", "Titulo", lIdProcessoSeletivo);
            ViewBag.IdAreaConcentracao = new SelectList(_areaConcentracaoAppServico.ObtemTodos(), "Id", "Nome", lIdAreaConcentracao);

            return View(avaliacaoViewModel);
        }

        // GET: Distribuição
        public ActionResult Distribuicao()
        {
            var candidatoProcessoSeletivoViewModel = Mapper.Map<IEnumerable<CandidatoProcessoSeletivo>, IEnumerable<CandidatoProcessoSeletivoViewModel>>(_candidatoProcessoSeletivoAppServico.ObtemTodosSemAvaliacao());

            ViewBag.IdProfessor = new SelectList(_usuarioAppServico.ObtemUsuariosProfessores(), "Id", "Nome");//Usuario com perfil de Professor

            return View(candidatoProcessoSeletivoViewModel);
        }

        [HttpPost]
        public ActionResult Distribuicao(FormCollection form)
        {
            int? lIdProfessor = null;
            if (!string.IsNullOrEmpty(form["IdProfessor"]))
            {
                lIdProfessor = int.Parse(form["IdProfessor"]);
            }

            var candidatoProcessoSeletivoViewModel = Mapper.Map<IEnumerable<CandidatoProcessoSeletivo>, IEnumerable<CandidatoProcessoSeletivoViewModel>>(_candidatoProcessoSeletivoAppServico.ObtemAvaliacoesPorProfessor(lIdProfessor));

            ViewBag.IdProfessor = new SelectList(_usuarioAppServico.ObtemUsuariosProfessores(), "Id", "Nome", lIdProfessor);//Usuario com perfil de Professor

            return View(candidatoProcessoSeletivoViewModel);
        }

        public ActionResult EditDistribuicao(int id)
        {
            var candidatoProcessoSeletivo = _candidatoProcessoSeletivoAppServico.ObtemPorId(id);
            var candidatoProcessoSeletivoViewModel = Mapper.Map<CandidatoProcessoSeletivo, CandidatoProcessoSeletivoViewModel>(candidatoProcessoSeletivo);

            ViewBag.IdProfessor = new SelectList(_usuarioAppServico.ObtemUsuariosProfessores(), "Id", "Nome");//Usuario com perfil de Professor

            return View(candidatoProcessoSeletivoViewModel);
        }

        [HttpPost]
        public ActionResult EditDistribuicao(CandidatoProcessoSeletivoViewModel pCandidatoProcessoSeletivo, FormCollection formulario)
        {
            int lIdProfessor = Convert.ToInt32(formulario["IdProfessor"]);

            if (ModelState.IsValid)
            {
                _candidatoProcessoSeletivoAppServico.DistribuiAvaliacaoResponsavel(pCandidatoProcessoSeletivo.Id, lIdProfessor);
            }

            return RedirectToAction("Distribuicao");
        }

        public ActionResult EdicaoDistribuicao(int id)
        {
            var candidatoProcessoSeletivo = _candidatoProcessoSeletivoAppServico.ObtemPorId(id);
            var candidatoProcessoSeletivoViewModel = Mapper.Map<CandidatoProcessoSeletivo, CandidatoProcessoSeletivoViewModel>(candidatoProcessoSeletivo);

            ViewBag.IdProfessor = new SelectList(_usuarioAppServico.ObtemUsuariosProfessores(), "Id", "Nome", (candidatoProcessoSeletivo.Avaliacao.FirstOrDefault().IdProfessor!=null)?candidatoProcessoSeletivo.Avaliacao.FirstOrDefault().IdProfessor:0);//Usuario com perfil de Professor

            return View(candidatoProcessoSeletivoViewModel);
        }

        [HttpPost]
        public ActionResult EdicaoDistribuicao(CandidatoProcessoSeletivoViewModel pCandidatoProcessoSeletivo, FormCollection formulario)
        {
            int lIdProfessor = Convert.ToInt32(formulario["IdProfessor"]);

            if (ModelState.IsValid)
            {
                _candidatoProcessoSeletivoAppServico.AlterarDistribuicao(pCandidatoProcessoSeletivo.Id, lIdProfessor);
            }

            return RedirectToAction("Distribuicao");
        }

        // GET: Avaliacao/Details/5
        public ActionResult Details(int id)
        {
            var lAvaliacao = _avaliacaoAppServico.ObtemPorId(id);
            var lAvaliacaoViewModel = Mapper.Map<Avaliacao, AvaliacaoViewModel>(lAvaliacao);

            return View(lAvaliacaoViewModel);
        }

        // GET: Avaliacao/Create
        public ActionResult Create()
        {
            ViewBag.IdProfessor = new SelectList(_usuarioAppServico.ObtemTodos(), "Id", "Nome");

            return View();
        }

        // POST: Avaliacao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AvaliacaoViewModel pAvaliacao)
        {
            if (ModelState.IsValid)
            {
                var lAvaliacaoDomain = Mapper.Map<AvaliacaoViewModel, Avaliacao>(pAvaliacao);

                _avaliacaoAppServico.Add(lAvaliacaoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.IdProfessor = new SelectList(_usuarioAppServico.ObtemTodos(), "Id", "Nome");

            return View(pAvaliacao);
        }

        // GET: Avaliacao/Edit/5
        public ActionResult Edit(int id)
        {
            var lAvaliacao = _avaliacaoAppServico.ObtemPorId(id);
            var lAvaliacaoViewModel = Mapper.Map<Avaliacao, AvaliacaoViewModel>(lAvaliacao);

            ViewBag.IdProfessor = new SelectList(_usuarioAppServico.ObtemTodos(), "Id", "Nome");

            return View(lAvaliacaoViewModel);
        }

        // POST: Avaliacao/Edit/5
        [HttpPost]
        public ActionResult Edit(AvaliacaoViewModel pAvaliacaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var lAvaliacao = Mapper.Map<AvaliacaoViewModel, Avaliacao>(pAvaliacaoViewModel);
                _avaliacaoAppServico.Update(lAvaliacao);

                return RedirectToAction("Index");
            }

            ViewBag.IdProfessor = new SelectList(_usuarioAppServico.ObtemTodos(), "Id", "Nome");

            return View(pAvaliacaoViewModel);

        }

        public ActionResult Avaliacao(int id)
        {
            ////////1	1	Usuario Administrador
            ////////2	3	Usuario Secretaria 1
            ////////3	2	Usuario Professor 1
            ////////*4	2	Usuario Professor 2
            ////////5	2	Usuario Professor 3

            ////////1	Administrador
            ////////2	Professor
            ////////3	Secretaria

            ////////UsuarioViewModel lUsuario = GetUsuarioLogado();

            ////////var lUsuario = Mapper.Map<Usuario, UsuarioViewModel>(_usuarioAppServico.ObtemPorId(4));
            var lUsuario = Mapper.Map<UsuarioViewModel, Usuario>(GetUsuarioLogado());

            ViewBag.IdPerfil = lUsuario.Perfil.Id;
            ViewBag.Usuario = Mapper.Map<Usuario, UsuarioViewModel>(lUsuario);

            var lAvaliacao = _avaliacaoAppServico.ObtemAvaliacaoPorCandidatoProcesso(id);
            var lAvaliacaoViewModel = Mapper.Map<Avaliacao, AvaliacaoViewModel>(lAvaliacao);

            ViewBag.IdSituacaoAvaliacao = lAvaliacao.SituacaoAvaliacao.Id;
            ViewBag.lParecerAvaliador = lAvaliacao.ParecerAvaliador;
            ViewBag.ValorNota = 7; // Obter o cálculo da nota Parcial aqui //---------------------------------------------------------------------------

            var lQuestionario = Mapper.Map<Questionario, QuestionarioViewModel>(_questionarioAppServico.ObtemQuestionarioPorCandidatoProcesso(id));

            lQuestionario.ParecerAvaliador = lAvaliacao.ParecerAvaliador;

            lAvaliacaoViewModel.Questionario = lQuestionario;

            lAvaliacaoViewModel.Questionario.Questao.ForEach(x =>
                    {
                        if (x.RespostaQuestao == null || x.RespostaQuestao.Count == 0)
                        {
                            x.RespostaQuestao = new List<RespostaQuestaoViewModel> 
                            { 
                                new RespostaQuestaoViewModel()
                                {
                                    IdQuestao = x.Id
                                }
                            };
                        }
                        else if (x.RespostaQuestao.Any(r => r.IdAvaliacao == lAvaliacao.Id))
                        {
                            x.RespostaQuestao = x.RespostaQuestao.Where(z => z.IdAvaliacao == lAvaliacao.Id).ToList();
                        }
                        else
                        {
                            x.RespostaQuestao = new List<RespostaQuestaoViewModel> 
                            { 
                                new RespostaQuestaoViewModel()
                                {
                                    IdQuestao = x.Id
                                }
                            };
                        }
                    }
                );

            return View(lAvaliacaoViewModel);
        }

        public ActionResult DetalhesAvaliacao(int id)
        {
            var lAvaliacao = _avaliacaoAppServico.ObtemAvaliacaoPorCandidatoProcesso(id);
            var lAvaliacaoViewModel = Mapper.Map<Avaliacao, AvaliacaoViewModel>(lAvaliacao);

            var lQuestionario = Mapper.Map<Questionario, QuestionarioViewModel>(_questionarioAppServico.ObtemQuestionarioPorCandidatoProcesso(id));

            lQuestionario.ParecerAvaliador = lAvaliacao.ParecerAvaliador;

            lAvaliacaoViewModel.Questionario = lQuestionario;

            lAvaliacaoViewModel.Questionario.Questao.ForEach(x =>
            {
                if (x.RespostaQuestao == null || x.RespostaQuestao.Count == 0)
                {
                    x.RespostaQuestao = new List<RespostaQuestaoViewModel> 
                            { 
                                new RespostaQuestaoViewModel()
                                {
                                    IdQuestao = x.Id
                                }
                            };
                }
                else if (x.RespostaQuestao.Any(r => r.IdAvaliacao == lAvaliacao.Id))
                {
                    x.RespostaQuestao = x.RespostaQuestao.Where(z => z.IdAvaliacao == lAvaliacao.Id).ToList();
                }
                else
                {
                    x.RespostaQuestao = new List<RespostaQuestaoViewModel> 
                            { 
                                new RespostaQuestaoViewModel()
                                {
                                    IdQuestao = x.Id
                                }
                            };
                }
            }
    );

            return View(lAvaliacaoViewModel);
        }

        [HttpPost]
        public ActionResult Avaliacao(AvaliacaoViewModel pAvaliacaoViewModel, FormCollection form)
        {
            Avaliacao lAvaliacao = new Avaliacao();

            lAvaliacao.Id = pAvaliacaoViewModel.Id;
            if ((!string.IsNullOrEmpty(pAvaliacaoViewModel.ParecerAvaliador) && pAvaliacaoViewModel.IdSituacaoAvaliacao == (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIIProfessor)|| pAvaliacaoViewModel.IdSituacaoAvaliacao == (int)Dominio.Enums.SiuacaoAvaliacao.PendenteEtapaIII)
            {
                lAvaliacao.ParecerAvaliador = pAvaliacaoViewModel.ParecerAvaliador.Trim();
                //}

                if (pAvaliacaoViewModel.Questao != null)
                {
                    foreach (var item in pAvaliacaoViewModel.Questao)
                    {
                        foreach (var item2 in item.RespostaQuestao)
                        {
                            RespostaQuestao lResposta = new RespostaQuestao();
                            lResposta.Id = item2.Id;
                            lResposta.IdQuestao = item2.IdQuestao;
                            lResposta.ValorResposta = item2.ValorResposta;

                            if (item2.IdAvaliacao == lAvaliacao.Id)
                            {
                                lResposta.IdAvaliacao = item2.IdAvaliacao;
                            }
                            else
                            {
                                lResposta.IdAvaliacao = lAvaliacao.Id;
                            }

                            lAvaliacao.RespostaQuestao.Add(lResposta);
                        }
                    }
                }
                else
                {
                    List<RespostaQuestao> lListaRespostaQuestao = RetornaQuestoesEtapaIII(form, lAvaliacao.Id);

                    foreach (var item2 in lListaRespostaQuestao)
                    {
                        lAvaliacao.RespostaQuestao.Add(item2);
                    }
                }

                _avaliacaoAppServico.GravarRespostasAvaliacao(lAvaliacao);

                return RedirectToAction("Index");
                //.Mensagem("Candidatos Importados com Sucesso.")
            }
            else
            {
                return RedirectToAction("Avaliacao", "Avaliacao").Mensagem("Caro Professor, o Parecer do Avaliador é obrigatório.");
                //return View().Mensagem("Caro Professor, o Parecer do Avaliador é obrigatório.");
            }
        }

        // GET: Avaliacao/Delete/5
        public ActionResult Delete(int id)
        {
            var lAvaliacao = _avaliacaoAppServico.ObtemPorId(id);
            var lAvaliacaoViewModel = Mapper.Map<Avaliacao, AvaliacaoViewModel>(lAvaliacao);

            return View(lAvaliacaoViewModel);
        }

        // POST: Avaliacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lAvaliacao = _avaliacaoAppServico.ObtemPorId(id);
            _avaliacaoAppServico.Remove(lAvaliacao);

            return RedirectToAction("Index");
        }

        public ActionResult QuestoesQuestionario(int id)
        {
            var lQuestionario = Mapper.Map<Questionario, QuestionarioViewModel>(_questionarioAppServico.ObtemQuestionarioPorCandidatoProcesso(id));



            return PartialView("~/Views/Questao/_Questao.cshtml", lQuestionario.Questao);
        }

        private List<RespostaQuestao> RetornaQuestoesEtapaIII(FormCollection pForm, int pIdAvaliacao)
        {
            List<RespostaQuestao> lListaRespostaQuestao = new List<RespostaQuestao>();

            RespostaQuestao lRespostaQuestao16 = new RespostaQuestao();
            lRespostaQuestao16.ValorResposta = pForm[4].ToString();
            lRespostaQuestao16.IdQuestao = int.Parse(pForm[5].ToString());
            lRespostaQuestao16.IdAvaliacao = pIdAvaliacao;

            lListaRespostaQuestao.Add(lRespostaQuestao16);

            RespostaQuestao lRespostaQuestao17 = new RespostaQuestao();
            lRespostaQuestao17.ValorResposta = pForm[7].ToString();
            lRespostaQuestao17.IdQuestao = int.Parse(pForm[8].ToString());
            lRespostaQuestao17.IdAvaliacao = pIdAvaliacao;

            lListaRespostaQuestao.Add(lRespostaQuestao17);

            RespostaQuestao lRespostaQuestao18 = new RespostaQuestao();
            lRespostaQuestao18.ValorResposta = pForm[10].ToString();
            lRespostaQuestao18.IdQuestao = int.Parse(pForm[11].ToString());
            lRespostaQuestao18.IdAvaliacao = pIdAvaliacao;

            lListaRespostaQuestao.Add(lRespostaQuestao18);

            RespostaQuestao lRespostaQuestao19 = new RespostaQuestao();
            lRespostaQuestao19.ValorResposta = pForm[13].ToString();
            lRespostaQuestao19.IdQuestao = int.Parse(pForm[14].ToString());
            lRespostaQuestao19.IdAvaliacao = pIdAvaliacao;

            lListaRespostaQuestao.Add(lRespostaQuestao19);

            RespostaQuestao lRespostaQuestao20 = new RespostaQuestao();
            lRespostaQuestao20.ValorResposta = pForm[16].ToString();
            lRespostaQuestao20.IdQuestao = int.Parse(pForm[17].ToString());
            lRespostaQuestao20.IdAvaliacao = pIdAvaliacao;

            lListaRespostaQuestao.Add(lRespostaQuestao20);

            RespostaQuestao lRespostaQuestao21 = new RespostaQuestao();
            lRespostaQuestao21.ValorResposta = pForm[19].ToString();
            lRespostaQuestao21.IdQuestao = int.Parse(pForm[20].ToString());
            lRespostaQuestao21.IdAvaliacao = pIdAvaliacao;

            lListaRespostaQuestao.Add(lRespostaQuestao21);

            return lListaRespostaQuestao;
        }
    }
}
