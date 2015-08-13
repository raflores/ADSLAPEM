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
using System.Globalization;
using ADS.LAPEM.Web.Infrastructure.Grid;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Web.Areas.Reporte.Controllers
{
    public class RpteImpactoController : BaseController
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
        // GET: /Reporte/RpteImpacto/

        public ActionResult Index()
        {
            return View(GetModel(new Lote()));
        }

        [HttpPost]
        public FileContentResult GenerarRepo(Resultado resultado)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteImpacto.rdlc");
            decimal resultado1 = 0, resultado2 = 0, resultado3 = 0, resultado4 = 0, resultado5 = 0, resultado6 = 0;
            decimal tiempo1 = 0, tiempo2 = 0, tiempo3 = 0, tiempo4 = 0, tiempo5 = 0, tiempo6 = 0;
            decimal lado1 = 0, lado2 = 0, lado3 = 0, lado4 = 0, lado5 = 0, lado6 = 0;
            decimal atributo1 = 0, atributo2 = 0, atributo3 = 0, atributo4 = 0, atributo5 = 0, atributo6 = 0;
            DateTime fecha = DateTime.Parse(resultado.FechaPrueba.ToString("dd/MM/yyyy"));
            string noTubo = "", longMuestra = "", fechaInicio = "", fechaFin = "";

            //Resultado
            var resultQRY = ResultadoService.ReadResultado().Where(x => x.ProductoId == resultado.ProductoId && x.FechaPrueba == fecha).ToList();            

            
                int number = -1;
                for (int i = 0; i < resultQRY.Count; i++)
                {
                    if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                    {
                        if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-029-CNCP")
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            //for (int d = 0; d < resultDetalle.Count; d++)
                            //{
                            //    var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[i].Id).ToList();

                            //    for (int ad = 0; ad < atributoDetalle.Count; ad++)
                            //    {
                            //        if (atributoDetalle[ad].AtributoId == 3)
                            //        { 
                            //            switch(
                            //        }
                            //    }

                            //}

                            

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                                        for (int ad = 0; ad < atributoDetalle.Count; ad++)
                                        {
                                            switch (atributoDetalle[ad].AtributoId)
                                            { 
                                                case 5:
                                                    atributo1 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        break;
                                                case 6:
                                                    atributo2 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        break;
                                                case 7:
                                                    atributo3 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        break;
                                                case 8:
                                                    atributo4 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        break;
                                                case 9:
                                                    atributo5 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        break;
                                                case 10:
                                                    atributo6 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        break;
                                                case 149:
                                                        noTubo = atributoDetalle[ad].Valor;
                                                        break;
                                                case 150:
                                                        longMuestra = atributoDetalle[ad].Valor;
                                                        break;
                                                case 151:
                                                        fechaInicio = atributoDetalle[ad].Valor;
                                                        break;
                                                case 152:
                                                        fechaFin = atributoDetalle[ad].Valor;
                                                        break;
                                            }


                                            if (atributoDetalle[ad].AtributoId == 3)
                                            {
                                                switch (resultDetalle[j].MuestraNum)
                                                { 
                                                    case 1:
                                                        if (lado1 == 0)
                                                        {
                                                            lado1 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        }
                                                        else if (lado2 == 0)
                                                        {
                                                            lado2 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        }
                                                        else if (lado3 == 0)
                                                        {
                                                            lado3 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        }
                                                        else if (lado4 == 0)
                                                        {
                                                            lado4 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        }
                                                        else if (lado5 == 0)
                                                        {
                                                            lado5 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        }
                                                        else if (lado6 == 0)
                                                        {
                                                            lado6 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        }
                                                        break;
                                                }
                                            }

                                            if (atributoDetalle[ad].AtributoId == 4)
                                            {
                                                switch (resultDetalle[j].MuestraNum)
                                                {
                                                    case 1:
                                                        if (tiempo1 == 0)
                                                        {
                                                            tiempo1 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        }
                                                        else if (tiempo2 == 0)
                                                        {
                                                            tiempo2 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        }
                                                        else if (tiempo3 == 0)
                                                        {
                                                            tiempo3 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        }
                                                        else if (tiempo4 == 0)
                                                        {
                                                            tiempo4 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        }
                                                        else if (tiempo5 == 0)
                                                        {
                                                            tiempo5 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        }
                                                        else if (tiempo6 == 0)
                                                        {
                                                            tiempo6 = decimal.Parse(atributoDetalle[ad].Valor);
                                                        }
                                                        break;
                                                }
                                            }
                                        }



                                if (resultDetalle[j].MuestraNum == 1)
                                {
                                    resultado1 = resultDetalle[j].ResultadoDetalleValor;
                                }

                                if (resultDetalle[j].MuestraNum == 2)
                                {
                                    resultado2 = resultDetalle[j].ResultadoDetalleValor;
                                }

                                if (resultDetalle[j].MuestraNum == 3)
                                {
                                    resultado3 = resultDetalle[j].ResultadoDetalleValor;
                                }

                                if (resultDetalle[j].MuestraNum == 4)
                                {
                                    resultado4 = resultDetalle[j].ResultadoDetalleValor;
                                }

                                if (resultDetalle[j].MuestraNum == 5)
                                {
                                    resultado5 = resultDetalle[j].ResultadoDetalleValor;
                                }

                                if (resultDetalle[j].MuestraNum == 6)
                                {
                                    resultado6 = resultDetalle[j].ResultadoDetalleValor;
                                }
                            }

                        }
                    }


                    //if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-029-CNCP" || resultQRY[i].NormaEnsayo.Nombre == "ASTM D 2444")
                    //{
                    //    number = i;
                    //}
                }

                //if (number != -1)
                //{
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

                    BsdReportDataSource rds = new BsdReportDataSource("DsImpacto", resultQRY);
                    BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
                    BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle2);
                    BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
                    BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);
                    BsdReportDataSource rds6 = new BsdReportDataSource("DsEquipo", resultEquipo);
                    BsdReportDataSource rds7 = new BsdReportDataSource("DsNorma", listNorma);
                    BsdReportDataSource rds8 = new BsdReportDataSource("DsMDiametro", listDiametro);

                    BsdReportParameter parameter = new BsdReportParameter("Resultado1", resultado1.ToString(), true);
                    BsdReportParameter parameter2 = new BsdReportParameter("Resultado2", resultado2.ToString(), true);
                    BsdReportParameter parameter3 = new BsdReportParameter("Resultado3", resultado3.ToString(), true);
                    BsdReportParameter parameter4 = new BsdReportParameter("Resultado4", resultado4.ToString(), true);
                    BsdReportParameter parameter5 = new BsdReportParameter("Resultado5", resultado5.ToString(), true);
                    BsdReportParameter parameter6 = new BsdReportParameter("Resultado6", resultado6.ToString(), true);
                    BsdReportParameter plado1 = new BsdReportParameter("Lado1", lado1.ToString(), true);
                    BsdReportParameter plado2 = new BsdReportParameter("Lado2", lado2.ToString(), true);
                    BsdReportParameter plado3 = new BsdReportParameter("Lado3", lado3.ToString(), true);
                    BsdReportParameter plado4 = new BsdReportParameter("Lado4", lado4.ToString(), true);
                    BsdReportParameter plado5 = new BsdReportParameter("Lado5", lado5.ToString(), true);
                    BsdReportParameter plado6 = new BsdReportParameter("Lado6", lado6.ToString(), true);
                    BsdReportParameter ptiempo1 = new BsdReportParameter("Tiempo1", tiempo1.ToString(), true);
                    BsdReportParameter ptiempo2 = new BsdReportParameter("Tiempo2", tiempo2.ToString(), true);
                    BsdReportParameter ptiempo3 = new BsdReportParameter("Tiempo3", tiempo3.ToString(), true);
                    BsdReportParameter ptiempo4 = new BsdReportParameter("Tiempo4", tiempo4.ToString(), true);
                    BsdReportParameter ptiempo5 = new BsdReportParameter("Tiempo5", tiempo5.ToString(), true);
                    BsdReportParameter ptiempo6 = new BsdReportParameter("Tiempo6", tiempo6.ToString(), true);
                    BsdReportParameter patributo1 = new BsdReportParameter("MasaProyectil", atributo1.ToString(), true);
                    BsdReportParameter patributo2 = new BsdReportParameter("Acondicionamiento", atributo2.ToString(), true);
                    BsdReportParameter patributo3 = new BsdReportParameter("EnergiaRequerida", atributo3.ToString(), true);
                    BsdReportParameter patributo4 = new BsdReportParameter("TipoProyectil", atributo4.ToString(), true);
                    BsdReportParameter patributo5 = new BsdReportParameter("Temperatura", atributo5.ToString(), true);
                    BsdReportParameter patributo6 = new BsdReportParameter("AlturaProyectil", atributo6.ToString(), true);
                    BsdReportParameter patributo7 = new BsdReportParameter("Norma", "NormaTest", true);
                    BsdReportParameter patributo8 = new BsdReportParameter("NoTubo", noTubo, true);
                    BsdReportParameter patributo9 = new BsdReportParameter("LongMuestra", longMuestra, true);
                    BsdReportParameter patributo10 = new BsdReportParameter("FechaInicio", fechaInicio, true);
                    BsdReportParameter patributo11 = new BsdReportParameter("FechaFin", fechaFin, true);



                    IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
                    ds.Add(rds);
                    ds.Add(rds2);
                    ds.Add(rds3);
                    ds.Add(rds4);
                    ds.Add(rds5);
                    ds.Add(rds6);
                    ds.Add(rds7);
                    ds.Add(rds8);

                    BsdReport report = new BsdReport("Reporte de Impacto", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
                    report.Parameters.Add(parameter);
                    report.Parameters.Add(parameter2);
                    report.Parameters.Add(parameter3);
                    report.Parameters.Add(parameter4);
                    report.Parameters.Add(parameter5);
                    report.Parameters.Add(parameter6);
                    report.Parameters.Add(plado1);
                    report.Parameters.Add(plado2);
                    report.Parameters.Add(plado3);
                    report.Parameters.Add(plado4);
                    report.Parameters.Add(plado5);
                    report.Parameters.Add(plado6);
                    report.Parameters.Add(ptiempo1);
                    report.Parameters.Add(ptiempo2);
                    report.Parameters.Add(ptiempo3);
                    report.Parameters.Add(ptiempo4);
                    report.Parameters.Add(ptiempo5);
                    report.Parameters.Add(ptiempo6);
                    report.Parameters.Add(patributo1);
                    report.Parameters.Add(patributo2);
                    report.Parameters.Add(patributo3);
                    report.Parameters.Add(patributo4);
                    report.Parameters.Add(patributo5);
                    report.Parameters.Add(patributo6);
                    report.Parameters.Add(patributo7);
                    report.Parameters.Add(patributo8);
                    report.Parameters.Add(patributo9);
                    report.Parameters.Add(patributo10);
                    report.Parameters.Add(patributo11);


                    BsdReportResult result = ReportViewerService.CreateReport(report);

                    //FileStream fs = new FileStream(@"c:\Reportes\" + report.Name + "." + result.FileType, FileMode.OpenOrCreate);
                    //fs.Write(result.Content, 0, result.Content.Length);
                    //fs.Close();

                    return File(result.Content, result.MimeType);
                //}
                //else
                //{
                //    return View(GetModel(new Resultado()));
                //}
            
        }

        [HttpGet]
        public ActionResult Generar(long id)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteImpacto.rdlc");
            decimal resultado1 = 0, resultado2 = 0, resultado3 = 0, resultado4 = 0, resultado5 = 0, resultado6 = 0;
            decimal tiempo1 = 0, tiempo2 = 0, tiempo3 = 0, tiempo4 = 0, tiempo5 = 0, tiempo6 = 0;
            decimal lado1 = 0, lado2 = 0, lado3 = 0, lado4 = 0, lado5 = 0, lado6 = 0;
            decimal atributo1 = 0, atributo2 = 0, atributo3 = 0, atributo4 = 0, atributo5 = 0, atributo6 = 0;
            //DateTime fecha = DateTime.Parse(resultado.FechaPrueba.ToString("dd/MM/yyyy"));
            string noTubo = "", longMuestra = "", fechaInicio = "", fechaFin = "";

            //Resultado
            var resultQRY = ResultadoService.ReadResultadoByLote(id).ToList();


            int number = -1;
            for (int i = 0; i < resultQRY.Count; i++)
            {
                if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                {
                    if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-029-CNCP")
                    {
                        var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                        //for (int d = 0; d < resultDetalle.Count; d++)
                        //{
                        //    var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[i].Id).ToList();

                        //    for (int ad = 0; ad < atributoDetalle.Count; ad++)
                        //    {
                        //        if (atributoDetalle[ad].AtributoId == 3)
                        //        { 
                        //            switch(
                        //        }
                        //    }

                        //}



                        for (int j = 0; j < resultDetalle.Count; j++)
                        {
                            var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                            for (int ad = 0; ad < atributoDetalle.Count; ad++)
                            {
                                switch (atributoDetalle[ad].AtributoId)
                                {
                                    case 5:
                                        atributo1 = decimal.Parse(atributoDetalle[ad].Valor);
                                        break;
                                    case 6:
                                        atributo2 = decimal.Parse(atributoDetalle[ad].Valor);
                                        break;
                                    case 7:
                                        atributo3 = decimal.Parse(atributoDetalle[ad].Valor);
                                        break;
                                    case 8:
                                        atributo4 = decimal.Parse(atributoDetalle[ad].Valor);
                                        break;
                                    case 9:
                                        atributo5 = decimal.Parse(atributoDetalle[ad].Valor);
                                        break;
                                    case 10:
                                        atributo6 = decimal.Parse(atributoDetalle[ad].Valor);
                                        break;
                                    case 149:
                                        noTubo = atributoDetalle[ad].Valor;
                                        break;
                                    case 150:
                                        longMuestra = atributoDetalle[ad].Valor;
                                        break;
                                    case 151:
                                        fechaInicio = atributoDetalle[ad].Valor;
                                        break;
                                    case 152:
                                        fechaFin = atributoDetalle[ad].Valor;
                                        break;
                                }


                                if (atributoDetalle[ad].AtributoId == 3)
                                {
                                    switch (resultDetalle[j].MuestraNum)
                                    {
                                        case 1:
                                            if (lado1 == 0)
                                            {
                                                lado1 = decimal.Parse(atributoDetalle[ad].Valor);
                                            }
                                            else if (lado2 == 0)
                                            {
                                                lado2 = decimal.Parse(atributoDetalle[ad].Valor);
                                            }
                                            else if (lado3 == 0)
                                            {
                                                lado3 = decimal.Parse(atributoDetalle[ad].Valor);
                                            }
                                            else if (lado4 == 0)
                                            {
                                                lado4 = decimal.Parse(atributoDetalle[ad].Valor);
                                            }
                                            else if (lado5 == 0)
                                            {
                                                lado5 = decimal.Parse(atributoDetalle[ad].Valor);
                                            }
                                            else if (lado6 == 0)
                                            {
                                                lado6 = decimal.Parse(atributoDetalle[ad].Valor);
                                            }
                                            break;
                                    }
                                }

                                if (atributoDetalle[ad].AtributoId == 4)
                                {
                                    switch (resultDetalle[j].MuestraNum)
                                    {
                                        case 1:
                                            if (tiempo1 == 0)
                                            {
                                                tiempo1 = decimal.Parse(atributoDetalle[ad].Valor);
                                            }
                                            else if (tiempo2 == 0)
                                            {
                                                tiempo2 = decimal.Parse(atributoDetalle[ad].Valor);
                                            }
                                            else if (tiempo3 == 0)
                                            {
                                                tiempo3 = decimal.Parse(atributoDetalle[ad].Valor);
                                            }
                                            else if (tiempo4 == 0)
                                            {
                                                tiempo4 = decimal.Parse(atributoDetalle[ad].Valor);
                                            }
                                            else if (tiempo5 == 0)
                                            {
                                                tiempo5 = decimal.Parse(atributoDetalle[ad].Valor);
                                            }
                                            else if (tiempo6 == 0)
                                            {
                                                tiempo6 = decimal.Parse(atributoDetalle[ad].Valor);
                                            }
                                            break;
                                    }
                                }
                            }



                            if (resultDetalle[j].MuestraNum == 1)
                            {
                                resultado1 = resultDetalle[j].ResultadoDetalleValor;
                            }

                            if (resultDetalle[j].MuestraNum == 2)
                            {
                                resultado2 = resultDetalle[j].ResultadoDetalleValor;
                            }

                            if (resultDetalle[j].MuestraNum == 3)
                            {
                                resultado3 = resultDetalle[j].ResultadoDetalleValor;
                            }

                            if (resultDetalle[j].MuestraNum == 4)
                            {
                                resultado4 = resultDetalle[j].ResultadoDetalleValor;
                            }

                            if (resultDetalle[j].MuestraNum == 5)
                            {
                                resultado5 = resultDetalle[j].ResultadoDetalleValor;
                            }

                            if (resultDetalle[j].MuestraNum == 6)
                            {
                                resultado6 = resultDetalle[j].ResultadoDetalleValor;
                            }
                        }

                    }
                }


                //if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-029-CNCP" || resultQRY[i].NormaEnsayo.Nombre == "ASTM D 2444")
                //{
                //    number = i;
                //}
            }

            //if (number != -1)
            //{
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

            BsdReportDataSource rds = new BsdReportDataSource("DsImpacto", resultQRY);
            BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
            BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle2);
            BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
            BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);
            BsdReportDataSource rds6 = new BsdReportDataSource("DsEquipo", resultEquipo);
            BsdReportDataSource rds7 = new BsdReportDataSource("DsNorma", listNorma);
            BsdReportDataSource rds8 = new BsdReportDataSource("DsMDiametro", listDiametro);

            BsdReportParameter parameter = new BsdReportParameter("Resultado1", resultado1.ToString(), true);
            BsdReportParameter parameter2 = new BsdReportParameter("Resultado2", resultado2.ToString(), true);
            BsdReportParameter parameter3 = new BsdReportParameter("Resultado3", resultado3.ToString(), true);
            BsdReportParameter parameter4 = new BsdReportParameter("Resultado4", resultado4.ToString(), true);
            BsdReportParameter parameter5 = new BsdReportParameter("Resultado5", resultado5.ToString(), true);
            BsdReportParameter parameter6 = new BsdReportParameter("Resultado6", resultado6.ToString(), true);
            BsdReportParameter plado1 = new BsdReportParameter("Lado1", lado1.ToString(), true);
            BsdReportParameter plado2 = new BsdReportParameter("Lado2", lado2.ToString(), true);
            BsdReportParameter plado3 = new BsdReportParameter("Lado3", lado3.ToString(), true);
            BsdReportParameter plado4 = new BsdReportParameter("Lado4", lado4.ToString(), true);
            BsdReportParameter plado5 = new BsdReportParameter("Lado5", lado5.ToString(), true);
            BsdReportParameter plado6 = new BsdReportParameter("Lado6", lado6.ToString(), true);
            BsdReportParameter ptiempo1 = new BsdReportParameter("Tiempo1", tiempo1.ToString(), true);
            BsdReportParameter ptiempo2 = new BsdReportParameter("Tiempo2", tiempo2.ToString(), true);
            BsdReportParameter ptiempo3 = new BsdReportParameter("Tiempo3", tiempo3.ToString(), true);
            BsdReportParameter ptiempo4 = new BsdReportParameter("Tiempo4", tiempo4.ToString(), true);
            BsdReportParameter ptiempo5 = new BsdReportParameter("Tiempo5", tiempo5.ToString(), true);
            BsdReportParameter ptiempo6 = new BsdReportParameter("Tiempo6", tiempo6.ToString(), true);
            BsdReportParameter patributo1 = new BsdReportParameter("MasaProyectil", atributo1.ToString(), true);
            BsdReportParameter patributo2 = new BsdReportParameter("Acondicionamiento", atributo2.ToString(), true);
            BsdReportParameter patributo3 = new BsdReportParameter("EnergiaRequerida", atributo3.ToString(), true);
            BsdReportParameter patributo4 = new BsdReportParameter("TipoProyectil", atributo4.ToString(), true);
            BsdReportParameter patributo5 = new BsdReportParameter("Temperatura", atributo5.ToString(), true);
            BsdReportParameter patributo6 = new BsdReportParameter("AlturaProyectil", atributo6.ToString(), true);
            BsdReportParameter patributo7 = new BsdReportParameter("Norma", "NormaTest", true);
            BsdReportParameter patributo8 = new BsdReportParameter("NoTubo", noTubo, true);
            BsdReportParameter patributo9 = new BsdReportParameter("LongMuestra", longMuestra, true);
            BsdReportParameter patributo10 = new BsdReportParameter("FechaInicio", fechaInicio, true);
            BsdReportParameter patributo11 = new BsdReportParameter("FechaFin", fechaFin, true);



            IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
            ds.Add(rds);
            ds.Add(rds2);
            ds.Add(rds3);
            ds.Add(rds4);
            ds.Add(rds5);
            ds.Add(rds6);
            ds.Add(rds7);
            ds.Add(rds8);

            BsdReport report = new BsdReport("Reporte de Impacto", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
            report.Parameters.Add(parameter);
            report.Parameters.Add(parameter2);
            report.Parameters.Add(parameter3);
            report.Parameters.Add(parameter4);
            report.Parameters.Add(parameter5);
            report.Parameters.Add(parameter6);
            report.Parameters.Add(plado1);
            report.Parameters.Add(plado2);
            report.Parameters.Add(plado3);
            report.Parameters.Add(plado4);
            report.Parameters.Add(plado5);
            report.Parameters.Add(plado6);
            report.Parameters.Add(ptiempo1);
            report.Parameters.Add(ptiempo2);
            report.Parameters.Add(ptiempo3);
            report.Parameters.Add(ptiempo4);
            report.Parameters.Add(ptiempo5);
            report.Parameters.Add(ptiempo6);
            report.Parameters.Add(patributo1);
            report.Parameters.Add(patributo2);
            report.Parameters.Add(patributo3);
            report.Parameters.Add(patributo4);
            report.Parameters.Add(patributo5);
            report.Parameters.Add(patributo6);
            report.Parameters.Add(patributo7);
            report.Parameters.Add(patributo8);
            report.Parameters.Add(patributo9);
            report.Parameters.Add(patributo10);
            report.Parameters.Add(patributo11);


            BsdReportResult result = ReportViewerService.CreateReport(report);

            //FileStream fs = new FileStream(@"c:\Reportes\" + report.Name + "." + result.FileType, FileMode.OpenOrCreate);
            //fs.Write(result.Content, 0, result.Content.Length);
            //fs.Close();

            return File(result.Content, result.MimeType);

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

        private RpteImpactoViewModel GetModel(Lote lote)
        {
            return new RpteImpactoViewModel(lote, ProductoService.ReadProducto()); 
        }

    }
}
