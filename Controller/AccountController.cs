
using FirstStaticWeb.Interface;
using FirstStaticWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstStaticWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IAccountRepository _accountRepository; 
        public AccountController(IAccountRepository  accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<UserModel>> RegisterUser(UserModel user) 
        {
            if (user == null)
            {
                return BadRequest();
            }
            else {
                var res = await _accountRepository.RegisterUser(user);
                
            }
           return Ok(user);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel login)
        {
            var user = await _accountRepository.LoginAsync(login);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            return Ok(user);
        }

    }
}
