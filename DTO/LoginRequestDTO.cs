using System.ComponentModel.DataAnnotations;

namespace reservation_system.DTO
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "email is required")]
        public string email { get; set; }

        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }
    }
}
