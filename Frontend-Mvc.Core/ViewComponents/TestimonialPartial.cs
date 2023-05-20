using Microsoft.AspNetCore.Mvc;

namespace Frontend_Mvc.Core.ViewComponents
{
    public class TestimonialPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
