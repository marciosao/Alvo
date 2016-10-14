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
    public class ProcessoSeletivoController : Controller
    {
        private readonly IProcessoSeletivoAppServico _processoSeletivoAppServico;

        public ProcessoSeletivoController(IProcessoSeletivoAppServico processoSeletivoAppServico)
        {
            _processoSeletivoAppServico = processoSeletivoAppServico;
        }

        // GET: ProcessoSeletivo
        public ActionResult Index()
        {
            var processoSeletivoViewModel = Mapper.Map<IEnumerable<ProcessoSeletivo>, IEnumerable<ProcessoSeletivoViewModel>>(_processoSeletivoAppServico.ObtemTodos());
            return View(processoSeletivoViewModel);
        }

        // GET: ProcessoSeletivo/Details/5
        public ActionResult Details(int id)
        {
            var lProcessoSeletivo = _processoSeletivoAppServico.ObtemPorId(id);
            var lProcessoSeletivoViewModel = Mapper.Map<ProcessoSeletivo, ProcessoSeletivoViewModel>(lProcessoSeletivo);

            return View(lProcessoSeletivoViewModel);
        }

        // GET: ProcessoSeletivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProcessoSeletivo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProcessoSeletivoViewModel pProcessoSeletivo)
        {
            if (ModelState.IsValid)
            {
                var lProcessoSeletivoDomain = Mapper.Map<ProcessoSeletivoViewModel, ProcessoSeletivo>(pProcessoSeletivo);

                _processoSeletivoAppServico.Add(lProcessoSeletivoDomain);

                return RedirectToAction("Index");
            }

            return View(pProcessoSeletivo);
        }

        // GET: ProcessoSeletivo/Edit/5
        public ActionResult Edit(int id)
        {
            var lProcessoSeletivo = _processoSeletivoAppServico.ObtemPorId(id);
            var lProcessoSeletivoViewModel = Mapper.Map<ProcessoSeletivo, ProcessoSeletivoViewModel>(lProcessoSeletivo);

            return View(lProcessoSeletivoViewModel);
        }

        // POST: ProcessoSeletivo/Edit/5
        [HttpPost]
        public ActionResult Edit(ProcessoSeletivoViewModel pProcessoSeletivoViewModel)
        {
            if (ModelState.IsValid)
            {
                var lProcessoSeletivo = Mapper.Map<ProcessoSeletivoViewModel, ProcessoSeletivo>(pProcessoSeletivoViewModel);
                _processoSeletivoAppServico.Update(lProcessoSeletivo);

                return RedirectToAction("Index");
            }

            return View(pProcessoSeletivoViewModel);
        }

        // GET: ProcessoSeletivo/Delete/5
        public ActionResult Delete(int id)
        {
            var lProcessoSeletivo = _processoSeletivoAppServico.ObtemPorId(id);
            var lProcessoSeletivoViewModel = Mapper.Map<ProcessoSeletivo, ProcessoSeletivoViewModel>(lProcessoSeletivo);

            return View(lProcessoSeletivoViewModel);
        }

        // POST: ProcessoSeletivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lProcessoSeletivo = _processoSeletivoAppServico.ObtemPorId(id);
            _processoSeletivoAppServico.Remove(lProcessoSeletivo);

            return RedirectToAction("Index");
        }
    }
}
