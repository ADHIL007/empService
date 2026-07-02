using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using empService.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace empService.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {

            _configuration = configuration;
        }



        [HttpPost("/login")]
        public IActionResult Login([FromBody] UserLoginDTO loginDTO)
        {
            if (loginDTO.Name == "admin" && loginDTO.Password == "admin")
            {
                var Token = GenerateJwtToken(loginDTO.Name);
                return Ok(Token);
            }

            return Unauthorized(new { message = "Invalid username or password credentials." });
        }

        private String GenerateJwtToken(String username)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "Admin")
            };


            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}