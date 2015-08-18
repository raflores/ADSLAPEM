using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Catalogo.Models
{
    public class CalibracionViewModel : BaseViewModel
    {
        public Calibracion Calibracion { get; set; }
        private IEnumerable<Equipo> _equipos { get; set; }
        private IEnumerable<Proveedor> _Proveedores { get; set; }

        public CalibracionViewModel(Calibracion calibracion)
        {
            Calibracion = calibracion;
        }

        public CalibracionViewModel(Calibracion calibracion, IEnumerable<Equipo> equipos, IEnumerable<Proveedor> proveedores)
        {
            Calibracion = calibracion;
            _equipos = equipos;
            _Proveedores = proveedores;
        }

        public IEnumerable<SelectListItem> Equipos
        {
            get
            {
                return _equipos.Select(x => new SelectListItem { Text = x.CodigoActivoFijo, Value = x.Id.ToString() });
            }
        }

        public IEnumerable<SelectListItem> Proveedores
        {
            get
            {
                return _Proveedores.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }  
    }
}