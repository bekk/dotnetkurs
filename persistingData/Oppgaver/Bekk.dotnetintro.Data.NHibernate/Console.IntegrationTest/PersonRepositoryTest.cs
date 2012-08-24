using System.Linq;
using Bekk.dotnetintro.Data.NHibernate.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Console.IntegrationTest
{
    [TestClass]
    public class PersonRepositoryTest
    {
        private static ISessionFactory _sessionFactory;
        private static Configuration _configuration;

        [ClassInitialize]
        public static void InitializeTestClass(TestContext context)
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof (Person).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        [TestInitialize]
        public void InitializeTest()
        {
            new SchemaExport(_configuration).Execute(false, true, false);
        }

        [TestMethod]
        public void Add_PersonIsNull_ExceptionNotThrown()
        {
            var repository = new PersonRepository();

            repository.Add(null);
        }

        [TestMethod]
        public void Add_ValidPerson_PersonAddedToDatabase()
        {
            var newPerson = new Person {FirstName = "Albert", LastName = "Einstein"};
            var repository = new PersonRepository();

            repository.Add(newPerson);

            using (var session = _sessionFactory.OpenSession())
            {
                var addedPerson = session.Get<Person>(newPerson.Id);
                Assert.AreEqual("Albert", addedPerson.FirstName);
                Assert.AreEqual("Einstein", newPerson.LastName);
            }
        }

        [TestMethod]
        public void Update_ChangeEmailOfExistingPerson_EmailChanged()
        {
            var existingPerson = new Person {FirstName = "Albert", LastName = "Einstein", Email = "albert@einstein.com"};
            var repository = new PersonRepository();
            repository.Add(existingPerson);

            existingPerson.Email = "a@einstein.com";

            repository.Update(existingPerson);

            using (var session = _sessionFactory.OpenSession())
            {
                var updatedPerson = session.Get<Person>(existingPerson.Id);
                Assert.AreEqual("a@einstein.com", updatedPerson.Email);
            }
        }

        [TestMethod]
        public void Remove_ExisitingPersonInDb_ExistingPersonRemoved()
        {
            var existingPerson = new Person { FirstName = "Albert", LastName = "Einstein", Email = "albert@einstein.com" };
            var repository = new PersonRepository();
            repository.Add(existingPerson);

            repository.Remove(existingPerson);

            using (var session = _sessionFactory.OpenSession())
            {
                var removedPerson = session.Get<Person>(existingPerson.Id);
                Assert.IsNull(removedPerson);
            }
        }

        [TestMethod]
        public void GetBy_ValidIdForPersonInDb_PersonReturned()
        {
            var existingPerson = new Person { FirstName = "Albert", LastName = "Einstein", Email = "albert@einstein.com" };
            var repository = new PersonRepository();
            repository.Add(existingPerson);

            var personFromDb = repository.GetBy(existingPerson.Id);

            Assert.AreEqual("Albert", personFromDb.FirstName);
            Assert.AreEqual("Einstein", personFromDb.LastName);
        }

        [TestMethod]
        public void GetAllPersonsWith_FirstNameIsAlbert_TwoPersonsReturned()
        {
            var albert1 = new Person { FirstName = "Albert", LastName = "Einstein", Email = "albert@einstein.com" };
            var albert2 = new Person { FirstName = "Albert", LastName = "TheOtherEinstein", Email = "albert@theOtherEinstein.com" };
            var isaac = new Person { FirstName = "Isaac", LastName = "Newton", Email = "isaac@newton.com" };

            var repository = new PersonRepository();
            repository.Add(albert1);
            repository.Add(albert2);
            repository.Add(isaac);

            var alberts = repository.GetAllPersonsWith("Albert");

            Assert.AreEqual(2, alberts.Count());
        }
    }
}
