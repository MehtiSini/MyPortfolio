using Microsoft.AspNetCore.Mvc;
using MyQuery.Contracts.Person;

namespace MyPortfolio.Pages.ViewComponents
{
    public class HeroViewComponent : ViewComponent
    {
        private readonly IPersonQuery _query;
        public HeroViewComponent(IPersonQuery query)
        {
            _query = query;
        }
        public PersonQueryViewModel Person { get; set; }

        public IViewComponentResult Invoke()
        {
            Person = _query.GetInformation();

            return View(Person);
        }

    }
}
