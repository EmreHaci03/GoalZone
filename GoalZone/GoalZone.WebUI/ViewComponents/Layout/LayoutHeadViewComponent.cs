using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebUI.ViewComponents.Layout
{
    public class LayoutHeadViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
