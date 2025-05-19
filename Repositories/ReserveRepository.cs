using reservation_system.Contexts;
using reservation_system.Domains;
using reservation_system.DTO;
using reservation_system.Interfaces;

namespace reservation_system.Repositories
{
    public class ReserveRepository : IReserveRepository
    {
        private readonly ServiceDbContext _ctx;

        public ReserveRepository(ServiceDbContext ctx)
        {
            _ctx = ctx;
        }

        public void CancelReservation(int id)
        {
            throw new NotImplementedException();
        }

        public void GetAllReservation()
        {
            throw new NotImplementedException();
        }

        public void RegisterReservation(ReserveDTO reserve, int id)
        {

            TimeSpan timeStart = TimeSpan.Parse("16:00:00");
            TimeSpan timeEnd = TimeSpan.Parse("23:00:00");

            if (reserve.reservation_date.TimeOfDay < timeStart || reserve.reservation_date.TimeOfDay > timeEnd)
            {
                Console.WriteLine("Data o");
                return;
            }

            List<ReserveDomain> reserveFind = _ctx.reserve.Where(r => r.reservation_date.Date == reserve.reservation_date.Date).ToList();

            foreach (var r in reserveFind)
            {
                if (reserve.reservation_date.Hour >= r.reservation_date.Hour && reserve.reservation_date.Hour <= r.reservation_date.Hour + 3)
                {
                    Console.WriteLine("Horário não disponível!");
                    return;
                }
            }

            ReserveDomain reserveDomain = new()
            {
                reservation_date = reserve.reservation_date,
                status = reserve.status,
                tableId = reserve.tableId,
                userId = id
            };

            _ctx.reserve.Add(reserveDomain);
            _ctx.SaveChanges();
        }
    }
}
