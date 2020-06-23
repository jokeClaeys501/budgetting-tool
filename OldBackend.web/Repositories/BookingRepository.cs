using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pencil42App.Util;
using Pencil42App.Web.Entities;

namespace Pencil42App.Web.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly App42Context _context; //moet in de context want deze objecten kunnen niet worden meegegeven aan week door inheritance
        public BookingRepository(App42Context context)
        {
            _context = context;
        }
        public void Add(Booking time)
        {
            int id_to_add = time.Id;
            Booking check_booking = _context.Bookings.Where(b => b.Id == id_to_add).FirstOrDefault();
            Suggestion check_suggestion = _context.Suggestions.Where(s => s.Id == id_to_add).FirstOrDefault();
            if ((check_booking == null) && (check_suggestion == null))
            {
                _context.Bookings.Add(time);
                _context.SaveChanges();
            }
            else
            {
                throw new System.InvalidOperationException("Id of booking is already in use");
            }

        }

        public void AddFromSuggestion(Booking time)
        {
            Logger.Info(this, "Adding to repository"); // TODO
            int id_to_add = time.Id;
            Suggestion check_suggestion = _context.Suggestions.Where(s => s.Id == id_to_add).FirstOrDefault();
            Booking check_booking = _context.Bookings.Where(b => b.Id == id_to_add).FirstOrDefault();
            Logger.Info(this, "Got check_booking"); // TODO
            if ((check_booking == null) && (check_suggestion == null))
            {
                Logger.Info(this, "check_booking was null"); // TODO
                _context.Bookings.Add(time);
                Logger.Info(this, "Booking was added to context"); // TODO
                _context.SaveChanges(); // 500 internal server error
                Logger.Info(this, "Context was saved"); // TODO
            }
            else
            {
                Logger.Info(this, "check_booking was not null"); // TODO
                throw new System.InvalidOperationException("Id of booking is already in use");
            }
            Logger.Info(this, "Exiting repository"); // TODO
        }

        public void Delete(int time_id)
        {
            var dbTime = _context.Bookings.FirstOrDefault(w => w.Id == time_id);
            if (dbTime == null)
            {
                throw new ArgumentOutOfRangeException("Timeregistering not found when trying to delete");

            }
            _context.Bookings.Remove(dbTime);
            _context.SaveChanges();
        }

        public Booking Get(int time_id)
        {
            return _context.Bookings.Where(t => t.Id == time_id).FirstOrDefault();
        }

        public Booking[] GetAll()
        {
            return _context.Bookings.ToArray();
        }

        public void Update(int time_id, Booking time)
        {
            var dbTime = _context.Bookings.FirstOrDefault(t => t.Id == time_id);
            if (dbTime == null)
            {
                throw new ArgumentOutOfRangeException("Timeregistering not found when trying to update");
            }

            dbTime.WeekId = time.WeekId;
            dbTime.Kind = time.Kind;
            dbTime.DayOfWeek = time.DayOfWeek;
            dbTime.Id = time.Id;
            dbTime.NumberOfHours = time.NumberOfHours;
 
            
        }
        public int createUniqueId (){
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
