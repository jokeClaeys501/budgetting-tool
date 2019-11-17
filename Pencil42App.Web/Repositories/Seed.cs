using Microsoft.EntityFrameworkCore;
using Pencil42App.Util;
using Pencil42App.Web.Entities;
using static Pencil42App.Web.Entities.Time_registering;

namespace Pencil42App.Web.Repositories
{
    public class Seed
    {
        private readonly App42Context _context;
        private readonly IUserRepository _userRepository;
        private readonly IWeekRepository _weekRepository;

        private readonly IBookingRepository _bookingRepository;

        public Seed(IUserRepository userRepository, IWeekRepository weekRepository, IBookingRepository bookingRepository, App42Context ctx)
        {
            _userRepository = userRepository;
            _weekRepository = weekRepository;
            _bookingRepository = bookingRepository;
            _context = ctx;
        }

        public void Run()
        {
            _context.Database.Migrate();
            // _context.Database.EnsureCreated();

            if(_userRepository.Get("dummy") == null)
            {
                Logger.Info(this, "Seed dummy"); 
                _userRepository.Add(new Entities.User
                {
                    Id = "dummy",
                    Name = "Dummy Dumdum",
                    Suggestions = new[]
                    {
                        new Suggestion
                        {
                            Id=1,
                            Name="Intern 8 uur gewerkt",
                            NumberOfHours=8.0,
                            Description="dotNET",
                            Milestone="Fixing app42",
                            Type=BookingType.Training
                        }
                    }
                    /* Weeks = new[] 
                    {
                        new Week 
                        {
                            Id=1,
                            WeekNumber=1,
                            Year=1900,
                            HoursWorked=0,
                            UserId = "dummy",
                            Week_complete=false
                        }
                    } */
                    
                });
            }
        }
        /* public void Run()
        {
            _context.Database.Migrate();
            // _context.Database.EnsureCreated();

            if(_userRepository.Get("1") == null)
            {
                Logger.Info(this, "Seed 1"); // TODO
                _userRepository.Add(new Entities.User
                {
                    Id = "1",
                    Name = "Oompaloompa",
                    Suggestions = new[]
                    {
                        new Suggestion
                        {
                            Id=1,
                            Name="Intern 8 uur gewerkt",
                            NumberOfHours=8.0,
                            Description="dotNET",
                            Milestone="Fixing app42",
                            Type=BookingType.Training
                        }
                    },
                    
                });
            }
            if (_userRepository.Get("2") == null)
            {
                Logger.Info(this, "Seed 2"); // TODO
                _userRepository.Add(new Entities.User
                {
                    Id = "2",
                    Name = "Oompaloompaa",
                    Weeks = new[]
                    {
                        new Week
                        {
                            Id=2,
                            WeekNumber=32,
                            Year=2019,
                            HoursWorked=32,
                            UserId ="2",
                            Week_complete=false
                        }
                    },

                });
                
            }
            if(_weekRepository.Get(3) == null)
            {
                Logger.Info(this, "Seed 3"); // TODO
                _weekRepository.Add(new Entities.Week
                {
                    Id=3,
                    WeekNumber=33,
                    Year=2019,
                    HoursWorked=8,
                    UserId = "2",
                    Week_complete=false
                });
            }

             if(_weekRepository.Get(4)==null){
                 Logger.Info(this, "Seed 4"); // TODO
                 _weekRepository.Add(new Entities.Week{
                     Id=4,
                    WeekNumber=34,
                    Year=2019,
                    HoursWorked=8,
                    UserId = "2",
                    Week_complete=false,
                    Bookings = new[]
                    {
                        new Booking{
                            Id = 3,
                            Kind = Booking.BookingKind.Werk,
                            DayOfWeek = Booking.Day.Monday,
                            NumberOfHours = 8,
                            WeekId = 4
                        }
                    },
                 });
                
                
            }
            
        } */
    }
}
