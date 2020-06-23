using Pencil42App.Web.Entities;

namespace Pencil42App.Web.Repositories
{
    public interface IUserRepository
    {
        User[] GetAll(); //je werkt maar op 1 tabel dus die mag objecten teruggeven
        //int[] GetMilestonesOfUser(int user_id); //je werkt op meerdere tabellen dus dan geef je ids terug
        //int GetHoursToWorkInAWeek(int user_id);
        User Get(string user_id);
        void Add(User user);
        void Update(string user_id, User user);
        void Delete(string user_id);
        //int[] GetSuggestions(int user_id);
    }
}
