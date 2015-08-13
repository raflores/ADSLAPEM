using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Services.Catalogo;
using ADS.LAPEM.Web.Controllers;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Web.Infrastructure.Grid;
using ADS.LAPEM.Web.Areas.Catalogo.Models;
using ADS.LAPEM.Web.Infrastructure.Filter;

namespace ADS.LAPEM.Web.Areas.Catalogo.Controllers
{
    [Authorize]
    public class SiloController : BaseController
    {
        protected ISiloService SiloService { get; set; }
        protected IPlantaService PlantaService { get; set; }
        //
        // GET: /Catalogo/Silo/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new Silo()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(Silo silo)
        {
            if (ModelState.IsValid)
            {
                SiloService.CreateSilo(silo);
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction(INDEX_VIEW);
            }
            else            
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
                //return View(GetModel(silo));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Silo silo = SiloService.ReadSiloById(id);
            return View(GetModel(silo));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(Silo silo)
        {
            if (ModelState.IsValid)
            {
                SiloService.UpdateSilo(silo);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(silo));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            Silo silo = SiloService.ReadSiloById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(silo));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(Silo silo)
        {
            SiloService.DeleteSilo(silo);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Silo> result = SiloService.ReadSilo(grid);

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
                        cell = new string[] { p.NumSilo, p.Descripcion, p.Planta.NombrePlanta, p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private SiloViewModel GetModel(Silo silo)
        {
            return new SiloViewModel(silo, PlantaService.ReadPlanta());
        }
    }
}
