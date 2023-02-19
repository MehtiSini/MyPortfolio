using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Contracts.AccountAgg
{
    public class RegisterAccount
    {
        [Required(ErrorMessage = ValidationMessage.IsRequiredEng)]
        public string? FullName { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequiredEng)]
        public string? Username { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequiredEng)]
        public string? Password { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequiredEng)]
        public string? RePassword { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequiredEng)]
        public string? Mobile { get; set; }
    }
    
}
