using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Catalogo.Models
{
    public class NormaEnsayoViewModel : BaseViewModel
    {
        public NormaEnsayo NormaEnsayo { get; set; }
        private IEnumerable<UnidadMedida> _UMS;
        private IEnumerable<Norma> _Normas;
        private NormaEnsayoValorIn[] NormaValorIn = new NormaEnsayoValorIn[1];
        private NormaEnsayoValorMm[] NormaValorMm = new NormaEnsayoValorMm[1];

        public NormaEnsayoViewModel(NormaEnsayo normaEnsayo)
        {
            NormaEnsayo = normaEnsayo;
        }

        public NormaEnsayoViewModel(NormaEnsayo normaEnsayo, IEnumerable<UnidadMedida> unidadesM, IEnumerable<Norma> normas)
        {
            NormaEnsayo = normaEnsayo;
            _UMS = unidadesM;
            _Normas = normas;
        }

        public IEnumerable<SelectListItem> UMS
        {
            get
            {
                return _UMS.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }

        public IEnumerable<SelectListItem> Norma
        {
            get
            {
                return _Normas.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }
    }
}