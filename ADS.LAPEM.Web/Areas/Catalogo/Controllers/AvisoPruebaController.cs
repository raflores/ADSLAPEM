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
    public class AvisoPruebaController : BaseController
    {
        protected IResultadoService ResultadoService { get; set; }
        protected IAvisoPruebaService AvisoPruebaService { get; set; }
        protected ILoteService LoteService { get; set; }
        
        // GET: /Catalogo/AvisoPrueba/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnviarAviso(List<Lote> lote)
        {
            List<Lote> listLote = new List<Lote>();

            foreach (Lote l in lote)
            {
                Lote lot = LoteService.ReadLoteById(l.Id);
                AvisoPrueba aviso = new AvisoPrueba();
                aviso.NoProveedor = 8448;
                aviso.FamiliaId = "FALO";
                aviso.UnidadId = "Kg";
                aviso.Pedido = "Particular";
                aviso.Partida = 0;
                aviso.Cantidad = lot.CantidadProducida;
                aviso.Costo = 0;
                aviso.Moneda = "MX";
                aviso.Iva = 16;
                aviso.Destino = "Almacen Santa Catarina";
                aviso.Observaciones = "-";
                aviso.DescProducto = "Transformador";
                aviso.ProductoId = (long)lot.ProductoId;
                aviso.LoteId = lot.Id;
                AvisoPruebaService.CreateAvisoPrueba(aviso);
                lot.Activo = false;
                LoteService.UpdateLote(lot);
            }

            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
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
                    where p.Aprobado == true && p.Activo == true
                    select new
                    {
                        id = p.Id,
                        cell = new string[] { p.Identificador, p.Producto.Codigo, p.Linea.Nombre, p.Turno.NombreTurno, p.FechaProduccion.ToShortDateString(),
                        p.CantidadProducida.ToString(), (p.Aprobado == true ? "Aprobado" : "Rechazado"), p.Id.ToString() }
                    }).ToArray()
            };
            //GridResult<Resultado> result = ResultadoService.ReadResultado(grid);

            //var jsonData = new
            //{
            //    total = result.TotalPages,
            //    result.PageIndex,
            //    records = result.TotalRecords,
            //    rows = (
            //        from p in result.Rows
            //        select new
            //        {
            //            id = p.Id,
            //            //cell = new string[] { p.EnviadoLapem.ToString(), p.ProductoDesc, p.NormaId.ToString(), p.NormaUM, p.NormaVMin.ToString(), p.NormaVMax.ToString() }
            //            cell = new string[] { p.NormaUM, p.NormaVMin.ToString(), p.NormaVMax.ToString() }
            //        }).ToArray()
            //};

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
