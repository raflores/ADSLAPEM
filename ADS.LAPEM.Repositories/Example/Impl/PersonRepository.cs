using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADS.LAPEM.Entities.Example;
using Bsd.Common.Infrastructure.Web.Grid;
using Bsd.Common.Infrastructure.Repository;
using Bsd.Common.Infrastructure.Repository.Impl;

namespace ADS.LAPEM.Repositories.Example.Impl
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public IQueryable<Person> ReadPersons()
        {
            return Get();
        }

        public GridResult<Person> ReadPersons(GridSettings grid)
        {
            return Get(grid);
        }

        public Person ReadPersonsById(long id)
        {
            return GetById(id);
        }

        public void CreatePerson(Person person)
        {
            Add(person);
        }

        public void UpdatePerson(Person person)
        {
            Edit(person);
        }

        public void DeletePerson(Person person)
        {
            Remove(person);
        }
    }
}
