using System;
using System.Collections.Generic;

namespace Bekk.dotnetintro.Data.NHibernate.Domain
{
    public interface ICarRepository
    {
        void Add(Car car);
        void Update(Car car);
        void Remove(Car car);
        Car GetBy(Guid id);
        IEnumerable<Car> GetAll(string make);
    }
}
