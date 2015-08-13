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
    public class LineaController : BaseController
    {
        protected ILineaService LineaService { get; set; }
        protected IPlantaService PlantaService { get; set; }
        //
        // GET: /Catalogo/Linea/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new Linea()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(Linea linea)
        {
            if (ModelState.IsValid)
            {
                linea.Activo = true;
                LineaService.CreateLinea(linea);
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(linea));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Linea linea = LineaService.ReadLineaById(id);
            return View(GetModel(linea));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(Linea linea)
        {
            if (ModelState.IsValid)
            {
                linea.Activo = true;
                LineaService.UpdateLinea(linea);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(linea));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            Linea linea = LineaService.ReadLineaById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(linea)); 
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(Linea linea)
        {
            Linea l = LineaService.ReadLineaById(linea.Id);
            l.Activo = false;
            LineaService.UpdateLinea(l);
            //LineaService.DeleteLinea(linea);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Linea> result = LineaService.ReadLinea(grid);

            var jsonData = new
            {
                total = result.TotalPages,
                result.PageIndex,
                records = result.TotalRecords,
                rows = (
                    from p in result.Rows
                    where p.Activo
                    select new
                    {
                        id = p.Id,
                        cell = new string[] { p.Nombre, p.Descripcion, p.Planta.NombrePlanta, p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    

        private LineaViewModel GetModel(Linea linea)
        {
            return new LineaViewModel(linea, PlantaService.ReadPlanta());
        }

    }
}
