﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Reporte.Models
{
    public class RpteAgrietamientoViewModel : BaseViewModel
    {
        public Lote Lote { get; set; }
        private IEnumerable<Producto> _Productos { get; set; }

        public RpteAgrietamientoViewModel(Lote lote)
        {
            Lote = lote;
        }

        public RpteAgrietamientoViewModel(Lote lote, IEnumerable<Producto> productos)
        {
            Lote = lote;
            _Productos = productos;
        }

        public IEnumerable<SelectListItem> Productos
        {
            get
            {
                return _Productos.Select(x => new SelectListItem { Text = x.Codigo + " " + x.Nombre, Value = x.Id.ToString() });
            }
        }
    }
}