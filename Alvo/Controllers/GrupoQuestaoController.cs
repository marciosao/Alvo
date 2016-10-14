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
    public class GrupoQuestaoController : Controller
    {
        private readonly IGrupoQuestaoAppServico _grupoQuestaoAppServico;

        public GrupoQuestaoController(IGrupoQuestaoAppServico grupoQuestaoAppServico)
        {
            _grupoQuestaoAppServico = grupoQuestaoAppServico;
        }

        // GET: GrupoQuestao
        public ActionResult Index()
        {
            var GrupoQuestaoViewModel = Mapper.Map<IEnumerable<GrupoQuestao>, IEnumerable<GrupoQuestaoViewModel>>(_grupoQuestaoAppServico.ObtemTodos());
            return View(GrupoQuestaoViewModel);
        }

        // GET: GrupoQuestao/Details/5
        public ActionResult Details(int id)
        {
            var lGrupoQuestao = _grupoQuestaoAppServico.ObtemPorId(id);
            var lGrupoQuestaoViewModel = Mapper.Map<GrupoQuestao, GrupoQuestaoViewModel>(lGrupoQuestao);

            return View(lGrupoQuestaoViewModel);
        }

        // GET: GrupoQuestao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoQuestao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GrupoQuestaoViewModel pGrupoQuestao)
        {
            if (ModelState.IsValid)
            {
                var lGrupoQuestaoDomain = Mapper.Map<GrupoQuestaoViewModel, GrupoQuestao>(pGrupoQuestao);

                _grupoQuestaoAppServico.Add(lGrupoQuestaoDomain);

                return RedirectToAction("Index");
            }

            return View(pGrupoQuestao);
        }

        // GET: GrupoQuestao/Edit/5
        public ActionResult Edit(int id)
        {
            var lGrupoQuestao = _grupoQuestaoAppServico.ObtemPorId(id);
            var lGrupoQuestaoViewModel = Mapper.Map<GrupoQuestao, GrupoQuestaoViewModel>(lGrupoQuestao);

            return View(lGrupoQuestaoViewModel);
        }

        // POST: GrupoQuestao/Edit/5
        [HttpPost]
        public ActionResult Edit(GrupoQuestaoViewModel pGrupoQuestaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var lGrupoQuestao = Mapper.Map<GrupoQuestaoViewModel, GrupoQuestao>(pGrupoQuestaoViewModel);
                _grupoQuestaoAppServico.Update(lGrupoQuestao);

                return RedirectToAction("Index");
            }

            return View(pGrupoQuestaoViewModel);

        }

        // GET: GrupoQuestao/Delete/5
        public ActionResult Delete(int id)
        {
            var lGrupoQuestao = _grupoQuestaoAppServico.ObtemPorId(id);
            var lGrupoQuestaoViewModel = Mapper.Map<GrupoQuestao, GrupoQuestaoViewModel>(lGrupoQuestao);

            return View(lGrupoQuestaoViewModel);
        }

        // POST: GrupoQuestao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lGrupoQuestao = _grupoQuestaoAppServico.ObtemPorId(id);
            _grupoQuestaoAppServico.Remove(lGrupoQuestao);

            return RedirectToAction("Index");
        }
    }
}
