using System.ComponentModel.DataAnnotations;

namespace ECom.Web.Models.Dto
{
    public class RegisterationRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string? Role { get; set; }
    }
}
