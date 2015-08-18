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
    public class NormaProductoController : BaseController
    {
        protected INormaProductoService NormaProductoService { get; set; }
        protected IProductoService ProductoService { get; set; }
        protected INormaEnsayoService NormaEnsayoService { get; set; }
        //
        // GET: /Catalogo/NormaProducto/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new NormaProducto()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(NormaProducto normaProducto)
        {
            if (ModelState.IsValid)
            {
                foreach (NormaEnsayo n in normaProducto.Normas)
                {
                    normaProducto.NormaEnsayoId = n.Id;
                    normaProducto.Activo = true;
                    NormaProductoService.CreateNormaProducto(normaProducto);
                }
                
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(normaProducto));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            NormaProducto normaProducto = NormaProductoService.ReadNormaProductoById(id);
            return View(GetModel(normaProducto));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(NormaProducto normaProducto)
        {
            if (ModelState.IsValid)
            {
                NormaProductoService.UpdateNormaProducto(normaProducto);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(normaProducto));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            NormaProducto normaProducto = NormaProductoService.ReadNormaProductoById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(normaProducto));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(NormaProducto normaProducto)
        {
            NormaProductoService.DeleteNormaProducto(normaProducto);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<NormaProducto> result = NormaProductoService.ReadNormaProducto(grid);

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
                        cell = new string[] { p.Nombre, p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        private NormaProductoViewModel GetModel(NormaProducto normaProducto)
        {
            return new NormaProductoViewModel(normaProducto, ProductoService.ReadProducto(), NormaEnsayoService.ReadNormaEnsayo());
        }

    }
}
