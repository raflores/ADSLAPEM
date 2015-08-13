using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Consulta.Models
{
    public class LoteViewModel : BaseViewModel
    {
        public Lote Lote { get; set; }
        public IEnumerable<Producto> Productos { get; set; }

        public LoteViewModel(Lote lote)
        {
            Lote = lote;
        }

        public LoteViewModel(Lote lote, IEnumerable<Producto> productos)
        {
            Lote = lote;
            Productos = productos;
        }

        public IEnumerable<SelectListItem> lstProducto
        {
            get
            {
                return Productos.Select(x => new SelectListItem { Text = x.Codigo, Value = x.Id.ToString() });
            }
        }
    }
}