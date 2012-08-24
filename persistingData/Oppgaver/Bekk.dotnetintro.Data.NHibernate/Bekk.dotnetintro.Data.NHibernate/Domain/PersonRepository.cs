using System;
using System.Collections.Generic;
using Bekk.dotnetintro.Data.NHibernate.Session;
using NHibernate.Criterion;

namespace Bekk.dotnetintro.Data.NHibernate.Domain
{
    public class PersonRepository : IPersonRepository
    {
        public void Add(Person person)
        {
            if (person == null) return;
            
            using (var session = NHibernateSessionManager.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(person);
                    transaction.Commit();
                }
            }
        }

        public void Update(Person person)
        {
            using (var session = NHibernateSessionManager.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(person);
                    transaction.Commit();
                }
            }
        }

        public void Remove(Person person)
        {
            using (var session = NHibernateSessionManager.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(person);
                    transaction.Commit();
                }
            }
        }

        public Person GetBy(Guid id)
        {
            using (var session = NHibernateSessionManager.OpenSession())
            {
                return session.Get<Person>(id);
            }
        }

        public IEnumerable<Person> GetAllPersonsWith(string firstName)
        {
            using (var session = NHibernateSessionManager.OpenSession())
            {
                return session.CreateCriteria<Person>().Add(Restrictions.Eq("FirstName", firstName)).List<Person>();
            }
        }
    }
}
