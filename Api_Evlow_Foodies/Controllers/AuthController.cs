using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Api.Evlow_Foodies.Datas.Repository.Contract;
using auth.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api_Evlow_Foodies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;
        private readonly ILogger _logger;
        public AuthController(IUserRepository repository, JwtService jwtService)
        {
            _userRepository = repository;
            _jwtService = jwtService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {

            var user = new User
            {
                UserFirstName = registerDTO.UserFirstName,
                UserLastName = registerDTO.UserLastName,
                UserPseudo = registerDTO.UserPseudo,
                UserEmail = registerDTO.UserEmail,
                UserPassword = BCrypt.Net.BCrypt.HashPassword(registerDTO.UserPassword)

            };
            return Created("succes", await _userRepository.CreateUserAsync(user));
        }
        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _userRepository.GetUserByPseudoAsync(loginDTO.UserPseudo);

            if (user == null)
            {
                return BadRequest(new { message = "Mauvais pseudo" });
            }

            if (!BCrypt.Net.BCrypt.Verify(loginDTO.UserPassword, user.UserPassword))
            {
                return BadRequest(new { message = "Mauvais mot de passe" });
            }
            var jwt = _jwtService.Generate(user.UserId);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });
            Response.Cookies.Append("userId", user.ToString());
            return Ok(new
            {
                message = "success",
                Token = jwt,
                User = user,
            });
        }

        [HttpGet("user")]
        public async Task <IActionResult> User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = await _userRepository.GetUserByIdAsync(userId);

                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "success"
            });
        }
    }
}