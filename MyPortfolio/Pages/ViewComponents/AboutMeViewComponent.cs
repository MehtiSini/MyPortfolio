using Microsoft.AspNetCore.Mvc;
using MyQuery.Contracts.Person;

namespace MyPortfolio.Pages.ViewComponents
{
    public class AboutMeViewComponent : ViewComponent
    {
        private readonly IPersonQueryModel _Query;
        public AboutMeViewComponent(IPersonQueryModel query)
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
