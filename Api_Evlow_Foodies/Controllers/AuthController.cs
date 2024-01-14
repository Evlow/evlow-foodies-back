using Api.Evlow_Foodies.Buisness.DTO;
using Api.Evlow_Foodies.Datas.Entities.Entities;
using Api.Evlow_Foodies.Datas.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Api_Evlow_Foodies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        public AuthController(IUserRepository repository)
        {
            _userRepository = repository;
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterDTO registerDTO) {+

            var user = new User
            {
                UserFirstName = registerDTO.UserFirstName,
                UserEmail = registerDTO.UserEmail,
                UserPassword = BCrypt.Net.BCrypt.HashPassword(registerDTO.UserPassword)

            };
            return Ok( "hello");
        }

    }
}
