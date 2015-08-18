using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Repositories.Data;
using ADS.LAPEM.Web.Controllers;
using ADS.LAPEM.Services.Catalogo;
using ADS.LAPEM.Web.Areas.Catalogo.Models;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Web.Infrastructure.Grid;
using ADS.LAPEM.Web.Infrastructure.Filter;

namespace ADS.LAPEM.Web.Areas.Catalogo.Controllers
{
    [Authorize]
    public class PlantaController : BaseController
    {
        protected IPlantaService PlantaService { get; set; }

        //
        // GET: /Catalogo/Planta/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Catalogo/Planta/Create
        [HttpGet]    
        public ActionResult Create()
        {
            return View(GetModel(new Planta()));
        }

        //
        // POST: /Catalogo/Planta/Create

        [HttpPost, LoggingFilter]
        public ActionResult Create(Planta planta)
        {
            if (ModelState.IsValid)
            {
                //planta.Activo = true;
                PlantaService.CreatePlanta(planta);
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction(INDEX_VIEW);
            }
            else 
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
                //return View(GetModel(planta));
            }
        }

        //
        // GET: /Catalogo/Planta/Edit/5
        [HttpGet]
        public ActionResult Edit(long id = 0)
        {
            Planta planta = PlantaService.ReadPlantaById(id);
            if (planta == null)
            {
                return HttpNotFound();
            }
            return View(GetModel(planta));
        }

        //
        // POST: /Catalogo/Planta/Edit/5

        [HttpPost, LoggingFilter]
        public ActionResult Edit(Planta planta)
        {
            if (ModelState.IsValid)
            {
                planta.Activo = true;
                PlantaService.UpdatePlanta(planta);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(planta));
            }            
        }

        //
        // GET: /Catalogo/Planta/Delete/5

        [HttpGet]
        public ActionResult Delete(long id = 0)
        {
            Planta planta = PlantaService.ReadPlantaById(id);
            if (planta == null)
            {
                return HttpNotFound();
            }

            return PartialView(DELETE_PARTIAL_VIEW, GetModel(planta));
        }

        //
        // POST: /Catalogo/Planta/Delete/5

        [HttpPost, LoggingFilter, ActionName("Delete")]
        public ActionResult Delete(Planta planta)
        {
            Planta p = PlantaService.ReadPlantaById(planta.Id);
            p.Activo = false;
            PlantaService.UpdatePlanta(p);
            //PlantaService.DeletePlanta(planta);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Planta> result = PlantaService.ReadPlanta(grid);

            var jsonData = new
            {
                total = result.TotalPages,
                result.PageIndex,
                records = result.TotalRecords,
                rows = (
                    from p in result.Rows
                    where p.Activo == true
                    select new
                    {
                        id = p.Id,
                        cell = new string[] { p.NombrePlanta, p.Ciudad, p.Estado, p.RFC, p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private PlantaViewModel GetModel(Planta planta)
        {
            return new PlantaViewModel(planta);
        }

        ////
        //// GET: /Catalogo/Planta/Details/5

        //public ActionResult Details(long id = 0)
        //{
        //    Planta planta = db.Plantas.Find(id);
        //    if (planta == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(planta);
        //}
    }
}