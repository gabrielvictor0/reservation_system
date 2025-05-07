using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using reservation_system.DTO;
using reservation_system.Interfaces;

namespace reservation_system.Controllers
{
    public class TableController : Controller
    {
        private readonly ITableRepository _tableRepository;

        public TableController(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("RegisterTable")]
        [Authorize(Roles = "Administrador")]
        public IActionResult PostTable([FromBody] TableDTO newTable)
        {
            _tableRepository.RegisterTable(newTable);
            return Created();
        }

    }
}
