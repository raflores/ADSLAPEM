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
    [Authorize]
    public class ProductoController : BaseController
    {
        protected IProductoService ProductoService { get; set; }
        protected IMedidaDiametroService MedidaDiametroService { get; set; }
        protected ITipoProductoService TipoProductoService { get; set; }
        protected IProveedorService ProveedorService { get; set; }
        protected INormaProductoService NormaProductoService { get; set; }
        protected INormaService NormaService { get; set; }
        protected IColorService ColorService { get; set; }
        //
        // GET: /Catalogo/Producto/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(GetModel(new Producto()));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.Activo = true;
                ProductoService.CreateProducto(producto);
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
                //return View(GetModel(producto));
            }
        }

        public Producto ListaNormaEditar(Producto producto)
        {
            IList<NormaProducto> normasProducto = NormaProductoService.ReadNormaProducto().ToList();            
            while(normasProducto.Count() != 0)            
            {
                //if (producto.Norma.Where(x => x.NormaProductoId == normasProducto[0].Id).Count() <= 0)
                //{
                //    Norma norma = new Norma()
                //    {
                //        NormaProductoId = normasProducto[0].Id,
                //        Nombre = normasProducto[0].Nombre
                //    };
                //    producto.Norma.Add(norma);                                       
                //}
                normasProducto.RemoveAt(0); 
            }

            return producto;            
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Producto producto = ProductoService.ReadProductoById(id);
            //producto.Norma = NormaService.ReadNormaByProductoId(producto.Id).ToList();            
            return View(GetModel(producto));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Edit(Producto producto)
        {            
            if (ModelState.IsValid)
            {
                ProductoService.UpdateProducto(producto);
                return RedirectToAction(INDEX_VIEW);
            }
            else
            {
                return View(GetModel(producto));
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            Producto producto = ProductoService.ReadProductoById(id);
            return PartialView(DELETE_PARTIAL_VIEW, GetModel(producto));
        }

        [HttpPost, LoggingFilter]
        public ActionResult Delete(Producto producto)
        {
            Producto p = ProductoService.ReadProductoById(producto.Id);
            p.Activo = false;
            ProductoService.UpdateProducto(p);
            //ProductoService.DeleteProducto(producto);
            return Json(JSON_SUCCESS, JsonRequestBehavior.AllowGet);
        }        

        [HttpGet]
        public ActionResult GetList(GridSettingsWeb grid)
        {
            GridResult<Producto> result = ProductoService.ReadProducto(grid);

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
                    cell = new string[] { p.Codigo, p.Nombre, p.Descripcion, p.MedidaDiametro.ValorIn.ToString(), p.Id.ToString() }
                }).ToArray()
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private ProductoViewModel GetModelEdit(Producto producto)
        {
            return new ProductoViewModel(producto, MedidaDiametroService.ReadMedidaDiametro(),
                TipoProductoService.ReadTipoProducto(), ProveedorService.ReadProveedor(), ColorService.ReadColor());
        }

        private ProductoViewModel GetModel(Producto producto)
        {            
            return new ProductoViewModel(producto, MedidaDiametroService.ReadMedidaDiametro(), 
                TipoProductoService.ReadTipoProducto(), ProveedorService.ReadProveedor(), ColorService.ReadColor(), NormaProductoService.ReadNormaProducto());
        }

        public IList<NormaProducto> ListaNormaProd()
        {
            IList<NormaProducto> listaNP = new List<NormaProducto>();

            foreach (NormaProducto normaProd in NormaProductoService.ReadNormaProducto())
            {
                listaNP.Add(normaProd);
            }

            return listaNP;
        }

    }
}
