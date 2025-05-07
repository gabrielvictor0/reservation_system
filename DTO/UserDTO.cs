using System.ComponentModel.DataAnnotations;

namespace reservation_system.DTO
{
    public class UserDTO
    {
        [Required(ErrorMessage = "name is required")]
        public string name {  get; set; }

        [Required(ErrorMessage = "email is required")]
        public string email { get; set; }

        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }

        [Required(ErrorMessage = "role is required")]
        public string role { get; set; }
    }
}
