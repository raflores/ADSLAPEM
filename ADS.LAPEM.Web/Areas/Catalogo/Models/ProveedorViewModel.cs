using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Catalogo.Models
{
    public class ProveedorViewModel : BaseViewModel
    {
        public Proveedor Proveedor { get; set; }

        public ProveedorViewModel(Proveedor proveedor)
        {
            Proveedor = proveedor;
        }
    }
}