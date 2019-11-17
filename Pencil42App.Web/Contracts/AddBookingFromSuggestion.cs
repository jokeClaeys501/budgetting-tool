using Pencil42App.Web.Entities;

namespace Pencil42App.Web.Contracts
{
    public class AddBookingFromSuggestion
    {
        public int WeekId { get; set; }
        //public enum Day { Monday, Tuesday, Thursday, Friday, Saturday, Sunday }
        public Booking.Day Day { get; set; }

        // public Suggestion Suggestion {get;set;}
    }
}