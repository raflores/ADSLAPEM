using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities.Common;
using ADS.LAPEM.Resources.Catalogo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bsd.Common.Infrastructure.Entity;

namespace ADS.LAPEM.Entities
{
    public class Especificacion : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "Producto_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Especificacion))]
        public long ProductoId { get; set; }

        [Required(ErrorMessageResourceName = "Norma_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Especificacion))]
        public long NormaId { get; set; }

        [Required(ErrorMessageResourceName = "NormaEnsayo_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Especificacion))]
        public long NormaEnsayoId { get; set; }

        [Required(ErrorMessageResourceName = "EnsayoId_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Especificacion))]
        public long EnsayoId { get; set; }

        [Required(ErrorMessageResourceName = "TipoEnsayo_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Especificacion))]
        public long TipoEnsayoId { get; set; }

        [Required(ErrorMessageResourceName = "UnidadMedida_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Especificacion))]
        public long UnidadMedidaId { get; set; }

        public decimal Minimo { get; set; }

        public decimal Maximo { get; set; }

        public decimal Objetivo { get; set; }

        public int Muestra { get; set; }

        public bool Activo { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Norma Norma { get; set; }
        public virtual NormaEnsayo NormaEnsayo { get; set; }
        public virtual TipoEnsayo TipoEnsayo { get; set; }
        public virtual Ensayo Ensayo { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }
    }
}
