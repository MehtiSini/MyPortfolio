using AccountManagement.Contracts.AccountAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPortfolio.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly IAccountApplication _application;
        public string SignUpMessage;

        public SignUpModel(IAccountApplication application)
        {
            _application = application;
        }

        public RegisterAccount Command;
        public void OnGet()
        {

        }

        public void OnPostRegister(RegisterAccount Command)
        {
            if (ModelState.IsValid)
            {
                var Password = Command.Password.Trim().Length;

                if (Password < 6)
                {
                    SignUpMessage = "Password length Should not be less than 6 Character";
                }
                else
                {
                    var result = _application.Register(Command);

                    if (result.IsSucceed)
                    {
                        SignUpMessage = "Operation Was Successful";
                    }
                }
            }
        }
    }
}
