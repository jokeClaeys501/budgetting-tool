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

            
        }

       
    }
}
