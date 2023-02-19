using Microsoft.AspNetCore.Mvc;
using MyQuery.Contracts.Person;

namespace MyPortfolio.Pages.ViewComponents
{
    public class ContactViewComponent : ViewComponent
    {
        private readonly IPersonQuery _Query;
        public ContactViewComponent(IPersonQuery query)
        {
            _Query = query;
        }

        public PersonQueryViewModel Person;

        public IViewComponentResult Invoke()
        {
            Person = _Query.GetInformation();

            return View(Person);
        }
    }
}
