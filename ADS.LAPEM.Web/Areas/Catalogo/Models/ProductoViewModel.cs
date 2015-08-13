using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Catalogo.Models
{
    public class ProductoViewModel : BaseViewModel
    {
        public Producto Producto { get; set; }
        private IEnumerable<MedidaDiametro> _MedidasDiametro;
        private IEnumerable<TipoProducto> _TipoProductos;
        private IEnumerable<Proveedor> _Proveedores;
        private IEnumerable<Color> _Colores;


        public ProductoViewModel(Producto producto)
        {
            Producto = producto;
        }

        public ProductoViewModel(Producto producto, IEnumerable<MedidaDiametro> medidasDiam, IEnumerable<TipoProducto> tipoProductos,
            IEnumerable<Proveedor> proveedores, IEnumerable<Color> colores)
        {
            Producto = producto;
            _MedidasDiametro = medidasDiam;
            _TipoProductos = tipoProductos;
            _Colores = colores;
            _Proveedores = proveedores;
        }

        public ProductoViewModel(Producto producto, IEnumerable<MedidaDiametro> medidasDiam, IEnumerable<TipoProducto> tipoProductos,
            IEnumerable<Proveedor> proveedores, IEnumerable<Color> colores, IEnumerable<NormaProducto> normaProducto)
        {
            Producto = producto;            
            _MedidasDiametro = medidasDiam;
            _TipoProductos = tipoProductos;
            _Proveedores = proveedores;
            _Colores = colores;
            //Producto.Norma = new List<Norma>();

            //foreach (NormaProducto normaP in normaProducto)
            //{
            //    Norma norma = new Norma();
            //    //norma.NormaProductoId = normaP.Id;
            //    norma.Nombre = normaP.Nombre;
            //    //Producto.Norma.Add(norma);
            //}           
        }

        public IEnumerable<SelectListItem> MedidasDiametro
        {
            get
            {
                return _MedidasDiametro.Select(x => new SelectListItem { Text = x.ValorIn + "/" + x.ValorMm, Value = x.Id.ToString() });
            }
        }

        public IEnumerable<SelectListItem> TipoProductos
        {
            get
            {
                return _TipoProductos.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }

        public IEnumerable<SelectListItem> Proveedores
        {
            get
            {
                return _Proveedores.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }

        public IEnumerable<SelectListItem> Colores
        {
            get
            {
                return _Colores.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }
    }
}