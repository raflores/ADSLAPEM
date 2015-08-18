using ADS.LAPEM.Entities.Common;
using ADS.LAPEM.Resources.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Bsd.Common.Infrastructure.Entity;

namespace ADS.LAPEM.Entities
{
    public class Calibracion : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "Equipo_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Calibracion))]
        public long EquipoId { get; set; }

        public DateTime FechaCalibracion { get; set; }
        public DateTime FechaVencimiento { get; set; }

        [Required]
        [RegularExpression(Bsd.Common.Infrastructure.Entity.RegExConstants.NUMERIC, ErrorMessageResourceName = "InformeNumerico", ErrorMessageResourceType = typeof(LAPEM_Entities_Calibracion))]
        public int NoInformeCalib { get; set; }

        [Required(ErrorMessageResourceName="PDFInfo_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Calibracion))]
        public string PDFInforme { get; set; }

        public byte[] FileContent { get; set; }

        public string Comentarios { get; set; }

        [Required(ErrorMessageResourceName = "Proveedor_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Calibracion))]
        public long ProveedorId { get; set; }

        public bool Activo { get; set; }

        public virtual Equipo Equipo { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
