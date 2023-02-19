using AccountManagement.Contracts.AccountAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Account
{
    public class IndexModel : PageModel
    {

        private readonly IAccountApplication _applicationAccount;
        public IndexModel(IAccountApplication applicationAccount)
        {
            _applicationAccount = applicationAccount;
        }

        public List<AccountViewModel> Accounts;

        public void OnGet()
        {
            Accounts = _applicationAccount.GetAccounts();
        }

        public IActionResult OnGetRegister()
        {
            var command = new RegisterAccount();

            return Partial("./Register", command);
        }

        public JsonResult OnPostRegister(RegisterAccount create)
        {
            var result = _applicationAccount.Register(create);

            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var Account = _applicationAccount.GetDetails(id);
            return Partial("Edit", Account);
        }

        public JsonResult OnPostEdit(EditAccount cmd)
        {
            var result = _applicationAccount.Edit(cmd);

            return new JsonResult(result);
        }

        public IActionResult OnGetChangePassword(long id)
        {
            var command = new ChangePassword { Id = id };
            return Partial("ChangePassword", command);
        }

        public JsonResult OnPostChangePassword(ChangePassword cmd)
        {
            var result = _applicationAccount.ChangePassword(cmd);

            return new JsonResult(result);
        }

    }
}
