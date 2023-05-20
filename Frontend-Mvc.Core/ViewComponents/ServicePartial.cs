using Microsoft.AspNetCore.Mvc;

namespace Frontend_Mvc.Core.ViewComponents
{
    public class ServicePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
