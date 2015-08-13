using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Seguridad.Models
{
    public class PerfilMenuViewModel : BaseViewModel
    {
        public PerfilMenu PerfilMenu { get; set; }
        private IEnumerable<Perfil> _Perfiles;
        private IEnumerable<Menu> _Menu;

        public PerfilMenuViewModel(PerfilMenu perfilMenu)
        {
            PerfilMenu = perfilMenu;
        }

        public PerfilMenuViewModel(PerfilMenu perfilMenu, IEnumerable<Perfil> perfiles, IEnumerable<Menu> menu)
        {
            PerfilMenu = perfilMenu;
            _Perfiles = perfiles;
            _Menu = menu;
        }

        public IEnumerable<SelectListItem> Perfiles
        {
            get
            {
                return _Perfiles.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }

        public IList<Menu> Menu
        {
            get
            {
                return _Menu.ToList();
            }
        }

    }
}