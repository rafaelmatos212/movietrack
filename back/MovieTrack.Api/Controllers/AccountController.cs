using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MovieTrack.Application.Mappers;
using MovieTrack.Application.RequestsResponse.Register;
using MovieTrack.Domain.Interfaces.Services;

namespace MovieTrack.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterUserResponse>> Register([FromBody] RegisterUserRequest request)
        {
            var userDto = RegisterMapper.ToDto(request);
            var user = await _accountService.Register(userDto);
            return RegisterMapper.ToResponse(user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            throw new NotImplementedException("Login method is not implemented yet.");
        }
    }
}
