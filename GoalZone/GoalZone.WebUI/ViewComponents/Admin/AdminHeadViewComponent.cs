using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebUI.ViewComponents.Admin
{
    public class AdminHeadViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
