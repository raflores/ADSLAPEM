using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADS.LAPEM.Entities;

namespace ADS.LAPEM.Web.Models
{
    public class MenuViewModel
    {
        public IList<Menu> Menu { get; set; }
        public Usuario Usuario { get; set; }

        public MenuViewModel(IList<Menu> menu, Usuario usuario)
        {
            Menu = menu;
            Usuario = usuario;
        }
    }
    
}