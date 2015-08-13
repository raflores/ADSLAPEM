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

namespace ADS.LAPEM.Web.Areas.Reporte.Controllers
{
    public class RpteDimensionalController : BaseController
    {
        protected IEquipoService EquipoService { get; set; }
        protected IResultadoDetalleService ResultadoDetalleService { get; set; }
        protected IProductoService ProductoService { get; set; }
        protected ITurnoService TurnoService { get; set; }
        protected IResultadoService ResultadoService { get; set; }
        protected IReportViewerService ReportViewerService { get; set; }
        //
        // GET: /Reporte/RpteDimensional/

        public ActionResult Index()
        {
            return View(GetModel(new Resultado()));
        }

        [HttpPost]
        public ActionResult GenerarRepo(Resultado resultado)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteDimensional.rdlc");
            decimal InteriorTubo = 0, ExteriorTubo = 0, ExteriorEspiga = 0, InteriorCampana = 0, ExteriorCampana = 0, UtilTubo = 0, Campana = 0;
            List<ResultadoDetalle> listParedInt = new List<ResultadoDetalle>();
            List<ResultadoDetalle> listDiamExt = new List<ResultadoDetalle>();
            List<ResultadoDetalle> listMiniEspiga = new List<ResultadoDetalle>();
            List<ResultadoDetalle> listIntCampana = new List<ResultadoDetalle>();
            List<ResultadoDetalle> listExtCampana = new List<ResultadoDetalle>();
            List<ResultadoDetalle> listUtilTubo = new List<ResultadoDetalle>();
            List<ResultadoDetalle> listLongCamp = new List<ResultadoDetalle>();
            List<Norma> listNorma = new List<Norma>();
            List<MedidaDiametro> listMD = new List<MedidaDiametro>();

            //Resultado
            var resultQRY = ResultadoService.ReadResultado().Where(x => x.ProductoId == resultado.ProductoId && x.FechaPrueba == resultado.FechaPrueba).ToList();

            if (resultQRY.Count > 0)
            {
                for (int i = 0; i < resultQRY.Count - 1; i++)
                {
                    if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                    {
                        listNorma.Add(resultQRY[i].Norma);
                        if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-021-CNCP")
                        {
                            if (resultQRY[i].Ensayo.Nombre == "Pared Interior")
                            {
                                var resultParedInterior = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id);
                                listParedInt = resultParedInterior.ToList();

                                for (int j = 0; j <= 14; j++)
                                {
                                    if (listParedInt.Count != 14)
                                    {
                                        ResultadoDetalle r = new ResultadoDetalle();
                                        listParedInt.Add(r);
                                    }
                                }
                            }

                            if (resultQRY[i].Ensayo.Nombre == "Diametro Exterior")
                            {
                                var resultDiamExterior = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id);
                                listDiamExt = resultDiamExterior.ToList();
                            }

                            if (resultQRY[i].Ensayo.Nombre == "Diametro exterior de espiga o mini espiga")
                            {
                                var resultMiniEspiga = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id);
                                listMiniEspiga = resultMiniEspiga.ToList();
                            }

                            if (resultQRY[i].Ensayo.Nombre == "Diametro Interior de campana")
                            {
                                var resultIntCampana = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id);
                                listIntCampana = resultIntCampana.ToList();
                            }

                            if (resultQRY[i].Ensayo.Nombre == "Diametro Exterior Campana")
                            {
                                var resultExtCampana = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id);
                                listExtCampana = resultExtCampana.ToList();
                            }

