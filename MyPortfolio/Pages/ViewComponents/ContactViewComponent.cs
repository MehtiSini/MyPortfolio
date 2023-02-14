using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Pages.ViewComponents
{
    public class ContactViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
