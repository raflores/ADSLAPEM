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
    public class CalibracionController : BaseController
    {
        protected ICalibracionService CalibracionService { get; set; }
        protected IEquipoService EquipoService { get; set; }
        protected IProveedorService ProveedorService { get; set; }
        //
        // GET: /Catalogo/Calibracion/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        { 
            return View(GetModel(new Calibracion()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(Calibracion calibracion)
        {
            if (ModelState.IsValid)
            {
                calibracion.Activo = true;
                calibracion.FileContent = System.IO.File.ReadAllBytes(Server.MapPath("calibracion.PDFInforme"));
                CalibracionService.CreateCalibracion(calibracion);
                //return RedirectToAction(INDEX_VIEW);
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return View(GetModel(calibracion));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Calibracion calibracion = CalibracionService.ReadCalibracionById(id);
            return View(GetModel(calibracion));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(Calibracion calibracion)
        {
            if (ModelState.IsValid)
            {
                calibracion.Activo = true;
                CalibracionService.UpdateCalibracion(calibracion);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(calibracion));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            Calibracion calibracion = CalibracionService.ReadCalibracionById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(calibracion)); 
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(Calibracion calibracion)
        {
            Calibracion calibracion2 = CalibracionService.ReadCalibracionById(calibracion.Id);
            calibracion2.Activo = false;
            CalibracionService.UpdateCalibracion(calibracion2);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Calibracion> result = CalibracionService.ReadCalibracion(grid);

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
                        cell = new string[] { p.NoInformeCalib.ToString(), p.Equipo.CodigoActivoFijo, p.FechaCalibracion.ToShortDateString(), p.FechaVencimiento.ToShortDateString(), p.PDFInforme, p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private CalibracionViewModel GetModel(Calibracion calibracion)
        {
            return new CalibracionViewModel(calibracion, EquipoService.ReadEquipo().Where(x => x.Activo == true), ProveedorService.ReadProveedor());
        }

    }
}
