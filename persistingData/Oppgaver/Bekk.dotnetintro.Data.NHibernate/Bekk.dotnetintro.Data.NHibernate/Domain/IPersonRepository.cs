using System;
using System.Collections.Generic;

namespace Bekk.dotnetintro.Data.NHibernate.Domain
{
    public interface IPersonRepository
    {
        void Add(Person person);
        void Update(Person person);
        void Remove(Person person);
        Person GetBy(Guid id);
        IEnumerable<Person> GetAllPersonsWith(string firstName);
    }
}
