using System.Collections.Generic;
using Pencil42App.Web.Entities;
using Pencil42App.Web.Repositories;
using static Pencil42App.Web.Entities.Time_registering;

namespace Pencil42App.Test.MockRepositories
{
    public class MockContext //: App42Context
    {
        public ISet<User> Users { get; set; }
        public ISet<Week> Weeks { get; set; }
        public ISet<Booking> Bookings { get; set; }
        public ISet<Suggestion> Suggestions { get; set; }

        public MockContext()
        {
            Suggestions.Add(new Suggestion()
            {
                Id = 2,
                Name = "Dit is een suggestie",
                NumberOfHours = 8.0,
                Description = "In MockContext",
                Milestone = "Mocking context",
                Type = BookingType.Training
            });
        }
    }
}