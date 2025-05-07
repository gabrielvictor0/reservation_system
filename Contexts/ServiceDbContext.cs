using Microsoft.EntityFrameworkCore;
using reservation_system.Domains;

namespace reservation_system.Contexts
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options) 
        {
        }

        public DbSet<UserDomain> user {  get; set; }
        public DbSet<TableDomain> table { get; set; }
        public DbSet<ReserveDomain> reserve { get; set; }
    }
}
