using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Pages.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
