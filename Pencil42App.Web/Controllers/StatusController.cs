using Microsoft.AspNetCore.Mvc;
using Pencil42App.Util;
using Pencil42App.Web.Entities;
using Pencil42App.Web.Repositories;
using Pencil42App.Web.Contracts;
using System;
using System.Linq;
using static Pencil42App.Web.Entities.Booking;

namespace Pencil42App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        private IWeekRepository _weekRepository;
        private IBookingRepository _bookingRepository;

         public StatusController(IWeekRepository weekRepository, IBookingRepository bookingRepository)
        {
            _weekRepository = weekRepository;
            _bookingRepository = bookingRepository;
        }

        [Route("/{userId}")]
        [HttpGet]
        public Week[] getAllWeeks([FromRoute] string userId)
        {
            Logger.Info(this, "All weeks are being retrieved"); 
            return _weekRepository.GetAll(userId);
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Week> getWeekWithId([FromRoute] int id)
        {
            Logger.Info(this, $"Week with id {id} is being retrieved");
            var week = _weekRepository.Get(id);
            if (week == null)
            {
                return NotFound();
            }
            return Ok(week);

        }

        [Route("/{userId}/{weekNumber}/{year}")]
        [HttpGet]
        public ActionResult<Week> getWeekWithWeekNumber([FromRoute] string userId, [FromRoute] int weekNumber, [FromRoute] int year)
        {
            Logger.Info(this, $"Week with weekNumber {weekNumber} is being retrieved");
            var week = _weekRepository.Get(weekNumber, year, userId);
            if (week == null)
            {
                return NotFound();
            }
            return Ok(week);
        }

        [Route("{weekid}/bookings")]
        [HttpGet]
        public Booking[] GetBookingsForWeek([FromRoute] int weekid)
        //public IActionResult Get([FromRoute] int id)
        {
            Logger.Info(this, $"Bookings of week with id {weekid} are being retrieved");
            return _weekRepository.GetAllBookings(weekid);

        }

        [Route("{weekid}/{milestone}/hours/{day}")]
        [HttpGet]
        public double GetWorkedHoursForDays([FromRoute] int weekid, [FromRoute] String milestone, [FromRoute] Day day)
        {
            Logger.Info(this, $"Hours of week with id {weekid} are being retrieved");
            var bookings_week_milestone = _weekRepository.GetAllBookings(weekid).Where(b => b.Milestone == milestone).Where(b => b.DayOfWeek == day);
            Logger.Warn(this, $"weekid:  {weekid} milestone: {milestone}  day: {day}");
            double sum_temp = 0;

            foreach (Booking booking in bookings_week_milestone){
                sum_temp = sum_temp + booking.NumberOfHours;
            }

            return sum_temp;
        }

        [Route("{weekid}/{bookingid}")]
        [HttpGet]
        public ActionResult<Booking> getBooking([FromRoute] int weekid, [FromRoute] int bookingid)
        {
            Logger.Info(this, $"Booking with id {bookingid} is being retrieved");
            
            var booking = _bookingRepository.Get(bookingid);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);

        }

        [Route("{weekid}/{bookingid}")]
        [HttpPut]
        public ActionResult<Week> AddBookingToWeekById([FromRoute] int weekid, [FromRoute] int bookingid)
        {
            var week = _weekRepository.Get(weekid);
            if (week == null)
            {
                return NotFound();
            }
           


            //in case its a suggestion
           
                Booking booking = _bookingRepository.Get(bookingid);
                if(booking != null)
                {
                     week.Bookings.Add(booking);
                    week.HoursWorked = week.HoursWorked + booking.NumberOfHours;
                }
                else
                {
                    return NotFound();
                }
       

            //week.HoursWorked = week.HoursWorked + 

            return Ok(week);
        }

        [Route("{weekid}")]
        [HttpPost]
        public ActionResult<Week> AddBookingToWeekByContract([FromRoute] int weekid, [FromBody] AddBooking book){
            Logger.Info(this, "BOOKING IS BEING ADDED");
   

            var bookingFromBooking = new Entities.Booking{
                Kind = book.kind,
                WeekId = weekid,
                DayOfWeek = book.day,
                Milestone = book.milestone,
                Description = book.description,
                Id = _bookingRepository.createUniqueId(),
                Type = book.type,

                NumberOfHours = book.nrOfHours
            };

            _bookingRepository.Add(bookingFromBooking);

            var week = _weekRepository.Get(weekid);
            if (week == null)
            {
                return NotFound();
            }
            week.Bookings.Add(bookingFromBooking);

            

              
                double v = week.HoursWorked + bookingFromBooking.NumberOfHours;
                week.HoursWorked = v;
            _weekRepository.Update(weekid, week);

            //week.HoursWorked = week.HoursWorked + 

            return Ok(week);


        }


        [Route("/fromsuggestion/{weekId}")]
        [HttpPost]
        public IActionResult AddBookingFromSuggestionToWeek([FromRoute] int weekId, [FromBody] AddBooking book){
            Logger.Info(this, "Booking is being added from suggestion");

            var bookingFromSuggestion = new Entities.Booking{
                Kind = book.kind,
                WeekId = book.WeekId,
                DayOfWeek = book.day,
                Milestone = book.milestone,
                Description = book.description,
                Id = _bookingRepository.createUniqueId(),
                Type = book.type,
                NumberOfHours = book.nrOfHours
                };
            Logger.Info(this, "Booking has been created"); // TODO

            _bookingRepository.AddFromSuggestion(bookingFromSuggestion);

            Logger.Info(this, "Booking was added from suggestion, retrieving week with id:" + weekId); // TODO

            var week = _weekRepository.Get(weekId);
            if (week == null)
            {
                return NotFound();
            }
            Logger.Info(this, "Adding booking to week"); // TODO
            week.Bookings.Add(bookingFromSuggestion);

            double v = week.HoursWorked + bookingFromSuggestion.NumberOfHours;
            week.HoursWorked = v;
            Logger.Info(this, "Updating week"); // TODO
            _weekRepository.Update(weekId, week);

            Logger.Info(this, "Returning 200 OK"); // TODO
            return Ok(week);
        }

        [Route("{id}/complete/{complete}")]
        [HttpPut]
        public IActionResult UpdateWeekWithComplete([FromRoute] int id, [FromRoute] Boolean complete)
        {
            Logger.Info(this, $"Week with id {id} is being updated");
            var week = _weekRepository.Get(id);
            week.Week_complete = complete;
            Logger.Info(this, $"complete: {week.Week_complete}");
            _weekRepository.Update(id, week);


            return Ok();
        }
    }
}