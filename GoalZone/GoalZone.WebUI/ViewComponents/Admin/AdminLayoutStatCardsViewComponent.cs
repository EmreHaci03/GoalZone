using GoalZone.BusinessLayer.Abstract;
using GoalZone.DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoalZone.WebUI.ViewComponents.Admin
{
    public class AdminLayoutStatCardsViewComponent:ViewComponent
    {
        private readonly GoalZoneContext _context;

        public AdminLayoutStatCardsViewComponent(GoalZoneContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.TotalMatch = await _context.FootballMatches.CountAsync();
            ViewBag.TotalMatchEvent = await _context.MatchEvents.CountAsync();
            ViewBag.TotalMatchStatistic = await _context.MatchStatistics.CountAsync();
            ViewBag.TotalTeam = await _context.Teams.CountAsync();
            return View();
        }
    }
}
