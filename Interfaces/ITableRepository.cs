using reservation_system.DTO;

namespace reservation_system.Interfaces
{
    public interface ITableRepository
    {
        void RegisterTable(TableDTO newTable);
    }
}
