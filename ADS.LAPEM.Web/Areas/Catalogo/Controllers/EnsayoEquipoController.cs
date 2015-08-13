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

namespace ADS.LAPEM.Web.Areas.Catalogo.Controllers
{
    public class EnsayoEquipoController : BaseController
    {
        protected IEnsayoEquipoService EnsayoEquipoService { get; set; }
        protected IEnsayoService EnsayoService { get; set; }
        protected IEquipoService EquipoService { get; set; }
        //
        // GET: /Catalogo/EnsayoEquipo/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new Equipo()));
        }

        [HttpPost]
        public ActionResult Create(Equipo equipo)
        {
            List<Ensayo> ensayos = equipo.Ensayos;
            //ensayoEquipo.Equipo = EquipoService.ReadEquipoById(ensayoEquipo.EquipoId);
            //ensayoEquipo.Equipo.Ensayos = ensayos;
            if (ModelState.IsValid)
            {
                //EnsayoEquipoService.CreateEnsayoEquipo(ensayoEquipo);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(equipo));
            }
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Equipo> result = EquipoService.ReadEquipo(grid);

            var jsonData = new
            {
                total = result.TotalPages,
                result.PageIndex,
                records = result.TotalRecords,
                rows = (
                    from p in result.Rows
                    where p.Activo
                    select new
                    {
                        id = p.Id,
                        cell = new string[] { p.Serie, p.Marca, p.Modelo, p.Descripcion, p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private EnsayoEquipoViewModel GetModel(Equipo equipo)
        {
            return new EnsayoEquipoViewModel(equipo, EnsayoService.ReadEnsayo(), EquipoService.ReadEquipo());
        }


    }
}
