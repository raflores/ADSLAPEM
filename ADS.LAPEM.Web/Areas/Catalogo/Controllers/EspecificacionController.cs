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
    public class EspecificacionController : BaseController
    {
        protected IEspecificacionService EspecificacionService { get; set; }
        protected INormaService NormaService { get; set; }
        protected INormaEnsayoService NormaEnsayoService { get; set; }
        protected IEnsayoService EnsayoService { get; set; }
        protected IProductoService ProductoService { get; set; }
        protected ITipoEnsayoService TipoEnsayoService { get; set; }
        protected IUnidadMedidaService UnidadMedidaService { get; set; }
        //
        // GET: /Catalogo/Especificacion/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        { 
            return View(GetModel(new Especificacion()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(Especificacion especificacion)
        {
            if (ModelState.IsValid)
            {
                especificacion.Activo = true;
                EspecificacionService.CreateEspecificacion(especificacion);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(especificacion));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Especificacion especificacion = EspecificacionService.ReadEspecificacionById(id);
            return View(GetModel(especificacion));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(Especificacion especificacion)
        {
            if (ModelState.IsValid)
            {
                EspecificacionService.UpdateEspecificacion(especificacion);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(especificacion));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            Especificacion especificacion = EspecificacionService.ReadEspecificacionById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(especificacion));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(Especificacion especificacion)
        {
            EspecificacionService.DeleteEspecificacion(especificacion);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Especificacion> result = EspecificacionService.ReadEspecificacion(grid);

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
                        cell = new string[] { p.Producto.Codigo, p.Norma.Nombre, p.NormaEnsayo.Nombre, p.Ensayo.Nombre,  p.Minimo.ToString(), p.Maximo.ToString(), p.Objetivo.ToString(), p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetProductoList()
        {
            IEnumerable<Producto> result = ProductoService.ReadProducto();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private EspecificacionViewModel GetModel(Especificacion especificacion)
        {
            return new EspecificacionViewModel(especificacion, NormaService.ReadNorma(), NormaEnsayoService.ReadNormaEnsayo(),
                EnsayoService.ReadEnsayo(), ProductoService.ReadProducto(), TipoEnsayoService.ReadTipoEnsayo(), UnidadMedidaService.ReadUM());
        }

    }
}
