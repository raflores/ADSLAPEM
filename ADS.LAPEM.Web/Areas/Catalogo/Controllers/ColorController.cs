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
    public class ColorController : BaseController
    {
        protected IColorService ColorService { get; set; }
        //
        // GET: /Catalogo/Color/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new Color()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(Color color)
        {
            if (ModelState.IsValid)
            {
                color.Activo = true;
                ColorService.CreateColor(color);
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Color color = ColorService.ReadColorById(id);
            return View(GetModel(color));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(Color color)
        {
            if (ModelState.IsValid)
            {
                color.Activo = true;
                ColorService.UpdateColor(color);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(color));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            Color color = ColorService.ReadColorById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(color));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(Color color)
        {
            Color color2 = ColorService.ReadColorById(color.Id);
            color2.Activo = false;
            ColorService.UpdateColor(color2);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Color> result = ColorService.ReadColor(grid);

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
                        cell = new string[] { p.Codigo, p.Nombre, p.Tipo, p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }


        private ColorViewModel GetModel(Color color)
        {
            return new ColorViewModel(color);
        }

    }
}

