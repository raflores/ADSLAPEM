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
    public class PerfilController : BaseController
    {

        protected IPerfilService PerfilService { get; set; }
        protected IMenuService MenuService { get; set; }
        protected IPerfilMenuService PerfilMenuService { get; set; }
        // GET: /Seguridad/Perfil/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        { 
            return View(GetModel(new Perfil()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                PerfilService.CreatePerfil(perfil);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(perfil));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
        //    Perfil perfil2 = PerfilService.ReadPerfilByName("Administrador");
            Perfil perfil = PerfilService.ReadPerfilById(id);
            Perfil perfil2 = PerfilService.ReadPerfilById(id);
            perfil.PerfilMenu = PerfilMenuService.ReadPerfilMenuByPerfilId(perfil.Id).ToList();
            //List<PerfilMenu> listPM = new List<PerfilMenu>();
            //List<long> listExistentes = new List<long>();
            //listPM = PerfilMenuService.ReadPerfilMenuByPerfilId(1).ToList();
            //List<Menu> listMenu = MenuService.ReadMenu().ToList();            

            //foreach (PerfilMenu p in perfil.PerfilMenu)
            //{
            //    listExistentes.Add(p.MenuId);                
            //}

            //foreach (PerfilMenu pm in listPM)
            //{
            //    if (listExistentes.Contains(pm.MenuId))
            //    {
            //        pm.Activo = true;
            //    }
            //    else
            //        pm.Activo = false;

            //    foreach (PerfilMenu pm2 in perfil.PerfilMenu)
            //    {
            //        if (pm.Id == pm2.Id)
            //        {
            //            pm.Activo = true;
            //        }
            //    }
            //}

            //perfil.PerfilMenu = listPM;

            return View(GetModelEdit(perfil));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                //List<PerfilMenu> listPM = perfil.PerfilMenu.ToList();
                //perfil.PerfilMenu = PerfilMenuService.ReadPerfilMenuByPerfilId(perfil.Id).ToList();

                //foreach (PerfilMenu pm in listPM)
                //{
                //    for (int i = 0; i <= listPM.Count - 1; i++)
                //    {
                //        if (pm.Id == perfil.PerfilMenu[i].Id)
                //        {
                //            perfil.PerfilMenu[i].Activo = pm.Activo;
                //        }
                //    }
                //}

                PerfilService.UpdatePerfil(perfil);
                foreach (PerfilMenu pm in perfil.PerfilMenu)
                {
                    PerfilMenuService.UpdatePerfilMenu(pm);
                }
                return RedirectToAction(INDEX_VIEW);
            }
            else
            { 
                return View(GetModel(perfil));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            Perfil perfil = PerfilService.ReadPerfilById(id);
            perfil.PerfilMenu = PerfilMenuService.ReadPerfilMenuByPerfilId(perfil.Id).ToList();
            return PartialView(DELETE_PARTIAL_VIEW, GetModelEdit(perfil));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(Perfil perfil)
        {
            PerfilService.DeletePerfil(perfil);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Perfil> result = PerfilService.ReadPerfil(grid);

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
                        cell = new string[] { p.Nombre, p.Descripcion, p.Id.ToString() }
                    }).ToArray()

             };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private PerfilViewModel GetModelEdit(Perfil perfil)
        {
            return new PerfilViewModel(perfil);
        }


        private PerfilViewModel GetModel(Perfil perfil)
        {
            return new PerfilViewModel(perfil, MenuService.ReadMenu());
        }
    }
}
