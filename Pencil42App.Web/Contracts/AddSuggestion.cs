using Pencil42App.Web.Entities;

namespace Pencil42App.Web.Contracts
{
    public class AddSuggestion
    {
        public string Name {get; set;}
        public string Milestone { get; set; }
        public int NumberOfHours {get;set;}
        public Booking.BookingKind Kind {get;set;}
        public Time_registering.BookingType Type {get;set;}
        public string Description { get; set; }
    }
}