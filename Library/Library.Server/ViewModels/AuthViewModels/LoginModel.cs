using System.ComponentModel.DataAnnotations;

namespace Library.Server.ViewModels.AuthViewModels
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Please enter User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
    }
}
