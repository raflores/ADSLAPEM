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
    public class Perfil : IEntity
    {
        [Key]
        public long Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Required(ErrorMessageResourceName = "Nombre_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Perfil))]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool Activo { get; set; }

        public IList<PerfilMenu> PerfilMenu { get; set; }
    }
}
