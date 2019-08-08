using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Register
{
    [Route("api/user")]
    [ApiController]
    public partial class UserController : ControllerBase
    {
        private static IRegisterService _registerService;

        public UserController(IRegisterService registerService) => _registerService = registerService;

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterDto registerInfo)
        {
            try
            {
                _registerService.CreateUser(registerInfo.Email, registerInfo.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
