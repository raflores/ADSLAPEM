using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Services.Seguridad;
using ADS.LAPEM.Web.Controllers;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Web.Infrastructure.Grid;
using ADS.LAPEM.Web.Areas.Seguridad.Models;
using ADS.LAPEM.Web.Infrastructure.Filter;

namespace ADS.LAPEM.Web.Areas.Seguridad.Controllers
{
    [Authorize]
    public class PerfilMenuController : BaseController
    {
        //protected IPerfilMenuService PerfilMenuService { get; set; }
        protected IPerfilService PerfilService { get; set; }
        protected IMenuService MenuService { get; set; }
        //
        // GET: /Seguridad/PerfilMenu/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new PerfilMenu()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(PerfilMenu perfilMenu)
        {
            if (ModelState.IsValid)
            {
                //foreach (Menu m in perfilMenu.ListMenu)
                //{
                //    perfilMenu.MenuId = m.Id;
                //    PerfilMenuService.CreatePerfilMenu(perfilMenu);
                //}
                
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(perfilMenu));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            PerfilMenu perfilMenu = PerfilMenuService.ReadPerfilMenuById(id);
            return View(GetModel(perfilMenu));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(PerfilMenu perfilMenu)
        {
            if (ModelState.IsValid)
            {
                PerfilMenuService.UpdatePerfilMenu(perfilMenu);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(perfilMenu));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            PerfilMenu perfilMenu = PerfilMenuService.ReadPerfilMenuById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(perfilMenu));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(PerfilMenu perfilMenu)
        {
            PerfilMenuService.DeletePerfilMenu(perfilMenu);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<PerfilMenu> result = PerfilMenuService.ReadPerfilMenu(grid);

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
                    cell = new string[] { p.Perfil.Nombre, p.Perfil.Descripcion, p.PerfilId.ToString() }
                }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private PerfilMenuViewModel GetModel(PerfilMenu perfilMenu)
        {
            return new PerfilMenuViewModel(perfilMenu, PerfilService.ReadPerfil(), MenuService.ReadMenu());
        }

    }
}
