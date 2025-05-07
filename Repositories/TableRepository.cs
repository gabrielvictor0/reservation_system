using reservation_system.Contexts;
using reservation_system.Domains;
using reservation_system.DTO;
using reservation_system.Interfaces;

namespace reservation_system.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly ServiceDbContext _ctx;

        public TableRepository(ServiceDbContext ctx)
        {
            _ctx = ctx;
        }

        public void RegisterTable(TableDTO newTable)
        {
            TableDomain table = new ()
            {
                name = newTable.name,
                capacity = newTable.capacity,
                status = newTable.status
            };

            _ctx.table.Add(table);
            _ctx.SaveChanges();
        }
    }
}
