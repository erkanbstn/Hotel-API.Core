using Microsoft.AspNetCore.Mvc;

namespace Frontend_Mvc.Core.ViewComponents
{
    public class CountPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
