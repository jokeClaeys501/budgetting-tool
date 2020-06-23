using System;
using System.Linq;
using Pencil42App.Web.Entities;
using Pencil42App.Web.Repositories;
using static Pencil42App.Web.Entities.Time_registering;

namespace Pencil42App.Test.MockRepositories
{
    public class MockSuggestionRepository : ISuggestionRepository
    {
        private readonly MockContext _context;

        public MockSuggestionRepository(MockContext context)
        {
            _context = context;
        }

        /* 
         * adds suggestion with id 1
         * doesn't add suggestion with id 2
         */
        public void Add(Suggestion suggestion)
        {
            int id_to_add = suggestion.Id;
            if (id_to_add == 1)
            {
                _context.Suggestions.Add(suggestion);
            }
            else if (id_to_add == 2)
            {
                throw new InvalidOperationException("Id of suggestion is already in use");
            }
            else
            {
                throw new ArgumentException("Id not mocked");
            }
        }

        public int createUniqueId()
        {
            throw new NotImplementedException();
        }

        // TODO
        public void Delete(int sugg_id)
        {
            var dbSuggestion = _context.Suggestions.FirstOrDefault(s => s.Id == sugg_id);
            if (dbSuggestion == null)
            {
                throw new ArgumentOutOfRangeException("suggestion not found when trying to delete");

            }
            _context.Suggestions.Remove(dbSuggestion);
        }

        /*
         * returns suggestion with id 1
         * doesn't return suggestion with id 2
         */
        public Suggestion Get(int sugg_id)
        { 
            if (sugg_id == 1)
            {
                return new Suggestion()
                {
                    Id = 1,
                    Name = "Intern 8 uur gewerkt",
                    NumberOfHours = 8.0,
                    Description = "dotNET",
                    Milestone = "Fixing app42",
                    Type = BookingType.Training
                };
            }
            if (sugg_id == 2)
            {
                throw new InvalidOperationException("Suggestion doesn't exist");
            }
            throw new ArgumentException("Id not mocked");
        }

        // TODO
        public Suggestion[] GetAll(int userId)
        {
            return _context.Suggestions.Where(s => s.UserId == userId).ToArray();
        }

        // TODO
        public void Update(int sugg_id, Suggestion suggestion)
        {
            var dbSuggestion = _context.Suggestions.FirstOrDefault(s => s.Id == sugg_id);
            if (dbSuggestion == null)
            {
                throw new ArgumentOutOfRangeException("suggestion not found when trying to update");
            }
            dbSuggestion.Name = suggestion.Name;
            dbSuggestion.Milestone = suggestion.Milestone;
            dbSuggestion.Type = suggestion.Type;
            dbSuggestion.Description = suggestion.Description;
            dbSuggestion.NumberOfHours = suggestion.NumberOfHours;
            dbSuggestion.UserId = suggestion.UserId;

            // _context.SaveChanges();
        }
    }
}
