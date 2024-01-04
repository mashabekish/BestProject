using BusinessLayer.Abstractions;
using BusinessLayer.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly IUserService _userService;

        public UserController(IUserService userService, JwtService jwtService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync(SignInDto data)
        {
            var user = await _userService.FindUserByEmailAsync(data.Email);
            if (user == null)
                return BadRequest("User with this login does not exist");

            if (BCrypt.Net.BCrypt.Verify(data.Password, user.Password))
            {
                var token = _jwtService.GetToken(user.Id);
                var userDto = new UserDto(user, token);
                return Ok(userDto);
            }
            else
                return BadRequest("Invalid password");
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(User user)
        {
            var existingUser = await _userService.FindUserByEmailAsync(user.Email);
            if (existingUser != null)
                return BadRequest("User with this login already exists");

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user = await _userService.CreateUserAsync(user);

            var token = _jwtService.GetToken(user.Id);
            var userDto = new UserDto(user, token);
            return Ok(userDto);
        }
    }
}
