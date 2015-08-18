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
using System.Globalization;
using ADS.LAPEM.Web.Infrastructure.Grid;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Web.Areas.Reporte.Controllers
{
    public class RpteRigidezController : BaseController
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
        // GET: /Reporte/RpteRigidez/

        public ActionResult Index()
        {
            return View(GetModel(new Lote()));
        }

        [HttpPost]
        public ActionResult GenerarRepo(Resultado resultado)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteRigidez.rdlc");

            string DiamIniMedido = "", DiamIniCorreccion = "", DiamIniCorregido = "";
            string DiamIniMedido2 = "", DiamIniCorreccion2 = "", DiamIniCorregido2 = "";
            string DiamIniMedido3 = "", DiamIniCorreccion3 = "", DiamIniCorregido3 = "";
            string DiamIniMedido4 = "", DiamIniCorreccion4 = "", DiamIniCorregido4 = "";
            string LongMedido = "", LongCorreccion = "", LongCorregido = "";
            string LongMedido2 = "", LongCorreccion2 = "", LongCorregido2 = "";
            string LongMedido3 = "", LongCorreccion3 = "", LongCorregido3 = "";
            string LongMedido4 = "", LongCorreccion4 = "", LongCorregido4 = "";
            string DiamFinMedido = "", DiamFinCorreccion = "", DiamFinCorregido = "";
            string DiamFinMedido2 = "", DiamFinCorreccion2 = "", DiamFinCorregido2 = "";
            string DiamFinMedido3 = "", DiamFinCorreccion3 = "", DiamFinCorregido3 = "";
            string DiamFinMedido4 = "", DiamFinCorreccion4 = "", DiamFinCorregido4 = "";
            string FuerzaMedido = "", FuerzaCorreccion = "", FuerzaCorregido = "";
            string FuerzaMedido2 = "", FuerzaCorreccion2 = "", FuerzaCorregido2 = "";
            string FuerzaMedido3 = "", FuerzaCorreccion3 = "", FuerzaCorregido3 = "";
            string FuerzaMedido4 = "", FuerzaCorreccion4 = "", FuerzaCorregido4 = "";
            string AyMedido = "", AyCorreccion = "", AyCorregido = "";
            string AyMedido2 = "", AyCorreccion2 = "", AyCorregido2 = "";
            string AyMedido3 = "", AyCorreccion3 = "", AyCorregido3 = "";
            string AyMedido4 = "", AyCorreccion4 = "", AyCorregido4 = "";
            string RigidezMedido = "", RigidezCorrec = "", RigidezCorregido = "";
            string RigidezMedido2 = "", RigidezCorrec2 = "", RigidezCorregido2 = "";
            string RigidezMedido3 = "", RigidezCorrec3 = "", RigidezCorregido3 = "";
            string RigidezMedido4 = "", RigidezCorrec4 = "", RigidezCorregido4 = "";
            string Temperatura = "", Especimen = "", Resultado = "", Humedad = "", Velocidad = "";
            string NoTubo = "";
            string Resultado1 = "", Resultado2 = "", Resultado3 = "", Resultado4 = "";


            //Resultado
            var resultQRY = ResultadoService.ReadResultado().Where(x => x.ProductoId == resultado.ProductoId && x.FechaPrueba == resultado.FechaPrueba).ToList();

            for (int i = 0; i < resultQRY.Count; i++)
            {
                if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                {
                    if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-208-CNCP")
                    {
                        var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                        for (int j = 0; j < resultDetalle.Count; j++)
                        {
                            if (resultDetalle[j].MuestraNum == 1)
                            {
                                Resultado1 = resultDetalle[j].ResultadoDetalleValor.ToString();
                            }
                            else if (resultDetalle[j].MuestraNum == 2)
                            {
                                Resultado2 = resultDetalle[j].ResultadoDetalleValor.ToString();
                            }
                            else if (resultDetalle[j].MuestraNum == 3)
                            { 
                                Resultado3 = resultDetalle[j].ResultadoDetalleValor.ToString();
                            }
                            else if (resultDetalle[j].MuestraNum == 4)
                            {
                                Resultado4 = resultDetalle[j].ResultadoDetalleValor.ToString();
                            }
                            var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                            for (int ad = 0; ad < atributoDetalle.Count; ad++)
                            {
                                switch (atributoDetalle[ad].AtributoId)
                                {
                                    case 54:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            DiamIniMedido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            DiamIniMedido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            DiamIniMedido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            DiamIniMedido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 55:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            DiamIniCorreccion = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            DiamIniCorreccion2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            DiamIniCorreccion3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            DiamIniCorreccion4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 56:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            DiamIniCorregido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            DiamIniCorregido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            DiamIniCorregido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            DiamIniCorregido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 57:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            LongMedido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            LongMedido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            LongMedido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            LongMedido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 58:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            LongCorreccion   = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            LongCorreccion2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            LongCorreccion3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            LongCorreccion4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 59:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            LongCorregido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            LongCorregido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            LongCorregido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            LongCorregido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 60:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            DiamFinMedido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            DiamFinMedido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            DiamFinMedido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            DiamFinMedido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 61:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            DiamFinCorreccion = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            DiamFinCorreccion2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            DiamFinCorreccion3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            DiamFinCorreccion4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 62:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            DiamFinCorregido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            DiamFinCorregido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            DiamFinCorregido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            DiamFinCorregido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 63:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            FuerzaMedido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            FuerzaMedido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            FuerzaMedido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            FuerzaMedido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 64:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            FuerzaCorreccion = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            FuerzaCorreccion2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            FuerzaCorreccion3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            FuerzaCorreccion4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 65:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            FuerzaCorregido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            FuerzaCorregido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            FuerzaCorregido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            FuerzaCorregido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 66:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            AyMedido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            AyMedido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            AyMedido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            AyMedido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 67:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            AyCorreccion = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            AyCorreccion2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            AyCorreccion3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            AyCorreccion4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 68:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            AyCorregido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            AyCorregido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            AyCorregido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            AyCorregido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 69:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            RigidezMedido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            RigidezMedido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            RigidezMedido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            RigidezMedido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 70:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            RigidezCorrec = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            RigidezCorrec2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            RigidezCorrec3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            RigidezCorrec4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 71:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            RigidezCorregido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            RigidezCorregido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            RigidezCorregido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            RigidezCorregido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 72:
                                        Temperatura = atributoDetalle[ad].Valor;
                                        break;
                                    case 73:
                                        Especimen = atributoDetalle[ad].Valor;
                                        break;
                                    case 74:
                                        Resultado = atributoDetalle[ad].Valor;
                                        break;
                                    case 75:
                                        Humedad = atributoDetalle[ad].Valor;
                                        break;
                                    case 76:
                                        Velocidad = atributoDetalle[ad].Valor;
                                        break;
                                    case 157:
                                        NoTubo = atributoDetalle[ad].Valor;
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

            BsdReportDataSource rds = new BsdReportDataSource("DsRigidez", resultQRY);
            BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
            BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle2);
            BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
            BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);
            BsdReportDataSource rds6 = new BsdReportDataSource("DsEquipo", resultEquipo);
            BsdReportDataSource rds7 = new BsdReportDataSource("DsNorma", listNorma);
            BsdReportDataSource rds8 = new BsdReportDataSource("DsMDiametro", listDiametro);

            BsdReportParameter parameter1 = new BsdReportParameter("DiametroInicialMedido", DiamIniMedido, true);
            BsdReportParameter parameter2 = new BsdReportParameter("DiametroInicialCorreccion", DiamIniCorreccion, true);
            BsdReportParameter parameter3 = new BsdReportParameter("DiametroInicialCorregido", DiamIniCorregido, true);
            BsdReportParameter parameter4 = new BsdReportParameter("LongitudMedido", LongMedido, true);
            BsdReportParameter parameter5 = new BsdReportParameter("LongitudCorreccion", LongCorreccion, true);
            BsdReportParameter parameter6 = new BsdReportParameter("LongitudCorregido", LongCorregido, true);
            BsdReportParameter parameter7 = new BsdReportParameter("DiametroFinalMedido", DiamFinMedido, true);
            BsdReportParameter parameter8 = new BsdReportParameter("DiametroFinalCorreccion", DiamFinCorreccion, true);
            BsdReportParameter parameter9 = new BsdReportParameter("DiametroFinalCorregido", DiamFinCorregido, true);
            BsdReportParameter parameter10 = new BsdReportParameter("FuerzaMedido", FuerzaMedido, true);
            BsdReportParameter parameter11 = new BsdReportParameter("FuerzaCorreccion", FuerzaCorreccion, true);
            BsdReportParameter parameter12 = new BsdReportParameter("FuerzaCorregido", FuerzaCorregido, true);
            BsdReportParameter parameter13 = new BsdReportParameter("AyMedido", AyMedido, true);
            BsdReportParameter parameter14 = new BsdReportParameter("AyCorreccion", AyCorreccion, true);
            BsdReportParameter parameter15 = new BsdReportParameter("AyCorregido", AyCorregido, true);
            BsdReportParameter parameter16 = new BsdReportParameter("RigidezMedido", RigidezMedido, true);
            BsdReportParameter parameter17 = new BsdReportParameter("RigidezCorreccion", RigidezCorrec, true);
            BsdReportParameter parameter18 = new BsdReportParameter("RigidezCorregido", RigidezCorregido, true);
            BsdReportParameter parameter19 = new BsdReportParameter("TemperaturaRigidez", Temperatura, true);
            BsdReportParameter parameter20 = new BsdReportParameter("EspecimenAdhesion", Especimen, true);
            BsdReportParameter parameter21 = new BsdReportParameter("ResultadoAdhesion", Resultado, true);
            BsdReportParameter parameter22 = new BsdReportParameter("HumedadRigidez", Humedad, true);
            BsdReportParameter parameter23 = new BsdReportParameter("VelocidadEnsayoRigidez", Velocidad, true);
            BsdReportParameter parameter24 = new BsdReportParameter("DiametroInicialMedido2", DiamFinMedido2, true);
            BsdReportParameter parameter25 = new BsdReportParameter("DiametroInicialMedido3", DiamFinMedido3, true);
            BsdReportParameter parameter26 = new BsdReportParameter("DiametroInicialMedido4", DiamFinMedido4, true);
            BsdReportParameter parameter27 = new BsdReportParameter("DiametroInicialCorreccion2", DiamIniCorreccion2, true);
            BsdReportParameter parameter28 = new BsdReportParameter("DiametroInicialCorreccion3", DiamIniCorreccion3, true);
            BsdReportParameter parameter29 = new BsdReportParameter("DiametroInicialCorreccion4", DiamIniCorreccion4, true);
            BsdReportParameter parameter30 = new BsdReportParameter("DiametroInicialCorregido2", DiamIniCorregido2, true);
            BsdReportParameter parameter31 = new BsdReportParameter("DiametroInicialCorregido3", DiamIniCorregido3, true);
            BsdReportParameter parameter32 = new BsdReportParameter("DiametroInicialCorregido4", DiamIniCorregido4, true);
            BsdReportParameter parameter33 = new BsdReportParameter("FuerzaMedido2", FuerzaMedido2, true);
            BsdReportParameter parameter34 = new BsdReportParameter("FuerzaMedido3", FuerzaMedido3, true);
            BsdReportParameter parameter35 = new BsdReportParameter("FuerzaMedido4", FuerzaMedido4, true);
            BsdReportParameter parameter36 = new BsdReportParameter("FuerzaCorreccion2", FuerzaCorreccion2, true);
            BsdReportParameter parameter37 = new BsdReportParameter("FuerzaCorreccion3", FuerzaCorreccion3, true);
            BsdReportParameter parameter38 = new BsdReportParameter("FuerzaCorreccion4", FuerzaCorreccion4, true);
            BsdReportParameter parameter39 = new BsdReportParameter("FuerzaCorregido2", FuerzaCorregido2, true);
            BsdReportParameter parameter40 = new BsdReportParameter("FuerzaCorregido3", FuerzaCorregido3, true);
            BsdReportParameter parameter41 = new BsdReportParameter("FuerzaCorregido4", FuerzaCorregido4, true);
            BsdReportParameter parameter42 = new BsdReportParameter("AyMedido2", AyMedido2, true);
            BsdReportParameter parameter43 = new BsdReportParameter("AyMedido3", AyMedido3, true);
            BsdReportParameter parameter44 = new BsdReportParameter("AyMedido4", AyMedido4, true);
            BsdReportParameter parameter45 = new BsdReportParameter("AyCorreccion2", AyCorreccion2, true);
            BsdReportParameter parameter46 = new BsdReportParameter("AyCorreccion3", AyCorreccion3, true);
            BsdReportParameter parameter47 = new BsdReportParameter("AyCorreccion4", AyCorreccion4, true);
            BsdReportParameter parameter48 = new BsdReportParameter("AyCorregido2", AyCorregido2, true);
            BsdReportParameter parameter49 = new BsdReportParameter("AyCorregido3", AyCorregido3, true);
            BsdReportParameter parameter50 = new BsdReportParameter("AyCorregido4", AyCorregido4, true);
            BsdReportParameter parameter51 = new BsdReportParameter("RigidezMedido2", RigidezMedido2, true);
            BsdReportParameter parameter52 = new BsdReportParameter("RigidezMedido3", RigidezMedido3, true);
            BsdReportParameter parameter53 = new BsdReportParameter("RigidezMedido4", RigidezMedido4, true);
            BsdReportParameter parameter54 = new BsdReportParameter("RigidezCorreccion2", RigidezCorrec2, true);
            BsdReportParameter parameter55 = new BsdReportParameter("RigidezCorreccion3", RigidezCorrec3, true);
            BsdReportParameter parameter56 = new BsdReportParameter("RigidezCorreccion4", RigidezCorrec4, true);
            BsdReportParameter parameter57 = new BsdReportParameter("RigidezCorregido2", RigidezCorregido2, true);
            BsdReportParameter parameter58 = new BsdReportParameter("RigidezCorregido3", RigidezCorregido3, true);
            BsdReportParameter parameter59 = new BsdReportParameter("RigidezCorregido4", RigidezCorregido4, true);
            BsdReportParameter parameter60 = new BsdReportParameter("LongitudMedido2", LongMedido2, true);
            BsdReportParameter parameter61 = new BsdReportParameter("LongitudMedido3", LongMedido3, true);
            BsdReportParameter parameter62 = new BsdReportParameter("LongitudMedido4", LongMedido4, true);
            BsdReportParameter parameter63 = new BsdReportParameter("LongitudCorreccion2", LongCorreccion2, true);
            BsdReportParameter parameter64 = new BsdReportParameter("LongitudCorreccion3", LongCorreccion3, true);
            BsdReportParameter parameter65 = new BsdReportParameter("LongitudCorreccion4", LongCorreccion4, true);
            BsdReportParameter parameter66 = new BsdReportParameter("LongitudCorregido2", LongCorregido2, true);
            BsdReportParameter parameter67 = new BsdReportParameter("LongitudCorregido3", LongCorregido3, true);
            BsdReportParameter parameter68 = new BsdReportParameter("LongitudCorregido4", LongCorregido4, true);
            BsdReportParameter parameter69 = new BsdReportParameter("DiametroFinalMedido2", DiamFinMedido2, true);
            BsdReportParameter parameter70 = new BsdReportParameter("DiametroFinalMedido3", DiamFinMedido3, true);
            BsdReportParameter parameter71 = new BsdReportParameter("DiametroFinalMedido4", DiamFinMedido4, true);
            BsdReportParameter parameter72 = new BsdReportParameter("DiametroFinalCorreccion2", DiamFinCorreccion2, true);
            BsdReportParameter parameter73 = new BsdReportParameter("DiametroFinalCorreccion3", DiamFinCorreccion3, true);
            BsdReportParameter parameter74 = new BsdReportParameter("DiametroFinalCorreccion4", DiamFinCorreccion4, true);
            BsdReportParameter parameter75 = new BsdReportParameter("DiametroFinalCorregido2", DiamFinCorregido2, true);
            BsdReportParameter parameter76 = new BsdReportParameter("DiametroFinalCorregido3", DiamFinCorregido3, true);
            BsdReportParameter parameter77 = new BsdReportParameter("DiametroFinalCorregido4", DiamFinCorregido4, true);
            BsdReportParameter parameter78 = new BsdReportParameter("NoTubo", NoTubo, true);
            BsdReportParameter parameter79 = new BsdReportParameter("Resultado1", Resultado1, true);
            BsdReportParameter parameter80 = new BsdReportParameter("Resultado2", Resultado2, true);
            BsdReportParameter parameter81 = new BsdReportParameter("Resultado3", Resultado3, true);
            BsdReportParameter parameter82 = new BsdReportParameter("Resultado4", Resultado4, true);

            IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
            ds.Add(rds);
            ds.Add(rds2);
            ds.Add(rds3);
            ds.Add(rds4);
            ds.Add(rds5);
            ds.Add(rds6);
            ds.Add(rds7);
            ds.Add(rds8);

            BsdReport report = new BsdReport("Reporte de Rigidez", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
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
            report.Parameters.Add(parameter41);
            report.Parameters.Add(parameter42);
            report.Parameters.Add(parameter43);
            report.Parameters.Add(parameter44);
            report.Parameters.Add(parameter45);
            report.Parameters.Add(parameter46);
            report.Parameters.Add(parameter47);
            report.Parameters.Add(parameter48);
            report.Parameters.Add(parameter49);
            report.Parameters.Add(parameter50);
            report.Parameters.Add(parameter51);
            report.Parameters.Add(parameter52);
            report.Parameters.Add(parameter53);
            report.Parameters.Add(parameter54);
            report.Parameters.Add(parameter55);
            report.Parameters.Add(parameter56);
            report.Parameters.Add(parameter57);
            report.Parameters.Add(parameter58);
            report.Parameters.Add(parameter59);
            report.Parameters.Add(parameter60);
            report.Parameters.Add(parameter61);
            report.Parameters.Add(parameter62);
            report.Parameters.Add(parameter63);
            report.Parameters.Add(parameter64);
            report.Parameters.Add(parameter65);
            report.Parameters.Add(parameter66);
            report.Parameters.Add(parameter67);
            report.Parameters.Add(parameter68);
            report.Parameters.Add(parameter69);
            report.Parameters.Add(parameter70);
            report.Parameters.Add(parameter71);
            report.Parameters.Add(parameter72);
            report.Parameters.Add(parameter73);
            report.Parameters.Add(parameter74);
            report.Parameters.Add(parameter75);
            report.Parameters.Add(parameter76);
            report.Parameters.Add(parameter77);
            report.Parameters.Add(parameter78);
            report.Parameters.Add(parameter79);
            report.Parameters.Add(parameter80);
            report.Parameters.Add(parameter81);
            report.Parameters.Add(parameter82);

            BsdReportResult result = ReportViewerService.CreateReport(report);

            return File(result.Content, result.MimeType);  
        }

        [HttpGet]
        public ActionResult Generar(long id)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteRigidez.rdlc");

            string DiamIniMedido = "", DiamIniCorreccion = "", DiamIniCorregido = "";
            string DiamIniMedido2 = "", DiamIniCorreccion2 = "", DiamIniCorregido2 = "";
            string DiamIniMedido3 = "", DiamIniCorreccion3 = "", DiamIniCorregido3 = "";
            string DiamIniMedido4 = "", DiamIniCorreccion4 = "", DiamIniCorregido4 = "";
            string LongMedido = "", LongCorreccion = "", LongCorregido = "";
            string LongMedido2 = "", LongCorreccion2 = "", LongCorregido2 = "";
            string LongMedido3 = "", LongCorreccion3 = "", LongCorregido3 = "";
            string LongMedido4 = "", LongCorreccion4 = "", LongCorregido4 = "";
            string DiamFinMedido = "", DiamFinCorreccion = "", DiamFinCorregido = "";
            string DiamFinMedido2 = "", DiamFinCorreccion2 = "", DiamFinCorregido2 = "";
            string DiamFinMedido3 = "", DiamFinCorreccion3 = "", DiamFinCorregido3 = "";
            string DiamFinMedido4 = "", DiamFinCorreccion4 = "", DiamFinCorregido4 = "";
            string FuerzaMedido = "", FuerzaCorreccion = "", FuerzaCorregido = "";
            string FuerzaMedido2 = "", FuerzaCorreccion2 = "", FuerzaCorregido2 = "";
            string FuerzaMedido3 = "", FuerzaCorreccion3 = "", FuerzaCorregido3 = "";
            string FuerzaMedido4 = "", FuerzaCorreccion4 = "", FuerzaCorregido4 = "";
            string AyMedido = "", AyCorreccion = "", AyCorregido = "";
            string AyMedido2 = "", AyCorreccion2 = "", AyCorregido2 = "";
            string AyMedido3 = "", AyCorreccion3 = "", AyCorregido3 = "";
            string AyMedido4 = "", AyCorreccion4 = "", AyCorregido4 = "";
            string RigidezMedido = "", RigidezCorrec = "", RigidezCorregido = "";
            string RigidezMedido2 = "", RigidezCorrec2 = "", RigidezCorregido2 = "";
            string RigidezMedido3 = "", RigidezCorrec3 = "", RigidezCorregido3 = "";
            string RigidezMedido4 = "", RigidezCorrec4 = "", RigidezCorregido4 = "";
            string Temperatura = "", Especimen = "", Resultado = "", Humedad = "", Velocidad = "";
            string NoTubo = "";
            string Resultado1 = "", Resultado2 = "", Resultado3 = "", Resultado4 = "";


            //Resultado
            var resultQRY = ResultadoService.ReadResultadoByLote(id).ToList();

            for (int i = 0; i < resultQRY.Count; i++)
            {
                if (resultQRY[i].Norma.Nombre == "NRF-057-CFE-2009")
                {
                    if (resultQRY[i].NormaEnsayo.Nombre == "NMX-E-208-CNCP")
                    {
                        var resultDetalle = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(resultQRY[i].Id).ToList();

                        for (int j = 0; j < resultDetalle.Count; j++)
                        {
                            if (resultDetalle[j].MuestraNum == 1)
                            {
                                Resultado1 = resultDetalle[j].ResultadoDetalleValor.ToString();
                            }
                            else if (resultDetalle[j].MuestraNum == 2)
                            {
                                Resultado2 = resultDetalle[j].ResultadoDetalleValor.ToString();
                            }
                            else if (resultDetalle[j].MuestraNum == 3)
                            {
                                Resultado3 = resultDetalle[j].ResultadoDetalleValor.ToString();
                            }
                            else if (resultDetalle[j].MuestraNum == 4)
                            {
                                Resultado4 = resultDetalle[j].ResultadoDetalleValor.ToString();
                            }
                            var atributoDetalle = AtributoDService.ReadAtributoDetalleByResultadoId(resultDetalle[j].Id).ToList();

                            for (int ad = 0; ad < atributoDetalle.Count; ad++)
                            {
                                switch (atributoDetalle[ad].AtributoId)
                                {
                                    case 54:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            DiamIniMedido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            DiamIniMedido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            DiamIniMedido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            DiamIniMedido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 55:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            DiamIniCorreccion = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            DiamIniCorreccion2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            DiamIniCorreccion3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            DiamIniCorreccion4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 56:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            DiamIniCorregido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            DiamIniCorregido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            DiamIniCorregido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            DiamIniCorregido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 57:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            LongMedido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            LongMedido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            LongMedido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            LongMedido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 58:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            LongCorreccion = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            LongCorreccion2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            LongCorreccion3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            LongCorreccion4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 59:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            LongCorregido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            LongCorregido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            LongCorregido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            LongCorregido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 60:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            DiamFinMedido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            DiamFinMedido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            DiamFinMedido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            DiamFinMedido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 61:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            DiamFinCorreccion = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            DiamFinCorreccion2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            DiamFinCorreccion3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            DiamFinCorreccion4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 62:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            DiamFinCorregido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            DiamFinCorregido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            DiamFinCorregido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            DiamFinCorregido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 63:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            FuerzaMedido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            FuerzaMedido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            FuerzaMedido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            FuerzaMedido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 64:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            FuerzaCorreccion = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            FuerzaCorreccion2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            FuerzaCorreccion3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            FuerzaCorreccion4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 65:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            FuerzaCorregido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            FuerzaCorregido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            FuerzaCorregido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            FuerzaCorregido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 66:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            AyMedido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            AyMedido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            AyMedido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            AyMedido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 67:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            AyCorreccion = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            AyCorreccion2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            AyCorreccion3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            AyCorreccion4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 68:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            AyCorregido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            AyCorregido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            AyCorregido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            AyCorregido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 69:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            RigidezMedido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            RigidezMedido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            RigidezMedido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            RigidezMedido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 70:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            RigidezCorrec = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            RigidezCorrec2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            RigidezCorrec3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            RigidezCorrec4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 71:
                                        if (resultDetalle[j].MuestraNum == 1)
                                        {
                                            RigidezCorregido = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 2)
                                        {
                                            RigidezCorregido2 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 3)
                                        {
                                            RigidezCorregido3 = atributoDetalle[ad].Valor;
                                        }
                                        if (resultDetalle[j].MuestraNum == 4)
                                        {
                                            RigidezCorregido4 = atributoDetalle[ad].Valor;
                                        }
                                        break;
                                    case 72:
                                        Temperatura = atributoDetalle[ad].Valor;
                                        break;
                                    case 73:
                                        Especimen = atributoDetalle[ad].Valor;
                                        break;
                                    case 74:
                                        Resultado = atributoDetalle[ad].Valor;
                                        break;
                                    case 75:
                                        Humedad = atributoDetalle[ad].Valor;
                                        break;
                                    case 76:
                                        Velocidad = atributoDetalle[ad].Valor;
                                        break;
                                    case 157:
                                        NoTubo = atributoDetalle[ad].Valor;
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

            BsdReportDataSource rds = new BsdReportDataSource("DsRigidez", resultQRY);
            BsdReportDataSource rds2 = new BsdReportDataSource("DsLote", listLote);
            BsdReportDataSource rds3 = new BsdReportDataSource("DsDetalle", resultDetalle2);
            BsdReportDataSource rds4 = new BsdReportDataSource("DsProducto", resultProducto);
            BsdReportDataSource rds5 = new BsdReportDataSource("DsTurno", listTurno);
            BsdReportDataSource rds6 = new BsdReportDataSource("DsEquipo", resultEquipo);
            BsdReportDataSource rds7 = new BsdReportDataSource("DsNorma", listNorma);
            BsdReportDataSource rds8 = new BsdReportDataSource("DsMDiametro", listDiametro);

            BsdReportParameter parameter1 = new BsdReportParameter("DiametroInicialMedido", DiamIniMedido, true);
            BsdReportParameter parameter2 = new BsdReportParameter("DiametroInicialCorreccion", DiamIniCorreccion, true);
            BsdReportParameter parameter3 = new BsdReportParameter("DiametroInicialCorregido", DiamIniCorregido, true);
            BsdReportParameter parameter4 = new BsdReportParameter("LongitudMedido", LongMedido, true);
            BsdReportParameter parameter5 = new BsdReportParameter("LongitudCorreccion", LongCorreccion, true);
            BsdReportParameter parameter6 = new BsdReportParameter("LongitudCorregido", LongCorregido, true);
            BsdReportParameter parameter7 = new BsdReportParameter("DiametroFinalMedido", DiamFinMedido, true);
            BsdReportParameter parameter8 = new BsdReportParameter("DiametroFinalCorreccion", DiamFinCorreccion, true);
            BsdReportParameter parameter9 = new BsdReportParameter("DiametroFinalCorregido", DiamFinCorregido, true);
            BsdReportParameter parameter10 = new BsdReportParameter("FuerzaMedido", FuerzaMedido, true);
            BsdReportParameter parameter11 = new BsdReportParameter("FuerzaCorreccion", FuerzaCorreccion, true);
            BsdReportParameter parameter12 = new BsdReportParameter("FuerzaCorregido", FuerzaCorregido, true);
            BsdReportParameter parameter13 = new BsdReportParameter("AyMedido", AyMedido, true);
            BsdReportParameter parameter14 = new BsdReportParameter("AyCorreccion", AyCorreccion, true);
            BsdReportParameter parameter15 = new BsdReportParameter("AyCorregido", AyCorregido, true);
            BsdReportParameter parameter16 = new BsdReportParameter("RigidezMedido", RigidezMedido, true);
            BsdReportParameter parameter17 = new BsdReportParameter("RigidezCorreccion", RigidezCorrec, true);
            BsdReportParameter parameter18 = new BsdReportParameter("RigidezCorregido", RigidezCorregido, true);
            BsdReportParameter parameter19 = new BsdReportParameter("TemperaturaRigidez", Temperatura, true);
            BsdReportParameter parameter20 = new BsdReportParameter("EspecimenAdhesion", Especimen, true);
            BsdReportParameter parameter21 = new BsdReportParameter("ResultadoAdhesion", Resultado, true);
            BsdReportParameter parameter22 = new BsdReportParameter("HumedadRigidez", Humedad, true);
            BsdReportParameter parameter23 = new BsdReportParameter("VelocidadEnsayoRigidez", Velocidad, true);
            BsdReportParameter parameter24 = new BsdReportParameter("DiametroInicialMedido2", DiamFinMedido2, true);
            BsdReportParameter parameter25 = new BsdReportParameter("DiametroInicialMedido3", DiamFinMedido3, true);
            BsdReportParameter parameter26 = new BsdReportParameter("DiametroInicialMedido4", DiamFinMedido4, true);
            BsdReportParameter parameter27 = new BsdReportParameter("DiametroInicialCorreccion2", DiamIniCorreccion2, true);
            BsdReportParameter parameter28 = new BsdReportParameter("DiametroInicialCorreccion3", DiamIniCorreccion3, true);
            BsdReportParameter parameter29 = new BsdReportParameter("DiametroInicialCorreccion4", DiamIniCorreccion4, true);
            BsdReportParameter parameter30 = new BsdReportParameter("DiametroInicialCorregido2", DiamIniCorregido2, true);
            BsdReportParameter parameter31 = new BsdReportParameter("DiametroInicialCorregido3", DiamIniCorregido3, true);
            BsdReportParameter parameter32 = new BsdReportParameter("DiametroInicialCorregido4", DiamIniCorregido4, true);
            BsdReportParameter parameter33 = new BsdReportParameter("FuerzaMedido2", FuerzaMedido2, true);
            BsdReportParameter parameter34 = new BsdReportParameter("FuerzaMedido3", FuerzaMedido3, true);
            BsdReportParameter parameter35 = new BsdReportParameter("FuerzaMedido4", FuerzaMedido4, true);
            BsdReportParameter parameter36 = new BsdReportParameter("FuerzaCorreccion2", FuerzaCorreccion2, true);
            BsdReportParameter parameter37 = new BsdReportParameter("FuerzaCorreccion3", FuerzaCorreccion3, true);
            BsdReportParameter parameter38 = new BsdReportParameter("FuerzaCorreccion4", FuerzaCorreccion4, true);
            BsdReportParameter parameter39 = new BsdReportParameter("FuerzaCorregido2", FuerzaCorregido2, true);
            BsdReportParameter parameter40 = new BsdReportParameter("FuerzaCorregido3", FuerzaCorregido3, true);
            BsdReportParameter parameter41 = new BsdReportParameter("FuerzaCorregido4", FuerzaCorregido4, true);
            BsdReportParameter parameter42 = new BsdReportParameter("AyMedido2", AyMedido2, true);
            BsdReportParameter parameter43 = new BsdReportParameter("AyMedido3", AyMedido3, true);
            BsdReportParameter parameter44 = new BsdReportParameter("AyMedido4", AyMedido4, true);
            BsdReportParameter parameter45 = new BsdReportParameter("AyCorreccion2", AyCorreccion2, true);
            BsdReportParameter parameter46 = new BsdReportParameter("AyCorreccion3", AyCorreccion3, true);
            BsdReportParameter parameter47 = new BsdReportParameter("AyCorreccion4", AyCorreccion4, true);
            BsdReportParameter parameter48 = new BsdReportParameter("AyCorregido2", AyCorregido2, true);
            BsdReportParameter parameter49 = new BsdReportParameter("AyCorregido3", AyCorregido3, true);
            BsdReportParameter parameter50 = new BsdReportParameter("AyCorregido4", AyCorregido4, true);
            BsdReportParameter parameter51 = new BsdReportParameter("RigidezMedido2", RigidezMedido2, true);
            BsdReportParameter parameter52 = new BsdReportParameter("RigidezMedido3", RigidezMedido3, true);
            BsdReportParameter parameter53 = new BsdReportParameter("RigidezMedido4", RigidezMedido4, true);
            BsdReportParameter parameter54 = new BsdReportParameter("RigidezCorreccion2", RigidezCorrec2, true);
            BsdReportParameter parameter55 = new BsdReportParameter("RigidezCorreccion3", RigidezCorrec3, true);
            BsdReportParameter parameter56 = new BsdReportParameter("RigidezCorreccion4", RigidezCorrec4, true);
            BsdReportParameter parameter57 = new BsdReportParameter("RigidezCorregido2", RigidezCorregido2, true);
            BsdReportParameter parameter58 = new BsdReportParameter("RigidezCorregido3", RigidezCorregido3, true);
            BsdReportParameter parameter59 = new BsdReportParameter("RigidezCorregido4", RigidezCorregido4, true);
            BsdReportParameter parameter60 = new BsdReportParameter("LongitudMedido2", LongMedido2, true);
            BsdReportParameter parameter61 = new BsdReportParameter("LongitudMedido3", LongMedido3, true);
            BsdReportParameter parameter62 = new BsdReportParameter("LongitudMedido4", LongMedido4, true);
            BsdReportParameter parameter63 = new BsdReportParameter("LongitudCorreccion2", LongCorreccion2, true);
            BsdReportParameter parameter64 = new BsdReportParameter("LongitudCorreccion3", LongCorreccion3, true);
            BsdReportParameter parameter65 = new BsdReportParameter("LongitudCorreccion4", LongCorreccion4, true);
            BsdReportParameter parameter66 = new BsdReportParameter("LongitudCorregido2", LongCorregido2, true);
            BsdReportParameter parameter67 = new BsdReportParameter("LongitudCorregido3", LongCorregido3, true);
            BsdReportParameter parameter68 = new BsdReportParameter("LongitudCorregido4", LongCorregido4, true);
            BsdReportParameter parameter69 = new BsdReportParameter("DiametroFinalMedido2", DiamFinMedido2, true);
            BsdReportParameter parameter70 = new BsdReportParameter("DiametroFinalMedido3", DiamFinMedido3, true);
            BsdReportParameter parameter71 = new BsdReportParameter("DiametroFinalMedido4", DiamFinMedido4, true);
            BsdReportParameter parameter72 = new BsdReportParameter("DiametroFinalCorreccion2", DiamFinCorreccion2, true);
            BsdReportParameter parameter73 = new BsdReportParameter("DiametroFinalCorreccion3", DiamFinCorreccion3, true);
            BsdReportParameter parameter74 = new BsdReportParameter("DiametroFinalCorreccion4", DiamFinCorreccion4, true);
            BsdReportParameter parameter75 = new BsdReportParameter("DiametroFinalCorregido2", DiamFinCorregido2, true);
            BsdReportParameter parameter76 = new BsdReportParameter("DiametroFinalCorregido3", DiamFinCorregido3, true);
            BsdReportParameter parameter77 = new BsdReportParameter("DiametroFinalCorregido4", DiamFinCorregido4, true);
            BsdReportParameter parameter78 = new BsdReportParameter("NoTubo", NoTubo, true);
            BsdReportParameter parameter79 = new BsdReportParameter("Resultado1", Resultado1, true);
            BsdReportParameter parameter80 = new BsdReportParameter("Resultado2", Resultado2, true);
            BsdReportParameter parameter81 = new BsdReportParameter("Resultado3", Resultado3, true);
            BsdReportParameter parameter82 = new BsdReportParameter("Resultado4", Resultado4, true);

            IList<BsdReportDataSource> ds = new List<BsdReportDataSource>();
            ds.Add(rds);
            ds.Add(rds2);
            ds.Add(rds3);
            ds.Add(rds4);
            ds.Add(rds5);
            ds.Add(rds6);
            ds.Add(rds7);
            ds.Add(rds8);

            BsdReport report = new BsdReport("Reporte de Rigidez", path, BsdReportFormat.PDF, ds, BsdReportType.Local);
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
            report.Parameters.Add(parameter41);
            report.Parameters.Add(parameter42);
            report.Parameters.Add(parameter43);
            report.Parameters.Add(parameter44);
            report.Parameters.Add(parameter45);
            report.Parameters.Add(parameter46);
            report.Parameters.Add(parameter47);
            report.Parameters.Add(parameter48);
            report.Parameters.Add(parameter49);
            report.Parameters.Add(parameter50);
            report.Parameters.Add(parameter51);
            report.Parameters.Add(parameter52);
            report.Parameters.Add(parameter53);
            report.Parameters.Add(parameter54);
            report.Parameters.Add(parameter55);
            report.Parameters.Add(parameter56);
            report.Parameters.Add(parameter57);
            report.Parameters.Add(parameter58);
            report.Parameters.Add(parameter59);
            report.Parameters.Add(parameter60);
            report.Parameters.Add(parameter61);
            report.Parameters.Add(parameter62);
            report.Parameters.Add(parameter63);
            report.Parameters.Add(parameter64);
            report.Parameters.Add(parameter65);
            report.Parameters.Add(parameter66);
            report.Parameters.Add(parameter67);
            report.Parameters.Add(parameter68);
            report.Parameters.Add(parameter69);
            report.Parameters.Add(parameter70);
            report.Parameters.Add(parameter71);
            report.Parameters.Add(parameter72);
            report.Parameters.Add(parameter73);
            report.Parameters.Add(parameter74);
            report.Parameters.Add(parameter75);
            report.Parameters.Add(parameter76);
            report.Parameters.Add(parameter77);
            report.Parameters.Add(parameter78);
            report.Parameters.Add(parameter79);
            report.Parameters.Add(parameter80);
            report.Parameters.Add(parameter81);
            report.Parameters.Add(parameter82);

            BsdReportResult result = ReportViewerService.CreateReport(report);

            return File(result.Content, result.MimeType);  
        }


        [HttpPost]
        public ActionResult GenerarReporte(Resultado resultado)
        {
            string path = Server.MapPath("/Infrastructure/Report/" + "RpteRigidez.rdlc");

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

        private RpteRigidezViewModel GetModel(Lote lote)
        {
            return new RpteRigidezViewModel(lote, ProductoService.ReadProducto());
        }

    }
}
