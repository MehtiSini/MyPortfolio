using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Pages.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