                            if (resultQRY[i].Ensayo.Nombre == "Longitud Util Tubo")
                            {
                                var resultUtilTubo = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id);
                                listUtilTubo = resultUtilTubo.ToList();
                            }

                            if (resultQRY[i].Ensayo.Nombre == "Longitud Campana")
                            {
                                var resultLongCampana = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id);
                                listLongCamp = resultLongCampana.ToList();
                            }

                        }
                    }
                    //if (resultQRY[i].Ensayo.Nombre == "Diametro Interior")
                    //{
                    //    InteriorTubo = resultQRY[i].ResultadoValor;
                    //}

                    //if (resultQRY[i].Ensayo.Nombre == "Diametro exterior de espiga o mini espiga")
                    //{
                    //    ExteriorEspiga = resultQRY[i].ResultadoValor;
                    //    ExteriorTubo = resultQRY[i].ResultadoValor;
                    //}

                    //if (resultQRY[i].Ensayo.Nombre == "Diametro Interior de campana")
                    //{
                    //    InteriorCampana = resultQRY[i].ResultadoValor;
                    //}

                    //if (resultQRY[i].Ensayo.Nombre == "Longitud de ceja de campana")
                    //{
                    //    Campana = resultQRY[i].ResultadoValor;
                    //}

                    //if (resultQRY[i].Ensayo.Nombre == "Longitud utilizable de espiga")
                    //{
                    //    UtilTubo = resultQRY[i].ResultadoValor;
                    //}

                    //if (resultQRY[i].Ensayo.Nombre == "Espesor de Flare de campana")
                    //{
                    //    ExteriorCampana = resultQRY[i].ResultadoValor;
                    //}
                }

                //Lote
                

                var resultLote = resultQRY[0].Lote;
                List<Lote> listLote = new List<Lote>();
                listLote.Add(resultLote);
                //ResultadoDetalle
                var resultDetalle = ResultadoDetalleService.ReadResultadoDetalle().Where(x => x.ResultadoId == resultQRY[0].Id).ToList();
                //Producto
                var resultProducto = ProductoService.ReadProducto().Where(x => x.Id == resultQRY[0].ProductoId).ToList();
                var resultEquipo = EquipoService.ReadEquipo().Where(x => x.Id == resultQRY[0].EquipoId).ToList();
                var resultTurno = resultLote.Turno;
                List<Turno> listTurno = new List<Turno>();
                listTurno.Add(resultTurno);

                BsdReportDataSource rds = new BsdReportDataSource("DsDimensional", resultQRY);
                BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
                BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle);
                BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
                BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);
                BsdReportDataSource rds6 = new BsdReportDataSource("DsEquipo", resultEquipo);
                BsdReportDataSource rds7 = new BsdReportDataSource("DsNorma", listNorma);
                BsdReportDataSource rds8 = new BsdReportDataSource("DsParedInterior", listParedInt);
                BsdReportDataSource rds9 = new BsdReportDataSource("DsParedExterior", listDiamExt);
                BsdReportDataSource rds10 = new BsdReportDataSource("DsMiniEspiga", listMiniEspiga);
                BsdReportDataSource rds11 = new BsdReportDataSource("DsIntCampana", listIntCampana);
                BsdReportDataSource rds12 = new BsdReportDataSource("DsExtCampana", listExtCampana);
                BsdReportDataSource rds13 = new BsdReportDataSource("DsUtilTubo", listUtilTubo);
                BsdReportDataSource rds14 = new BsdReportDataSource("DsCampana", listLongCamp);

                BsdReportParameter parameter = new BsdReportParameter("InteriorTubo", InteriorTubo.ToString(), true);
                BsdReportParameter parameter2 = new BsdReportParameter("ExteriorTubo", ExteriorTubo.ToString(), true);
                BsdReportParameter parameter3 = new BsdReportParameter("ExtMiniEspiga", ExteriorEspiga.ToString(), true);
                BsdReportParameter parameter4 = new BsdReportParameter("IntCampana", InteriorCampana.ToString(), true);
                BsdReportParameter parameter5 = new BsdReportParameter("ExtCampana", ExteriorCampana.ToString(), true);
                BsdReportParameter parameter6 = new BsdReportParameter("UtilTubo", UtilTubo.ToString(), true);
                BsdReportParameter parameter7 = new BsdReportParameter("Campana", Campana.ToString(), true);

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
                ds.Add(rds11);
                ds.Add(rds12);
                ds.Add(rds13);
                ds.Add(rds14);

                BsdReport report = new BsdReport("Reporte Dimensional", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
                report.Parameters.Add(parameter);
                report.Parameters.Add(parameter2);
                report.Parameters.Add(parameter3);
                report.Parameters.Add(parameter4);
                report.Parameters.Add(parameter5);
                report.Parameters.Add(parameter6);
                report.Parameters.Add(parameter7);
                BsdReportResult result = ReportViewerService.CreateReport(report);

                FileStream fs = new FileStream(@"c:\Reportes\" + report.Name + "." + result.FileType, FileMode.OpenOrCreate);
                fs.Write(result.Content, 0, result.Content.Length);
                fs.Close();

                return File(result.Content, result.MimeType);
            }
            else
            {
                return View(GetModel(new Resultado()));
            }
        }


        [HttpPost]
        public ActionResult GenerarReporte(Resultado resultado)
        {            
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

        private RpteDimensionalViewModel GetModel(Resultado resultado)
        {
            return new RpteDimensionalViewModel(resultado, ProductoService.ReadProducto());
        }


    }
}
