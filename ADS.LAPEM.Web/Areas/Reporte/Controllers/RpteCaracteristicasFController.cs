using System;
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
using System.IO;
using ADS.LAPEM.Web.Infrastructure.Grid;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Web.Areas.Reporte.Controllers
{
    public class RpteCaracteristicasFController : BaseController
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
        // GET: /Reporte/RpteCaracteristicasF/

        public ActionResult Index()
        {
            return View(GetModel(new Lote()));
        }

        [HttpPost]
        public ActionResult GenerarRepo(Resultado resultado)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteCaracteristicasF.rdlc");
            decimal atributo1 = 0, atributo2 = 0, atributo3 = 0, atributo4 = 0, atributo5 = 0, atributo6 = 0, atributo7 = 0, atributo8 = 0,
            atributo9 = 0, atributo10 = 0, atributo11 = 0, atributo12 = 0, atributo13 = 0, atributo14 = 0, atributo15 = 0,
            atributo16 = 0, atributo17 = 0, atributo18 = 0, atributo19 = 0, atributo20 = 0, atributo21 = 0, atributo22 = 0, atributo23 = 0,
            atributo24 = 0, atributo25 = 0, atributo26 = 0, atributo27 = 0, atributo28 = 0, atributo29 = 0, atributo30 = 0, atributo31 = 0,
            atributo32 = 0, atributo33 = 0, atributo34 = 0, atributo35 = 0;
            decimal resultado1 = 0, resultado2 = 0, resultado3 = 0, resultado4 = 0, resultado5 = 0, resultado6 = 0;
            string noTubo = "0", Foto1 = "", Foto2 = "", Foto3 = "";

            //Resultado
            var resultQRY = ResultadoService.ReadResultado().Where(x => x.ProductoId == resultado.ProductoId && x.FechaPrueba == resultado.FechaPrueba).ToList();

            if (resultQRY.Count > 0)
            {
                for (int i = 0; i < resultQRY.Count; i++)
                {
                    if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                    {
                        if (resultQRY[i].NormaEnsayo.Nombre == "ASTM D 4218")
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                                for (int ad = 0; ad < atributoDetalle.Count; ad++)
                                {
                                    switch (atributoDetalle[ad].AtributoId)
                                    {
                                        case 19:
                                            atributo1 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 20:
                                            atributo2 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 21:
                                            atributo3 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 22:
                                            atributo4 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 23:
                                            atributo5 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 24:
                                            atributo6 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 25:
                                            atributo7 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 26:
                                            atributo8 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 27:
                                            atributo9 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 28:
                                            atributo10 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 29:
                                            atributo11 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 30:
                                            atributo12 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 31:
                                            atributo13 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 32:
                                            atributo14 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 33:
                                            atributo15 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 34:
                                            atributo16 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 35:
                                            atributo17 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 36:
                                            atributo18 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 37:
                                            atributo19 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 38:
                                            atributo20 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 39:
                                            atributo21 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 40:
                                            atributo22 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 41:
                                            atributo23 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 42:
                                            atributo24 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 43:
                                            atributo25 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 44:
                                            atributo26 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 45:
                                            atributo27 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 46:
                                            atributo28 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 47:
                                            atributo29 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 48:
                                            atributo30 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 49:
                                            atributo31 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 50:
                                            atributo32 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 51:
                                            atributo33 = decimal.Parse(atributoDetalle[ad].Valor);
                                            Foto1 = atributoDetalle[ad].Valor;
                                            break;
                                        case 52:
                                            atributo34 = decimal.Parse(atributoDetalle[ad].Valor);
                                            Foto2 = atributoDetalle[ad].Valor;
                                            break;
                                        case 53:
                                            atributo35 = decimal.Parse(atributoDetalle[ad].Valor);
                                            Foto3 = atributoDetalle[ad].Valor;
                                            break;
                                        case 156:
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

                BsdReportDataSource rds = new BsdReportDataSource("DsCaracteristica", resultQRY);
                BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
                BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle2);
                BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
                BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);
                BsdReportDataSource rds6 = new BsdReportDataSource("DsEquipo", resultEquipo);
                BsdReportDataSource rds7 = new BsdReportDataSource("DsNorma", listNorma);
                BsdReportDataSource rds8 = new BsdReportDataSource("DsMDiametro", listDiametro);
                BsdReportDataSource rds9 = new BsdReportDataSource("DsVacio", ListVacio);
                BsdReportDataSource rds10 = new BsdReportDataSource("DsPresion", ListPresion);

                BsdReportParameter parameter1 = new BsdReportParameter("IndiceFluidez1", atributo1.ToString(), true);
                BsdReportParameter parameter2 = new BsdReportParameter("IndiceFluidez2", atributo2.ToString(), true);
                BsdReportParameter parameter3 = new BsdReportParameter("Densidad1", atributo3.ToString(), true);
                BsdReportParameter parameter4 = new BsdReportParameter("Densidad2", atributo4.ToString(), true);
                BsdReportParameter parameter5 = new BsdReportParameter("Pigmento1", atributo5.ToString(), true);
                BsdReportParameter parameter6 = new BsdReportParameter("Pigmento2", atributo6.ToString(), true);
                BsdReportParameter parameter7 = new BsdReportParameter("Resina1", atributo7.ToString(), true);
                BsdReportParameter parameter8 = new BsdReportParameter("Resina2", atributo8.ToString(), true);
                BsdReportParameter parameter9 = new BsdReportParameter("M11", atributo9.ToString(), true);
                BsdReportParameter parameter10 = new BsdReportParameter("M12", atributo10.ToString(), true);
                BsdReportParameter parameter11 = new BsdReportParameter("M13", atributo11.ToString(), true);
                BsdReportParameter parameter12 = new BsdReportParameter("M14", atributo12.ToString(), true);
                BsdReportParameter parameter13 = new BsdReportParameter("M15", atributo13.ToString(), true);
                BsdReportParameter parameter14 = new BsdReportParameter("M16", atributo14.ToString(), true);
                BsdReportParameter parameter15 = new BsdReportParameter("M21", atributo15.ToString(), true);
                BsdReportParameter parameter16 = new BsdReportParameter("M22", atributo16.ToString(), true);
                BsdReportParameter parameter17 = new BsdReportParameter("M23", atributo17.ToString(), true);
                BsdReportParameter parameter18 = new BsdReportParameter("M24", atributo18.ToString(), true);
                BsdReportParameter parameter19 = new BsdReportParameter("M25", atributo19.ToString(), true);
                BsdReportParameter parameter20 = new BsdReportParameter("M26", atributo20.ToString(), true);
                BsdReportParameter parameter21 = new BsdReportParameter("M31", atributo21.ToString(), true);
                BsdReportParameter parameter22 = new BsdReportParameter("M32", atributo22.ToString(), true);
                BsdReportParameter parameter23 = new BsdReportParameter("M33", atributo23.ToString(), true);
                BsdReportParameter parameter24 = new BsdReportParameter("M34", atributo24.ToString(), true);
                BsdReportParameter parameter25 = new BsdReportParameter("M35", atributo25.ToString(), true);
                BsdReportParameter parameter26 = new BsdReportParameter("M36", atributo26.ToString(), true);
                BsdReportParameter parameter27 = new BsdReportParameter("M41", atributo27.ToString(), true);
                BsdReportParameter parameter28 = new BsdReportParameter("M42", atributo28.ToString(), true);
                BsdReportParameter parameter29 = new BsdReportParameter("M43", atributo29.ToString(), true);
                BsdReportParameter parameter30 = new BsdReportParameter("M44", atributo30.ToString(), true);
                BsdReportParameter parameter31 = new BsdReportParameter("M45", atributo31.ToString(), true);
                BsdReportParameter parameter32 = new BsdReportParameter("M46", atributo32.ToString(), true);
                BsdReportParameter parameter33 = new BsdReportParameter("M44", atributo33.ToString(), true);
                BsdReportParameter parameter34 = new BsdReportParameter("M44", atributo34.ToString(), true);
                BsdReportParameter parameter35 = new BsdReportParameter("M44", atributo35.ToString(), true);
                BsdReportParameter parameter36 = new BsdReportParameter("NoTubo", noTubo, true);
                BsdReportParameter parameter37 = new BsdReportParameter("Foto1", Foto1, true);
                BsdReportParameter parameter38 = new BsdReportParameter("Foto2", Foto2, true);
                BsdReportParameter parameter39 = new BsdReportParameter("Foto3", Foto3, true);


                IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
                ds.Add(rds);
                ds.Add(rds2);
                ds.Add(rds3);
                ds.Add(rds4);
                ds.Add(rds5);
                ds.Add(rds6);
                ds.Add(rds7);
                ds.Add(rds8);
                ds.Add(rds9);
                ds.Add(rds10);

                BsdReport report = new BsdReport("Reporte de Caracteristicas", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
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

        [HttpGet]
        public ActionResult Generar(long id)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteCaracteristicasF.rdlc");

            decimal atributo1 = 0, atributo2 = 0, atributo3 = 0, atributo4 = 0, atributo5 = 0, atributo6 = 0, atributo7 = 0, atributo8 = 0,
            atributo9 = 0, atributo10 = 0, atributo11 = 0, atributo12 = 0, atributo13 = 0, atributo14 = 0, atributo15 = 0,
            atributo16 = 0, atributo17 = 0, atributo18 = 0, atributo19 = 0, atributo20 = 0, atributo21 = 0, atributo22 = 0, atributo23 = 0,
            atributo24 = 0, atributo25 = 0, atributo26 = 0, atributo27 = 0, atributo28 = 0, atributo29 = 0, atributo30 = 0, atributo31 = 0,
            atributo32 = 0, atributo33 = 0, atributo34 = 0, atributo35 = 0;
            decimal resultado1 = 0, resultado2 = 0, resultado3 = 0, resultado4 = 0, resultado5 = 0, resultado6 = 0;
            string noTubo = "0", Foto1 = "", Foto2 = "", Foto3 = "";

            var resultQRY = ResultadoService.ReadResultadoByLote(id).ToList();

            if (resultQRY.Count > 0)
            {
                for (int i = 0; i < resultQRY.Count; i++)
                {
                    if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                    {
                        if (resultQRY[i].NormaEnsayo.Nombre == "ASTM D 4218")
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                                for (int ad = 0; ad < atributoDetalle.Count; ad++)
                                {
                                    switch (atributoDetalle[ad].AtributoId)
                                    {
                                        case 19:
                                            atributo1 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 20:
                                            atributo2 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 21:
                                            atributo3 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 22:
                                            atributo4 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 23:
                                            atributo5 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 24:
                                            atributo6 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 25:
                                            atributo7 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 26:
                                            atributo8 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 27:
                                            atributo9 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 28:
                                            atributo10 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 29:
                                            atributo11 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 30:
                                            atributo12 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 31:
                                            atributo13 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 32:
                                            atributo14 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 33:
                                            atributo15 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 34:
                                            atributo16 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 35:
                                            atributo17 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 36:
                                            atributo18 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 37:
                                            atributo19 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 38:
                                            atributo20 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 39:
                                            atributo21 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 40:
                                            atributo22 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 41:
                                            atributo23 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 42:
                                            atributo24 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 43:
                                            atributo25 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 44:
                                            atributo26 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 45:
                                            atributo27 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 46:
                                            atributo28 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 47:
                                            atributo29 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 48:
                                            atributo30 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 49:
                                            atributo31 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 50:
                                            atributo32 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 51:
                                            atributo33 = decimal.Parse(atributoDetalle[ad].Valor);
                                            Foto1 = atributoDetalle[ad].Valor;
                                            break;
                                        case 52:
                                            atributo34 = decimal.Parse(atributoDetalle[ad].Valor);
                                            Foto2 = atributoDetalle[ad].Valor;
                                            break;
                                        case 53:
                                            atributo35 = decimal.Parse(atributoDetalle[ad].Valor);
                                            Foto3 = atributoDetalle[ad].Valor;
                                            break;
                                        case 156:
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

                BsdReportDataSource rds = new BsdReportDataSource("DsCaracteristica", resultQRY);
                BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
                BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle2);
                BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
                BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);
                BsdReportDataSource rds6 = new BsdReportDataSource("DsEquipo", resultEquipo);
                BsdReportDataSource rds7 = new BsdReportDataSource("DsNorma", listNorma);
                BsdReportDataSource rds8 = new BsdReportDataSource("DsMDiametro", listDiametro);
                BsdReportDataSource rds9 = new BsdReportDataSource("DsVacio", ListVacio);
                BsdReportDataSource rds10 = new BsdReportDataSource("DsPresion", ListPresion);

                BsdReportParameter parameter1 = new BsdReportParameter("IndiceFluidez1", atributo1.ToString(), true);
                BsdReportParameter parameter2 = new BsdReportParameter("IndiceFluidez2", atributo2.ToString(), true);
                BsdReportParameter parameter3 = new BsdReportParameter("Densidad1", atributo3.ToString(), true);
                BsdReportParameter parameter4 = new BsdReportParameter("Densidad2", atributo4.ToString(), true);
                BsdReportParameter parameter5 = new BsdReportParameter("Pigmento1", atributo5.ToString(), true);
                BsdReportParameter parameter6 = new BsdReportParameter("Pigmento2", atributo6.ToString(), true);
                BsdReportParameter parameter7 = new BsdReportParameter("Resina1", atributo7.ToString(), true);
                BsdReportParameter parameter8 = new BsdReportParameter("Resina2", atributo8.ToString(), true);
                BsdReportParameter parameter9 = new BsdReportParameter("M11", atributo9.ToString(), true);
                BsdReportParameter parameter10 = new BsdReportParameter("M12", atributo10.ToString(), true);
                BsdReportParameter parameter11 = new BsdReportParameter("M13", atributo11.ToString(), true);
                BsdReportParameter parameter12 = new BsdReportParameter("M14", atributo12.ToString(), true);
                BsdReportParameter parameter13 = new BsdReportParameter("M15", atributo13.ToString(), true);
                BsdReportParameter parameter14 = new BsdReportParameter("M16", atributo14.ToString(), true);
                BsdReportParameter parameter15 = new BsdReportParameter("M21", atributo15.ToString(), true);
                BsdReportParameter parameter16 = new BsdReportParameter("M22", atributo16.ToString(), true);
                BsdReportParameter parameter17 = new BsdReportParameter("M23", atributo17.ToString(), true);
                BsdReportParameter parameter18 = new BsdReportParameter("M24", atributo18.ToString(), true);
                BsdReportParameter parameter19 = new BsdReportParameter("M25", atributo19.ToString(), true);
                BsdReportParameter parameter20 = new BsdReportParameter("M26", atributo20.ToString(), true);
                BsdReportParameter parameter21 = new BsdReportParameter("M31", atributo21.ToString(), true);
                BsdReportParameter parameter22 = new BsdReportParameter("M32", atributo22.ToString(), true);
                BsdReportParameter parameter23 = new BsdReportParameter("M33", atributo23.ToString(), true);
                BsdReportParameter parameter24 = new BsdReportParameter("M34", atributo24.ToString(), true);
                BsdReportParameter parameter25 = new BsdReportParameter("M35", atributo25.ToString(), true);
                BsdReportParameter parameter26 = new BsdReportParameter("M36", atributo26.ToString(), true);
                BsdReportParameter parameter27 = new BsdReportParameter("M41", atributo27.ToString(), true);
                BsdReportParameter parameter28 = new BsdReportParameter("M42", atributo28.ToString(), true);
                BsdReportParameter parameter29 = new BsdReportParameter("M43", atributo29.ToString(), true);
                BsdReportParameter parameter30 = new BsdReportParameter("M44", atributo30.ToString(), true);
                BsdReportParameter parameter31 = new BsdReportParameter("M45", atributo31.ToString(), true);
                BsdReportParameter parameter32 = new BsdReportParameter("M46", atributo32.ToString(), true);
                BsdReportParameter parameter33 = new BsdReportParameter("M44", atributo33.ToString(), true);
                BsdReportParameter parameter34 = new BsdReportParameter("M44", atributo34.ToString(), true);
                BsdReportParameter parameter35 = new BsdReportParameter("M44", atributo35.ToString(), true);
                BsdReportParameter parameter36 = new BsdReportParameter("NoTubo", noTubo, true);
                BsdReportParameter parameter37 = new BsdReportParameter("Foto1", Foto1, true);
                BsdReportParameter parameter38 = new BsdReportParameter("Foto2", Foto2, true);
                BsdReportParameter parameter39 = new BsdReportParameter("Foto3", Foto3, true);


                IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
                ds.Add(rds);
                ds.Add(rds2);
                ds.Add(rds3);
                ds.Add(rds4);
                ds.Add(rds5);
                ds.Add(rds6);
                ds.Add(rds7);
                ds.Add(rds8);
                ds.Add(rds9);
                ds.Add(rds10);

                BsdReport report = new BsdReport("Reporte de Caracteristicas", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
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

        [HttpPost]
        public ActionResult GenerarReporte(Resultado resultado)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteCaracteristicasF.rdlc");

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

        private RpteCaracteristicasFViewModel GetModel(Lote lote)
        {
            return new RpteCaracteristicasFViewModel(lote, ProductoService.ReadProducto());
        }

    }
}
