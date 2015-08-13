using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Reporte.Models
{
    public class RpteDimensionalViewModel : BaseViewModel
    {
        public Resultado Resultado { get; set; }
        private IEnumerable<Producto> _Productos { get; set; }

        public RpteDimensionalViewModel(Resultado resultado)
        {
            Resultado = resultado;
        }

        public RpteDimensionalViewModel(Resultado resultado, IEnumerable<Producto> productos)
        {
            Resultado = resultado;
            _Productos = productos;
        }

        public IEnumerable<SelectListItem> Productos
        {
            get
            {
                return _Productos.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }
    }
}