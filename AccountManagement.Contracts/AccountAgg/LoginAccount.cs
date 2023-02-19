using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Contracts.AccountAgg
{
    public class LoginAccount
    {
        [Required(ErrorMessage = ValidationMessage.IsRequiredEng)]
        public string? Username { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequiredEng)]
        public string? Password { get; set; }
    }

}
