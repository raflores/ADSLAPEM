using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Services.Seguridad;
using ADS.LAPEM.Web.Controllers;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Web.Infrastructure.Grid;
using ADS.LAPEM.Web.Areas.Catalogo.Models;
using ADS.LAPEM.Web.Infrastructure.Filter;

namespace ADS.LAPEM.Web.Areas.Consulta.Controllers
{
    public class ConsultaLogController : BaseController
    {
        protected ISystemLogService SystemLogService { get; set; }
        //
        // GET: /Consulta/ConsultaLog/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<SystemLog> result = SystemLogService.ReadLog(grid);

            var jsonData = new
            {
                total = result.TotalPages,
                result.PageIndex,
                records = result.TotalRecords,
                rows = (
                    from p in result.Rows
                    select new
                    {
                        id = p.Id,
                        cell = new string[] { p.Usuario.Nombre, p.Accion, p.Modulo, p.Date.ToShortDateString(),  p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

    }
}
