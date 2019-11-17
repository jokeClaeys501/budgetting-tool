using Microsoft.AspNetCore.Mvc;
using Pencil42App.Util;
using Pencil42App.Web.Entities;
using Pencil42App.Web.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Pencil42App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "bsid")] //bsoa
    public class UsersController: Controller
    {
        private IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [Route("")]
        [HttpGet]

        public User[] GetAllUsers()
        {
            Logger.Info(this, "All customers are being retrieved");

            return _userRepository.GetAll();
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<User> GetUser([FromRoute] string id)
        {
            Logger.Info(this, $"User with id {id} is being retrieved");
            var user = _userRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdateUser([FromRoute] string id, [FromBody] User user)
        {
            Logger.Info(this, $"User with id {id} is being updated");
            if (string.IsNullOrWhiteSpace(user.Name) || user == null)
            {
                return BadRequest("user name is required");
            }
            _userRepository.Update(id, user);

            return Ok();
        }

        [Route("{id}/{hoursToWork}")]
        [HttpPut]
        public IActionResult UpdateUserWithHoursToWorkInAWeek([FromRoute] string id, [FromRoute] int hoursToWork)
        {
            Logger.Info(this, $"User with id {id} is being updated");
            var user = _userRepository.Get(id);
            user.HoursToWorkInAWeek = hoursToWork;
            Logger.Info(this, $"hoursToWork: {user.HoursToWorkInAWeek}");
            _userRepository.Update(id, user);


            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteUser([FromRoute] string id)
        {
            Logger.Info(this, $"User with id {id} is being deleted");
            var user = _userRepository.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Delete(id);

            return Ok();
        }

        [Route("")]
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            Logger.Info(this, $"User adding");
            if (user?.Id == null)
            {
                return BadRequest("user id is required");
            }

            if (string.IsNullOrWhiteSpace(user.Name))
            {
                return BadRequest("user name is required");
            }

            _userRepository.Add(user);

            return Ok();
        }

    }
}
