using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Alvo.ViewModels;
using Aplicacao.Interfaces;
using AutoMapper;
using Dominio.Entidades;

namespace Alvo.Controllers
{
    public class HomeController : Controller
    {

        private IUsuarioAppServico _usuarioApp;

        public HomeController(IUsuarioAppServico usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }


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
            var usuario = _usuarioApp.AutenticarUsuario(Mapper.Map<UsuarioViewModel, Usuario>(userModel));
            var lUsrViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);
            if (lUsrViewModel != null)
            {
                Session["Usuario"] = lUsrViewModel;
                this.AutenticarAplicacao(lUsrViewModel);
                return RedirectToAction("Index");
            }

          //  ModelState.AddModelError("Error", "Usuário/Senha não conferem");

            return View().Mensagem("Usuário/Senha não conferem");
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
            var usuario = (UsuarioViewModel)Session["Usuario"];
            ////////UsuarioViewModel usuariosView = new UsuarioViewModel();
            if (usuario != null)
            {
                ////////usuariosView = Mapper.Map<Usuario, UsuarioViewModel>(usuario);
                ////////ViewBag.Usuario = usuariosView;
                ViewBag.Usuario = usuario;
            }


            return PartialView("_Menu", usuario.Perfil.PerfilMenus);
        }

        [Authorize]
        public PartialViewResult AlterarSenha()
        {
            var usuario = (UsuarioViewModel)Session["Usuario"];

            ////////var Login = new UsuarioViewModel() { CPF = usuario.CPF };

            return PartialView("_AlterarSenha", usuario);
        }

        [Authorize]
        [HttpPost]
        public PartialViewResult AlterarSenha(AlterarSenhaUsuarioViewModel loginView)
        {

            if (ModelState.IsValid)
            {

                Usuario lUsuario = new Usuario();

                lUsuario.CPF = loginView.CPF;
                lUsuario.Senha = loginView.Senha;

                var usuario = _usuarioApp.AlterarSenha(lUsuario, loginView.NovaSenha);

                if (usuario != null)
                {
                    ModelState.AddModelError("Sucesso", "Senha Alterada com Sucesso"); //Mudar para padrao de mensagem

                }
                else
                {
                    ModelState.AddModelError("Error", "Senha incorreta. Tente novamente."); //Mudar para padrao de mensagem
                }
            }

            loginView.NovaSenha = String.Empty;
            loginView.ConfirmarSenha = String.Empty;
            loginView.Senha = String.Empty;

            return PartialView("_AlterarSenha", loginView);
        }


    }
}