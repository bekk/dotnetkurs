using System;
using System.Collections.Generic;
using NHibernate.Criterion;

namespace Bekk.dotnetintro.Data.NHibernate.Domain
{
    public class CarRepository : ICarRepository
    {
        public void Add(Car car)
        {
            if(car == null) return;

            using (var session = NHibernateSessionManager.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(car);
                    transaction.Commit();
                }
            }
        }

        public void Update(Car car)
        {
            using (var session = NHibernateSessionManager.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(car);
                    transaction.Commit();
                }
            }
        }

        public void Remove(Car car)
        {
            using (var session = NHibernateSessionManager.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(car);
                    transaction.Commit();
                }
            }
        }

        public Car GetBy(Guid id)
        {
            using (var session = NHibernateSessionManager.OpenSession())
            {
                return session.Get<Car>(id);
            }
        }

        public IEnumerable<Car> GetAll(string make)
        {
            using (var session = NHibernateSessionManager.OpenSession())
            {
                return session.CreateCriteria<Car>()
                              .Add(Restrictions.Eq("Make", make))
                              .List<Car>();
            }
        }
    }
}
