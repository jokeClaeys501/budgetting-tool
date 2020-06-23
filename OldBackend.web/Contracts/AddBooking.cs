using Pencil42App.Web.Entities;

namespace Pencil42App.Web.Contracts
{
    public class AddBooking
    {
        public int WeekId { get; set; }
        //public enum Day { Monday, Tuesday, Thursday, Friday, Saturday, Sunday }
        public Booking.Day day { get; set; }

        public Time_registering.BookingType type {get;set;}

        public Booking.BookingKind kind {get;set;}

        //public int bookingId {get;set;}

        public double nrOfHours {get;set;}

        public string description { get; set; }

        public string milestone { get; set; }
        
    }
}