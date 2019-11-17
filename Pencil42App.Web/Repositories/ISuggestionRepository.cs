using Pencil42App.Web.Entities;

namespace Pencil42App.Web.Repositories
{
    public interface ISuggestionRepository
    {
        Suggestion Get(int sugg_id);
        void Add(Suggestion suggestion);
        void Update(int sugg_id, Suggestion suggestion);
        void Delete(int sugg_id);
        Suggestion[] GetAll(string userId);
        int createUniqueId ();
    }
}
