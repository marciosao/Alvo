using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alvo.Controllers
{
    public class RespostaQuestaoController : Controller
    {
        // GET: RespostaQuestao
        public ActionResult Index()
        {
            return View();
        }

        // GET: RespostaQuestao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RespostaQuestao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RespostaQuestao/Create
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

        // GET: RespostaQuestao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RespostaQuestao/Edit/5
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

        // GET: RespostaQuestao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RespostaQuestao/Delete/5
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
