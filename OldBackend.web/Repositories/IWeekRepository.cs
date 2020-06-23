using Pencil42App.Web.Entities;

namespace Pencil42App.Web.Repositories
{
    public interface IWeekRepository
    {
        Week Get(int week_id);
        Week Get(int weeknr, int year, string userId);
        void Add(Week week);
        Booking[] GetAllBookings(int weekid);
        void Update(int week_id, Week week);
        void Delete(int week_id);
    
        int GetWeekId(string userId, int weekNr);

        Week[] GetAll(string userId);
    }
}
