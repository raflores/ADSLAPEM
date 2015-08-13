using ADS.LAPEM.Entities.Common;
using ADS.LAPEM.Resources.Example;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bsd.Common.Infrastructure.Entity;

namespace ADS.LAPEM.Entities.Example
{
    public class Person : IEntity
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessageResourceName = "Firstname_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Person))]
        [RegularExpression(Bsd.Common.Infrastructure.Entity.RegExConstants.ALPHA, ErrorMessageResourceName = "Firstname_Alpha", ErrorMessageResourceType = typeof(LAPEM_Entities_Person))]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessageResourceName = "Lastname_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Person))]
        [RegularExpression(Bsd.Common.Infrastructure.Entity.RegExConstants.ALPHA, ErrorMessageResourceName = "Lastname_Alpha", ErrorMessageResourceType = typeof(LAPEM_Entities_Person))]
        [StringLength(50)]
        public string Lastname { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessageResourceName = "Email_Required", ErrorMessageResourceType = typeof(LAPEM_Entities_Person))]
        [StringLength(50)]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        [Display(Name = "Telephone")]
        [StringLength(10)]
        public string Telephone { get; set; }
    }
}
