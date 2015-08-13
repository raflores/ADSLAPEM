using ADS.LAPEM.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Bsd.Common.Infrastructure.Entity;

namespace ADS.LAPEM.Entities
{
    public class Permiso : IEntity
    {
        [Key]
        public long Id { get; set; }

        public long PerfilId { get; set; }

        public long MenuId { get; set; }

        public virtual Perfil Perfil { get; set; }

        public virtual Menu Menu { get; set; }

        public bool Activo { get; set; }
    }
}
