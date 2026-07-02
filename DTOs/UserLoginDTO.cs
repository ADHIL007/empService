using System.ComponentModel.DataAnnotations;

namespace empService.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public required String Name { get; set; }
        [Required]
        public required string Password { get; set; }

    }

}