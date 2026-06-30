using empService.DTOs;
using empService.Services;
using Microsoft.AspNetCore.Mvc;

namespace empService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;


        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserRequest dto)
        {
            var user = _userService.CreateUser(dto);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserEmail(int id, UpdateUserEmail dto)
        {
            var updatedUser = _userService.UpdateUserEmail(id, dto.Email);


            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {

            _userService.DeleteUserByID(id);

            return NoContent();


        }
    }


}