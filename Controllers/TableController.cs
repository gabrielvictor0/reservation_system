using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using reservation_system.Domains;
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

        [HttpGet("ListAll")]
        public IActionResult GetAllTable()
        {
            return Ok(_tableRepository.ListTables());
        }

        [HttpDelete("DeleteTable")]
        [Authorize(Roles = "Administrador")]
        public IActionResult DeleteTable(int id)
        {
            _tableRepository.RemoveTable(id);
            return Ok("Mesa removida com êxito!");
        }

        [HttpPatch("PatchTable")]
        [Authorize(Roles = "Administrador")]
        public IActionResult PatchTable(int id, [FromBody] TableDTO table)
        {
            _tableRepository.UpdateTable(table, id);
            return Ok("Mesa atualizada com êxito!");
        }
    }
}
