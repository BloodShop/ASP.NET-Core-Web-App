using System.ComponentModel.DataAnnotations;

namespace ReverseEnginereeing.ViewModels
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and confirmation didnt match")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
