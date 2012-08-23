using System;

namespace Bekk.dotnetintro.Data.NHibernate.Domain
{
    public class Car
    {
        public virtual Guid Id { get; set; }
        public virtual string Make { get; set; }
        public virtual string RegistrationNumber { get; set; }
    }
}
