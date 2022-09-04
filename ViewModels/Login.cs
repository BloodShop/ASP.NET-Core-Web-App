using System.ComponentModel.DataAnnotations;

namespace ReverseEnginereeing.ViewModels
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        public bool RememberMe { get; set; }
    }
}
