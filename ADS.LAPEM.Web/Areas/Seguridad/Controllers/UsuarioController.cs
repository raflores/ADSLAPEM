using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using System.Web.Security;
using ADS.LAPEM.Services.Seguridad;
using ADS.LAPEM.Services.Catalogo;
using ADS.LAPEM.Web.Controllers;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Web.Infrastructure.Grid;
using ADS.LAPEM.Web.Areas.Seguridad.Models;
using ADS.LAPEM.Services.Infrastructure;
using ADS.LAPEM.Web.Infrastructure.Filter;

namespace ADS.LAPEM.Web.Areas.Seguridad.Controllers
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        
        //protected IUsuarioService UsuarioService { get; set; }
        protected IPerfilService PerfilService { get; set; }
        protected IPlantaService PlantaService { get; set; }
        protected ILdapService LdapService { get; set; }
        //
        // GET: /Seguridad/Usuario/



        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        { 
            return View(GetModel(new Usuario()));
        }

        [HttpPost, LoggingFilter]        
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Activo = true;
                UsuarioService.CreateUsuario(usuario);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(usuario));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Usuario usuario = UsuarioService.ReadUsuarioById(id);
            return View(GetModel(usuario));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Activo = true;
                UsuarioService.UpdateUsuario(usuario);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(usuario));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            Usuario usuario = UsuarioService.ReadUsuarioById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(usuario));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(Usuario usuario)
        {
            UsuarioService.DeleteUsuario(usuario);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public JsonResult GetUsuarioLDAP(string nombre)
        //{
        //Usuario userPrincipal = LdapService.Read(nombre)
        //if (userPrincipal != null)
        //{
        //var json = new { AccountName = userPrincipal.SamAccountName, success = true };
        //return Json(json, JsonRequestBehavior.AllowGet);
        //}
        //else
        //{
        //var json = new { Mensaje = "No se encontró el usuario", success = false };
        //return Json(json, JsonRequestBehavior.AllowGet);
        //  }            
       //}
        

        [HttpPost]
        public JsonResult AutoCompleteUsername(string term )
        {
            List<Usuario> list = LdapService.SearchUsers();

            var result = (from p in list
                          where p.Username.Contains(term)
                          select new { p.Username }).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Usuario> result = UsuarioService.ReadUsuario(grid);

            var jsonData = new
            {
                total = result.TotalPages,
                result.PageIndex,
                records = result.TotalRecords,
                rows = (
                    from p in result.Rows
                    select new
                    {
                        id = p.Id,
                        //cell = new string[] { p.Nombre, p.Username, p.puesto, p.Planta.NombrePlanta, p.Perfil.Nombre, p.Id.ToString() }
                        cell = new string[] { p.Nombre, p.Username, p.Puesto, p.Planta.NombrePlanta, p.Id.ToString() }
                    }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private UsuarioViewModel GetModel(Usuario usuario)
        {            
            return new UsuarioViewModel(usuario, PerfilService.ReadPerfil(), PlantaService.ReadPlanta());
        }

    }
}
