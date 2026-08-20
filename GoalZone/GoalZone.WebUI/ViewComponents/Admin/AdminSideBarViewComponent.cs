using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebUI.ViewComponents.Admin
{
    public class AdminSideBarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
