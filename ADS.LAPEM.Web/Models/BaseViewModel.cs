using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADS.LAPEM.Web.Models
{
    public class BaseViewModel
    {
        public List<string> Mensajes { get; set; }

        public BaseViewModel()
        {
            Mensajes = new List<string>();
        }
    }
}