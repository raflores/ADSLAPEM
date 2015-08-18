using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities.Example;
using Bsd.Common.Infrastructure.Web.Grid;

namespace ADS.LAPEM.Services.Example
{
    public interface IPersonService
    {
        IEnumerable<Person> ReadPerson();
        GridResult<Person> ReadPerson(GridSettings grid);
        Person ReadPersonById(long id);
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
    }
}
