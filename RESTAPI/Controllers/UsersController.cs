using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Services;

namespace RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        #region API CRUD OPERATION
        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User usr)
        {
            var existinguser = _userService.ExistsUser(usr.Id);
            if (existinguser != null)
            {
                return StatusCode(409, $"User '{usr.Id}' already exists.");
            }
            else
            {
                _userService.Create(usr);
                return CreatedAtAction(nameof(Get), new { _id = usr._id }, usr);
            }

        }

        [HttpGet]
        public ActionResult<List<User>> Get() => _userService.Get();
        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var usr = _userService.Get(id);

            if (usr == null)
            {
                return NotFound();
            }

            return usr;
        }
        // PUT api/<UsersController>/<id>
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] User usr)
        {
            var existinguser = _userService.Get(id);

            if (existinguser == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            _userService.Update(id, usr);

            return Ok($"User data updated");
        }

        // DELETE api/<UsersController>/<id>
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound($"User with Id = {id} not found");
            }

            _userService.Remove(user._id);

            return Ok($"User with Id = {id} deleted");
        }
        #endregion

    }
}
