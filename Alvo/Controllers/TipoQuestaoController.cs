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
    public class TipoQuestaoController : Controller
    {
        private readonly ITipoQuestaoAppServico _tipoQuestaoAppServico;

        public TipoQuestaoController(ITipoQuestaoAppServico tipoQuestaoAppServico)
        {
            _tipoQuestaoAppServico = tipoQuestaoAppServico;
        }
        // GET: TipoQuestao
        public ActionResult Index()
        {
            var tipoQuestaoViewModel = Mapper.Map<IEnumerable<TipoQuestao>, IEnumerable<TipoQuestaoViewModel>>(_tipoQuestaoAppServico.ObtemTodos());
            return View(tipoQuestaoViewModel);
        }

        // GET: TipoQuestao/Details/5
        public ActionResult Details(int id)
        {
            var lTipoQuestao = _tipoQuestaoAppServico.ObtemPorId(id);
            var lTipoQuestaoViewModel = Mapper.Map<TipoQuestao, TipoQuestaoViewModel>(lTipoQuestao);

            return View(lTipoQuestaoViewModel);
        }

        // GET: TipoQuestao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoQuestao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoQuestaoViewModel pTipoQuestao)
        {
            if (ModelState.IsValid)
            {
                var lTipoQuestaoDomain = Mapper.Map<TipoQuestaoViewModel, TipoQuestao>(pTipoQuestao);

                _tipoQuestaoAppServico.Add(lTipoQuestaoDomain);

                return RedirectToAction("Index");
            }

            return View(pTipoQuestao);
        }

        // GET: TipoQuestao/Edit/5
        public ActionResult Edit(int id)
        {
            var lTipoQuestao = _tipoQuestaoAppServico.ObtemPorId(id);
            var lTipoQuestaoViewModel = Mapper.Map<TipoQuestao, TipoQuestaoViewModel>(lTipoQuestao);

            return View(lTipoQuestaoViewModel);
        }

        // POST: TipoQuestao/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoQuestaoViewModel pTipoQuestaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var lTipoQuestao = Mapper.Map<TipoQuestaoViewModel, TipoQuestao>(pTipoQuestaoViewModel);
                _tipoQuestaoAppServico.Update(lTipoQuestao);

                return RedirectToAction("Index");
            }

            return View(pTipoQuestaoViewModel);
        }

        // GET: TipoQuestao/Delete/5
        public ActionResult Delete(int id)
        {
            var lTipoQuestao = _tipoQuestaoAppServico.ObtemPorId(id);
            var lTipoQuestaoViewModel = Mapper.Map<TipoQuestao, TipoQuestaoViewModel>(lTipoQuestao);

            return View(lTipoQuestaoViewModel);
        }

        // POST: TipoQuestao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lTipoQuestao = _tipoQuestaoAppServico.ObtemPorId(id);
            _tipoQuestaoAppServico.Remove(lTipoQuestao);

            return RedirectToAction("Index");
        }
    }
}
