using ADS.LAPEM.Entities.Example;
using Bsd.Common.Infrastructure.Web.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.LAPEM.Repositories.Example
{
    public interface IPersonRepository
    {
        IQueryable<Person> ReadPersons();
        GridResult<Person> ReadPersons(GridSettings grid);
        Person ReadPersonsById(long id);
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
    }
}
