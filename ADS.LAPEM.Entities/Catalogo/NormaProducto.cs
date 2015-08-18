using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ADS.LAPEM.Entities.Common;
using ADS.LAPEM.Resources.Catalogo;
using Bsd.Common.Infrastructure.Entity;


namespace ADS.LAPEM.Entities
{
    public class NormaProducto : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "Nombre_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_NormaProducto))]
        public string Nombre { get; set; }

        public long NormaEnsayoId { get; set; }

        public long ProductoId { get; set; }

        public bool Activo { get; set; }

        [NotMapped]
        public List<NormaEnsayo> Normas { get; set; }

        public virtual NormaEnsayo NormaEnsayo { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
