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
    public class OpcaoQuestaoController : Controller
    {
        private readonly IOpcaoQuestaoAppServico _opcaoQuestaoAppServico;
        private readonly IPerfilAppServico _perfilAppServico;
        public OpcaoQuestaoController(IOpcaoQuestaoAppServico opcaoQuestaoAppServico, IPerfilAppServico perfilAppServico)
        {
            this._opcaoQuestaoAppServico = opcaoQuestaoAppServico;
            this._perfilAppServico = perfilAppServico;
        }

        // GET: OpcaoQuestao
        public ActionResult Index()
        {
            var opcaoQuestaoViewModel = Mapper.Map<IEnumerable<OpcaoQuestao>, IEnumerable<OpcaoQuestaoViewModel>>(_opcaoQuestaoAppServico.ObtemTodos());
            return View(opcaoQuestaoViewModel);
        }

        // GET: OpcaoQuestao/Details/5
        public ActionResult Details(int id)
        {
            var lOpcaoQuestao = _opcaoQuestaoAppServico.ObtemPorId(id);
            var lOpcaoQuestaoViewModel = Mapper.Map<OpcaoQuestao, OpcaoQuestaoViewModel>(lOpcaoQuestao);

            return View(lOpcaoQuestaoViewModel);
        }

        // GET: OpcaoQuestao/Create
        public ActionResult Create()
        {
            ViewBag.IdPerfil = new SelectList(_perfilAppServico.ObtemTodos(), "Id", "Nome");

            return View();
        }

        // POST: OpcaoQuestao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OpcaoQuestaoViewModel pOpcaoQuestao)
        {
            if (ModelState.IsValid)
            {
                var lOpcaoQuestaoDomain = Mapper.Map<OpcaoQuestaoViewModel, OpcaoQuestao>(pOpcaoQuestao);

                _opcaoQuestaoAppServico.Add(lOpcaoQuestaoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.IdPerfil = new SelectList(_perfilAppServico.ObtemTodos(), "Id", "Nome");

            return View(pOpcaoQuestao);
        }

        // GET: OpcaoQuestao/Edit/5
        public ActionResult Edit(int id)
        {
            var lOpcaoQuestao = _opcaoQuestaoAppServico.ObtemPorId(id);
            var lOpcaoQuestaoViewModel = Mapper.Map<OpcaoQuestao, OpcaoQuestaoViewModel>(lOpcaoQuestao);

            ViewBag.IdPerfil = new SelectList(_perfilAppServico.ObtemTodos(), "Id", "Nome");

            return View(lOpcaoQuestaoViewModel);
        }

        // POST: OpcaoQuestao/Edit/5
        [HttpPost]
        public ActionResult Edit(OpcaoQuestaoViewModel pOpcaoQuestaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var lOpcaoQuestao = Mapper.Map<OpcaoQuestaoViewModel, OpcaoQuestao>(pOpcaoQuestaoViewModel);
                _opcaoQuestaoAppServico.Update(lOpcaoQuestao);

                return RedirectToAction("Index");
            }

            ViewBag.IdPerfil = new SelectList(_perfilAppServico.ObtemTodos(), "Id", "Nome");

            return View(pOpcaoQuestaoViewModel);

        }

        // GET: OpcaoQuestao/Delete/5
        public ActionResult Delete(int id)
        {
            var lOpcaoQuestao = _opcaoQuestaoAppServico.ObtemPorId(id);
            var lOpcaoQuestaoViewModel = Mapper.Map<OpcaoQuestao, OpcaoQuestaoViewModel>(lOpcaoQuestao);

            return View(lOpcaoQuestaoViewModel);
        }

        // POST: OpcaoQuestao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lOpcaoQuestao = _opcaoQuestaoAppServico.ObtemPorId(id);
            _opcaoQuestaoAppServico.Remove(lOpcaoQuestao);

            return RedirectToAction("Index");
        }
    }
}
