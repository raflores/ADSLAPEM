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
using ADS.LAPEM.Web.Areas.Consulta.Models;
using ADS.LAPEM.Web.Infrastructure.Filter;

namespace ADS.LAPEM.Web.Areas.Consulta.Controllers
{
    public class ConsultaEnLineaController : BaseController
    {
        protected IResultadoService ResultadoService { get; set; }
        protected ILoteService LoteService { get; set; }
        protected IProductoService ProductoService { get; set; }
        
        // GET: /Consulta/ConsultaEnLinea/

        public ActionResult Index()
        {
            return View(GetModel(new Lote()));
        }

        [HttpGet]
        public ActionResult GetDetalle(GridSettingsWeb grid, long id)
        {
            GridResult<Resultado> result = ResultadoService.ReadResultado(grid);

            var jsonData = new
            {
                total = result.TotalPages,
                result.PageIndex,
                records = result.TotalRecords,
                rows = (
                    from p in result.Rows
                    where p.LoteId == id
                    select new
                    {
                        id = p.Id,
                        cell = new string[] { p.LoteId.ToString(), p.Ensayo.Nombre, p.NormaUM, p.NormaVMin.ToString(), p.NormaVMax.ToString(), p.ResultadoValor.ToString(), (p.Aprobado == 1 ? "Aprobado" : "Rechazado"), p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDetail(long id)
        {
            List<Resultado> result = ResultadoService.ReadResultadoByLote(id).ToList();

            var jsonData = new
            {
                rows = (
                    from p in result
                    select new
                    {
                        cell = new string[] { p.Norma.Nombre, p.NormaEnsayo.Nombre, p.ResultadoValor.ToString(),
                        (p.Aprobado == 1 ? "Aprobado" : "Rechazado") }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Lote> result = LoteService.ReadLote(grid);

            var jsonData = new
            {
                total = result.TotalPages,
                result.PageIndex,
                records = result.TotalRecords,
                rows = (
                    from p in result.Rows
                    where p.Aprobado == false
                    select new
                    {
                        id = p.Id,
                        cell = new string[] { p.Identificador, p.Producto.Codigo, p.Linea.Planta.NombrePlanta, p.Linea.Nombre, p.Turno.NombreTurno, p.FechaProduccion.ToShortDateString(),
                        p.CantidadProducida.ToString(), (p.Aprobado == true ? "Aprobado" : "Rechazado"), p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private LoteViewModel GetModel(Lote lote)
        {
            return new LoteViewModel(lote, ProductoService.ReadProducto());
        }


        //[HttpGet]
        //public ActionResult GetList(GridSettingsWeb grid)
        //{
        //    GridResult<Resultado> result = ResultadoService.ReadResultado(grid);
        //    Lote resultLote = LoteService.ReadLoteById(1);

        //    var jsonData = new
        //    {
        //        total = result.TotalPages,
        //        result.PageIndex,
        //        records = result.TotalRecords,
        //        rows = (
        //            from p in result.Rows
        //            orderby p.FechaPrueba descending
        //            select new
        //            {
        //                id = p.Id,
        //                cell = new string[] { p.FechaPrueba.ToShortDateString(), p.Lote.Identificador, p.Lote.Producto.Nombre, p.Lote.Linea.Nombre, (p.Aprobado == 1 ? "Sí" : "No"), p.Id.ToString() }
        //            }).ToArray()
        //    };

        //    return Json(jsonData, JsonRequestBehavior.AllowGet);
        //}

    }
}
