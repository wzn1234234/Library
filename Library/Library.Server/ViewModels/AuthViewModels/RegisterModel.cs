using System.ComponentModel.DataAnnotations;

namespace Library.Server.ViewModels.AuthViewModels
{
    public class RegisterModel : LoginModel
    {
        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please choose role")]
        public int RoleId { get; set; }
    }
}
