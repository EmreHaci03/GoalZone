using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebUI.ViewComponents.Layout
{
    public class LayoutNavbarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
