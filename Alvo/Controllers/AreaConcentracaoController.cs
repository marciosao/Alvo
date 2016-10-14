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
    public class AreaConcentracaoController : Controller
    {
        private readonly IAreaConcentracaoAppServico _areaConcentracaoAppServico;
        public AreaConcentracaoController(IAreaConcentracaoAppServico areaConcentracaoAppServico)
        {
            _areaConcentracaoAppServico = areaConcentracaoAppServico;
        }
        // GET: AreaConcentracao
        public ActionResult Index()
        {
            var AreaConcentracaoViewModel = Mapper.Map<IEnumerable<AreaConcentracao>, IEnumerable<AreaConcentracaoViewModel>>(_areaConcentracaoAppServico.ObtemTodos());
            return View(AreaConcentracaoViewModel);
        }

        // GET: AreaConcentracao/Details/5
        public ActionResult Details(int id)
        {
            var lAreaConcentracao = _areaConcentracaoAppServico.ObtemPorId(id);
            var lAreaConcentracaoViewModel = Mapper.Map<AreaConcentracao, AreaConcentracaoViewModel>(lAreaConcentracao);

            return View(lAreaConcentracaoViewModel);
        }

        // GET: AreaConcentracao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreaConcentracao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AreaConcentracaoViewModel pAreaConcentracao)
        {
            if (ModelState.IsValid)
            {
                var lAreaConcentracaoDomain = Mapper.Map<AreaConcentracaoViewModel, AreaConcentracao>(pAreaConcentracao);

                _areaConcentracaoAppServico.Add(lAreaConcentracaoDomain);

                return RedirectToAction("Index");
            }

            return View(pAreaConcentracao);
        }

        // GET: AreaConcentracao/Edit/5
        public ActionResult Edit(int id)
        {
            var lAreaConcentracao = _areaConcentracaoAppServico.ObtemPorId(id);
            var lAreaConcentracaoViewModel = Mapper.Map<AreaConcentracao, AreaConcentracaoViewModel>(lAreaConcentracao);

            return View(lAreaConcentracaoViewModel);
        }

        // POST: AreaConcentracao/Edit/5
        [HttpPost]
        public ActionResult Edit(AreaConcentracaoViewModel pAreaConcentracaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var lAreaConcentracao = Mapper.Map<AreaConcentracaoViewModel, AreaConcentracao>(pAreaConcentracaoViewModel);
                _areaConcentracaoAppServico.Update(lAreaConcentracao);

                return RedirectToAction("Index");
            }

            return View(pAreaConcentracaoViewModel);
        }

        // GET: AreaConcentracao/Delete/5
        public ActionResult Delete(int id)
        {
            var lAreaConcentracao = _areaConcentracaoAppServico.ObtemPorId(id);
            var lAreaConcentracaoViewModel = Mapper.Map<AreaConcentracao, AreaConcentracaoViewModel>(lAreaConcentracao);

            return View(lAreaConcentracaoViewModel);
        }

        // POST: AreaConcentracao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lAreaConcentracao = _areaConcentracaoAppServico.ObtemPorId(id);
            _areaConcentracaoAppServico.Remove(lAreaConcentracao);

            return RedirectToAction("Index");
        }
    }
}
