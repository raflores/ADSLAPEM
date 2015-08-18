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

namespace ADS.LAPEM.Web.Areas.Consulta.Controllers
{
    public class ConsultaAvisoController : BaseController
    {
        protected IAvisoPruebaService AvisoPruebaService { get; set; }
        protected ILoteService LoteService { get; set; }
        //
        // GET: /Consulta/ConsultaAviso/

        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult GetDetail(long id)
        //{
        //    List<Lote> result = ResultadoService.ReadResultadoByLote(id).ToList();

        //    var jsonData = new
        //    {
        //        rows = (
        //            from p in result
        //            select new
        //            {
        //                cell = new string[] { p.Norma.Nombre, p.NormaEnsayo.Nombre, p.ResultadoValor.ToString(),
        //                p.Aprobado.ToString() }
        //            }).ToArray()
        //    };

        //    return Json(jsonData, JsonRequestBehavior.AllowGet);

        //}

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<AvisoPrueba> result = AvisoPruebaService.ReadAvisoPrueba(grid);

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
                        cell = new string[] { p.NumAviso.ToString(), p.Lote.Identificador, p.Lote.Producto.Codigo, p.FamiliaId, p.Pedido, p.Cantidad.ToString(), p.Costo.ToString(), p.Moneda,
                        p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

    }
}
