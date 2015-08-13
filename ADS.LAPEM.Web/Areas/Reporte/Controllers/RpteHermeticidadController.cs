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
    public class RpteHermeticidadController : BaseController
    {
        protected ILoteService LoteService { get; set; }
        protected IEquipoService EquipoService { get; set; }        
        protected IResultadoDetalleService ResultadoDetalleService { get; set; }
        protected IProductoService ProductoService { get; set; }
        protected ITurnoService TurnoService { get; set; }
        protected IResultadoService ResultadoService { get; set; }
        protected IReportViewerService ReportViewerService { get; set; }
        protected IAtributoDService AtributoDService { get; set; }
        //
        // GET: /Reporte/RpteHermeticidad/

        public ActionResult Index()
        {
            return View(GetModel(new Lote()));
        }

        [HttpPost]
        public ActionResult GenerarRepo(Resultado resultado)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteHermeticidad.rdlc");
            decimal atributo1 = 0, atributo2 = 0, atributo3 = 0, atributo4 = 0, atributo5 = 0, atributo6 = 0, atributo7 = 0, atributo8 = 0,
            atributo9 = 0, atributo10 = 0, atributo11 = 0, atributo12 = 0, atributo13 = 0, atributo14 = 0, atributo15 = 0,
            atributo16 = 0, atributo17 = 0, atributo18 = 0;
            string resultado1 = "", resultado2 = "", resultado3 = "", resultado4 = "", resultado5 = "", resultado6 = "";
            DateTime fecha = DateTime.Parse(resultado.FechaPrueba.ToString("dd/MM/yyyy"));
            string noTubo = "", perfil = "";
            //long ProductoId = resultado.ProductoId;
            //DateTime Fecha = resultado.FechaPrueba;

            //if (resultado.Lote.Identificador != null)
            //{
            //    var resultLote = LoteService.ReadLoteByIdentificador(resultado.Lote.Identificador).ToList();
            //    ProductoId = resultLote[0].ProductoId;
            //    Fecha = resultLote[0].FechaProduccion;
            //}

            //Resultado
            var resultQRY = ResultadoService.ReadResultado().Where(x => x.ProductoId == x.ProductoId && x.FechaPrueba == x.FechaPrueba).ToList();            

            if (resultQRY.Count > 0)
            {
                int number = -1;
                for (int i = 0; i < resultQRY.Count; i++)
                {
                    if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                    {
                        if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-205-CNCP" || resultQRY[i].NormaEnsayo.Nombre == "ASTM D 3212")
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                switch (resultDetalle[j].MuestraNum)
                                { 
                                    case 1:
                                        resultado1 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        if (resultado1 == "1.00")
                                        {
                                            resultado1 = "Aprobado";
                                        }
                                        else
                                            resultado1 = "Rechazado";
                                        break;
                                    case 2:
                                        resultado2 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        if (resultado2 == "1.00")
                                        {
                                            resultado2 = "Aprobado";
                                        }
                                        else
                                            resultado2 = "Rechazado";
                                        break;
                                    case 3:
                                        resultado3 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        if (resultado3 == "1.00")
                                        {
                                            resultado3 = "Aprobado";
                                        }
                                        else
                                            resultado3 = "Rechazado";
                                        break;
                                    case 4:
                                        resultado4 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        if (resultado4 == "1.00")
                                        {
                                            resultado4 = "Aprobado";
                                        }
                                        else
                                            resultado4 = "Rechazado";
                                        break;
                                    case 5:
                                        resultado5 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        if (resultado5 == "1.00")
                                        {
                                            resultado5 = "Aprobado";
                                        }
                                        else
                                            resultado5 = "Rechazado";
                                        break;
                                    case 6:
                                        resultado6 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        if (resultado6 == "1.00")
                                        {
                                            resultado6 = "Aprobado";
                                        }
                                        else
                                            resultado6 = "Rechazado";
                                        break;

                                }

                                var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                                for (int ad = 0; ad < atributoDetalle.Count; ad++)
                                {
                                    switch (atributoDetalle[ad].AtributoId)
                                    { 
                                        case 77:
                                            atributo1 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 78:
                                            atributo2 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 79:
                                            atributo3 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 80:
                                            atributo4 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 81:
                                            atributo5 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 82:
                                            atributo6 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 83:
                                            atributo7 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 84:
                                            atributo8 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 85: 
                                            atributo9 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 86:
                                            atributo10 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 87:
                                            atributo11 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 88:
                                            atributo12 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 89:
                                            atributo13 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 90:
                                            atributo14 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 91:
                                            atributo15 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 92:
                                            atributo16 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 93:
                                            atributo17 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 94:
                                            atributo18 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 153:
                                            noTubo = atributoDetalle[ad].Valor;
                                            break;
                                        case 154:
                                            perfil = atributoDetalle[ad].Valor;
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

                    foreach (Resultado r in resultQRY)
                    {
                        if (r.Ensayo.Nombre == "Hermeticidad Agua posición normal, desalineamiento 1.5 ° y deflexion 5 % - 10 min por posición ")
                        {
                            ListPresion.Add(r);
                        }

                        if (r.Ensayo.Nombre == "Hermeticidad Vacio posición normal, desalineamiento 1.5 ° y deflexion 5 % - 10 min por posición ")
                        {
                            ListVacio.Add(r);
                        }
                    }


                    BsdReportDataSource rds = new BsdReportDataSource("DsHermeticidad", resultQRY);
                    BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
                    BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle2);
                    BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
                    BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);
                    BsdReportDataSource rds6 = new BsdReportDataSource("DsEquipo", resultEquipo);
                    BsdReportDataSource rds7 = new BsdReportDataSource("DsNorma", listNorma);
                    BsdReportDataSource rds8 = new BsdReportDataSource("DsMDiametro", listDiametro);
                    BsdReportDataSource rds9 = new BsdReportDataSource("DsVacio", ListVacio);
                    BsdReportDataSource rds10 = new BsdReportDataSource("DsPresion", ListPresion);

                    BsdReportParameter parameter1 = new BsdReportParameter("PresionRequerida", atributo1.ToString(), true);
                    BsdReportParameter parameter2 = new BsdReportParameter("DistanciaApoyo", atributo2.ToString(), true);
                    BsdReportParameter parameter3 = new BsdReportParameter("Tiempo", atributo3.ToString(), true);
                    BsdReportParameter parameter4 = new BsdReportParameter("VacioRequerido", atributo4.ToString(), true);
                    BsdReportParameter parameter5 = new BsdReportParameter("Deflexion", atributo5.ToString(), true);
                    BsdReportParameter parameter6 = new BsdReportParameter("Desalineamiento", atributo6.ToString(), true);
                    BsdReportParameter parameter7 = new BsdReportParameter("Vacio2", atributo7.ToString(), true);
                    BsdReportParameter parameter8 = new BsdReportParameter("Vacio3", atributo8.ToString(), true);
                    BsdReportParameter parameter9 = new BsdReportParameter("Vacio6", atributo9.ToString(), true);
                    BsdReportParameter parameter10 = new BsdReportParameter("Vacio7", atributo10.ToString(), true);
                    BsdReportParameter parameter11 = new BsdReportParameter("Vacio10", atributo11.ToString(), true);
                    BsdReportParameter parameter12 = new BsdReportParameter("Vacio11", atributo12.ToString(), true);
                    BsdReportParameter parameter13 = new BsdReportParameter("Presion2", atributo13.ToString(), true);
                    BsdReportParameter parameter14 = new BsdReportParameter("Presion3", atributo14.ToString(), true);
                    BsdReportParameter parameter15 = new BsdReportParameter("Presion6", atributo15.ToString(), true);
                    BsdReportParameter parameter16 = new BsdReportParameter("Presion7", atributo16.ToString(), true);
                    BsdReportParameter parameter17 = new BsdReportParameter("Presion10", atributo17.ToString(), true);
                    BsdReportParameter parameter18 = new BsdReportParameter("Presion11", atributo18.ToString(), true);
                    BsdReportParameter parameter19 = new BsdReportParameter("Vacio1", resultado1.ToString(), true);
                    BsdReportParameter parameter20 = new BsdReportParameter("Vacio5", resultado2.ToString(), true);
                    BsdReportParameter parameter21 = new BsdReportParameter("Vacio9", resultado3.ToString(), true);
                    BsdReportParameter parameter22 = new BsdReportParameter("Presion1", resultado4.ToString(), true);
                    BsdReportParameter parameter23 = new BsdReportParameter("Presion5", resultado5.ToString(), true);
                    BsdReportParameter parameter24 = new BsdReportParameter("Presion9", resultado6.ToString(), true);
                    BsdReportParameter parameter25 = new BsdReportParameter("Vacio4", "1", true);
                    BsdReportParameter parameter26 = new BsdReportParameter("Vacio8", "2", true);
                    BsdReportParameter parameter27 = new BsdReportParameter("Vacio12", "3", true);
                    BsdReportParameter parameter28 = new BsdReportParameter("Presion4", "4", true);
                    BsdReportParameter parameter29 = new BsdReportParameter("Presion8", "5", true);
                    BsdReportParameter parameter30 = new BsdReportParameter("Presion12", "6", true);
                    BsdReportParameter parameter31 = new BsdReportParameter("NoTubo", noTubo, true);
                    BsdReportParameter parameter32 = new BsdReportParameter("Perfil", perfil, true);

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

                    BsdReport report = new BsdReport("Reporte de Hermeticidad", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
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
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteHermeticidad.rdlc");
            decimal atributo1 = 0, atributo2 = 0, atributo3 = 0, atributo4 = 0, atributo5 = 0, atributo6 = 0, atributo7 = 0, atributo8 = 0,
            atributo9 = 0, atributo10 = 0, atributo11 = 0, atributo12 = 0, atributo13 = 0, atributo14 = 0, atributo15 = 0,
            atributo16 = 0, atributo17 = 0, atributo18 = 0;
            string resultado1 = "", resultado2 = "", resultado3 = "", resultado4 = "", resultado5 = "", resultado6 = "";
            //DateTime fecha = DateTime.Parse(resultado.FechaPrueba.ToString("dd/MM/yyyy"));
            string noTubo = "", perfil = "";
            //long ProductoId = resultado.ProductoId;
            //DateTime Fecha = resultado.FechaPrueba;

            //if (resultado.Lote.Identificador != null)
            //{
            //    var resultLote = LoteService.ReadLoteByIdentificador(resultado.Lote.Identificador).ToList();
            //    ProductoId = resultLote[0].ProductoId;
            //    Fecha = resultLote[0].FechaProduccion;
            //}

            //Resultado
            var resultQRY = ResultadoService.ReadResultadoByLote(id).ToList();

            if (resultQRY.Count > 0)
            {
                int number = -1;
                for (int i = 0; i < resultQRY.Count; i++)
                {
                    if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                    {
                        if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-205-CNCP" || resultQRY[i].NormaEnsayo.Nombre == "ASTM D 3212")
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                switch (resultDetalle[j].MuestraNum)
                                {
                                    case 1:
                                        resultado1 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        if (resultado1 == "1.00")
                                        {
                                            resultado1 = "Aprobado";
                                        }
                                        else
                                            resultado1 = "Rechazado";
                                        break;
                                    case 2:
                                        resultado2 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        if (resultado2 == "1.00")
                                        {
                                            resultado2 = "Aprobado";
                                        }
                                        else
                                            resultado2 = "Rechazado";
                                        break;
                                    case 3:
                                        resultado3 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        if (resultado3 == "1.00")
                                        {
                                            resultado3 = "Aprobado";
                                        }
                                        else
                                            resultado3 = "Rechazado";
                                        break;
                                    case 4:
                                        resultado4 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        if (resultado4 == "1.00")
                                        {
                                            resultado4 = "Aprobado";
                                        }
                                        else
                                            resultado4 = "Rechazado";
                                        break;
                                    case 5:
                                        resultado5 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        if (resultado5 == "1.00")
                                        {
                                            resultado5 = "Aprobado";
                                        }
                                        else
                                            resultado5 = "Rechazado";
                                        break;
                                    case 6:
                                        resultado6 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        if (resultado6 == "1.00")
                                        {
                                            resultado6 = "Aprobado";
                                        }
                                        else
                                            resultado6 = "Rechazado";
                                        break;

                                }

                                var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                                for (int ad = 0; ad < atributoDetalle.Count; ad++)
                                {
                                    switch (atributoDetalle[ad].AtributoId)
                                    {
                                        case 77:
                                            atributo1 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 78:
                                            atributo2 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 79:
                                            atributo3 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 80:
                                            atributo4 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 81:
                                            atributo5 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 82:
                                            atributo6 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 83:
                                            atributo7 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 84:
                                            atributo8 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 85:
                                            atributo9 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 86:
                                            atributo10 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 87:
                                            atributo11 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 88:
                                            atributo12 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 89:
                                            atributo13 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 90:
                                            atributo14 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 91:
                                            atributo15 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 92:
                                            atributo16 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 93:
                                            atributo17 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 94:
                                            atributo18 = decimal.Parse(atributoDetalle[ad].Valor);
                                            break;
                                        case 153:
                                            noTubo = atributoDetalle[ad].Valor;
                                            break;
                                        case 154:
                                            perfil = atributoDetalle[ad].Valor;
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

                foreach (Resultado r in resultQRY)
                {
                    if (r.Ensayo.Nombre == "Hermeticidad Agua posición normal, desalineamiento 1.5 ° y deflexion 5 % - 10 min por posición ")
                    {
                        ListPresion.Add(r);
                    }

                    if (r.Ensayo.Nombre == "Hermeticidad Vacio posición normal, desalineamiento 1.5 ° y deflexion 5 % - 10 min por posición ")
                    {
                        ListVacio.Add(r);
                    }
                }


                BsdReportDataSource rds = new BsdReportDataSource("DsHermeticidad", resultQRY);
                BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
                BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle2);
                BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
                BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);
                BsdReportDataSource rds6 = new BsdReportDataSource("DsEquipo", resultEquipo);
                BsdReportDataSource rds7 = new BsdReportDataSource("DsNorma", listNorma);
                BsdReportDataSource rds8 = new BsdReportDataSource("DsMDiametro", listDiametro);
                BsdReportDataSource rds9 = new BsdReportDataSource("DsVacio", ListVacio);
                BsdReportDataSource rds10 = new BsdReportDataSource("DsPresion", ListPresion);

                BsdReportParameter parameter1 = new BsdReportParameter("PresionRequerida", atributo1.ToString(), true);
                BsdReportParameter parameter2 = new BsdReportParameter("DistanciaApoyo", atributo2.ToString(), true);
                BsdReportParameter parameter3 = new BsdReportParameter("Tiempo", atributo3.ToString(), true);
                BsdReportParameter parameter4 = new BsdReportParameter("VacioRequerido", atributo4.ToString(), true);
                BsdReportParameter parameter5 = new BsdReportParameter("Deflexion", atributo5.ToString(), true);
                BsdReportParameter parameter6 = new BsdReportParameter("Desalineamiento", atributo6.ToString(), true);
                BsdReportParameter parameter7 = new BsdReportParameter("Vacio2", atributo7.ToString(), true);
                BsdReportParameter parameter8 = new BsdReportParameter("Vacio3", atributo8.ToString(), true);
                BsdReportParameter parameter9 = new BsdReportParameter("Vacio6", atributo9.ToString(), true);
                BsdReportParameter parameter10 = new BsdReportParameter("Vacio7", atributo10.ToString(), true);
                BsdReportParameter parameter11 = new BsdReportParameter("Vacio10", atributo11.ToString(), true);
                BsdReportParameter parameter12 = new BsdReportParameter("Vacio11", atributo12.ToString(), true);
                BsdReportParameter parameter13 = new BsdReportParameter("Presion2", atributo13.ToString(), true);
                BsdReportParameter parameter14 = new BsdReportParameter("Presion3", atributo14.ToString(), true);
                BsdReportParameter parameter15 = new BsdReportParameter("Presion6", atributo15.ToString(), true);
                BsdReportParameter parameter16 = new BsdReportParameter("Presion7", atributo16.ToString(), true);
                BsdReportParameter parameter17 = new BsdReportParameter("Presion10", atributo17.ToString(), true);
                BsdReportParameter parameter18 = new BsdReportParameter("Presion11", atributo18.ToString(), true);
                BsdReportParameter parameter19 = new BsdReportParameter("Vacio1", resultado1.ToString(), true);
                BsdReportParameter parameter20 = new BsdReportParameter("Vacio5", resultado2.ToString(), true);
                BsdReportParameter parameter21 = new BsdReportParameter("Vacio9", resultado3.ToString(), true);
                BsdReportParameter parameter22 = new BsdReportParameter("Presion1", resultado4.ToString(), true);
                BsdReportParameter parameter23 = new BsdReportParameter("Presion5", resultado5.ToString(), true);
                BsdReportParameter parameter24 = new BsdReportParameter("Presion9", resultado6.ToString(), true);
                BsdReportParameter parameter25 = new BsdReportParameter("Vacio4", "1", true);
                BsdReportParameter parameter26 = new BsdReportParameter("Vacio8", "2", true);
                BsdReportParameter parameter27 = new BsdReportParameter("Vacio12", "3", true);
                BsdReportParameter parameter28 = new BsdReportParameter("Presion4", "4", true);
                BsdReportParameter parameter29 = new BsdReportParameter("Presion8", "5", true);
                BsdReportParameter parameter30 = new BsdReportParameter("Presion12", "6", true);
                BsdReportParameter parameter31 = new BsdReportParameter("NoTubo", noTubo, true);
                BsdReportParameter parameter32 = new BsdReportParameter("Perfil", perfil, true);

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

                BsdReport report = new BsdReport("Reporte de Hermeticidad", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
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
            long ProductoId = resultado.ProductoId;
            DateTime Fecha = resultado.FechaPrueba;            

            if (resultado.Lote.Identificador != null)
            {
                var resultLote = LoteService.ReadLoteByIdentificador(resultado.Lote.Identificador).ToList();
                ProductoId = long.Parse(resultLote[0].ProductoId.ToString());
                Fecha = resultLote[0].FechaProduccion;
                resultado.ProductoId = ProductoId;
            }

            //Resultado
            var resultQRY = ResultadoService.ReadResultado().Where(x => x.ProductoId == ProductoId && x.FechaPrueba == Fecha).ToList();
            
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

        private RpteHermeticidadViewModel GetModel(Lote lote)
        {
            return new RpteHermeticidadViewModel(lote, ProductoService.ReadProducto());
        }
    }
}
