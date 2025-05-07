using reservation_system.Domains;
using reservation_system.DTO;

namespace reservation_system.Interfaces
{
    public interface IUserRepository
    {
        void RegisterUser(UserDTO newUser);

        UserDomain Login(LoginRequestDTO request);
    }
}
