using System;
using System.Linq;
using Pencil42App.Web.Entities;

namespace Pencil42App.Web.Repositories
{
    public class SuggestionRepository : ISuggestionRepository
    {
        private readonly App42Context _context;

        public SuggestionRepository(App42Context context)
        {
            _context = context;
        }

        public void Add(Suggestion suggestion)
        {
            int id_to_add = suggestion.Id;
            Booking check_booking = _context.Bookings.Where(b => b.Id == id_to_add).FirstOrDefault();
            Suggestion check_suggestion = _context.Suggestions.Where(s => s.Id == id_to_add).FirstOrDefault();
            if ((check_booking == null) && (check_suggestion == null))
            {
                _context.Suggestions.Add(suggestion);
                _context.SaveChanges();
            }
            else
            {
                throw new System.InvalidOperationException("Id of suggestion is already in use");
            }
        }

        public void Delete(int sugg_id)
        {
            var dbSuggestion = _context.Suggestions.FirstOrDefault(s => s.Id == sugg_id);
            if (dbSuggestion == null)
            {
                throw new ArgumentOutOfRangeException("suggestion not found when trying to delete");

            }
            _context.Suggestions.Remove(dbSuggestion);
            _context.SaveChanges();
        }

        public Suggestion Get(int sugg_id)
        {
            return _context.Suggestions.Where(s => s.Id == sugg_id).FirstOrDefault();
        }

        public Suggestion[] GetAll(string userId)
        {
            return _context.Suggestions.Where(s => s.UserId == userId).ToArray();
        }

        public void Update(int sugg_id, Suggestion suggestion)
        {
            var dbSuggestion = _context.Suggestions.FirstOrDefault(s => s.Id == sugg_id);
            if(dbSuggestion == null)
            {
                throw new ArgumentOutOfRangeException("suggestion not found when trying to update");
            }
            dbSuggestion.Name = suggestion.Name;
            dbSuggestion.Milestone = suggestion.Milestone;
            dbSuggestion.Type = suggestion.Type;
            dbSuggestion.Description = suggestion.Description;
            dbSuggestion.NumberOfHours = suggestion.NumberOfHours;
            dbSuggestion.UserId = suggestion.UserId;

            _context.SaveChanges();
        }
        public int createUniqueId (){
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
