using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities.Example;
using Bsd.Common.Infrastructure.Web.Grid;
using ADS.LAPEM.Repositories.Example;

namespace ADS.LAPEM.Services.Example.Impl
{
    public class PersonService : IPersonService
    {
        protected IPersonRepository PersonRepository { get; set; }

        public IEnumerable<Person> ReadPerson()
        {
            return PersonRepository.ReadPersons();
        }

        public GridResult<Person> ReadPerson(GridSettings grid)
        {
            return PersonRepository.ReadPersons(grid);
        }

        public Person ReadPersonById(long id)
        {
            return PersonRepository.ReadPersonsById(id);
        }

        public void CreatePerson(Person person)
        {
            person.CreatedDate = DateTime.Now;
            PersonRepository.CreatePerson(person);
        }

        public void UpdatePerson(Person person)
        {
            person.CreatedDate = DateTime.Now;
            PersonRepository.UpdatePerson(person);
        }

        public void DeletePerson(Person person)
        {
            PersonRepository.DeletePerson(person);
        }
    }
}
