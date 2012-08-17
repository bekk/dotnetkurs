using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Bekk.dotnetintro.TDD.Booking.UnitTest
{
    [TestClass]
    public class BookingComponentTest
    {
        [TestMethod]
        public void ConfirmBooking_ManualMocking_SendCalledOnEmailService()
        {
            var mockedEmailService = new FakeEmailService();
            var bookingComponent = new BookingComponent(mockedEmailService);

            var booking = new Booking();
            var person = new Person();

            bookingComponent.ConfirmBooking(booking, person);

            Assert.IsTrue(mockedEmailService.SendIsExecuted);
        }

        [TestMethod]
        public void ConfirmBooking_MockingThroughRhinoMocks_SendCalledOnEmailService()
        {
            var mockedEmailService = MockRepository.GenerateMock<IEmailService>();
            var bookingComponent = new BookingComponent(mockedEmailService);

            var booking = new Booking();
            var person = new Person();

            bookingComponent.ConfirmBooking(booking, person);

            mockedEmailService.AssertWasCalled(service => service.Send(Arg<Email>.Is.Anything));
        }
    }

    public class FakeEmailService : IEmailService
    {
        public bool SendIsExecuted { get; set; }

        public void Send(Email email)
        {
            SendIsExecuted = true;
        }
    }
}
