using System;
using System.Linq;
using Bekk.dotnetintro.Data.NHibernate.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace CarDemo.IntegrationTest
{
    [TestClass]
    public class CarRepositoryTest
    {
        private static Configuration _configuration;
        private static ISessionFactory _sessionFactory;

        //expensive process to BuildSessionFactory, hence only done once for all tests
        [ClassInitialize]
        public static void InitializeTestClass(TestContext context)
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof (Car).Assembly);

            _sessionFactory = _configuration.BuildSessionFactory();
        }

        //assuring clean-slate for each test by regenereating the schema.
        [TestInitialize]
        public void InitializeTest()
        {
            new SchemaExport(_configuration).Execute(false, true, false);
        }

        [TestMethod]
        public void Add_CarIsNot_ExceptionNotThrown()
        {
            new CarRepository().Add(null);
        }

        [TestMethod]
        public void Add_NewCard_NewCarAdded()
        {
            var newCar = new Car {Make = "Saab", RegistrationNumber = "DN10000"};
            var repository = new CarRepository();
            repository.Add(newCar);

            AssertValuesForCarIsPersisted(newCar);
        }

        [TestMethod]
        public void Update_RegistrationNumberChanged_ChangePersistsInDataBase()
        {
            var newCar = new Car { Make = "Saab", RegistrationNumber = "DN10000" };
            var carRepository = new CarRepository();
            carRepository.Add(newCar);

            newCar.RegistrationNumber = "LJ10000";

            carRepository.Update(newCar);

            AssertValuesForCarIsPersisted(newCar);
        }

        [TestMethod]
        public void Remove_CarExistsInDb_CarRemoved()
        {
            var newCar = new Car { Make = "Saab", RegistrationNumber = "DN10000" };
            var carRepository = new CarRepository();
            carRepository.Add(newCar);

            carRepository.Remove(newCar);

            AssertCarIsNotInDb(newCar);
        }

        [TestMethod]
        public void GetBy_IdNotInDatabase_ReturnValueIsNull()
        {
            var carRepository = new CarRepository();
            var id = Guid.NewGuid();

            var nullCar = carRepository.GetBy(id);

            Assert.IsNull(nullCar);
        }

        [TestMethod]
        public void GetBy_IdFromCarInDb_CarReturned()
        {
            var newCar = new Car { Make = "Saab", RegistrationNumber = "DN10000" };
            var carRepository = new CarRepository();
            carRepository.Add(newCar);

            var savedCar = carRepository.GetBy(newCar.Id);

            Assert.AreEqual(newCar.Id, savedCar.Id);
        }

        [TestMethod]
        public void GetAll_TwoSaabsAndOneBMWInDb_OnlySaabsReturned()
        {
            var saab1 = new Car { Make = "Saab", RegistrationNumber = "DN10000"};
            var saab2 = new Car { Make = "Saab", RegistrationNumber = "DN10001"};
            var bmw1 = new Car { Make = "BMW", RegistrationNumber = "DN10002"};

            var carRepository = new CarRepository();
            carRepository.Add(saab1);
            carRepository.Add(saab2);
            carRepository.Add(bmw1);

            var saabs = carRepository.GetAll("Saab");

            Assert.AreEqual(2, saabs.Count());
        }

        private static void AssertCarIsNotInDb(Car car)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var removedCar = session.Get<Car>(car.Id);
                Assert.IsNull(removedCar);
            }
        }

        private static void AssertValuesForCarIsPersisted(Car newCar)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var addedCar = session.Get<Car>(newCar.Id);
                Assert.IsNotNull(addedCar);
                Assert.AreEqual(newCar.Id, addedCar.Id);
                Assert.AreEqual(newCar.Make, addedCar.Make);
                Assert.AreEqual(newCar.RegistrationNumber, addedCar.RegistrationNumber);
            }
        }
    }
}
