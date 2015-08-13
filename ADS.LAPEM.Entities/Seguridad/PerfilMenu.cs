using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ADS.LAPEM.Entities.Common;
using ADS.LAPEM.Resources.Seguridad;
using System.ComponentModel.DataAnnotations.Schema;
using Bsd.Common.Infrastructure.Entity;

namespace ADS.LAPEM.Entities
{
    public class PerfilMenu : IEntity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Perfil")]
        public long PerfilId { get; set; }

        [ForeignKey("Menu")]
        public long MenuId { get; set; }

        [NotMapped]
        public string Nombre { get; set; }
        
        public virtual Perfil Perfil { get; set; }
        public virtual Menu Menu { get; set; }

        public bool Activo { get; set; }
    }
}
