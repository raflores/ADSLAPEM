using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bsd.Common.Report;
using Bsd.Common.Report.Impl;
using Bsd.Common.Report.Model;
using ADS.LAPEM.Services.Catalogo;
using ADS.LAPEM.Web.Controllers;
using ADS.LAPEM.Web.Areas.Reporte.Models;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Infrastructure.Grid;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Web.Areas.Reporte.Controllers
{
    public class RpteAgrietamientoController : BaseController
    {
        protected IResultadoService ResultadoService { get; set; }
        protected IResultadoDetalleService ResultadoDetalleService { get; set; }
        protected IProductoService ProductoService { get; set; }
        protected ITurnoService TurnoService { get; set; }
        protected IReportViewerService ReportViewerService { get; set; }
        protected IAtributoDService AtributoDService { get; set; }
        protected ILoteService LoteService { get; set; }
        //
        // GET: /Reporte/RpteAgrietamiento/

        public ActionResult Index()
        {
            return View(GetModel(new Lote()));
            //return View();
        }

        //[HttpGet]
        //public ActionResult GenerarReporte()
        //{
        //    return View(GetModel(new Resultado()));
        //}

        [HttpPost]
        public ActionResult GenerarRepo(Resultado resultado)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteAgrietamiento.rdlc");

            string longA1 = "", longA2 = "", longA3 = "";
            string longB1 = "", longB2 = "", longB3 = "";
            string temp1 = "", temp2 = "", temp3 = "";
            string sol1 = "", sol2 = "", sol3 = "";
            string resultado1 = "", resultado2 = "", resultado3 = "";
            string perfil = "", noTubo = "";

            //Resultado
            var resultQRY = ResultadoService.ReadResultado().Where(x => x.ProductoId == resultado.ProductoId && x.FechaPrueba == resultado.FechaPrueba).ToList();

            for (int i = 0; i < resultQRY.Count; i++)
            {
                if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                {
                    if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-184-SCFI")
                    {
                        var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                        for (int j = 0; j < resultDetalle.Count; j++)
                        {
                            var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                            for (int ad = 0; ad < atributoDetalle.Count; ad++)
                            {
                                switch (atributoDetalle[ad].AtributoId)
                                {
                                    case 1:
                                        if (longA1 == "")
                                        {
                                            longA1 = atributoDetalle[ad].Valor;
                                            resultado1 = resultDetalle[j].Resultado.ResultadoValor.ToString(); 
                                        }
                                        else if (longA2 == "")
                                        {
                                            longA2 = atributoDetalle[ad].Valor;
                                            resultado2 = resultDetalle[j].Resultado.ResultadoValor.ToString(); 
                                        }
                                        else if (longA3 == "")
                                        {
                                            longA3 = atributoDetalle[ad].Valor;
                                            resultado3 = resultDetalle[j].Resultado.ResultadoValor.ToString(); 
                                        }
                                        break;
                                    case 2:
                                        if (longB1 == "")
                                        {
                                            longB1 = atributoDetalle[ad].Valor;
                                        }
                                        else if (longB2 == "")
                                        {
                                            longB2 = atributoDetalle[ad].Valor;
                                        }
                                        else if (longB3 == "")
                                        {
                                            longB3 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 11:
                                        if (temp1 == "")
                                        {
                                            temp1 = atributoDetalle[ad].Valor;
                                        }
                                        else if (temp2 == "")
                                        {
                                            temp2 = atributoDetalle[ad].Valor;
                                        }
                                        else if (temp3 == "")
                                        {
                                            temp3 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 12:
                                        if (sol1 == "")
                                        {
                                            sol1 = atributoDetalle[ad].Valor;
                                        }
                                        else if (sol2 == "")
                                        {
                                            sol2 = atributoDetalle[ad].Valor;
                                        }
                                        else if (sol3 == "")
                                        {
                                            sol3 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 147:
                                        perfil = atributoDetalle[ad].Valor;
                                        break;
                                    case 148:
                                        noTubo = atributoDetalle[ad].Valor;
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            //Lote
            var resultLote = resultQRY[0].Lote;
            List<Lote> listLote = new List<Lote>();
            listLote.Add(resultLote);
            //ResultadoDetalle
            var resultDetalle2 = ResultadoDetalleService.ReadResultadoDetalle().Where(x => x.ResultadoId == resultQRY[0].Id).ToList();
            //Producto
            var resultProducto = ProductoService.ReadProducto().Where(x => x.Id == resultQRY[0].ProductoId).ToList();
            //var resultEquipo = EquipoService.ReadEquipo().Where(x => x.Id == resultQRY[0].EquipoId).ToList();
            var resultTurno = resultLote.Turno;
            List<Turno> listTurno = new List<Turno>();
            listTurno.Add(resultTurno);
            //var resultNorma = resultQRY[0].Norma;
            //List<Norma> listNorma = new List<Norma>();
            //listNorma.Add(resultNorma);
            //var resultDiametro = resultProducto[0].MedidaDiametro;
            //List<MedidaDiametro> listDiametro = new List<MedidaDiametro>();
            //listDiametro.Add(resultDiametro);
            //List<Resultado> ListVacio = new List<Resultado>();
            //List<Resultado> ListPresion = new List<Resultado>();
            //List<Equipo> listEquipo = new List<Equipo>();

            BsdReportDataSource rds = new BsdReportDataSource("DsAgrietamiento", resultQRY);
            BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
            BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle2);
            BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
            BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);

            BsdReportParameter parameter1 = new BsdReportParameter("NoTubo", noTubo, true);
            BsdReportParameter parameter2 = new BsdReportParameter("Perfil", perfil, true);
            BsdReportParameter parameter3 = new BsdReportParameter("LongA1", longA1, true);
            BsdReportParameter parameter4 = new BsdReportParameter("LongA2", longA2, true);
            BsdReportParameter parameter5 = new BsdReportParameter("LongA3", longA3, true);
            BsdReportParameter parameter6 = new BsdReportParameter("LongB1", longB1, true);
            BsdReportParameter parameter7 = new BsdReportParameter("LongB2", longB2, true);
            BsdReportParameter parameter8 = new BsdReportParameter("LongB3", longB3, true);
            BsdReportParameter parameter9 = new BsdReportParameter("Resultado1", resultado1, true);
            BsdReportParameter parameter10 = new BsdReportParameter("Resultado2", resultado2, true);
            BsdReportParameter parameter11 = new BsdReportParameter("Resultado3", resultado3, true);
            BsdReportParameter parameter12 = new BsdReportParameter("Temp1", temp1, true);
            BsdReportParameter parameter13 = new BsdReportParameter("Temp2", temp2, true);
            BsdReportParameter parameter14 = new BsdReportParameter("Temp3", temp3, true);
            BsdReportParameter parameter15 = new BsdReportParameter("Sol1", sol1, true);
            BsdReportParameter parameter16 = new BsdReportParameter("Sol2", sol2, true);
            BsdReportParameter parameter17 = new BsdReportParameter("Sol3", sol3, true);

            IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
            ds.Add(rds);
            ds.Add(rds2);
            ds.Add(rds3);
            ds.Add(rds4);
            ds.Add(rds5);

            BsdReport report = new BsdReport("Reporte de Agrietamiento", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
            report.Parameters.Add(parameter1);
            report.Parameters.Add(parameter2);
            report.Parameters.Add(parameter3);
            report.Parameters.Add(parameter4);
            report.Parameters.Add(parameter5);
            report.Parameters.Add(parameter6);
            report.Parameters.Add(parameter7);
            report.Parameters.Add(parameter8);
            report.Parameters.Add(parameter9);
            report.Parameters.Add(parameter10);
            report.Parameters.Add(parameter11);
            report.Parameters.Add(parameter12);
            report.Parameters.Add(parameter13);
            report.Parameters.Add(parameter14);
            report.Parameters.Add(parameter15);
            report.Parameters.Add(parameter16);
            report.Parameters.Add(parameter17);

            BsdReportResult result = ReportViewerService.CreateReport(report);

            return File(result.Content, result.MimeType); 

            //BsdReport report = new BsdReport("Reporte Agrietamiento", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
            ////report.Parameters.Add(parameter);
            //BsdReportResult result = ReportViewerService.CreateReport(report);

            ////FileStream fs = new FileStream(@"c:\Reportes\" + report.Name + "." + result.FileType, FileMode.OpenOrCreate);
            ////fs.Write(result.Content, 0, result.Content.Length);
            ////fs.Close();

            //return File(result.Content, result.MimeType);            

                
        }

        [HttpGet]
        public ActionResult Generar(long id)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteAgrietamiento.rdlc");

            string longA1 = "", longA2 = "", longA3 = "";
            string longB1 = "", longB2 = "", longB3 = "";
            string temp1 = "", temp2 = "", temp3 = "";
            string sol1 = "", sol2 = "", sol3 = "";
            string resultado1 = "", resultado2 = "", resultado3 = "";
            string perfil = "", noTubo = "";

            var resultQRY = ResultadoService.ReadResultadoByLote(id).ToList();

            for (int i = 0; i < resultQRY.Count; i++)
            {
                if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                {
                    if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-184-SCFI")
                    {
                        var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                        for (int j = 0; j < resultDetalle.Count; j++)
                        {
                            var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                            for (int ad = 0; ad < atributoDetalle.Count; ad++)
                            {
                                switch (atributoDetalle[ad].AtributoId)
                                {
                                    case 1:
                                        if (longA1 == "")
                                        {
                                            longA1 = atributoDetalle[ad].Valor;
                                            resultado1 = resultDetalle[j].Resultado.ResultadoValor.ToString();
                                        }
                                        else if (longA2 == "")
                                        {
                                            longA2 = atributoDetalle[ad].Valor;
                                            resultado2 = resultDetalle[j].Resultado.ResultadoValor.ToString();
                                        }
                                        else if (longA3 == "")
                                        {
                                            longA3 = atributoDetalle[ad].Valor;
                                            resultado3 = resultDetalle[j].Resultado.ResultadoValor.ToString();
                                        }
                                        break;
                                    case 2:
                                        if (longB1 == "")
                                        {
                                            longB1 = atributoDetalle[ad].Valor;
                                        }
                                        else if (longB2 == "")
                                        {
                                            longB2 = atributoDetalle[ad].Valor;
                                        }
                                        else if (longB3 == "")
                                        {
                                            longB3 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 11:
                                        if (temp1 == "")
                                        {
                                            temp1 = atributoDetalle[ad].Valor;
                                        }
                                        else if (temp2 == "")
                                        {
                                            temp2 = atributoDetalle[ad].Valor;
                                        }
                                        else if (temp3 == "")
                                        {
                                            temp3 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 12:
                                        if (sol1 == "")
                                        {
                                            sol1 = atributoDetalle[ad].Valor;
                                        }
                                        else if (sol2 == "")
                                        {
                                            sol2 = atributoDetalle[ad].Valor;
                                        }
                                        else if (sol3 == "")
                                        {
                                            sol3 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 147:
                                        perfil = atributoDetalle[ad].Valor;
                                        break;
                                    case 148:
                                        noTubo = atributoDetalle[ad].Valor;
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            //Lote
            var resultLote = resultQRY[0].Lote;
            List<Lote> listLote = new List<Lote>();
            listLote.Add(resultLote);
            //ResultadoDetalle
            var resultDetalle2 = ResultadoDetalleService.ReadResultadoDetalle().Where(x => x.ResultadoId == resultQRY[0].Id).ToList();
            //Producto
            var resultProducto = ProductoService.ReadProducto().Where(x => x.Id == resultQRY[0].ProductoId).ToList();
            //var resultEquipo = EquipoService.ReadEquipo().Where(x => x.Id == resultQRY[0].EquipoId).ToList();
            var resultTurno = resultLote.Turno;
            List<Turno> listTurno = new List<Turno>();
            listTurno.Add(resultTurno);
            //var resultNorma = resultQRY[0].Norma;
            //List<Norma> listNorma = new List<Norma>();
            //listNorma.Add(resultNorma);
            //var resultDiametro = resultProducto[0].MedidaDiametro;
            //List<MedidaDiametro> listDiametro = new List<MedidaDiametro>();
            //listDiametro.Add(resultDiametro);
            //List<Resultado> ListVacio = new List<Resultado>();
            //List<Resultado> ListPresion = new List<Resultado>();
            //List<Equipo> listEquipo = new List<Equipo>();

            BsdReportDataSource rds = new BsdReportDataSource("DsAgrietamiento", resultQRY);
            BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
            BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle2);
            BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
            BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);

            BsdReportParameter parameter1 = new BsdReportParameter("NoTubo", noTubo, true);
            BsdReportParameter parameter2 = new BsdReportParameter("Perfil", perfil, true);
            BsdReportParameter parameter3 = new BsdReportParameter("LongA1", longA1, true);
            BsdReportParameter parameter4 = new BsdReportParameter("LongA2", longA2, true);
            BsdReportParameter parameter5 = new BsdReportParameter("LongA3", longA3, true);
            BsdReportParameter parameter6 = new BsdReportParameter("LongB1", longB1, true);
            BsdReportParameter parameter7 = new BsdReportParameter("LongB2", longB2, true);
            BsdReportParameter parameter8 = new BsdReportParameter("LongB3", longB3, true);
            BsdReportParameter parameter9 = new BsdReportParameter("Resultado1", resultado1, true);
            BsdReportParameter parameter10 = new BsdReportParameter("Resultado2", resultado2, true);
            BsdReportParameter parameter11 = new BsdReportParameter("Resultado3", resultado3, true);
            BsdReportParameter parameter12 = new BsdReportParameter("Temp1", temp1, true);
            BsdReportParameter parameter13 = new BsdReportParameter("Temp2", temp2, true);
            BsdReportParameter parameter14 = new BsdReportParameter("Temp3", temp3, true);
            BsdReportParameter parameter15 = new BsdReportParameter("Sol1", sol1, true);
            BsdReportParameter parameter16 = new BsdReportParameter("Sol2", sol2, true);
            BsdReportParameter parameter17 = new BsdReportParameter("Sol3", sol3, true);

            IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
            ds.Add(rds);
            ds.Add(rds2);
            ds.Add(rds3);
            ds.Add(rds4);
            ds.Add(rds5);

            BsdReport report = new BsdReport("Reporte de Agrietamiento", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
            report.Parameters.Add(parameter1);
            report.Parameters.Add(parameter2);
            report.Parameters.Add(parameter3);
            report.Parameters.Add(parameter4);
            report.Parameters.Add(parameter5);
            report.Parameters.Add(parameter6);
            report.Parameters.Add(parameter7);
            report.Parameters.Add(parameter8);
            report.Parameters.Add(parameter9);
            report.Parameters.Add(parameter10);
            report.Parameters.Add(parameter11);
            report.Parameters.Add(parameter12);
            report.Parameters.Add(parameter13);
            report.Parameters.Add(parameter14);
            report.Parameters.Add(parameter15);
            report.Parameters.Add(parameter16);
            report.Parameters.Add(parameter17);

            BsdReportResult result = ReportViewerService.CreateReport(report);

            return File(result.Content, result.MimeType); 

            //if (resultQRY.Count > 0)
            //{
            //    return Json("Success", JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Error", JsonRequestBehavior.AllowGet);
            //}   
            
        }
        

        [HttpPost]
        public ActionResult GenerarReporte(Resultado resultado)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteAgrietamiento.rdlc");
            //Resultado
            var resultAtributo = AtributoDService.ReadAtributoDetalle().Where(x => x.AtributoId == 1).ToList();
            var resultAtributo2 = AtributoDService.ReadAtributoDetalle().Where(x => x.AtributoId == 2).ToList();
            var resultQRY = ResultadoService.ReadResultado().Where(x => x.ProductoId == resultado.ProductoId && x.FechaPrueba == resultado.FechaPrueba).ToList();
            //var resultQRY = ResultadoService.ReadResultado().ToList();

            if (resultQRY.Count > 0)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }    

            //if (resultado.ProductoId > 0)
            //{
            //    resultQRY.Where(x => x.ProductoId == resultado.ProductoId).ToList();
            //}

            //if (resultado.FechaPrueba != null)
            //{
            //    resultQRY.Where(x => x.FechaPrueba == resultado.FechaPrueba).ToList();
            //}

            if (resultQRY.Count > 0)
            {
                int number = -1;
                for (int i = 0; i < resultQRY.Count - 1; i++)
                {
                    if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-184-SCFI")
                    {
                        number = i;
                    }
                }

                if (number != -1)
                {
                    var resultLote = resultQRY[number].Lote;
                    List<Lote> listLote = new List<Lote>();
                    listLote.Add(resultLote);
                    //ResultadoDetalle
                    var resultDetalle = ResultadoDetalleService.ReadResultadoDetalle().Where(x => x.ResultadoId == resultQRY[0].Id).ToList();
                    //Producto
                    var resultProducto = ProductoService.ReadProducto().Where(x => x.Id == resultQRY[0].ProductoId).ToList();
                    var resultTurno = resultLote.Turno;
                    List<Turno> listTurno = new List<Turno>();
                    listTurno.Add(resultTurno);

                    BsdReportDataSource rds = new BsdReportDataSource("DsAgrietamiento", resultQRY);
                    BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
                    BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle);
                    BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
                    BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);
                    BsdReportDataSource rds6 = new BsdReportDataSource("DsAtributo1", resultAtributo);
                    BsdReportDataSource rds7 = new BsdReportDataSource("DsAtributo2", resultAtributo2);

                    //BsdReportParameter parameter = new BsdReportParameter("Test", "1", true);
                    


                    IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
                    ds.Add(rds);
                    ds.Add(rds2);
                    ds.Add(rds3);
                    ds.Add(rds4);
                    ds.Add(rds5);
                    ds.Add(rds6);
                    ds.Add(rds7);

                    

                    BsdReport report = new BsdReport("Reporte Agrietamiento", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
                    //report.Parameters.Add(parameter);
                    BsdReportResult result = ReportViewerService.CreateReport(report);

                    //FileStream fs = new FileStream(@"c:\Reportes\" + report.Name + "." + result.FileType, FileMode.OpenOrCreate);
                    //fs.Write(result.Content, 0, result.Content.Length);
                    //fs.Close();

                    return File(result.Content, result.MimeType);
                }
                else
                {
                    return View(GetModel(new Lote()));
                }
                                
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }            

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
                    where p.Activo == true
                    select new
                    {
                        id = p.Id,
                        cell = new string[] { p.Identificador, p.Producto.Codigo, p.FechaProduccion.ToShortDateString(), p.CantidadProducida.ToString(), p.Id.ToString() }
                    }).ToArray()

            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }      


        private RpteAgrietamientoViewModel GetModel(Lote lote)
        {
            return new RpteAgrietamientoViewModel(lote, ProductoService.ReadProducto());
        }
    }
}
