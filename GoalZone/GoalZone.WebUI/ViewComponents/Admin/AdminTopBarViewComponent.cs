using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebUI.ViewComponents.Admin
{
    public class AdminTopBarViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
