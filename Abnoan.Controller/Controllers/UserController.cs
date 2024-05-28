using Abnoan.Business.Model;
using Abnoan.Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace Abnoan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserDto>> GetAll()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPost]
        public ActionResult<UserDto> Post(UserDto user)
        {
            _userService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserDto user)
        {
            if (id != user.Id) return BadRequest();
            var existingUser = _userService.GetUserById(id);
            if (existingUser == null) return NotFound();

            _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();

            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
