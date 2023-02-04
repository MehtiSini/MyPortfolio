using InformationManagement.Contracts.Person;
using InformationManagement.Contracts.Skill;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPortfolio.Areas.Administration.Pages.Person
{
    public class CreateModel : PageModel
    {
        public CreatePerson Command;
        private readonly IPersonAppliaction _personApplication;
        public CreateModel(IPersonAppliaction personApplication)
        {
            _personApplication = personApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(CreatePerson Command)
        {
            _personApplication.Create(Command);

            return RedirectToPage("Index");
        }
    }
}
