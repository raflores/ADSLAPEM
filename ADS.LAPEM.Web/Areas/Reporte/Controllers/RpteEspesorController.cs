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
    public class RpteEspesorController : BaseController
    {
        protected IEquipoService EquipoService { get; set; }
        protected IResultadoDetalleService ResultadoDetalleService { get; set; }
        protected IProductoService ProductoService { get; set; }
        protected ITurnoService TurnoService { get; set; }
        protected IResultadoService ResultadoService { get; set; }
        protected IReportViewerService ReportViewerService { get; set; }
        protected IAtributoDService AtributoDService { get; set; }
        protected ILoteService LoteService { get; set; }
        //
        // GET: /Reporte/RpteEspesor/

        public ActionResult Index()
        {
            return View(GetModel(new Lote()));
        }

        [HttpPost]
        public ActionResult GenerarRepo(Resultado resultado)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteEspesores.rdlc");

            string InteriorA = "", InteriorAC = "", InteriorC = "", InteriorCB = "", InteriorB = "", InteriorBD = "", InteriorD = "", InteriorDA = "";
            string CoronaA = "", CoronaAC = "", CoronaC = "", CoronaCB = "", CoronaB = "", CoronaBD = "", CoronaD = "", CoronaDA = "";
            string LateralAA = "", LateralAAC = "", LateralAC = "", LateralACB = "", LateralAB = "", LateralABD = "", LateralAD = "", LateralADA = "";
            string LateralBA = "", LateralBAC = "", LateralBC = "", LateralBCB = "", LateralBB = "", LateralBBD = "", LateralBD = "", LateralBDA = "";
            string DobleA = "", DobleAC = "", DobleC = "", DobleCB = "", DobleB = "", DobleBD = "", DobleD = "", DobleDA = "";

            //Resultado
            var resultQRY = ResultadoService.ReadResultado().Where(x => x.ProductoId == resultado.ProductoId && x.FechaPrueba == resultado.FechaPrueba).ToList();

            for (int i = 0; i < resultQRY.Count; i++)
            {
                if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                {
                    if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-021-CNCP")
                    {
                        if (resultQRY[i].EnsayoId == 1)
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                switch (resultDetalle[j].MuestraNum)
                                { 
                                    case 1:
                                        InteriorA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 2:
                                        InteriorAC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 3:
                                        InteriorC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 4:
                                        InteriorCB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 5:
                                        InteriorB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 6:
                                        InteriorBD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 7:
                                        InteriorD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 8:
                                        InteriorDA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                }
                            }
                        }

                        if (resultQRY[i].EnsayoId == 6)
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                switch (resultDetalle[j].MuestraNum)
                                {
                                    case 1:
                                        CoronaA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 2:
                                        CoronaAC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 3:
                                        CoronaC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 4:
                                        CoronaCB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 5:
                                        CoronaB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 6:
                                        CoronaBD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 7:
                                        CoronaD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 8:
                                        CoronaDA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                }
                            }
                        }

                        if (resultQRY[i].EnsayoId == 7)
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                switch (resultDetalle[j].MuestraNum)
                                {
                                    case 1:
                                        LateralAA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 2:
                                        LateralAAC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 3:
                                        LateralAC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 4:
                                        LateralACB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 5:
                                        LateralAB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 6:
                                        LateralABD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 7:
                                        LateralAD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 8:
                                        LateralADA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                }
                            }
                        }

                        if (resultQRY[i].EnsayoId == 8)
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                switch (resultDetalle[j].MuestraNum)
                                {
                                    case 1:
                                        LateralBA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 2:
                                        LateralBAC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 3:
                                        LateralBC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 4:
                                        LateralBCB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 5:
                                        LateralBB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 6:
                                        LateralBBD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 7:
                                        LateralBD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 8:
                                        LateralBDA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                }
                            }
                        }

                        if (resultQRY[i].EnsayoId == 9)
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                switch (resultDetalle[j].MuestraNum)
                                {
                                    case 1:
                                        DobleA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 2:
                                        DobleAC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 3:
                                        DobleC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 4:
                                        DobleCB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 5:
                                        DobleB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 6:
                                        DobleBD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 7:
                                        DobleD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 8:
                                        DobleDA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                }
                            }
                        }
                        

                        //for (int j = 0; j < resultDetalle.Count; j++)
                        //{
                        //    var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                        //    for (int ad = 0; ad < atributoDetalle.Count; ad++)
                        //    {
                        //        switch (atributoDetalle[ad].AtributoId)
                        //        {
                        //            case 107:
                        //                InteriorA = atributoDetalle[ad].Valor;                                        
                        //                break;
                        //            case 108:
                        //                InteriorAC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 109:
                        //                InteriorC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 110:
                        //                InteriorCB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 111:
                        //                InteriorB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 112:
                        //                InteriorBD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 113:
                        //                InteriorD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 114:
                        //                InteriorDA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 115:
                        //                CoronaA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 116:
                        //                CoronaAC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 117:
                        //                CoronaC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 118:
                        //                CoronaCB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 119:
                        //                CoronaB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 120:
                        //                CoronaBD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 121:
                        //                CoronaD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 122:
                        //                CoronaDA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 123:
                        //                LateralAA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 124:
                        //                LateralAAC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 125:
                        //                LateralAC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 126:
                        //                LateralACB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 127:
                        //                LateralAB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 128:
                        //                LateralABD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 129:
                        //                LateralAD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 130:
                        //                LateralADA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 131:
                        //                LateralBA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 132:
                        //                LateralBAC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 133:
                        //                LateralBC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 134:
                        //                LateralBCB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 135:
                        //                LateralBB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 136:
                        //                LateralBBD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 137:
                        //                LateralBD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 138:
                        //                LateralBDA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 139:
                        //                DobleA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 140:
                        //                DobleAC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 141:
                        //                DobleC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 142:
                        //                DobleCB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 143:
                        //                DobleB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 144:
                        //                DobleBD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 145:
                        //                DobleD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 146:
                        //                DobleDA = atributoDetalle[ad].Valor;
                        //                break;
                        //        }
                        //    }
                        //}
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
            var resultEquipo = EquipoService.ReadEquipo().Where(x => x.Id == resultQRY[0].EquipoId).ToList();
            var resultTurno = resultLote.Turno;
            List<Turno> listTurno = new List<Turno>();
            listTurno.Add(resultTurno);
            var resultNorma = resultQRY[0].Norma;
            List<Norma> listNorma = new List<Norma>();
            listNorma.Add(resultNorma);
            var resultDiametro = resultProducto[0].MedidaDiametro;
            List<MedidaDiametro> listDiametro = new List<MedidaDiametro>();
            listDiametro.Add(resultDiametro);
            List<Resultado> ListVacio = new List<Resultado>();
            List<Resultado> ListPresion = new List<Resultado>();
            List<Equipo> listEquipo = new List<Equipo>();

            BsdReportDataSource rds = new BsdReportDataSource("DsEspesores", resultQRY);
            BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
            BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle2);
            BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
            BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);
            BsdReportDataSource rds6 = new BsdReportDataSource("DsEquipo", resultEquipo);
            BsdReportDataSource rds7 = new BsdReportDataSource("DsNorma", listNorma);
            BsdReportDataSource rds8 = new BsdReportDataSource("DsMDiametro", listDiametro);
                        
            BsdReportParameter parameter1 = new BsdReportParameter("InteriorA", InteriorA, true);
            BsdReportParameter parameter2 = new BsdReportParameter("InteriorAC", InteriorAC, true);
            BsdReportParameter parameter3 = new BsdReportParameter("InteriorC", InteriorC, true);
            BsdReportParameter parameter4 = new BsdReportParameter("InteriorCB", InteriorCB, true);
            BsdReportParameter parameter5 = new BsdReportParameter("InteriorB", InteriorB, true);
            BsdReportParameter parameter6 = new BsdReportParameter("InteriorBD", InteriorBD, true);
            BsdReportParameter parameter7 = new BsdReportParameter("InteriorD", InteriorD, true);
            BsdReportParameter parameter8 = new BsdReportParameter("InteriorDA", InteriorDA, true);
            BsdReportParameter parameter9 = new BsdReportParameter("CoronaA", CoronaA, true);
            BsdReportParameter parameter10 = new BsdReportParameter("CoronaAC", CoronaAC, true);
            BsdReportParameter parameter11 = new BsdReportParameter("CoronaC", CoronaC, true);
            BsdReportParameter parameter12 = new BsdReportParameter("CoronaCB", CoronaCB, true);
            BsdReportParameter parameter13 = new BsdReportParameter("CoronaB", CoronaB, true);
            BsdReportParameter parameter14 = new BsdReportParameter("CoronaBD", CoronaBD, true);
            BsdReportParameter parameter15 = new BsdReportParameter("CoronaD", CoronaD, true);
            BsdReportParameter parameter16 = new BsdReportParameter("CoronaDA", CoronaDA, true);
            BsdReportParameter parameter17 = new BsdReportParameter("LateralAA", LateralAA, true);
            BsdReportParameter parameter18 = new BsdReportParameter("LateralAAC", LateralAAC, true);
            BsdReportParameter parameter19 = new BsdReportParameter("LateralAC", LateralAC, true);
            BsdReportParameter parameter20 = new BsdReportParameter("LateralACB", LateralACB, true);
            BsdReportParameter parameter21 = new BsdReportParameter("LateralAB", LateralAB, true);
            BsdReportParameter parameter22 = new BsdReportParameter("LateralABD", LateralABD, true);
            BsdReportParameter parameter23 = new BsdReportParameter("LateralAD", LateralAD, true);
            BsdReportParameter parameter24 = new BsdReportParameter("LateralADA", LateralADA, true);
            BsdReportParameter parameter25 = new BsdReportParameter("LateralBA", LateralBA, true);
            BsdReportParameter parameter26 = new BsdReportParameter("LateralBAC", LateralBAC, true);
            BsdReportParameter parameter27 = new BsdReportParameter("LateralBC", LateralBC, true);
            BsdReportParameter parameter28 = new BsdReportParameter("LateralBCB", LateralBCB, true);
            BsdReportParameter parameter29 = new BsdReportParameter("LateralBB", LateralBB, true);
            BsdReportParameter parameter30 = new BsdReportParameter("LateralBBD", LateralBBD, true);
            BsdReportParameter parameter31 = new BsdReportParameter("LateralBD", LateralBD, true);
            BsdReportParameter parameter32 = new BsdReportParameter("LateralBDA", LateralBDA, true);
            BsdReportParameter parameter33 = new BsdReportParameter("DobleA", DobleA, true);
            BsdReportParameter parameter34 = new BsdReportParameter("DobleAC", DobleAC, true);
            BsdReportParameter parameter35 = new BsdReportParameter("DobleC", DobleC, true);
            BsdReportParameter parameter36 = new BsdReportParameter("DobleCB", DobleCB, true);
            BsdReportParameter parameter37 = new BsdReportParameter("DobleB", DobleB, true);
            BsdReportParameter parameter38 = new BsdReportParameter("DobleBD", DobleBD, true);
            BsdReportParameter parameter39 = new BsdReportParameter("DobleD", DobleD, true);
            BsdReportParameter parameter40 = new BsdReportParameter("DobleDA", DobleDA, true);

            IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
            ds.Add(rds);
            ds.Add(rds2);
            ds.Add(rds3);
            ds.Add(rds4);
            ds.Add(rds5);
            ds.Add(rds6);
            ds.Add(rds7);
            ds.Add(rds8);

            BsdReport report = new BsdReport("Reporte de Espesores", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
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
            report.Parameters.Add(parameter18);
            report.Parameters.Add(parameter19);
            report.Parameters.Add(parameter20);
            report.Parameters.Add(parameter21);
            report.Parameters.Add(parameter22);
            report.Parameters.Add(parameter23);
            report.Parameters.Add(parameter24);
            report.Parameters.Add(parameter25);
            report.Parameters.Add(parameter26);
            report.Parameters.Add(parameter27);
            report.Parameters.Add(parameter28);
            report.Parameters.Add(parameter29);
            report.Parameters.Add(parameter30);
            report.Parameters.Add(parameter31);
            report.Parameters.Add(parameter32);
            report.Parameters.Add(parameter33);
            report.Parameters.Add(parameter34);
            report.Parameters.Add(parameter35);
            report.Parameters.Add(parameter36);
            report.Parameters.Add(parameter37);
            report.Parameters.Add(parameter38);
            report.Parameters.Add(parameter39);
            report.Parameters.Add(parameter40);

            BsdReportResult result = ReportViewerService.CreateReport(report);

            return File(result.Content, result.MimeType); 

            //if (resultQRY.Count > 0)
            //{
            //    //Lote
            //    var resultLote = resultQRY[0].Lote;
            //    List<Lote> listLote = new List<Lote>();
            //    listLote.Add(resultLote);
            //    //ResultadoDetalle
            //    var resultDetalle = ResultadoDetalleService.ReadResultadoDetalle().Where(x => x.ResultadoId == resultQRY[0].Id).ToList();
            //    //Producto
            //    var resultProducto = ProductoService.ReadProducto().Where(x => x.Id == resultQRY[0].ProductoId).ToList();
            //    var resultEquipo = EquipoService.ReadEquipo().Where(x => x.Id == resultQRY[0].EquipoId).ToList();
            //    var resultTurno = resultLote.Turno;
            //    List<Turno> listTurno = new List<Turno>();
            //    listTurno.Add(resultTurno);
            //    var resultNorma = resultQRY[0].Norma;
            //    List<Norma> listNorma = new List<Norma>();
            //    listNorma.Add(resultNorma);
            //    var resultDiametro = resultProducto[0].MedidaDiametro;
            //    List<MedidaDiametro> listDiametro = new List<MedidaDiametro>();
            //    listDiametro.Add(resultDiametro);

            //    BsdReportDataSource rds = new BsdReportDataSource("DsEspesores", resultQRY);
            //    BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
            //    BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle);
            //    BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
            //    BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);
            //    BsdReportDataSource rds6 = new BsdReportDataSource("DsEquipo", resultEquipo);
            //    BsdReportDataSource rds7 = new BsdReportDataSource("DsNorma", listNorma);
            //    BsdReportDataSource rds8 = new BsdReportDataSource("DsMDiametro", listDiametro);

            //    IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
            //    ds.Add(rds);
            //    ds.Add(rds2);
            //    ds.Add(rds3);
            //    ds.Add(rds4);
            //    ds.Add(rds5);
            //    ds.Add(rds6);
            //    ds.Add(rds7);
            //    ds.Add(rds8);

            //    BsdReport report = new BsdReport("Reporte de Espesores", path, BsdReportFormat.PDF, ds, BsdReportType.Local);

            //    BsdReportResult result = ReportViewerService.CreateReport(report);

            //    FileStream fs = new FileStream(@"c:\Reportes\" + report.Name + "." + result.FileType, FileMode.OpenOrCreate);
            //    fs.Write(result.Content, 0, result.Content.Length);
            //    fs.Close();

            //    return File(result.Content, result.MimeType);
            //}
            //else
            //{
            //    return View(GetModel(new Resultado()));
            //}
        }

        [HttpGet]
        public ActionResult Generar(long id)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteEspesores.rdlc");

            string InteriorA = "", InteriorAC = "", InteriorC = "", InteriorCB = "", InteriorB = "", InteriorBD = "", InteriorD = "", InteriorDA = "";
            string CoronaA = "", CoronaAC = "", CoronaC = "", CoronaCB = "", CoronaB = "", CoronaBD = "", CoronaD = "", CoronaDA = "";
            string LateralAA = "", LateralAAC = "", LateralAC = "", LateralACB = "", LateralAB = "", LateralABD = "", LateralAD = "", LateralADA = "";
            string LateralBA = "", LateralBAC = "", LateralBC = "", LateralBCB = "", LateralBB = "", LateralBBD = "", LateralBD = "", LateralBDA = "";
            string DobleA = "", DobleAC = "", DobleC = "", DobleCB = "", DobleB = "", DobleBD = "", DobleD = "", DobleDA = "";

            //Resultado
            var resultQRY = ResultadoService.ReadResultadoByLote(id).ToList();

            for (int i = 0; i < resultQRY.Count; i++)
            {
                if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                {
                    if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-021-CNCP")
                    {
                        if (resultQRY[i].EnsayoId == 1)
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                switch (resultDetalle[j].MuestraNum)
                                {
                                    case 1:
                                        InteriorA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 2:
                                        InteriorAC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 3:
                                        InteriorC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 4:
                                        InteriorCB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 5:
                                        InteriorB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 6:
                                        InteriorBD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 7:
                                        InteriorD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 8:
                                        InteriorDA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                }
                            }
                        }

                        if (resultQRY[i].EnsayoId == 6)
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                switch (resultDetalle[j].MuestraNum)
                                {
                                    case 1:
                                        CoronaA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 2:
                                        CoronaAC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 3:
                                        CoronaC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 4:
                                        CoronaCB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 5:
                                        CoronaB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 6:
                                        CoronaBD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 7:
                                        CoronaD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 8:
                                        CoronaDA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                }
                            }
                        }

                        if (resultQRY[i].EnsayoId == 7)
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                switch (resultDetalle[j].MuestraNum)
                                {
                                    case 1:
                                        LateralAA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 2:
                                        LateralAAC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 3:
                                        LateralAC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 4:
                                        LateralACB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 5:
                                        LateralAB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 6:
                                        LateralABD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 7:
                                        LateralAD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 8:
                                        LateralADA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                }
                            }
                        }

                        if (resultQRY[i].EnsayoId == 8)
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                switch (resultDetalle[j].MuestraNum)
                                {
                                    case 1:
                                        LateralBA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 2:
                                        LateralBAC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 3:
                                        LateralBC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 4:
                                        LateralBCB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 5:
                                        LateralBB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 6:
                                        LateralBBD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 7:
                                        LateralBD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 8:
                                        LateralBDA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                }
                            }
                        }

                        if (resultQRY[i].EnsayoId == 9)
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                switch (resultDetalle[j].MuestraNum)
                                {
                                    case 1:
                                        DobleA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 2:
                                        DobleAC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 3:
                                        DobleC = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 4:
                                        DobleCB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 5:
                                        DobleB = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 6:
                                        DobleBD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 7:
                                        DobleD = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 8:
                                        DobleDA = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                }
                            }
                        }


                        //for (int j = 0; j < resultDetalle.Count; j++)
                        //{
                        //    var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                        //    for (int ad = 0; ad < atributoDetalle.Count; ad++)
                        //    {
                        //        switch (atributoDetalle[ad].AtributoId)
                        //        {
                        //            case 107:
                        //                InteriorA = atributoDetalle[ad].Valor;                                        
                        //                break;
                        //            case 108:
                        //                InteriorAC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 109:
                        //                InteriorC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 110:
                        //                InteriorCB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 111:
                        //                InteriorB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 112:
                        //                InteriorBD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 113:
                        //                InteriorD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 114:
                        //                InteriorDA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 115:
                        //                CoronaA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 116:
                        //                CoronaAC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 117:
                        //                CoronaC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 118:
                        //                CoronaCB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 119:
                        //                CoronaB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 120:
                        //                CoronaBD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 121:
                        //                CoronaD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 122:
                        //                CoronaDA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 123:
                        //                LateralAA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 124:
                        //                LateralAAC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 125:
                        //                LateralAC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 126:
                        //                LateralACB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 127:
                        //                LateralAB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 128:
                        //                LateralABD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 129:
                        //                LateralAD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 130:
                        //                LateralADA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 131:
                        //                LateralBA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 132:
                        //                LateralBAC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 133:
                        //                LateralBC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 134:
                        //                LateralBCB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 135:
                        //                LateralBB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 136:
                        //                LateralBBD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 137:
                        //                LateralBD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 138:
                        //                LateralBDA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 139:
                        //                DobleA = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 140:
                        //                DobleAC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 141:
                        //                DobleC = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 142:
                        //                DobleCB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 143:
                        //                DobleB = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 144:
                        //                DobleBD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 145:
                        //                DobleD = atributoDetalle[ad].Valor;
                        //                break;
                        //            case 146:
                        //                DobleDA = atributoDetalle[ad].Valor;
                        //                break;
                        //        }
                        //    }
                        //}
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
            var resultEquipo = EquipoService.ReadEquipo().Where(x => x.Id == resultQRY[0].EquipoId).ToList();
            var resultTurno = resultLote.Turno;
            List<Turno> listTurno = new List<Turno>();
            listTurno.Add(resultTurno);
            var resultNorma = resultQRY[0].Norma;
            List<Norma> listNorma = new List<Norma>();
            listNorma.Add(resultNorma);
            var resultDiametro = resultProducto[0].MedidaDiametro;
            List<MedidaDiametro> listDiametro = new List<MedidaDiametro>();
            listDiametro.Add(resultDiametro);
            List<Resultado> ListVacio = new List<Resultado>();
            List<Resultado> ListPresion = new List<Resultado>();
            List<Equipo> listEquipo = new List<Equipo>();

            BsdReportDataSource rds = new BsdReportDataSource("DsEspesores", resultQRY);
            BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
            BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle2);
            BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
            BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);
            BsdReportDataSource rds6 = new BsdReportDataSource("DsEquipo", resultEquipo);
            BsdReportDataSource rds7 = new BsdReportDataSource("DsNorma", listNorma);
            BsdReportDataSource rds8 = new BsdReportDataSource("DsMDiametro", listDiametro);

            BsdReportParameter parameter1 = new BsdReportParameter("InteriorA", InteriorA, true);
            BsdReportParameter parameter2 = new BsdReportParameter("InteriorAC", InteriorAC, true);
            BsdReportParameter parameter3 = new BsdReportParameter("InteriorC", InteriorC, true);
            BsdReportParameter parameter4 = new BsdReportParameter("InteriorCB", InteriorCB, true);
            BsdReportParameter parameter5 = new BsdReportParameter("InteriorB", InteriorB, true);
            BsdReportParameter parameter6 = new BsdReportParameter("InteriorBD", InteriorBD, true);
            BsdReportParameter parameter7 = new BsdReportParameter("InteriorD", InteriorD, true);
            BsdReportParameter parameter8 = new BsdReportParameter("InteriorDA", InteriorDA, true);
            BsdReportParameter parameter9 = new BsdReportParameter("CoronaA", CoronaA, true);
            BsdReportParameter parameter10 = new BsdReportParameter("CoronaAC", CoronaAC, true);
            BsdReportParameter parameter11 = new BsdReportParameter("CoronaC", CoronaC, true);
            BsdReportParameter parameter12 = new BsdReportParameter("CoronaCB", CoronaCB, true);
            BsdReportParameter parameter13 = new BsdReportParameter("CoronaB", CoronaB, true);
            BsdReportParameter parameter14 = new BsdReportParameter("CoronaBD", CoronaBD, true);
            BsdReportParameter parameter15 = new BsdReportParameter("CoronaD", CoronaD, true);
            BsdReportParameter parameter16 = new BsdReportParameter("CoronaDA", CoronaDA, true);
            BsdReportParameter parameter17 = new BsdReportParameter("LateralAA", LateralAA, true);
            BsdReportParameter parameter18 = new BsdReportParameter("LateralAAC", LateralAAC, true);
            BsdReportParameter parameter19 = new BsdReportParameter("LateralAC", LateralAC, true);
            BsdReportParameter parameter20 = new BsdReportParameter("LateralACB", LateralACB, true);
            BsdReportParameter parameter21 = new BsdReportParameter("LateralAB", LateralAB, true);
            BsdReportParameter parameter22 = new BsdReportParameter("LateralABD", LateralABD, true);
            BsdReportParameter parameter23 = new BsdReportParameter("LateralAD", LateralAD, true);
            BsdReportParameter parameter24 = new BsdReportParameter("LateralADA", LateralADA, true);
            BsdReportParameter parameter25 = new BsdReportParameter("LateralBA", LateralBA, true);
            BsdReportParameter parameter26 = new BsdReportParameter("LateralBAC", LateralBAC, true);
            BsdReportParameter parameter27 = new BsdReportParameter("LateralBC", LateralBC, true);
            BsdReportParameter parameter28 = new BsdReportParameter("LateralBCB", LateralBCB, true);
            BsdReportParameter parameter29 = new BsdReportParameter("LateralBB", LateralBB, true);
            BsdReportParameter parameter30 = new BsdReportParameter("LateralBBD", LateralBBD, true);
            BsdReportParameter parameter31 = new BsdReportParameter("LateralBD", LateralBD, true);
            BsdReportParameter parameter32 = new BsdReportParameter("LateralBDA", LateralBDA, true);
            BsdReportParameter parameter33 = new BsdReportParameter("DobleA", DobleA, true);
            BsdReportParameter parameter34 = new BsdReportParameter("DobleAC", DobleAC, true);
            BsdReportParameter parameter35 = new BsdReportParameter("DobleC", DobleC, true);
            BsdReportParameter parameter36 = new BsdReportParameter("DobleCB", DobleCB, true);
            BsdReportParameter parameter37 = new BsdReportParameter("DobleB", DobleB, true);
            BsdReportParameter parameter38 = new BsdReportParameter("DobleBD", DobleBD, true);
            BsdReportParameter parameter39 = new BsdReportParameter("DobleD", DobleD, true);
            BsdReportParameter parameter40 = new BsdReportParameter("DobleDA", DobleDA, true);

            IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
            ds.Add(rds);
            ds.Add(rds2);
            ds.Add(rds3);
            ds.Add(rds4);
            ds.Add(rds5);
            ds.Add(rds6);
            ds.Add(rds7);
            ds.Add(rds8);

            BsdReport report = new BsdReport("Reporte de Espesores", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
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
            report.Parameters.Add(parameter18);
            report.Parameters.Add(parameter19);
            report.Parameters.Add(parameter20);
            report.Parameters.Add(parameter21);
            report.Parameters.Add(parameter22);
            report.Parameters.Add(parameter23);
            report.Parameters.Add(parameter24);
            report.Parameters.Add(parameter25);
            report.Parameters.Add(parameter26);
            report.Parameters.Add(parameter27);
            report.Parameters.Add(parameter28);
            report.Parameters.Add(parameter29);
            report.Parameters.Add(parameter30);
            report.Parameters.Add(parameter31);
            report.Parameters.Add(parameter32);
            report.Parameters.Add(parameter33);
            report.Parameters.Add(parameter34);
            report.Parameters.Add(parameter35);
            report.Parameters.Add(parameter36);
            report.Parameters.Add(parameter37);
            report.Parameters.Add(parameter38);
            report.Parameters.Add(parameter39);
            report.Parameters.Add(parameter40);

            BsdReportResult result = ReportViewerService.CreateReport(report);

            return File(result.Content, result.MimeType); 
        }


        [HttpPost]
        public ActionResult GenerarReporte(Resultado resultado)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteEspesores.rdlc");

            //Resultado
            var resultQRY = ResultadoService.ReadResultado().Where(x => x.ProductoId == resultado.ProductoId && x.FechaPrueba == resultado.FechaPrueba).ToList();

            if (resultQRY.Count > 0)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
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

        private RpteEspesorViewModel GetModel(Lote lote)
        {
            return new RpteEspesorViewModel(lote, ProductoService.ReadProducto());
        }

    }
}
