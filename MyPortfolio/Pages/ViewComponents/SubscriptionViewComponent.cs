using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Pages.ViewComponents
{
    public class SubscriptionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
