using FirstStaticWeb.Interface;
using FirstStaticWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstStaticWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var usersList = await _usersRepository.GetAllUsersAsync();
            return Ok(usersList);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest("User data is null.");
            }

            try
            {
                var user = await _usersRepository.AddUserAsync(userModel);
                return CreatedAtAction(nameof(GetAllUsers), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel userModel,int id)
        {
            if (userModel == null)
            {
                return BadRequest("User data is null.");
            }

            try
            {
                var updatedUser = await _usersRepository.UpdateUserAsync(userModel, id);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var deletedUser = await _usersRepository.DeleteUserAsync(id);
                if (deletedUser == null)
                {
                    return NotFound($"User with id {id} not found.");
                }

                return Ok(deletedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
