using InformationManagement.Contracts.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPortfolio.Areas.Administration.Pages.Person
{
    public class IndexModel : PageModel
    {
        public List<PersonViewModel> Persons;

        private readonly IPersonAppliaction _personApplicaction;
        public IndexModel(IPersonAppliaction personApplicaction)
        {
            _personApplicaction = personApplicaction;
        }
        public void OnGet()
        {
            Persons = _personApplicaction.GetList();
        }

        public IActionResult OnGetCreate(CreatePerson Cmd)
        {
            return Partial("./Create", Cmd);
        }
        public IActionResult OnPostCreate(CreatePerson Cmd)
        {
            var Operation = _personApplicaction.Create(Cmd);

            return new JsonResult(Operation);
        }

        public IActionResult OnGetEdit(long id)
        {
            var Result = _personApplicaction.GetDetails(id);

            return Partial("./Edit", Result);
        }
        public IActionResult OnPostEdit(EditPerson Cmd)
        {
            var Operation = _personApplicaction.Edit(Cmd);

            return new JsonResult(Operation);
        }
    }
}
