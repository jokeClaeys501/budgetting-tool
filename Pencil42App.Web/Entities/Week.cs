using System.Collections.Generic;

namespace Pencil42App.Web.Entities
{
    public class Week
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }
        public int Year { get; set; }
        public bool[] CompleteDays { get; set; }
        //public Time_registering[] Time_registering { get; set; }
        //public List<int> Time_registering_ids { get; set; } //moet want die time_registering mag geen property zijn van iets in de database op context
       public virtual ICollection<Booking> Bookings { get; set; }
        public double HoursWorked { get; set; }

        public string UserId { get; set; }

        public bool Week_complete { get; set; }
    }
}
