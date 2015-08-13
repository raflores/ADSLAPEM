using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADS.LAPEM.Entities;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Consulta.Models
{
    public class LogViewModel : BaseViewModel
    {
        public SystemLog SystemLog { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }

        public LogViewModel(SystemLog systemLog)
        {
            SystemLog = systemLog;
        }

        public LogViewModel(SystemLog systemLog, IEnumerable<Usuario> usuarios)
        {
            SystemLog = systemLog;
            Usuarios = usuarios;
        }

        public IEnumerable<SelectListItem> ListUsuarios
        {
            get
            {
                return Usuarios.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            }
        }

        
    }
}