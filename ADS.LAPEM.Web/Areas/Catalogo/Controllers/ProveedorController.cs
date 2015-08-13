using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Repositories.Data;
using ADS.LAPEM.Web.Controllers;
using ADS.LAPEM.Services.Catalogo;
using ADS.LAPEM.Web.Areas.Catalogo.Models;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Web.Infrastructure.Grid;
using ADS.LAPEM.Web.Infrastructure.Filter;

namespace ADS.LAPEM.Web.Areas.Catalogo.Controllers
{
    [Authorize]
    public class ProveedorController : BaseController
    {
        protected IProveedorService ProveedorService { get; set; }
        //
        // GET: /Catalogo/Proveedor/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new Proveedor()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                ProveedorService.CreateProveedor(proveedor);
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
                //return View(GetModel(proveedor));
            }
        }

        [HttpGet]
        public ActionResult Edit(long id = 0)
        {
            Proveedor proveedor = ProveedorService.ReadProveedorById(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }

            return View(GetModel(proveedor));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                ProveedorService.UpdateProveedor(proveedor);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(proveedor));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id = 0)
        {
            Proveedor proveedor = ProveedorService.ReadProveedorById(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }

            return PartialView(DELETE_PARTIAL_VIEW, GetModel(proveedor));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(Proveedor proveedor)
        {
            ProveedorService.DeleteProveedor(proveedor);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Proveedor> result = ProveedorService.ReadProveedor(grid);

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
                        cell = new string[] { p.Nombre, p.RFC, p.Giro, p.Direccion, p.Ciudad, p.Estado, p.CorreoContacto, p.Id.ToString() }
                    }).ToArray()
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private ProveedorViewModel GetModel(Proveedor proveedor)
        {
            return new ProveedorViewModel(proveedor);
        }

    }
}
