using ADS.LAPEM.Entities.Common;
using ADS.LAPEM.Resources.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Bsd.Common.Infrastructure.Entity;

namespace ADS.LAPEM.Entities
{
    public class Menu : IEntity
    {
        [Key]
        public long Id { get; set; }        

        [Required(ErrorMessageResourceName = "Nombre_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Menu))]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Padre { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public string Area { get; set; }

        public bool Activo { get; set; }

    }
}
