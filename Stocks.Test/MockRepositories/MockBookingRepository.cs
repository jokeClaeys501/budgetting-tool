using Pencil42App.Web.Entities;
using Pencil42App.Web.Repositories;

namespace Pencil42App.Test.Controllers
{
    internal class MockBookingRepository : IBookingRepository
    {
        public void Add(Booking booking)
        {
            throw new System.NotImplementedException();
        }

        public void AddFromSuggestion(Booking booking)
        {
            throw new System.NotImplementedException();
        }

        public int createUniqueId(int user_id)
        {
            throw new System.NotImplementedException();
        }

        public int createUniqueId()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int time_id)
        {
            throw new System.NotImplementedException();
        }

        public Booking Get(int time_id)
        {
            throw new System.NotImplementedException();
        }

        public Booking[] GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(int time_id, Booking booking)
        {
            throw new System.NotImplementedException();
        }
    }
}