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
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppServico _usuarioAppServico;
        private readonly IPerfilAppServico _perfilAppServico;
        public UsuarioController(IUsuarioAppServico usuarioAppServico, IPerfilAppServico perfilAppServico)
        {
            this._usuarioAppServico = usuarioAppServico;
            this._perfilAppServico = perfilAppServico;
        }

        // GET: Usuario
        public ActionResult Index()
        {
            var usuarioViewModel = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioAppServico.ObtemTodos());
            return View(usuarioViewModel);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            var lUsuario = _usuarioAppServico.ObtemPorId(id);
            var lUsuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(lUsuario);

            return View(lUsuarioViewModel);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.IdPerfil = new SelectList(_perfilAppServico.ObtemTodos(), "Id", "Nome");

            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel pUsuario)
        {
            if (ModelState.IsValid)
            {
                var lUsuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(pUsuario);

                _usuarioAppServico.GravarUsuario(lUsuarioDomain);

                return RedirectToAction("Index");
            }

            ViewBag.IdPerfil = new SelectList(_perfilAppServico.ObtemTodos(), "Id", "Nome");

            return View(pUsuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var lUsuario = _usuarioAppServico.ObtemPorId(id);
            var lUsuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(lUsuario);

            ViewBag.IdPerfil = new SelectList(_perfilAppServico.ObtemTodos(), "Id", "Nome", lUsuarioViewModel.Perfil.Id);

            return View(lUsuarioViewModel);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel pUsuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var lUsuario = Mapper.Map<UsuarioViewModel, Usuario>(pUsuarioViewModel);
                _usuarioAppServico.Update(lUsuario);

                return RedirectToAction("Index");
            }

            ViewBag.IdPerfil = new SelectList(_perfilAppServico.ObtemTodos(), "Id", "Nome");

            return View(pUsuarioViewModel);

        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            var lUsuario = _usuarioAppServico.ObtemPorId(id);
            var lUsuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(lUsuario);

            return View(lUsuarioViewModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var lUsuario = _usuarioAppServico.ObtemPorId(id);
            _usuarioAppServico.Remove(lUsuario);

            return RedirectToAction("Index");
        }
    }
}
