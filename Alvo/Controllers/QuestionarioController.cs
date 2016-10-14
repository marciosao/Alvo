using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao.Interfaces;
using Dominio.Entidades;
using Alvo.ViewModels;
using AutoMapper;

namespace Alvo.Controllers
{
    public class QuestionarioController : Controller
    {
        private readonly IQuestionarioAppServico _questionarioAppServico;
        private readonly ICategoriaQuestaoAppServico _categoriaQuestaoAppServico;
        private readonly ITipoQuestaoAppServico _tipoQuestaoAppServico;
        private readonly IEtapaAppServico _etapaAppServico;
        private readonly IGrupoQuestaoAppServico _grupoQuestaoAppServico;

        public QuestionarioController(IQuestionarioAppServico questionarioAppServico, ICategoriaQuestaoAppServico categoriaQuestaoAppServico, ITipoQuestaoAppServico tipoQuestaoAppServico, IEtapaAppServico etapaAppServico, IGrupoQuestaoAppServico grupoQuestaoAppServico)
        {
            _questionarioAppServico = questionarioAppServico;
            _categoriaQuestaoAppServico = categoriaQuestaoAppServico;
            _tipoQuestaoAppServico = tipoQuestaoAppServico;
            _etapaAppServico = etapaAppServico;
            _grupoQuestaoAppServico = grupoQuestaoAppServico;
        }

        // GET: Questionario
        public ActionResult Index()
        {
            var questionarioViewModel = Mapper.Map<IEnumerable<Questionario>, IEnumerable<QuestionarioViewModel>>(_questionarioAppServico.ObtemTodos());
            return View(questionarioViewModel);
        }

        // GET: Questionario/Details/5
        public ActionResult Details(int id)
        {
            var lQuestionario = _questionarioAppServico.ObtemPorId(id);
            var lQuestionarioViewModel = Mapper.Map<Questionario, QuestionarioViewModel>(lQuestionario);

            return View(lQuestionarioViewModel);
        }

        // GET: Questionario/Create
        public ActionResult Create()
        {
            ViewBag.IdEtapa = new SelectList(_etapaAppServico.ObtemTodos(), "Id", "Nome");
            ViewBag.IdCategoriaQuestao = new SelectList(_grupoQuestaoAppServico.ObtemTodos(), "Id", "Nome");
            return View();
        }

        // POST: Questionario/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(QuestionarioViewModel pQuestionario)
        {
            if (ModelState.IsValid)
            {
                var lQuestionarioDomain = Mapper.Map<QuestionarioViewModel, Questionario>(pQuestionario);

                _questionarioAppServico.Add(lQuestionarioDomain);

                return RedirectToAction("Index");
            }

            ViewBag.IdEtapa = new SelectList(_etapaAppServico.ObtemTodos(), "Id", "Nome");
            ViewBag.IdCategoriaQuestao = new SelectList(_grupoQuestaoAppServico.ObtemTodos(), "Id", "Nome");

            return View(pQuestionario);
        }

        // GET: Questionario/Edit/5
        public ActionResult Edit(int id)
        {
            var lQuestionario = _questionarioAppServico.ObtemPorId(id);
            var lQuestionarioViewModel = Mapper.Map<Questionario, QuestionarioViewModel>(lQuestionario);

            ViewBag.IdEtapa = new SelectList(_etapaAppServico.ObtemTodos(), "Id", "Nome");
            ViewBag.IdCategoriaQuestao = new SelectList(_grupoQuestaoAppServico.ObtemTodos(), "Id", "Nome");

            return View(lQuestionarioViewModel);
        }

        // POST: Questionario/Edit/5
        [HttpPost]
        public ActionResult Edit(QuestionarioViewModel pQuestionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var lQuestionario = Mapper.Map<QuestionarioViewModel, Questionario>(pQuestionarioViewModel);
                _questionarioAppServico.Update(lQuestionario);

                return RedirectToAction("Index");
            }

            ViewBag.IdEtapa = new SelectList(_etapaAppServico.ObtemTodos(), "Id", "Nome");
            ViewBag.IdCategoriaQuestao = new SelectList(_grupoQuestaoAppServico.ObtemTodos(), "Id", "Nome");

            return View(pQuestionarioViewModel);
        }

        // GET: Questionario/Delete/5
        public ActionResult Delete(int id)
        {
            var lQuestionario = _questionarioAppServico.ObtemPorId(id);
            var lQuestionarioViewModel = Mapper.Map<Questionario, QuestionarioViewModel>(lQuestionario);

            return View(lQuestionarioViewModel);
        }

        // POST: Questionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lQuestionario = _questionarioAppServico.ObtemPorId(id);
            _questionarioAppServico.Remove(lQuestionario);

            return RedirectToAction("Index");
        }
    }
}
