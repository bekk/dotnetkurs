namespace Bekk.dotnetintro.TDD.Booking
{
    public class BookingComponent
    {
        private IEmailService _emailService;


        public BookingComponent(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void ConfirmBooking(Booking booking, Person person)
        {
            var email = new Email();
            _emailService.Send(email);
        }
    }
}
