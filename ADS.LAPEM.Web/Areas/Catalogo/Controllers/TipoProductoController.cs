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
    public class TipoProductoController : BaseController
    {
        protected ITipoProductoService TipoProductoService { get; set; }
        //
        // GET: /Catalogo/TipoProducto/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new TipoProducto()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(TipoProducto tipoProducto)
        {
            if (ModelState.IsValid)
            {
                TipoProductoService.CreateTipoProducto(tipoProducto);
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
                //return View(GetModel(tipoProducto));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            TipoProducto tipoProducto = TipoProductoService.ReadTipoProductoById(id);
            return View(GetModel(tipoProducto));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(TipoProducto tipoProducto)
        {
            if (ModelState.IsValid)
            {
                TipoProductoService.UpdateTipoProducto(tipoProducto);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(tipoProducto));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            TipoProducto tipoProducto = TipoProductoService.ReadTipoProductoById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(tipoProducto));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(TipoProducto tipoProducto)
        {
            TipoProductoService.DeleteTipoProducto(tipoProducto);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<TipoProducto> result = TipoProductoService.ReadTipoProducto(grid);

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

        private TipoProductoViewModel GetModel(TipoProducto tipoProducto)
        {
            return new TipoProductoViewModel(tipoProducto);
        }  

    }
}
