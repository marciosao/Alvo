using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alvo.Controllers
{
    public class PerfilMenuController : Controller
    {
        // GET: PerfilMenu
        public ActionResult Index()
        {
            return View();
        }

        // GET: PerfilMenu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PerfilMenu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilMenu/Create
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

        // GET: PerfilMenu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PerfilMenu/Edit/5
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

        // GET: PerfilMenu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PerfilMenu/Delete/5
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
