using System.ComponentModel.DataAnnotations;

namespace FincoreCoreMvc.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string pass { get; set; }
    }
}
