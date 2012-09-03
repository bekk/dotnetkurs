using System.Linq;
using Bekk.dotnetintro.WebApi.Persons.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bekk.dotnetintro.WebApi.Persons.UnitTest
{
    [TestClass]
    public class PersonRepositoryTest
    {
        [TestMethod]
        public void Get_RepositoryContainsTwoPersons_EmptyListReturned()
        {
            var repository = new PersonRepository();

            var persons = repository.Get();

            Assert.AreEqual(2, persons.Count());
        }
    }
}
