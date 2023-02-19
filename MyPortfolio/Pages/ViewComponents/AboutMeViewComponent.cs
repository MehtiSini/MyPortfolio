using Microsoft.AspNetCore.Mvc;
using MyQuery.Contracts.Person;

namespace MyPortfolio.Pages.ViewComponents
{
    public class AboutMeViewComponent : ViewComponent
    {
        private readonly IPersonQuery _Query;
        public AboutMeViewComponent(IPersonQuery query)
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
