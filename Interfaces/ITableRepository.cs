using Microsoft.AspNetCore.JsonPatch;
using reservation_system.Domains;
using reservation_system.DTO;

namespace reservation_system.Interfaces
{
    public interface ITableRepository
    {
        void RegisterTable(TableDTO newTable);

        List<TableDomain> ListTables();

        void RemoveTable(int id);

        void UpdateTable(TableDTO table, int id);
    }
}
