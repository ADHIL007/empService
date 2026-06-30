using System.ComponentModel.DataAnnotations;

namespace empService.DTOs
{
    public class CreateUserRequest
    {
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}