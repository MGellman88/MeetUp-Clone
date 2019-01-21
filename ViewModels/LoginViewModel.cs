using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBelt.ViewModels
{
    public class LoginViewModel
    {
       [Required(ErrorMessage = "Required Field")]
        [EmailAddress]
        public string LoginEmail { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }
    }
}