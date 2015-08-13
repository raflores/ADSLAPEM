using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Catalogo.Models
{
    public class NormaProductoViewModel : BaseViewModel
    {
        public NormaProducto NormaProducto { get; set; }
        private IEnumerable<Producto> _Productos { get; set; }
        private IEnumerable<NormaEnsayo> _NormasEnsayo { get; set; }

        public NormaProductoViewModel(NormaProducto normaProducto)
        {
            NormaProducto = normaProducto;
        }

        public NormaProductoViewModel(NormaProducto normaProducto, IEnumerable<Producto> productos, IEnumerable<NormaEnsayo> _normase)
        {
            NormaProducto = normaProducto;
            _Productos = productos;
            _NormasEnsayo = _normase;
            normaProducto.Normas = new List<NormaEnsayo>();

            foreach (NormaEnsayo n in _NormasEnsayo)
            {
                NormaProducto.Normas.Add(n);
            }

        }

        public IEnumerable<SelectListItem> Productos
        {
            get
            {
                return _Productos.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }

        public IEnumerable<SelectListItem> NormasEnsayo
        {
            get
            {
                return _NormasEnsayo.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }
    }
}