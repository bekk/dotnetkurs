using System.Collections.Generic;
using Bekk.dotnetintro.WebApi.Persons.Models;

namespace Bekk.dotnetintro.WebApi.Persons.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public IEnumerable<Person> Get()
        {
            return new List<Person>
                       {
                           new Person{FirstName = "Albert", LastName = "Einstein"},
                           new Person{FirstName = "Isaac", LastName = "Newton"}
                       };
        }
    }
}