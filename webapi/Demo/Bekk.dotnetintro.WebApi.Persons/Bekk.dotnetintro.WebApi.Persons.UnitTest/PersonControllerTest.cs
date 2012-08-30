using System.Collections.Generic;
using System.Linq;
using Bekk.dotnetintro.WebApi.Persons.Controllers;
using Bekk.dotnetintro.WebApi.Persons.Models;
using Bekk.dotnetintro.WebApi.Persons.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Bekk.dotnetintro.WebApi.Persons.UnitTest
{
    [TestClass]
    public class PersonControllerTest
    {
        [TestMethod]
        public void Get_NoPersonsInRepository_EmptyListReturned()
        {
            var stubbedRepository = MockRepository.GenerateStub<IPersonRepository>();
            stubbedRepository.Stub(repository => repository.Get()).Return(new List<Person>());
            var controller = new PersonController(stubbedRepository);

            var persons = controller.Get();

            Assert.AreEqual(0, persons.Count());
        }

        [TestMethod]
        public void Get_TwoPersonsInRepository_TwoPersonsReturned()
        {
            var repository = MockRepository.GenerateStub<IPersonRepository>();
            var personsInRepository = new List<Person>{new Person(), new Person()};
            repository.Stub(personRepository => personRepository.Get()).Return(personsInRepository);

            var controller = new PersonController(repository);

            var persons = controller.Get();

            Assert.AreEqual(2, persons.Count());
        }
    }
}
