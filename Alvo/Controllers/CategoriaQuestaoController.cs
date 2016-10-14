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
    public class CategoriaQuestaoController : Controller
    {
        private readonly ICategoriaQuestaoAppServico _categoriaQuestaoAppServico;
        private readonly IGrupoQuestaoAppServico _grupoQuestaoAppServico;

        public CategoriaQuestaoController(ICategoriaQuestaoAppServico categoriaQuestaoAppServico, IGrupoQuestaoAppServico grupoQuestaoAppServico)
        {
            _categoriaQuestaoAppServico = categoriaQuestaoAppServico;
            _grupoQuestaoAppServico = grupoQuestaoAppServico;
        }

        // GET: CategoriaQuestao
        public ActionResult Index()
        {
            var categoriaQuestaoViewModel = Mapper.Map<IEnumerable<CategoriaQuestao>, IEnumerable<CategoriaQuestaoViewModel>>(_categoriaQuestaoAppServico.ObtemTodos());
            return View(categoriaQuestaoViewModel);
        }

        // GET: CategoriaQuestao/Details/5
        public ActionResult Details(int id)
        {
            var lCategoriaQuestao = _categoriaQuestaoAppServico.ObtemPorId(id);
            var lCategoriaQuestaoViewModel = Mapper.Map<CategoriaQuestao, CategoriaQuestaoViewModel>(lCategoriaQuestao);

            return View(lCategoriaQuestaoViewModel);
        }

        // GET: CategoriaQuestao/Create
        public ActionResult Create()
        {
            ViewBag.IdGrupoQuestao = new SelectList(_grupoQuestaoAppServico.ObtemTodos(), "Id", "Nome");
            return View();
        }

        // POST: CategoriaQuestao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaQuestaoViewModel pCategoriaQuestao)
        {
            if (ModelState.IsValid)
            {
                var lCategoriaQuestaoDomain = Mapper.Map<CategoriaQuestaoViewModel, CategoriaQuestao>(pCategoriaQuestao);

                _categoriaQuestaoAppServico.Add(lCategoriaQuestaoDomain);

                return RedirectToAction("Index");
            }
            ViewBag.IdGrupoQuestao = new SelectList(_grupoQuestaoAppServico.ObtemTodos(), "Id", "Nome");
            return View(pCategoriaQuestao);
        }

        // GET: CategoriaQuestao/Edit/5
        public ActionResult Edit(int id)
        {
            var lCategoriaQuestao = _categoriaQuestaoAppServico.ObtemPorId(id);
            var lCategoriaQuestaoViewModel = Mapper.Map<CategoriaQuestao, CategoriaQuestaoViewModel>(lCategoriaQuestao);

            ViewBag.IdGrupoQuestao = new SelectList(_grupoQuestaoAppServico.ObtemTodos(), "Id", "Nome");

            return View(lCategoriaQuestaoViewModel);
        }

        // POST: CategoriaQuestao/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoriaQuestaoViewModel pCategoriaQuestaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var lCategoriaQuestao = Mapper.Map<CategoriaQuestaoViewModel, CategoriaQuestao>(pCategoriaQuestaoViewModel);
                _categoriaQuestaoAppServico.Update(lCategoriaQuestao);

                return RedirectToAction("Index");
            }

            ViewBag.IdGrupoQuestao = new SelectList(_grupoQuestaoAppServico.ObtemTodos(), "Id", "Nome");

            return View(pCategoriaQuestaoViewModel);
        }

        // GET: CategoriaQuestao/Delete/5
        public ActionResult Delete(int id)
        {
            var lCategoriaQuestao = _categoriaQuestaoAppServico.ObtemPorId(id);
            var lCategoriaQuestaoViewModel = Mapper.Map<CategoriaQuestao, CategoriaQuestaoViewModel>(lCategoriaQuestao);

            return View(lCategoriaQuestaoViewModel);
        }

        // POST: CategoriaQuestao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lCategoriaQuestao = _categoriaQuestaoAppServico.ObtemPorId(id);
            _categoriaQuestaoAppServico.Remove(lCategoriaQuestao);

            return RedirectToAction("Index");
        }
    }
}
