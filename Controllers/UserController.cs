using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using reservation_system.Domains;
using reservation_system.DTO;
using reservation_system.Interfaces;
using reservation_system.Repositories;
using reservation_system.Services;

namespace reservation_system.Controllers
{
    public class UserController : Controller
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUserRepository _userRepository;

        public UserController(IJwtTokenService jwtTokenService, IUserRepository userRepository)
        {
            _jwtTokenService = jwtTokenService;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("RegisterUser")]
        public IActionResult PostUser([FromBody] UserDTO newUser)
        {
            _userRepository.RegisterUser(newUser);   
            return Created();
        }

        [HttpPost("Login")]
        public IActionResult LoginUser([FromBody] LoginRequestDTO request)
        {
            var user = _userRepository.Login(request);

            if(user == null)
            {
                return BadRequest("Usuário não encontrado.");
            }

            var token = _jwtTokenService.GenerateToken(user.id, user.name, user.role);

            return Ok(new { token });
        }
    }
}

