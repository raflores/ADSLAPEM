using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Seguridad.Models
{
    public class AccountViewModel : BaseViewModel
    {
        public Usuario Usuario { get; set; }

        public AccountViewModel(Usuario usuario)
        {
            Usuario = usuario;
        }

    }
}