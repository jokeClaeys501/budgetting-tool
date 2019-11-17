using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pencil42App.Web.Entities;
using Pencil42App.Util;

namespace Pencil42App.Web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly App42Context _context;

        public UserRepository(App42Context context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            // user.Weeks = new Week[52]; 
            for (int i = 1; i < 53; i++) {
                _context.Weeks.Add(new Week {
                    Id=this.createUniqueId()+i,
                    WeekNumber=i,
                    Year=1900,
                    HoursWorked=0,
                    UserId = user.Id,
                    Week_complete=false
                });
            }
            /* foreach (Week week in user.Weeks)
            {
                Logger.Info(this, $"user week: {week}");
                    week.Id=this.createUniqueId();
                    week.WeekNumber=1;
                    week.Year=1900;
                    week.HoursWorked=0;
                    week.UserId = "dummy";
                    week.Week_complete=false;
            }; */
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public int createUniqueId (){
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        public void Delete(string user_id)
        {
            var dbUser = _context.Users.FirstOrDefault(u => u.Id == user_id);
            if (dbUser == null)
            {
                throw new ArgumentOutOfRangeException("user not found when trying to delete");

            }
            _context.Users.Remove(dbUser);
            _context.SaveChanges();
        }

        public User Get(string user_id)
        {
            return _context.Users.Where(u => u.Id == user_id).FirstOrDefault();
        }

        public User[] GetAll()
        {
            return _context.Users
                .Include(u => u.Suggestions)
                .ToArray();
        }


        public void Update(string user_id, User user)
        {
            var dbUser = _context.Users.FirstOrDefault(u => u.Id == user_id);
            if(dbUser == null)
            {
                throw new ArgumentOutOfRangeException("user not found when trying to update");   
            }
            dbUser.Name = user.Name;
            dbUser.HoursToWorkInAWeek = user.HoursToWorkInAWeek;
            dbUser.Suggestions = user.Suggestions;

            _context.SaveChanges();
        }
    }
}
