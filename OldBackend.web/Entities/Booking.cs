using System;
using static Pencil42App.Web.Entities.Suggestion;

namespace Pencil42App.Web.Entities
{
    public class Booking : Time_registering
    {
        public enum BookingKind { Verlof, Werk }
        public int WeekId {get;set;}   
        public enum Day { Monday, Tuesday, Thursday, Friday, Saturday, Sunday }
        public Day DayOfWeek { get; set; }
        public BookingKind Kind { get; set; }

        public double NumberOfHours { get; set; }

    }
}