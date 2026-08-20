using GoalZone.DtoLayer.DTOS.DefaultDto;
using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient();

            var lastWeekResponse = await client.GetAsync("https://localhost:7084/api/FootballMatch/GetLastFootballMatchWeek");

            if (lastWeekResponse.IsSuccessStatusCode)
            {
                var jsonData = await lastWeekResponse.Content.ReadAsStringAsync();
                var lastWeek = JsonConvert.DeserializeObject<int>(jsonData);
                ViewBag.LastWeek = lastWeek;
            }

            var DateResponse = await client.GetAsync($"https://localhost:7084/api/FootballMatch/{ViewBag.LastWeek}");

            if (DateResponse.IsSuccessStatusCode)
            {
                var DatejsonData = await DateResponse.Content.ReadAsStringAsync();
                var DateValue =JsonConvert.DeserializeObject<List<ResultFootballMatchDto>>(DatejsonData);
                ViewBag.FirstMatchDate = DateValue.Min(x => x.MatchDate).ToString("dd MMM yyyy");
                ViewBag.LastMatchDate = DateValue.Max(x => x.MatchDate).ToString("dd MMM yyyy");
            }

            var statusResponse = await client.GetAsync("https://localhost:7084/api/DashboardStatistic/MatchWithStatus");

            if (statusResponse.IsSuccessStatusCode)
            {
                var jsonData = await statusResponse.Content.ReadAsStringAsync();
                var statusCounts =
                    JsonConvert.DeserializeObject<List<MatchStatusCountDto>>(jsonData);
                return View(statusCounts);
            }




            return View(new List<MatchStatusCountDto>());
        }
    }
}