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
    public class EquipoController : BaseController
    {

        protected IEquipoService EquipoService { get; set; }
        protected IPlantaService PlantaService { get; set; }
        protected ICalibracionService CalibracionService { get; set; }
        //
        // GET: /Catalogo/Equipo/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new Equipo()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                equipo.Activo = true;
                EquipoService.CreateEquipo(equipo);
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(equipo));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Equipo equipo = EquipoService.ReadEquipoById(id);           
            return View(GetModel(equipo));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                equipo.Activo = true;
                EquipoService.UpdateEquipo(equipo);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(equipo));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            Equipo equipo = EquipoService.ReadEquipoById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(equipo));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(Equipo equipo)
        {
            Equipo e = EquipoService.ReadEquipoById(equipo.Id);
            e.RazonBorrado = equipo.RazonBorrado;
            e.Activo = false;
            EquipoService.UpdateEquipo(e);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult MostrarPDF(long id)
        {
            //Equipo equipo = EquipoService.ReadEquipoById(id);
            //List<Calibracion> Calibraciones = equipo.Calibraciones.ToList();
            Calibracion calibracion = CalibracionService.ReadCalibracionById(id);

            return base.File(calibracion.FileContent, "application/pdf");
        }

        [HttpGet]
        public ActionResult Detail(long id)
        {             
            Equipo equipo = EquipoService.ReadEquipoById(id);

            
            //if (equipo.Calibraciones.Count > 0)
            if (equipo.Calibraciones != null)
            {
                var jsonData = new
                {
                    rows = (
                        from p in equipo.Calibraciones
                        select new
                        {
                            cell = new string[] { p.NoInformeCalib.ToString(), p.FechaCalibracion.ToShortDateString(), p.Proveedor.Nombre, "<a href=../" + "Catalogo/Equipo/MostrarPDF?id=" + p.Id + " class='ui-icon ui-icon-circle-arrow-s' /></a>" }
                        }).ToArray()
                };

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var jsonData = new { };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }

            
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Equipo> result = EquipoService.ReadEquipo(grid);            

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
                        cell = new string[] { p.CodigoActivoFijo, p.Serie, p.Marca, p.Modelo, p.Planta.NombrePlanta, p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        private EquipoViewModel GetModel(Equipo equipo)
        {
            return new EquipoViewModel(equipo, PlantaService.ReadPlanta());
        }
    }
}
