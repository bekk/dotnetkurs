using System.Collections.Generic;
using Bekk.dotnetintro.WebApi.Persons.Models;

namespace Bekk.dotnetintro.WebApi.Persons.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> Get();
    }
}