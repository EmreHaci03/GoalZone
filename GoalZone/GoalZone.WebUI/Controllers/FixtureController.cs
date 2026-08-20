using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.Controllers
{
    public class FixtureController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public FixtureController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int? week)
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7084/api/FootballMatch");

            var allMatches = new List<ResultFootballMatchDto>();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                allMatches = JsonConvert.DeserializeObject<List<ResultFootballMatchDto>>(json);
            }

            
            var allWeeks = allMatches
                .Select(x => x.Week)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            
            int selectedWeek = week ?? (allWeeks.Any() ? allWeeks.First() : 1);

            ViewBag.AllWeeks = allWeeks;
            ViewBag.SelectedWeek = selectedWeek;

            
            var weekMatches = allMatches
                .Where(x => x.Week == selectedWeek)
                .OrderBy(x => x.MatchDate)
                .ToList();

            return View(weekMatches);
        }
    }
}