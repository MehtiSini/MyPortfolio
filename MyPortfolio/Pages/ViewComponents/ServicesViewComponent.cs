using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Pages.ViewComponents
{
    public class ServicesViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
