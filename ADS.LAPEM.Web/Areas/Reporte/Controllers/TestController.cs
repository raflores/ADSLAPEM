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

namespace ADS.LAPEM.Web.Areas.Reporte.Controllers
{
    public class TestController : BaseController
    {
        protected ILineaService LineaService { get; set; }
        protected IReportViewerService ReportViewerService { get; set; }
        //
        // GET: /Reporte/Test/

        public ActionResult Index()
        {
            return View();
        }

        //public FileContentResult GeneraReporte()
        //{
        //    string path = Server.MapPath("/Infrastructure/Report/" + "Report1.rdlc");
        //    //string path = Server.MapPath("Report1.rdlc");
        //    BsdReportDataSource rds = new BsdReportDataSource("NewTest", LineaService.ReadLinea().ToList());
        //    BsdReport report = new BsdReport("Lineas", path, BsdReportFormat.PDF, rds, BsdReportType.Local);

        //    //IReportViewerService ReportViewerService = new ReportViewerService();
        //    BsdReportResult result = ReportViewerService.CreateReport(report);

        //    FileStream fs = new FileStream(@"c:\Reportes\" + report.Name + "." + result.FileType, FileMode.OpenOrCreate);
        //    fs.Write(result.Content, 0, result.Content.Length);            
        //    fs.Close();

        //    return File(result.Content, result.MimeType);
        //}
    }
}
