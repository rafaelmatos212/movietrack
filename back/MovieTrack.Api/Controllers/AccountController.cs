using Microsoft.AspNetCore.Mvc;
using MovieTrack.Application.Interfaces;
using MovieTrack.Application.Mappers;
using MovieTrack.Application.RequestsResponse.Login;
using MovieTrack.Application.RequestsResponse.Register;

namespace MovieTrack.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class AccountController(IAccountService _accountService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var user = await _accountService.Register(RegisterMapper.ToDto(request));
            return CreatedAtAction(nameof(Register), RegisterMapper.ToResponse(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _accountService.Login(request.Email, request.Password);
            return Ok(LoginMapper.ToResponse(token));
        }
    }
}
