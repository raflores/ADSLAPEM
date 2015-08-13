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

namespace ADS.LAPEM.Web.Areas.Consulta.Controllers
{
    public class ConsultaImagenController : Controller
    {
        protected IResultadoService ResultadoService { get; set; }
        
        //
        // GET: /Consulta/ConsultaImagen/

        public ActionResult Index()
        {
            return View();
        }

    }
}
