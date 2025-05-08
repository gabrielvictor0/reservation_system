using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reservation_system.Domains
{
    [Table("reserve")]
    public class ReserveDomain
    {
        [Key]
        public int id { get; set; }

        public DateTime reservation_date { get; set; }

        public string status { get; set; }

        [ForeignKey("user")]
        public int userId { get; set; }

        [ForeignKey("table")]
        public int tableId { get; set; }

        public TableDomain table {  get; set; }

        public UserDomain user {  get; set; }
    }
}
