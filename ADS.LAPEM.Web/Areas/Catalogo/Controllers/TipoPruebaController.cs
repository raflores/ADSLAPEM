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
    public class TipoPruebaController : BaseController
    {
        protected ITipoPruebaService TipoPruebaService { get; set; }
        //
        // GET: /Catalogo/TipoPrueba/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new TipoPrueba()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(TipoPrueba tipoPrueba)
        {
            if (ModelState.IsValid)
            {
                TipoPruebaService.CreateTipoPrueba(tipoPrueba);
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
                //return View(GetModel(tipoPrueba));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            TipoPrueba tipoPrueba = TipoPruebaService.ReadTipoPruebaById(id);
            return View(GetModel(tipoPrueba));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(TipoPrueba tipoPrueba)
        {
            if (ModelState.IsValid)
            {
                TipoPruebaService.UpdateTipoPrueba(tipoPrueba);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(tipoPrueba));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            TipoPrueba tipoPrueba = TipoPruebaService.ReadTipoPruebaById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(tipoPrueba));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(TipoPrueba tipoPrueba)
        {
            TipoPruebaService.DeleteTipoPrueba(tipoPrueba);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<TipoPrueba> result = TipoPruebaService.ReadTipoPrueba(grid);

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

        private TipoPruebaViewModel GetModel(TipoPrueba tipoPrueba)
        {
            return new TipoPruebaViewModel(tipoPrueba);
        }       

    }
}

