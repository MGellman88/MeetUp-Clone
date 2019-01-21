using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBelt.ViewModels
{
    public class RegistrationViewModel
    {
        [Key]
        public int UserID { get ; set; }

        [Required(ErrorMessage = "Required Field")]
        [MinLength (2, ErrorMessage = "Name must be longer than 2 characters")]
        [Display (Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MinLength (2, ErrorMessage = "Name must be longer than 2 characters")]
        [Display (Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [DataType (DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType (DataType.Password)]
        [Compare ("Password")]
        [Display (Name = "Password Confirmation")]
        public string PasswordConfirmation { get; set; }
    }
} 