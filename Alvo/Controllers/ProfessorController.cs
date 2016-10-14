using Alvo.ViewModels;
using Aplicacao.Interfaces;
using AutoMapper;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alvo.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorAppServico _professorAppServico;
        public ProfessorController(IProfessorAppServico professorAppServico)
        {
            _professorAppServico = professorAppServico;
        }
        // GET: Professor
        public ActionResult Index()
        {
            var ProfessorViewModel = Mapper.Map<IEnumerable<Professor>, IEnumerable<ProfessorViewModel>>(_professorAppServico.ObtemTodos());
            return View(ProfessorViewModel);
        }

        // GET: Professor/Details/5
        public ActionResult Details(int id)
        {
            var lProfessor = _professorAppServico.ObtemPorId(id);
            var lProfessorViewModel = Mapper.Map<Professor, ProfessorViewModel>(lProfessor);

            return View(lProfessorViewModel);
        }

        // GET: Professor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfessorViewModel pProfessor)
        {
            if (ModelState.IsValid)
            {
                var lProfessorDomain = Mapper.Map<ProfessorViewModel, Professor>(pProfessor);

                _professorAppServico.Add(lProfessorDomain);

                return RedirectToAction("Index");
            }

            return View(pProfessor);
        }

        // GET: Professor/Edit/5
        public ActionResult Edit(int id)
        {
            var lProfessor = _professorAppServico.ObtemPorId(id);
            var lProfessorViewModel = Mapper.Map<Professor, ProfessorViewModel>(lProfessor);

            return View(lProfessorViewModel);
        }

        // POST: Professor/Edit/5
        [HttpPost]
        public ActionResult Edit(ProfessorViewModel pProfessorViewModel)
        {
            if (ModelState.IsValid)
            {
                var lProfessor = Mapper.Map<ProfessorViewModel, Professor>(pProfessorViewModel);
                _professorAppServico.Update(lProfessor);

                return RedirectToAction("Index");
            }

            return View(pProfessorViewModel);
        }

        // GET: Professor/Delete/5
        public ActionResult Delete(int id)
        {
            var lProfessor = _professorAppServico.ObtemPorId(id);
            var lProfessorViewModel = Mapper.Map<Professor, ProfessorViewModel>(lProfessor);

            return View(lProfessorViewModel);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lProfessor = _professorAppServico.ObtemPorId(id);
            _professorAppServico.Remove(lProfessor);

            return RedirectToAction("Index");
        }
    }
}
