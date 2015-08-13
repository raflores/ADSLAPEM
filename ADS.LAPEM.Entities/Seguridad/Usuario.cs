using ADS.LAPEM.Entities.Common;
using ADS.LAPEM.Resources.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bsd.Common.Infrastructure.Entity;

namespace ADS.LAPEM.Entities
{
    public class Usuario : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "Nombre_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Usuario))]
        [StringLength(50, MinimumLength = 5)]
        public string Nombre { get; set; }

        [Required(ErrorMessageResourceName = "Usuario_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Usuario))]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [NotMapped]
        public string Password { get; set; }

        public long PlantaId { get; set; }        

        public string Puesto { get; set; }
        public string Email { get; set; }

        public long PerfilId { get; set; }

        public bool Activo { get; set; }

        public virtual Planta Planta { get; set; }
        public virtual Perfil Perfil { get; set; }

    }
}
