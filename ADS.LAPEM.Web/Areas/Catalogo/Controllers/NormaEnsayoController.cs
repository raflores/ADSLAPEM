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
    public class NormaEnsayoController : BaseController
    {
        protected INormaEnsayoService NormaEnsayoService { get; set; }
        protected IUnidadMedidaService UnidadMedidaService { get; set; }
        protected INormaService NormaService { get; set; }
        protected IMedidaDiametroService MedidaDiametroService { get; set; }
        protected INormaEnsayoValorInService NormaEnsayoValorInService { get; set; }
        protected INormaEnsayoValorMmService NormaEnsayoValorMmService { get; set; }

        //
        // GET: /Catalogo/NormaEnsayo/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new NormaEnsayo()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(NormaEnsayo normaEnsayo)
        {
            if (ModelState.IsValid)
            {
                NormaEnsayoService.CreateNormaEnsayo(normaEnsayo);
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
                //return View(GetModel(normaEnsayo));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            NormaEnsayo normaEnsayo = NormaEnsayoService.ReadNormaEnsayoById(id);   
            return View(GetModelEdit(normaEnsayo));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(NormaEnsayo normaEnsayo)
        {
            if (ModelState.IsValid)
            {
                NormaEnsayoService.UpdateNormaEnsayo(normaEnsayo);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(normaEnsayo));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            NormaEnsayo normaEnsayo = NormaEnsayoService.ReadNormaEnsayoById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(normaEnsayo));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(NormaEnsayo normaEnsayo)
        {
            NormaEnsayoService.DeleteNormaEnsayo(normaEnsayo);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<NormaEnsayo> result = NormaEnsayoService.ReadNormaEnsayo(grid);

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

        private NormaEnsayoViewModel GetModelEdit(NormaEnsayo normaEnsayo)
        {
            return new NormaEnsayoViewModel(normaEnsayo, UnidadMedidaService.ReadUM(), NormaService.ReadNorma());
        }


        private NormaEnsayoViewModel GetModel(NormaEnsayo normaEnsayo)
        {
            return new NormaEnsayoViewModel(normaEnsayo, UnidadMedidaService.ReadUM(), NormaService.ReadNorma());
        }       

    }
}
