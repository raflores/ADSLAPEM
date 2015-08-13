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
using ADS.LAPEM.Web.Infrastructure.Grid;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Web.Areas.Reporte.Controllers
{
    public class RpteAplastamientoController : BaseController
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
        // GET: /Reporte/RpteAplastamiento/

        public ActionResult Index()
        {
            return View(GetModel(new Lote()));
        }

        [HttpPost]
        public ActionResult GenerarRepo(Resultado resultado)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteAplastamiento.rdlc");

            string resultado1 = "", resultado2 = "", resultado3 = "", resultado4 = "";
            string longitud0 = "", longitud45 = "", longitud90 = "", longitud135 = "";
            string diametroInt0 = "", diametroInt45 = "", diametroInt90 = "", diametroInt135 = "";
            string aplastamiento0 = "", aplastamiento45 = "", aplastamiento90 = "", aplastamiento135 = "";
            string ay0 = "", ay45 = "", ay90 = "", ay135 = "";
            string TiempoEnsayo0 = "", tiempoEnsayo45 = "", tiempoEnsayo90 = "", tiempoEnsayo145 = "";
            string velocidad = "", temperatura = "", noTubo = "";

            //Resultado
            var resultQRY = ResultadoService.ReadResultado().Where(x => x.ProductoId == resultado.ProductoId && x.FechaPrueba == resultado.FechaPrueba).ToList();

            
                for (int i = 0; i < resultQRY.Count; i++)
                {
                    if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                    {
                        if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-014-CNCP")
                        {
                            var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                            for (int j = 0; j < resultDetalle.Count; j++)
                            {
                                switch (resultDetalle[j].MuestraNum)
                                { 
                                    case 1:
                                        resultado1 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 2:
                                        resultado2 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 3:
                                        resultado3 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                    case 4:
                                        resultado4 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        break;
                                }
                                var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                                for (int ad = 0; ad < atributoDetalle.Count; ad++)
                                {
                                    switch (atributoDetalle[ad].AtributoId)
                                    {
                                        case 13:
                                            if (resultDetalle[j].MuestraNum == 1)
                                            {
                                                velocidad = atributoDetalle[ad].Valor;
                                            }
                                            break;
                                        case 14:
                                            if (resultDetalle[j].MuestraNum == 1)
                                            {
                                                temperatura = atributoDetalle[ad].Valor;
                                            }
                                            break;
                                        case 15:
                                            if (resultDetalle[j].MuestraNum == 1)
                                            {
                                                if (longitud0 == "")
                                                {
                                                    longitud0 = atributoDetalle[ad].Valor;
                                                }
                                                else if (longitud45 == "")
                                                {
                                                    longitud45 = atributoDetalle[ad].Valor;
                                                }
                                                else if(longitud90 == "")
                                                {
                                                    longitud90 = atributoDetalle[ad].Valor;
                                                }
                                                else if (longitud135 == "")
                                                {
                                                    longitud135 = atributoDetalle[ad].Valor;
                                                }
                                                
                                                resultado1 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                            }                                            
                                            break;
                                        case 16:
                                            if (resultDetalle[j].MuestraNum == 1)
                                            {
                                                if (diametroInt0 == "")
                                                {
                                                    diametroInt0 = atributoDetalle[ad].Valor;
                                                }
                                                else if (diametroInt45 == "")
                                                {
                                                    diametroInt45 = atributoDetalle[ad].Valor;
                                                }
                                                else if (diametroInt90 == "")
                                                {
                                                    diametroInt90 = atributoDetalle[ad].Valor;
                                                }
                                                else if (diametroInt135 == "")
                                                {
                                                    diametroInt135 = atributoDetalle[ad].Valor;
                                                }                                                
                                            }                                            
                                            break;
                                        case 17:
                                            if (resultDetalle[j].MuestraNum == 1)
                                            {
                                                if (TiempoEnsayo0 == "")
                                                {
                                                    TiempoEnsayo0 = atributoDetalle[ad].Valor;
                                                }
                                                else if (tiempoEnsayo45 == "")
                                                {
                                                    tiempoEnsayo45 = atributoDetalle[ad].Valor;
                                                }
                                                else if (tiempoEnsayo90 == "")
                                                {
                                                    tiempoEnsayo90 = atributoDetalle[ad].Valor;
                                                }
                                                else if (tiempoEnsayo145 == "")
                                                {
                                                    tiempoEnsayo145 = atributoDetalle[ad].Valor;
                                                }
                                                
                                            }
                                            break;
                                        case 18:
                                            if (resultDetalle[j].MuestraNum == 1)
                                            {
                                                if (aplastamiento0 == "")
                                                {
                                                    aplastamiento0 = atributoDetalle[ad].Valor;
                                                }
                                                else if(aplastamiento45 == "")
                                                {
                                                    aplastamiento45 = atributoDetalle[ad].Valor;
                                                }
                                                else if (aplastamiento90 == "")
                                                {
                                                    aplastamiento90 = atributoDetalle[ad].Valor;
                                                }
                                                else if (aplastamiento135 == "")
                                                {
                                                    aplastamiento135 = atributoDetalle[ad].Valor;
                                                }
                                            }
                                            break;
                                        case 106:
                                            if (resultDetalle[j].MuestraNum == 1)
                                            {
                                                if (ay0 == "")
                                                {
                                                    ay0 = atributoDetalle[ad].Valor;
                                                }
                                                else if (ay45 == "")
                                                {
                                                    ay45 = atributoDetalle[ad].Valor;
                                                }
                                                else if (ay90 == "")
                                                {
                                                    ay90 = atributoDetalle[ad].Valor;
                                                }
                                                else if (ay135 == "")
                                                {
                                                    ay135 = atributoDetalle[ad].Valor;
                                                }                                                
                                            }
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

                BsdReportDataSource rds = new BsdReportDataSource("DsAplastamiento", resultQRY);
                BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
                BsdReportDataSource rds3 = new BsdReportDataSource("DsProducto", resultProducto);
                BsdReportDataSource rds4 = new BsdReportDataSource("DsTurno", listTurno);
                BsdReportDataSource rds5 = new BsdReportDataSource("DsEquipo", resultEquipo);
                BsdReportDataSource rds6 = new BsdReportDataSource("DsNorma", listNorma);
                BsdReportDataSource rds7 = new BsdReportDataSource("DsDiametro", listDiametro);

                BsdReportParameter parameter1 = new BsdReportParameter("Longitud0", longitud0, true);
                BsdReportParameter parameter2 = new BsdReportParameter("Longitud45", longitud45, true);
                BsdReportParameter parameter3 = new BsdReportParameter("Longitud90", longitud90, true);
                BsdReportParameter parameter4 = new BsdReportParameter("Longitud135", longitud135, true);
                BsdReportParameter parameter5 = new BsdReportParameter("Diametro0", diametroInt0, true);
                BsdReportParameter parameter6 = new BsdReportParameter("Diametro45", diametroInt45, true);
                BsdReportParameter parameter7 = new BsdReportParameter("Diametro90", diametroInt90, true);
                BsdReportParameter parameter8 = new BsdReportParameter("Diametro135", diametroInt135, true);
                BsdReportParameter parameter9 = new BsdReportParameter("Aplastamiento0", aplastamiento0, true);
                BsdReportParameter parameter10 = new BsdReportParameter("Aplastamiento45", aplastamiento45, true);
                BsdReportParameter parameter11 = new BsdReportParameter("Aplastamiento90", aplastamiento90, true);
                BsdReportParameter parameter12 = new BsdReportParameter("Aplastamiento135", aplastamiento135, true);
                BsdReportParameter parameter13 = new BsdReportParameter("Ay0", ay0, true);
                BsdReportParameter parameter14 = new BsdReportParameter("Ay45", ay45, true);
                BsdReportParameter parameter15 = new BsdReportParameter("Ay90", ay90, true);
                BsdReportParameter parameter16 = new BsdReportParameter("Ay135", ay135, true);
                BsdReportParameter parameter17 = new BsdReportParameter("Tiempo0", TiempoEnsayo0, true);
                BsdReportParameter parameter18 = new BsdReportParameter("Tiempo45", tiempoEnsayo45, true);
                BsdReportParameter parameter19 = new BsdReportParameter("Tiempo90", tiempoEnsayo90, true);
                BsdReportParameter parameter20 = new BsdReportParameter("Tiempo135", tiempoEnsayo145, true);
                BsdReportParameter parameter21 = new BsdReportParameter("Resultado0", resultado1, true);
                BsdReportParameter parameter22 = new BsdReportParameter("Resultado45", resultado2, true);
                BsdReportParameter parameter23 = new BsdReportParameter("Resultado90", resultado3, true);
                BsdReportParameter parameter24 = new BsdReportParameter("Resultado135", resultado4, true);
                BsdReportParameter parameter25 = new BsdReportParameter("Velocidad", velocidad, true);
                BsdReportParameter parameter26 = new BsdReportParameter("Temperatura", temperatura, true);
                BsdReportParameter parameter27 = new BsdReportParameter("NoTubo", noTubo, true);

                IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
                ds.Add(rds);
                ds.Add(rds2);
                ds.Add(rds3);
                ds.Add(rds4);
                ds.Add(rds5);
                ds.Add(rds6);
                ds.Add(rds7);

                BsdReport report = new BsdReport("Reporte de Aplastamiento", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
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

                BsdReportResult result = ReportViewerService.CreateReport(report);

                return File(result.Content, result.MimeType);  

        }

        [HttpGet]
        public ActionResult Generar(long id)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteAplastamiento.rdlc");

            string resultado1 = "", resultado2 = "", resultado3 = "", resultado4 = "";
            string longitud0 = "", longitud45 = "", longitud90 = "", longitud135 = "";
            string diametroInt0 = "", diametroInt45 = "", diametroInt90 = "", diametroInt135 = "";
            string aplastamiento0 = "", aplastamiento45 = "", aplastamiento90 = "", aplastamiento135 = "";
            string ay0 = "", ay45 = "", ay90 = "", ay135 = "";
            string TiempoEnsayo0 = "", tiempoEnsayo45 = "", tiempoEnsayo90 = "", tiempoEnsayo145 = "";
            string velocidad = "", temperatura = "", noTubo = "";

            var resultQRY = ResultadoService.ReadResultadoByLote(id).ToList();

            for (int i = 0; i < resultQRY.Count; i++)
            {
                if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                {
                    if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-014-CNCP")
                    {
                        var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                        for (int j = 0; j < resultDetalle.Count; j++)
                        {
                            switch (resultDetalle[j].MuestraNum)
                            {
                                case 1:
                                    resultado1 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                    break;
                                case 2:
                                    resultado2 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                    break;
                                case 3:
                                    resultado3 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                    break;
                                case 4:
                                    resultado4 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                    break;
                            }
                            var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                            for (int ad = 0; ad < atributoDetalle.Count; ad++)
                            {
                                switch (atributoDetalle[ad].AtributoId)
                                {
                                    case 13:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            velocidad = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 14:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            temperatura = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 15:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            if (longitud0 == "")
                                            {
                                                longitud0 = atributoDetalle[ad].Valor;
                                            }
                                            else if (longitud45 == "")
                                            {
                                                longitud45 = atributoDetalle[ad].Valor;
                                            }
                                            else if (longitud90 == "")
                                            {
                                                longitud90 = atributoDetalle[ad].Valor;
                                            }
                                            else if (longitud135 == "")
                                            {
                                                longitud135 = atributoDetalle[ad].Valor;
                                            }

                                            resultado1 = resultDetalle[j].ResultadoDetalleValor.ToString();
                                        }
                                        break;
                                    case 16:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            if (diametroInt0 == "")
                                            {
                                                diametroInt0 = atributoDetalle[ad].Valor;
                                            }
                                            else if (diametroInt45 == "")
                                            {
                                                diametroInt45 = atributoDetalle[ad].Valor;
                                            }
                                            else if (diametroInt90 == "")
                                            {
                                                diametroInt90 = atributoDetalle[ad].Valor;
                                            }
                                            else if (diametroInt135 == "")
                                            {
                                                diametroInt135 = atributoDetalle[ad].Valor;
                                            }
                                        }
                                        break;
                                    case 17:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            if (TiempoEnsayo0 == "")
                                            {
                                                TiempoEnsayo0 = atributoDetalle[ad].Valor;
                                            }
                                            else if (tiempoEnsayo45 == "")
                                            {
                                                tiempoEnsayo45 = atributoDetalle[ad].Valor;
                                            }
                                            else if (tiempoEnsayo90 == "")
                                            {
                                                tiempoEnsayo90 = atributoDetalle[ad].Valor;
                                            }
                                            else if (tiempoEnsayo145 == "")
                                            {
                                                tiempoEnsayo145 = atributoDetalle[ad].Valor;
                                            }

                                        }
                                        break;
                                    case 18:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            if (aplastamiento0 == "")
                                            {
                                                aplastamiento0 = atributoDetalle[ad].Valor;
                                            }
                                            else if (aplastamiento45 == "")
                                            {
                                                aplastamiento45 = atributoDetalle[ad].Valor;
                                            }
                                            else if (aplastamiento90 == "")
                                            {
                                                aplastamiento90 = atributoDetalle[ad].Valor;
                                            }
                                            else if (aplastamiento135 == "")
                                            {
                                                aplastamiento135 = atributoDetalle[ad].Valor;
                                            }
                                        }
                                        break;
                                    case 106:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            if (ay0 == "")
                                            {
                                                ay0 = atributoDetalle[ad].Valor;
                                            }
                                            else if (ay45 == "")
                                            {
                                                ay45 = atributoDetalle[ad].Valor;
                                            }
                                            else if (ay90 == "")
                                            {
                                                ay90 = atributoDetalle[ad].Valor;
                                            }
                                            else if (ay135 == "")
                                            {
                                                ay135 = atributoDetalle[ad].Valor;
                                            }
                                        }
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

            BsdReportDataSource rds = new BsdReportDataSource("DsAplastamiento", resultQRY);
            BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
            BsdReportDataSource rds3 = new BsdReportDataSource("DsProducto", resultProducto);
            BsdReportDataSource rds4 = new BsdReportDataSource("DsTurno", listTurno);
            BsdReportDataSource rds5 = new BsdReportDataSource("DsEquipo", resultEquipo);
            BsdReportDataSource rds6 = new BsdReportDataSource("DsNorma", listNorma);
            BsdReportDataSource rds7 = new BsdReportDataSource("DsDiametro", listDiametro);

            BsdReportParameter parameter1 = new BsdReportParameter("Longitud0", longitud0, true);
            BsdReportParameter parameter2 = new BsdReportParameter("Longitud45", longitud45, true);
            BsdReportParameter parameter3 = new BsdReportParameter("Longitud90", longitud90, true);
            BsdReportParameter parameter4 = new BsdReportParameter("Longitud135", longitud135, true);
            BsdReportParameter parameter5 = new BsdReportParameter("Diametro0", diametroInt0, true);
            BsdReportParameter parameter6 = new BsdReportParameter("Diametro45", diametroInt45, true);
            BsdReportParameter parameter7 = new BsdReportParameter("Diametro90", diametroInt90, true);
            BsdReportParameter parameter8 = new BsdReportParameter("Diametro135", diametroInt135, true);
            BsdReportParameter parameter9 = new BsdReportParameter("Aplastamiento0", aplastamiento0, true);
            BsdReportParameter parameter10 = new BsdReportParameter("Aplastamiento45", aplastamiento45, true);
            BsdReportParameter parameter11 = new BsdReportParameter("Aplastamiento90", aplastamiento90, true);
            BsdReportParameter parameter12 = new BsdReportParameter("Aplastamiento135", aplastamiento135, true);
            BsdReportParameter parameter13 = new BsdReportParameter("Ay0", ay0, true);
            BsdReportParameter parameter14 = new BsdReportParameter("Ay45", ay45, true);
            BsdReportParameter parameter15 = new BsdReportParameter("Ay90", ay90, true);
            BsdReportParameter parameter16 = new BsdReportParameter("Ay135", ay135, true);
            BsdReportParameter parameter17 = new BsdReportParameter("Tiempo0", TiempoEnsayo0, true);
            BsdReportParameter parameter18 = new BsdReportParameter("Tiempo45", tiempoEnsayo45, true);
            BsdReportParameter parameter19 = new BsdReportParameter("Tiempo90", tiempoEnsayo90, true);
            BsdReportParameter parameter20 = new BsdReportParameter("Tiempo135", tiempoEnsayo145, true);
            BsdReportParameter parameter21 = new BsdReportParameter("Resultado0", resultado1, true);
            BsdReportParameter parameter22 = new BsdReportParameter("Resultado45", resultado2, true);
            BsdReportParameter parameter23 = new BsdReportParameter("Resultado90", resultado3, true);
            BsdReportParameter parameter24 = new BsdReportParameter("Resultado135", resultado4, true);
            BsdReportParameter parameter25 = new BsdReportParameter("Velocidad", velocidad, true);
            BsdReportParameter parameter26 = new BsdReportParameter("Temperatura", temperatura, true);
            BsdReportParameter parameter27 = new BsdReportParameter("NoTubo", noTubo, true);

            IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
            ds.Add(rds);
            ds.Add(rds2);
            ds.Add(rds3);
            ds.Add(rds4);
            ds.Add(rds5);
            ds.Add(rds6);
            ds.Add(rds7);

            BsdReport report = new BsdReport("Reporte de Aplastamiento", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
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

            BsdReportResult result = ReportViewerService.CreateReport(report);

            return File(result.Content, result.MimeType);  


        }

        [HttpPost]
        public ActionResult GenerarReporte(Resultado resultado)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteAplastamiento.rdlc");

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

        private RpteAplastamientoViewModel GetModel(Lote lote)
        {
            return new RpteAplastamientoViewModel(lote, ProductoService.ReadProducto());
        }

    }
}
