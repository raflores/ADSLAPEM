using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Services.Infrastructure;
using ADS.LAPEM.Services.Seguridad;
using ADS.LAPEM.Web.Controllers;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Web.Infrastructure.Grid;
using ADS.LAPEM.Web.Areas.Seguridad.Models;
using ADS.LAPEM.Web.Infrastructure.Filter;

namespace ADS.LAPEM.Web.Areas.Seguridad.Controllers
{
    public class AccountController : BaseController
    {
        protected ILdapService LdapService { get; set; }
        //protected IUsuarioService UsuarioService { get; set; }
        //
        // GET: /Seguridad/Account/

        public ActionResult Index()
        {
            return View(GetModel(new Usuario()));
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {            
            Usuario user = usuario;
            //if (LdapService.Authenticate(usuario.Username, usuario.Password))
            //{
            List<Usuario> ListUsuario = UsuarioService.ReadUsuarioByUsername(usuario.Username).ToList();
            usuario = (Usuario)ListUsuario[0];
            FormsAuthentication.SetAuthCookie(usuario.Username, false);
            //    //return RedirectToAction(INDEX_VIEW, new { controller = "Home", area = "" });
            return Json("Success", JsonRequestBehavior.AllowGet);
            //    //return Json("Error", JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Error", JsonRequestBehavior.AllowGet);
            //}                  
        }

        //[HttpPost]
        //public ActionResult Login(Usuario usuario)
        //{
        //    Usuario user = usuario;
        //    if (LdapService.Authenticate(usuario.Username, usuario.Password))
        //    {
        //        List<Usuario> ListUsuario = UsuarioService.ReadUsuarioByUsername(usuario.Username).ToList();
        //        usuario = (Usuario)ListUsuario[0];
        //        FormsAuthentication.SetAuthCookie(usuario.Username, false);
        //        return RedirectToAction(INDEX_VIEW, new { controller = "Home", area = "" });
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Login data is incorrect!");
        //        return RedirectToAction(INDEX_VIEW);
        //    }
        //}

        [HttpGet]
        public ActionResult LoginSuccess()
        {            
            return RedirectToAction(INDEX_VIEW, new { controller = "Home", area = "" });
        }

        [HttpGet]
        public ActionResult LoginFail()
        {
            return PartialView("_Validacion", GetModel(new Usuario()));
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction(INDEX_VIEW);
        }

        private AccountViewModel GetModel(Usuario usuario)
        {
            return new AccountViewModel(usuario);
        }

    }
}
