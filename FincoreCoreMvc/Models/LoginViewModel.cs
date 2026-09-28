using System.ComponentModel.DataAnnotations;

namespace FincoreCoreMvc.Models
{
    public class LoginViewModel
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string pass { get; set; }
    }
}
