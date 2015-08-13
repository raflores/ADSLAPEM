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
    public class NormaController : BaseController
    {
        protected INormaService NormaService { get; set; }
        //
        // GET: /Catalogo/Norma/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new Norma()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(Norma norma)
        {
            if (ModelState.IsValid)
            {
                norma.Activo = true;
                NormaService.CreateNorma(norma);
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
                //return View(GetModel(norma));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Norma norma = NormaService.ReadNormaById(id);
            return View(GetModel(norma));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(Norma norma)
        {
            if (ModelState.IsValid)
            {
                norma.Activo = true;
                NormaService.UpdateNorma(norma);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(norma));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            Norma norma = NormaService.ReadNormaById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(norma));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(Norma norma)
        {
            Norma norma2 = NormaService.ReadNormaById(norma.Id);
            norma2.Activo = false;
            NormaService.UpdateNorma(norma2);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Norma> result = NormaService.ReadNorma(grid);

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

        private NormaViewModel GetModel(Norma norma)
        {
            return new NormaViewModel(norma);
        }

    }
}
