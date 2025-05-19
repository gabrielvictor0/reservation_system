using reservation_system.DTO;

namespace reservation_system.Interfaces
{
    public interface IReserveRepository
    {
        void RegisterReservation(ReserveDTO reserve, int id);

        void GetAllReservation();

        void CancelReservation(int id);
    }
}
