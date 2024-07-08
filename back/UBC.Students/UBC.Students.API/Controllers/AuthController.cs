using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using UBC.Students.Application.ViewModels;
using UBC.Users.Application.Interfaces;

namespace UBC.Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration configuration, ILogger<AuthController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(IEnumerable<TokenViewModel>), (int)HttpStatusCode.OK)]
        [AllowAnonymous] 
        public async Task<ActionResult<string>> Login([FromBody] LoginUserViewModel login, [FromServices] IUserService service)
        {
            var user = await service.GetByLogin(login, new System.Threading.CancellationToken());

            if (user == null)
                return NotFound();

            if (user == null)
                return Unauthorized("Invalid Username or Password");

            var token = GenerateJwtToken(user);
            return Ok(token);
        }

        private TokenViewModel GenerateJwtToken(UserViewModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenViewModel
            {
                Token = generatedToken,
                ExpiresIn = 30 * 60
            };
        }
    }
}
