using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Dominio.Entidades;
using Alvo.ViewModels;

namespace Alvo.Controllers
{
    public class BaseController : Controller
    {
        protected const string SESSAO_USUARIO = "Usuario";

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Se usuário não é válido, a requisição é redirecionada 
            // para a página de login configurada.
            if (!IsUsuarioValido())
            {
                filterContext.Result = new RedirectResult(FormsAuthentication.LoginUrl, true);
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }

        /// <summary>
        /// Verifica se há usuário válido e ativo na sessão
        /// </summary>
        private bool IsUsuarioValido()
        {
            return (Session != null) && (Session[SESSAO_USUARIO] != null);
        }

        /// <summary>
        /// Recupera o usuário logado, caso haja algum
        /// </summary>
        /// <returns></returns>
        protected UsuarioViewModel GetUsuarioLogado()
        {
            UsuarioViewModel usuario = null;

            if (Session != null)
            {
                usuario = Session[SESSAO_USUARIO] as UsuarioViewModel;
            }
            return usuario;
        }
    }
}