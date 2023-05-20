using Microsoft.AspNetCore.Mvc;

namespace Frontend_Mvc.Core.ViewComponents
{
    public class StaffPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
