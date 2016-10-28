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
    public class AvaliacaoController : Controller
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
            // variável para teste..  pegar o usuário logado no sistema
            int lUsuario = 1;

            var candidatoProcessoSeletivoViewModel = Mapper.Map<IEnumerable<CandidatoProcessoSeletivo>, IEnumerable<CandidatoProcessoSeletivoViewModel>>(_candidatoProcessoSeletivoAppServico.ObtemAvaliacoesPorProfessor(lUsuario));

            return View(candidatoProcessoSeletivoViewModel);
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
            var lAvaliacao = _avaliacaoAppServico.ObtemPorId(id);
            var lAvaliacaoViewModel = Mapper.Map<Avaliacao, AvaliacaoViewModel>(lAvaliacao);

            ViewBag.IdAvaliacao = id;

            var lQuestionario = Mapper.Map<Questionario, QuestionarioViewModel>(_questionarioAppServico.ObtemQuestionarioPorCandidatoProcesso(id));

            lAvaliacaoViewModel.Questionario = lQuestionario;

            lAvaliacaoViewModel.Questionario.Questao.ForEach(x =>
                    {
                        x.RespostaQuestao = new List<RespostaQuestaoViewModel> 
                        { 
                            new RespostaQuestaoViewModel()
                            {
                                IdQuestao = x.Id
                            }
                        };
                    }
                );

            return View(lAvaliacaoViewModel);
        }

        public ActionResult DetalhesAvaliacao(int id)
        {
            var lAvaliacao = _avaliacaoAppServico.ObtemPorId(id);
            var lAvaliacaoViewModel = Mapper.Map<Avaliacao, AvaliacaoViewModel>(lAvaliacao);

            ViewBag.IdAvaliacao = id;

            var lQuestionario = Mapper.Map<Questionario, QuestionarioViewModel>(_questionarioAppServico.ObtemQuestionarioPorCandidatoProcesso(id));

            lAvaliacaoViewModel.Questionario = lQuestionario;

            ////////lAvaliacaoViewModel.Questionario.Questao.ForEach(x =>
            ////////{
            ////////    x.RespostaQuestao = new List<RespostaQuestaoViewModel> 
            ////////            { 
            ////////                new RespostaQuestaoViewModel()
            ////////                {
            ////////                    IdQuestao = x.Id
            ////////                }
            ////////            };
            ////////}
            ////////    );

            return View(lAvaliacaoViewModel);
        }

        [HttpPost]
        public ActionResult Avaliacao(AvaliacaoViewModel pAvaliacaoViewModel)
        {
            Avaliacao lAvaliacao = new Avaliacao();

            lAvaliacao.Id = pAvaliacaoViewModel.Id;

            foreach (var item in pAvaliacaoViewModel.Questao)
            {
                foreach (var item2 in item.RespostaQuestao)
                {
                    if (item2.IdAvaliacao == lAvaliacao.Id)
                    {
                        RespostaQuestao lResposta = new RespostaQuestao();
                        lResposta.IdAvaliacao = item2.IdAvaliacao;
                        lResposta.IdQuestao = item2.IdQuestao;
                        lResposta.ValorResposta = item2.ValorResposta;

                        lAvaliacao.RespostaQuestao.Add(lResposta);
                    }
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

    }
}
