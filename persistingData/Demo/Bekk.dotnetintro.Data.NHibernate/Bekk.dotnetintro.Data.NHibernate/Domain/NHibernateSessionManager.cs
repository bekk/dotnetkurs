using NHibernate;
using NHibernate.Cfg;

namespace Bekk.dotnetintro.Data.NHibernate.Domain
{
    public class NHibernateSessionManager
    {
        private static ISessionFactory _sessionFactory;
        private static readonly object LockObject = new object();

        private static ISessionFactory GetSessionFactory()
        {
            lock (LockObject)
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof (Car).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return GetSessionFactory().OpenSession();
        }
    }
}
