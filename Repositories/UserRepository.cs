using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using reservation_system.Contexts;
using reservation_system.Domains;
using reservation_system.DTO;
using reservation_system.Interfaces;

namespace reservation_system.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IJwtTokenService _jwtTokenService;
        private readonly ServiceDbContext _ctx;

        public UserRepository(IJwtTokenService jwtTokenService, ServiceDbContext ctx)
        {
            _jwtTokenService = jwtTokenService;
            _ctx = ctx;
        }

        public UserDomain Login(LoginRequestDTO request)
        {
 
            try
            {
                UserDomain user = _ctx.user.First(u => u.email == request.email);

                if (user != null)
                {
                    if (BCrypt.Net.BCrypt.EnhancedVerify(request.password, user.password))
                    {
                        return user;
                    }
                }

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
            
        }

        public void RegisterUser(UserDTO newUser)
        {
           UserDomain user = new UserDomain();

            user.name = newUser.name;
            user.email = newUser.email;
            user.password = BCrypt.Net.BCrypt.EnhancedHashPassword(newUser.password, 13);
            user.role = newUser.role;

           _ctx.user.Add(user);
           _ctx.SaveChanges();
        }
    }
}
