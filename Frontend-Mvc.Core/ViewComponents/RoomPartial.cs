using Microsoft.AspNetCore.Mvc;

namespace Frontend_Mvc.Core.ViewComponents
{
    public class RoomPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
