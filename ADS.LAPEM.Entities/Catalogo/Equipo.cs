using ADS.LAPEM.Entities.Common;
using ADS.LAPEM.Resources.Catalogo;
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
    public class Equipo : IEntity
    {
        [Key]
        public long Id { get; set; }
        
        [Required(ErrorMessageResourceName = "ActivoFijo_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Equipo))]
        [StringLength(10)]
        public string CodigoActivoFijo { get; set; }

        [Required(ErrorMessageResourceName = "Serie_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Equipo))]
        public string Serie { get; set; }

        [Required(ErrorMessageResourceName = "Marca_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Equipo))]
        public string Marca { get; set; }

        [Required(ErrorMessageResourceName = "Modelo_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Equipo))]
        public string Modelo { get; set; }

        public string Descripcion { get; set; }
        public DateTime FechaCompra { get; set; }

        [NotMapped]
        public List<Ensayo> Ensayos { get; set; }

        [NotMapped]
        public List<EnsayoEquipo> EnsayoEquipo { get; set; }

        [Required(ErrorMessageResourceName = "Planta_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Equipo))]
        public long PlantaId { get; set; }
        
        public bool Activo { get; set; }

        public string RazonBorrado { get; set; }

        public virtual ICollection<Calibracion> Calibraciones { get; set; }
        public virtual Planta Planta { get; set; }
    }
}
