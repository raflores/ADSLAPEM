using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Services.Infrastructure;
using ADS.LAPEM.Services.Seguridad;
using ADS.LAPEM.Web.Controllers;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Web.Infrastructure.Grid;
using ADS.LAPEM.Web.Areas.Seguridad.Models;
using ADS.LAPEM.Web.Models;
using Spring.Context;
using Spring.Context.Support;

namespace ADS.LAPEM.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected const string LOGIN_VIEW = "Login";
        protected const string INDEX_VIEW = "Index";
        protected const string CREATE_VIEW = "Create";
        protected const string EDIT_VIEW = "Edit";
        protected const string DELETE_VIEW = "Delete";
        protected const string JSON_SUCCESS = "Success";
        protected const string JSON_ERROR = "Error";
        protected const string CREATE_PARTIAL_VIEW = "_Create";
        protected const string EDIT_PARTIAL_VIEW = "_Edit";
        protected const string DELETE_PARTIAL_VIEW = "_Delete";
        protected const string FORMA_PARTIAL_VIEW = "_Forma";

        protected IUsuarioService UsuarioService { get; set; }
        protected IPerfilMenuService PerfilMenuService { get; set; }

        [ChildActionOnly]
        public ActionResult GetMenu()
        {
            //TODO Eliminar cuando se descubra una mejor forma
            IApplicationContext appContext =
                new XmlApplicationContext(HttpContext.Server.MapPath(@"~/Config/service.xml"),
                    HttpContext.Server.MapPath(@"~/Config/repository.xml"));
            UsuarioService = (IUsuarioService)appContext.GetObject("UsuarioService");
            PerfilMenuService = (IPerfilMenuService)appContext.GetObject("PerfilMenuService");
            //

            List<Usuario> ListUsuario = UsuarioService.ReadUsuarioByUsername(User.Identity.Name).ToList();
            Usuario usuario = (Usuario)ListUsuario[0];
            IList<PerfilMenu> ListPM = PerfilMenuService.ReadPerfilMenuByPerfilId(usuario.PerfilId).ToList();
            IList<Menu> items = new List<Menu>();

            foreach (PerfilMenu pm in ListPM)
            {
                pm.Menu.Activo = pm.Activo;
                items.Add(pm.Menu);
            }

            MenuViewModel menuViewModel = new MenuViewModel(items, usuario);

            return PartialView("_Nav", menuViewModel);

        }
    }

}
