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
        public AvaliacaoController(IAvaliacaoAppServico avaliacaoAppServico, IUsuarioAppServico usuarioAppServico, ICandidatoProcessoSeletivoAppServico candidatoProcessoSeletivoAppServico, IAreaConcentracaoAppServico areaConcentracaoAppServico, IQuestionarioAppServico questionarioAppServico)
        {
            _avaliacaoAppServico = avaliacaoAppServico;
            _usuarioAppServico = usuarioAppServico;
            _candidatoProcessoSeletivoAppServico = candidatoProcessoSeletivoAppServico;
            _areaConcentracaoAppServico = areaConcentracaoAppServico;
            _questionarioAppServico = questionarioAppServico;
        }

        // GET: Avaliacao
        public ActionResult Index()
        {
            UsuarioViewModel lUsuario = GetUsuarioLogado();

            var candidatoProcessoSeletivoViewModel = Mapper.Map<IEnumerable<CandidatoProcessoSeletivo>, IEnumerable<CandidatoProcessoSeletivoViewModel>>(_candidatoProcessoSeletivoAppServico.ObtemAvaliacoesPorProfessor(lUsuario.Id));

            return View(candidatoProcessoSeletivoViewModel);
        }

        public ActionResult Classificacao()
        {
            var avaliacaoViewModel = Mapper.Map<IEnumerable<Avaliacao>, IEnumerable<AvaliacaoViewModel>>(_avaliacaoAppServico.ObtemCandidatosClassificacao(0));

            return View(avaliacaoViewModel);
        }

        // GET: Distribuição
        public ActionResult Distribuicao()
        {
            var candidatoProcessoSeletivoViewModel = Mapper.Map<IEnumerable<CandidatoProcessoSeletivo>, IEnumerable<CandidatoProcessoSeletivoViewModel>>(_candidatoProcessoSeletivoAppServico.ObtemTodosSemAvaliacao());
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
            if (!string.IsNullOrEmpty(pAvaliacaoViewModel.ParecerAvaliador))
            {
                lAvaliacao.ParecerAvaliador = pAvaliacaoViewModel.ParecerAvaliador.Trim();
            }

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
                List<RespostaQuestaoViewModel> lListaRespostaQuestao = RetornaQuestoesEtapaIII(form);

                foreach (var item2 in lListaRespostaQuestao)
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

            _avaliacaoAppServico.GravarRespostasAvaliacao(lAvaliacao);

            return RedirectToAction("Index");
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

        private List<RespostaQuestaoViewModel> RetornaQuestoesEtapaIII(FormCollection pForm)
        {
            List<RespostaQuestaoViewModel> lListaRespostaQuestao = new List<RespostaQuestaoViewModel>();
            RespostaQuestaoViewModel lRespostaQuestao = new RespostaQuestaoViewModel();

            for (int i = 0; i < pForm.Count; i++)
            {
                string teste = pForm[i].ToString();
            }

            return lListaRespostaQuestao;
        }
    }
}
