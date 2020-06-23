using Microsoft.AspNetCore.Mvc;
using Pencil42App.Util;
using Pencil42App.Web.Entities;
using Pencil42App.Web.Repositories;
using Pencil42App.Web.Contracts;

namespace Pencil42App.Web.Controllers
{
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class SuggestionsController : Controller
    {
        private ISuggestionRepository _suggestionRepository;

        public SuggestionsController(ISuggestionRepository suggestionRepository, IBookingRepository bookingRepository)
        {
            _suggestionRepository = suggestionRepository;
        }

        [Route("")]
        [HttpGet]
        public Suggestion[] GetAllSuggestions([FromRoute] string userId)
        { 
            Logger.Info(this, $"All suggestions are being retrieved for user {userId}");

            return _suggestionRepository.GetAll(userId);
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Suggestion> GetSuggestion([FromRoute] int id)
        {
            Logger.Info(this, $"Suggestion with id {id} is being retrieved");
            Suggestion suggestion = _suggestionRepository.Get(id);
            if (suggestion == null)
            {
                return NotFound();
            }
            return Ok(suggestion);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdateSuggestion([FromRoute] int id, [FromBody] Suggestion suggestion, [FromRoute] string userId)
        {
            Logger.Info(this, $"Suggestion with id {id} is being updated");
            if (suggestion == null)//suggestion null of Id null: null coalescing operator
            {
                return BadRequest("suggestion is required");
            }
            var sugg = _suggestionRepository.Get(suggestion.Id);
            if (sugg == null)
            {
                return BadRequest($"A suggestion with id {suggestion.Id} does not yet exist");
            }
            if (suggestion.UserId != userId || suggestion.Id != id)
            {
                return BadRequest("Ids don't match");
            }
            if (string.IsNullOrWhiteSpace(suggestion.Name) || string.IsNullOrWhiteSpace(suggestion.Milestone))
            {
                return BadRequest("suggestion name and/or milestone is required");
            }
            if (suggestion.NumberOfHours <= 0)
            {
                return BadRequest("suggestion hours need to be greater than 0");
            }

            _suggestionRepository.Update(id, suggestion);
            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult DeleteSuggestion([FromRoute] int id)
        {
            Logger.Info(this, $"Suggestion with id {id} is being deleted");
            var sugg = _suggestionRepository.Get(id);
            if (sugg == null)
            {
                return NotFound();
            }

            _suggestionRepository.Delete(id);
            return Ok();
        }

        [Route("")]
        [HttpPost]
        public IActionResult AddSuggestion([FromBody] Suggestion suggestion, [FromRoute] string userId)
        { 
            // idee: suggestion invullen vanuit URL, suggestion opsplitsen zodat een kleiner object moet ingevuld worden door user?
            Logger.Info(this, $"Adding suggestion");
            if (suggestion?.Id == null)//suggestion null of Id null: null coalescing operator
            {
                return BadRequest("suggestion id is required");
            }
            var sugg = _suggestionRepository.Get(suggestion.Id);
            if (sugg != null)
            {
                return BadRequest($"A suggestion with id {suggestion.Id} already exists");
            }
            if (suggestion.UserId != userId)
            {
                return BadRequest("user id doesn't match url");
            }
            if (string.IsNullOrWhiteSpace(suggestion.Name) || string.IsNullOrWhiteSpace(suggestion.Milestone))
            {
                return BadRequest("suggestion name and/or milestone is required");
            }
            if (suggestion.NumberOfHours <= 0)
            {
                return BadRequest("suggestion type can't be null and/or hours need to be greater than 0");
            }
            
            _suggestionRepository.Add(suggestion);
            return Ok();
        }

    [Route("addByContract")]
    [HttpPost]
    public ActionResult<Week> AddSuggestionByContract([FromRoute] string userId, [FromBody] AddSuggestion contract){
        Logger.Info(this, "Adding suggestion by contract");

        // Suggestion: id, userId, Name, NumberOfHours, Kind, Type, Milestone, Description
        Suggestion newSugg = new Suggestion{
            Id = _suggestionRepository.createUniqueId(),
            UserId = userId,
            Name = contract.Name,
            NumberOfHours = contract.NumberOfHours,
            Kind = contract.Kind,
            Type = contract.Type,
            Milestone = contract.Milestone,
            Description = contract.Description,
        };
        this.AddSuggestion(newSugg,userId);
        return Ok(newSugg);
        }
    }
}
