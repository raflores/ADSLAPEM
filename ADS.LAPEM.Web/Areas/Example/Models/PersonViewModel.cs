using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADS.LAPEM.Entities.Example;
using ADS.LAPEM.Web.Models;

namespace ADS.LAPEM.Web.Areas.Example.Models
{
    public class PersonViewModel : BaseViewModel
    {
        public Person Person { get; set; }

        public PersonViewModel(Person person)
        {
            Person = person;
        }
    }
}