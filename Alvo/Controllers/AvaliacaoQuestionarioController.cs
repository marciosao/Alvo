using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alvo.Controllers
{
    public class AvaliacaoQuestionarioController : Controller
    {
        // GET: AvaliacaoQuestionario
        public ActionResult Index()
        {
            return View();
        }

        // GET: AvaliacaoQuestionario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AvaliacaoQuestionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvaliacaoQuestionario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AvaliacaoQuestionario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AvaliacaoQuestionario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AvaliacaoQuestionario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AvaliacaoQuestionario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
