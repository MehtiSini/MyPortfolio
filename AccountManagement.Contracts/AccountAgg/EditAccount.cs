using MyFramework.Tools;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Contracts.AccountAgg
{
    public class EditAccount : LoginAccount
    {

        [Required(ErrorMessage = ValidationMessage.IsRequiredEng)]
        public string? FullName { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequiredEng)]
        public string? Mobile { get; set; }

        public long Id { get; set; }
    }
}
