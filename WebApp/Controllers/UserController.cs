using BusinessLayer.Abstractions;
using BusinessLayer.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly JwtConfig _jwtConfig;
        private readonly IUserService _userService;

        public UserController(IUserService userService, JwtConfig jwtConfig)
        {
            _jwtConfig = jwtConfig;
            _userService = userService;
        }

        private string GetToken(int userId)
        {
            var claims = new Claim[]
            {
                new(ClaimTypes.NameIdentifier, userId.ToString()),
            };
            var jwt = new JwtSecurityToken(
                issuer: _jwtConfig.ValidIssuer,
                audience: _jwtConfig.ValidAudience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(_jwtConfig.IssuerSigningKey, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
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
                var token = GetToken(user.Id);
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

            var token = GetToken(user.Id);
            var userDto = new UserDto(user, token);
            return Ok(userDto);
        }
    }
}
