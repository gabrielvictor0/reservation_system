using System.ComponentModel.DataAnnotations;

namespace reservation_system.DTO
{
    public class TableDTO
    {
        public string? name { get; set; }

        public int? capacity { get; set; }

        public string? status { get; set; }
    }
}
