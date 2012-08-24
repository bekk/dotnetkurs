using System;

namespace Bekk.dotnetintro.Data.NHibernate.Domain
{
    public class Person
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
    }
}
