using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebUI.ViewComponents.Layout
{
    public class LayoutFooterViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
