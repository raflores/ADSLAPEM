using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;


namespace ADS.LAPEM.Web.Areas.Catalogo.Models
{
    public class EspecificacionViewModel : BaseViewModel
    {
        public Especificacion Especificacion { get; set; }
        private IEnumerable<Norma> _normas { get; set; }
        private IEnumerable<NormaEnsayo> _normasEnsayo { get; set; }
        private IEnumerable<Ensayo> _ensayos { get; set; }
        private IEnumerable<Producto> _productos { get; set; }
        private IEnumerable<TipoEnsayo> _tiposEnsayo { get; set; }
        private IEnumerable<UnidadMedida> _unidadesMedida { get; set; }

        public EspecificacionViewModel(Especificacion especificacion)
        {
            Especificacion = especificacion;
        }

        public EspecificacionViewModel(Especificacion especificacion, IEnumerable<Norma> normas, IEnumerable<NormaEnsayo> normasEnsayo,
            IEnumerable<Ensayo> ensayos, IEnumerable<Producto> productos, IEnumerable<TipoEnsayo> tiposEnsayo , IEnumerable<UnidadMedida> unidadesMedida)
        {
            Especificacion = especificacion;
            _normas = normas;
            _normasEnsayo = normasEnsayo;
            _ensayos = ensayos;
            _productos = productos;
            _tiposEnsayo = tiposEnsayo;
            _unidadesMedida = unidadesMedida;
        }

        public IEnumerable<SelectListItem> Normas
        {
            get
            {
                return _normas.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }

        public IEnumerable<SelectListItem> NormasEnsayo
        {
            get
            {
                return _normasEnsayo.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }

        public IEnumerable<SelectListItem> Productos
        {
            get
            {
                return _productos.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }

        public IEnumerable<SelectListItem> TiposEnsayo
        {
            get
            {
                return _tiposEnsayo.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }

        public IEnumerable<SelectListItem> Unidades
        {
            get
            {
                return _unidadesMedida.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }

        public IEnumerable<SelectListItem> Ensayos
        {
            get
            {
                return _ensayos.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }
    }
}