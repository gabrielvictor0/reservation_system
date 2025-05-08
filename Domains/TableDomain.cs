using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reservation_system.Domains
{
    [Table("table")]
    public class TableDomain
    {
        [Key]
        public int id { get; set; }

        public string? name { get; set; }

        public int? capacity { get; set; }

        public string? status { get; set; }
    }
}
