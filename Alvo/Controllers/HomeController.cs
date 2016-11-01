using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Alvo.ViewModels;
using AutoMapper;
using Dominio.Entidades;

namespace Alvo.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var usuarioSession = Session["Usuario"];
            if (usuarioSession == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel userModel)
        {

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login");
        }

        private void AutenticarAplicacao(UsuarioViewModel usuario)
        {
            FormsAuthenticationTicket autentic = new FormsAuthenticationTicket(usuario.CPF, false, 120);


            // Criptografa o ticket por questão de segurança
            string encryptedTicket = FormsAuthentication.Encrypt(autentic);

            // Cria um cookie(será usado para validação do asp.net)
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            // Seta expiração
            if (autentic.IsPersistent) authCookie.Expires = autentic.Expiration;

            //Adiciona o cookie na aplicação
            Response.Cookies.Add(authCookie);
        }

        [Authorize]
        public PartialViewResult _MenuResult()
        {
            var usuario = (Usuario)Session["Usuario"];
            UsuarioViewModel usuariosView = new UsuarioViewModel();
            if (usuario != null)
            {
                usuariosView = Mapper.Map<Usuario, UsuarioViewModel>(usuario);
            }


            return PartialView("_Menu", usuariosView.perfil.perfilmenus);
        }


    }
}