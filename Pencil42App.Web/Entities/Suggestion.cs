namespace Pencil42App.Web.Entities
{
    public class Suggestion: Time_registering
    {
        public double NumberOfHours { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public Booking.BookingKind Kind { get; set; }

    }


}
