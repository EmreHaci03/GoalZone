using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebUI.ViewComponents.Layout
{
    public class LayoutScriptViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
