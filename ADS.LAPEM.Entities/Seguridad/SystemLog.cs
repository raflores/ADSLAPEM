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
    public class SystemLog : IEntity
    {
        [Key]
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public DateTime Date { get; set; }
        public string Modulo { get; set; }
        public string Accion { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
