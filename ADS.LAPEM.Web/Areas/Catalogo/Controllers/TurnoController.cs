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
    public class TurnoController : BaseController
    {
        protected ITurnoService TurnoService { get; set; }
        //
        // GET: /Catalogo/Turno/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new Turno()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(Turno turno)
        {
            if (ModelState.IsValid)
            {
                TurnoService.CreateTurno(turno);
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
                //return View(GetModel(turno));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Turno turno = TurnoService.ReadTurnoById(id);
            return View(GetModel(turno));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(Turno turno)
        {
            if (ModelState.IsValid)
            {
                TurnoService.UpdateTurno(turno);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(turno));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            Turno turno = TurnoService.ReadTurnoById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(turno));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(Turno turno)
        {
            TurnoService.DeleteTurno(turno);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Turno> result = TurnoService.ReadTurno(grid);

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
                        cell = new string[] { p.NombreTurno, p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private TurnoViewModel GetModel(Turno turno)
        {
            return new TurnoViewModel(turno);
        }

    }
}
