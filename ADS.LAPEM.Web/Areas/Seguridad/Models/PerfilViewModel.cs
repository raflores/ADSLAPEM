using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Seguridad.Models
{
    public class PerfilViewModel : BaseViewModel
    {
        public Perfil Perfil { get; set; }
        private IEnumerable<Menu> _Menu;

        public PerfilViewModel(Perfil perfil)
        {
            Perfil = perfil;
        }

        public PerfilViewModel(Perfil perfil, IEnumerable<Menu> Menu)
        {
            Perfil = perfil;
            Perfil.PerfilMenu = new List<PerfilMenu>();
            _Menu = Menu;

            foreach (Menu m in Menu)
            {
                PerfilMenu pm = new PerfilMenu();
                pm.MenuId = m.Id;
                pm.Nombre = m.Nombre;
                //Menu menu = m;
                //Menu menu = new Menu();
                //menu.Id = m.Id;
                //menu.Nombre = m.Nombre;
                //pm.Menu = menu;                
                Perfil.PerfilMenu.Add(pm);
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