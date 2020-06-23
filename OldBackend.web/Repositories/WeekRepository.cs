using System;
using System.Linq;
using Pencil42App.Web.Entities;
using Pencil42App.Util;

namespace Pencil42App.Web.Repositories
{
    public class WeekRepository : IWeekRepository
    {
        private readonly App42Context _context;
        public WeekRepository(App42Context context)
        {
            _context = context;
        }
        public void Add(Week week)
        {
            _context.Weeks.Add(week);
            _context.SaveChanges();
        }

        public void Delete(int week_id)
        {
            var dbWeek = _context.Weeks.FirstOrDefault(w => w.Id == week_id);
            if (dbWeek == null)
            {
                throw new ArgumentOutOfRangeException("user not found when trying to delete");

            }
            _context.Weeks.Remove(dbWeek);
            _context.SaveChanges();
        }

        public Week Get(int week_id)
        {
            Week result = _context.Weeks.Where(w => w.Id == week_id).FirstOrDefault();
            Logger.Info(this, "searched for week with id:" + week_id + "-" + "returning week with id:" + result.Id);
            return result;
        }

        public Week Get(int weeknr, int year, string userId)
        {
            return _context.Weeks.Where(w => w.WeekNumber == weeknr).Where(w=>w.Year==year).Where(w=>w.UserId==userId).FirstOrDefault();
        }

        public int GetWeekId(string userId, int weekNr){
           Week week = _context.Weeks.Where(w => w.UserId == userId).Where(w => w.WeekNumber == weekNr).FirstOrDefault();
            return week.Id;
       }

       public Booking[] GetAllBookings(int weekid){
           Week week = _context.Weeks.Where(w => w.Id == weekid).FirstOrDefault();
           return _context.Bookings.Where(b => b.WeekId == weekid).ToArray();
       }

        public Week[] GetAll(string userId)
        {
            return _context.Weeks.Where(w => w.UserId == userId).ToArray();
        }

        public void Update(int week_id, Week week)
        {
            Logger.Info(this, $"Week is being updated");
            var dbWeek = _context.Weeks.FirstOrDefault(w => w.Id == week_id);
            if (dbWeek == null)
            {
                throw new ArgumentOutOfRangeException("week not found when trying to update");
            }
            dbWeek.WeekNumber = week.WeekNumber;
            dbWeek.Year = week.Year;
            dbWeek.CompleteDays = week.CompleteDays;
            dbWeek.UserId = week.UserId;
            dbWeek.HoursWorked = week.HoursWorked;
            dbWeek.Bookings = week.Bookings;
            dbWeek.Week_complete = week.Week_complete;
            Logger.Info(this, $"Week has {dbWeek.HoursWorked} hours");
            _context.SaveChanges();
        }
    }
}
