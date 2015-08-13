using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;
using System.Web.Mvc;

namespace ADS.LAPEM.Web.Areas.Seguridad.Models
{
    public class UsuarioViewModel : BaseViewModel
    {
        public Usuario Usuario { get; set; }
        private IEnumerable<Perfil> _perfiles;
        private IEnumerable<Planta> _plantas;

        public UsuarioViewModel(Usuario usuario)
        {
            Usuario = usuario;
        }        

        public UsuarioViewModel(Usuario usuario, IEnumerable<Perfil> perfiles, IEnumerable<Planta> plantas)
        {
            Usuario = usuario;
            _perfiles = perfiles;
            _plantas = plantas;
        }

        public IEnumerable<SelectListItem> Perfiles
        {
            get 
            { 
                return _perfiles.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() } );
            } 
        }

        public IEnumerable<SelectListItem> Plantas
        {
            get
            { 
                return _plantas.Select(x => new SelectListItem { Text = x.NombrePlanta, Value = x.Id.ToString() } );
            }
        }
    }
}

