using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using reservation_system.Domains;
using reservation_system.DTO;
using reservation_system.Interfaces;
using System.Security.Claims;

namespace reservation_system.Controllers
{
    public class ReserveController : Controller
    {
        private readonly IReserveRepository _reserveRepository;

        public ReserveController(IReserveRepository reserveRepository)
        {
            _reserveRepository = reserveRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("PostReservation")]
        [Authorize(Roles = "Comum")]
        public IActionResult PostReservation([FromBody]ReserveDTO reserve) 
        {

            var idUser = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(idUser == null)
            {
                return BadRequest();
            }

            var userId = Convert.ToInt32(idUser);

            _reserveRepository.RegisterReservation(reserve, userId);

            return Ok("Reserva cadastrada com sucesso!");
        }
    }
}
