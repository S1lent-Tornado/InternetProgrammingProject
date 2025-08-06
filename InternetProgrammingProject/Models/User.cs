using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetProgrammingProject.Models
{
    public class User
    {
        [Key]
        [EmailAddress]
        [Required]
        required public string Email { get; set; }

        [Required]
        required public string FirstName { get; set; }

        [Required]
        required public string LastName { get; set; }

        [Required]
        required public string Country { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[A-Za-z](?=.*[a-z])(?=.*[A-z])(?=.*\d).{7,}$",
            ErrorMessage = "Password must start with a letter, contain uppercase, lowercase, a digit, and be at least 8 characters.")]
        required public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        required public string ConfirmPassword { get; set; }
    }
}
