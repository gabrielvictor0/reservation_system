using System.ComponentModel.DataAnnotations;

namespace reservation_system.DTO
{
    public class ReserveDTO
    {
        [Required(ErrorMessage = "date is required")]
        public DateTime reservation_date { get; set; }

        [Required(ErrorMessage = "status is required")]
        public string status { get; set; }

        [Required(ErrorMessage = "tableId is required")]
        public int tableId { get; set; }
    }
}
