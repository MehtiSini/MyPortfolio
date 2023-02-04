using InformationManagement.Contracts.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPortfolio.Areas.Administration.Pages.Person
{
    public class EditModel : PageModel
    {
        public List<PersonViewModel> PersonViewModels;
        public EditPerson Command;

        private readonly IPersonAppliaction _personApplication;

        public EditModel(IPersonAppliaction personApplication)
        {
            _personApplication = personApplication;
        }

        public void OnGet(long id)
        {
            Command = _personApplication.GetDetails(id);
        }

        public IActionResult OnPost(EditPerson Command)
        {
            _personApplication.Edit(Command);
            return RedirectToPage("Index");
        }
    }
}
