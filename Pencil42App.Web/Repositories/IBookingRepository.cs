using Pencil42App.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pencil42App.Web.Repositories
{
    public interface IBookingRepository
    {
        Booking Get(int time_id);
        void Add(Booking booking);
        void AddFromSuggestion(Booking booking);
        void Update(int time_id, Booking booking);
        void Delete(int time_id);
        int createUniqueId ();

        Booking[] GetAll();
    }
}
