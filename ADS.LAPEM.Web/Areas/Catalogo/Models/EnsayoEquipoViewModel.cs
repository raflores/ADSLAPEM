using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Catalogo.Models
{
    public class EnsayoEquipoViewModel : BaseViewModel
    {
        public Equipo Equipo { get; set; }
        //public EnsayoEquipo EnsayoEquipo { get; set; }
        private IEnumerable<Ensayo> _ensayos { get; set; }
        private IEnumerable<Equipo> _equipos { get; set; }

        public EnsayoEquipoViewModel(Equipo equipo)
        {
            Equipo = equipo;
        }

        public EnsayoEquipoViewModel(Equipo equipo, IEnumerable<Ensayo> ensayos, IEnumerable<Equipo> equipos)
        {
            Equipo = equipo;
            Ensayo ensayo = new Ensayo();
            List<Ensayo> listEnayo = ensayos.ToList();
            ensayo.Id = listEnayo[0].Id;
            Equipo.Ensayos = ensayos.ToList();
            //EnsayoEquipo = ensayoEquipo;
            //Equipo equipo = new Equipo();
            //equipo.Id = ensayoEquipo.EquipoId;
            //EnsayoEquipo.Equipo = equipo;
            //Ensayo ensayo = new Ensayo();
            //List<Ensayo> listEnayo = ensayos.ToList();
            //ensayo.Id = listEnayo[0].Id;
            //EnsayoEquipo.Equipo.Ensayos = ensayos.ToList();
            //EnsayoEquipo.EnsayoId = listEnayo[0].Id;
            _ensayos = ensayos;
            _equipos = equipos;
        }

        public IEnumerable<SelectListItem> Ensayos
        {
            get
            {
                return _ensayos.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }

        public IEnumerable<SelectListItem> Equipos
        {
            get
            { 
                return _equipos.Select(x => new SelectListItem { Text = x.Modelo, Value = x.Id.ToString() });
            }
        }
    }
}