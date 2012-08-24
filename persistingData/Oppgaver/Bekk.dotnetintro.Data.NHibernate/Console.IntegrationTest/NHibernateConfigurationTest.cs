using Bekk.dotnetintro.Data.NHibernate.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Console.IntegrationTest
{
    [TestClass]
    public class NHibernateConfigurationTest
    {
        [TestMethod]
        public void Execute_ConfigurationIsPresent_SchemaGenerated()
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddAssembly(typeof(Person).Assembly);

            new SchemaExport(configuration).Execute(false, true, false);
        }
    }
}
