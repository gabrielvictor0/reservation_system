using System.ComponentModel.DataAnnotations;

namespace reservation_system.DTO
{
    public class TableDTO
    {
        [Required(ErrorMessage = "name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "capacity is required")]
        public int capacity { get; set; }

        [Required(ErrorMessage = "status is required")]
        public string status { get; set; }
    }
}
