using AccountManagement.Contracts.AccountAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyPortfolio.Pages
{
    public class LoginModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }

        private readonly IAccountApplication _accountAppplication;

        public LoginAccount Command;

        public LoginModel(IAccountApplication accountAppplication)
        {
            _accountAppplication = accountAppplication;
        }


        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(LoginAccount Command)
        {
            if (ModelState.IsValid)
            {
                var result = _accountAppplication.Login(Command);

                if (result.IsSucceed)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    LoginMessage = "Username and Password Are not matched together";
                    return RedirectToPage("./Login");
                }
            }

            //Situation That ModelState has Problem...
            LoginMessage = "There is something worng with the form";
            return RedirectToPage("Login");
        }
    }
}
