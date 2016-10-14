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
    public class QuestaoController : Controller
    {
        private readonly IQuestaoAppServico _questaoAppServico;
        private readonly ICategoriaQuestaoAppServico _categoriaQuestaoAppServico;
        private readonly IQuestionarioAppServico _questionarioAppServico;
        private readonly ITipoQuestaoAppServico _tipoQuestaoAppServico;
        private readonly IEtapaAppServico _etapaAppServico;

        public QuestaoController(IQuestaoAppServico questaoAppServico, ICategoriaQuestaoAppServico categoriaQuestaoAppServico, IQuestionarioAppServico questionarioAppServico, ITipoQuestaoAppServico tipoQuestaoAppServico, IEtapaAppServico etapaAppServico)
        {
            _questaoAppServico = questaoAppServico;
            _categoriaQuestaoAppServico = categoriaQuestaoAppServico;
            _questionarioAppServico = questionarioAppServico;
            _tipoQuestaoAppServico = tipoQuestaoAppServico;
            _etapaAppServico = etapaAppServico;
        }
        // GET: Questao
        public ActionResult Index()
        {
            var QuestaoViewModel = Mapper.Map<IEnumerable<Questao>, IEnumerable<QuestaoViewModel>>(_questaoAppServico.ObtemTodos());
            return View(QuestaoViewModel);
        }

        // GET: Questao/Details/5
        public ActionResult Details(int id)
        {
            var lQuestao = _questaoAppServico.ObtemPorId(id);
            var lQuestaoViewModel = Mapper.Map<Questao, QuestaoViewModel>(lQuestao);

            return View(lQuestaoViewModel);
        }

        // GET: Questao/Create
        public ActionResult Create()
        {
            //ViewBag.IdCategoria = new SelectList(_categoriaQuestaoAppServico.ObtemTodos(), "Id", "Nome");
            //ViewBag.IdQuestionario = new SelectList(_questionarioAppServico.ObtemTodos(), "Id", "Descricao");
            //ViewBag.IdTipoQuestao = new SelectList(_tipoQuestaoAppServico.ObtemTodos(), "Id", "Nome");
            ViewBag.IdEtapa = new SelectList(_etapaAppServico.ObtemTodos(), "Id", "Nome");

            return View();
        }

        // POST: Questao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestaoViewModel pQuestao)
        {
            if (ModelState.IsValid)
            {
                var lQuestaoDomain = Mapper.Map<QuestaoViewModel, Questao>(pQuestao);

                _questaoAppServico.Add(lQuestaoDomain);

                return RedirectToAction("Index");
            }

            //ViewBag.IdCategoria = new SelectList(_categoriaQuestaoAppServico.ObtemTodos(), "Id", "Nome");
            //ViewBag.IdQuestionario = new SelectList(_questionarioAppServico.ObtemTodos(), "Id", "Descricao");
            //ViewBag.IdTipoQuestao = new SelectList(_tipoQuestaoAppServico.ObtemTodos(), "Id", "Nome");
            ViewBag.IdEtapa = new SelectList(_etapaAppServico.ObtemTodos(), "Id", "Nome");
            
            return View(pQuestao);
        }

        // GET: Questao/Edit/5
        public ActionResult Edit(int id)
        {
            var lQuestao = _questaoAppServico.ObtemPorId(id);
            var lQuestaoViewModel = Mapper.Map<Questao, QuestaoViewModel>(lQuestao);

            ViewBag.IdCategoria = new SelectList(_categoriaQuestaoAppServico.ObtemTodos(), "Id", "Nome");
            ViewBag.IdQuestionario = new SelectList(_questionarioAppServico.ObtemTodos(), "Id", "Descricao");
            ViewBag.IdTipoQuestao = new SelectList(_tipoQuestaoAppServico.ObtemTodos(), "Id", "Nome");

            return View(lQuestaoViewModel);
        }

        // POST: Questao/Edit/5
        [HttpPost]
        public ActionResult Edit(QuestaoViewModel pQuestaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var lQuestao = Mapper.Map<QuestaoViewModel, Questao>(pQuestaoViewModel);
                _questaoAppServico.Update(lQuestao);

                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(_categoriaQuestaoAppServico.ObtemTodos(), "Id", "Nome");
            ViewBag.IdQuestionario = new SelectList(_questionarioAppServico.ObtemTodos(), "Id", "Descricao");
            ViewBag.IdTipoQuestao = new SelectList(_tipoQuestaoAppServico.ObtemTodos(), "Id", "Nome");

            return View(pQuestaoViewModel);

        }

        // GET: Questao/Delete/5
        public ActionResult Delete(int id)
        {
            var lQuestao = _questaoAppServico.ObtemPorId(id);
            var lQuestaoViewModel = Mapper.Map<Questao, QuestaoViewModel>(lQuestao);

            return View(lQuestaoViewModel);
        }

        // POST: Questao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lQuestao = _questaoAppServico.ObtemPorId(id);
            _questaoAppServico.Remove(lQuestao);

            return RedirectToAction("Index");
        }

        public ActionResult CriarQuestao()
        {
            QuestaoViewModel _questaoViewModel = new QuestaoViewModel();

            ViewBag.IdCategoria = new SelectList(_categoriaQuestaoAppServico.ObtemTodos(), "Id", "Nome");
            ViewBag.IdTipoQuestao = new SelectList(_tipoQuestaoAppServico.ObtemTodos(), "Id", "Nome");

            return PartialView("~/Views/Questao/_PartialQuestaoCreate.cshtml");
        }


        public ActionResult _PartialCreateQuestao()
        {
            ViewBag.IdEtapa = new SelectList(_etapaAppServico.ObtemTodos(), "Id", "Nome");

            return View();
        }


    }
}
