using System.ComponentModel.DataAnnotations;

namespace reservation_system.DTO
{
    public class ReserveDTO
    {
        public DateTime reservation_date { get; set; }

        public string status { get; set; }

        public int tableId { get; set; }
    }
}
