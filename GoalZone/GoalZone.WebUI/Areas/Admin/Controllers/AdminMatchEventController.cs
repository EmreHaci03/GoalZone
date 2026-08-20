using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using GoalZone.DtoLayer.DTOS.MatchEventDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace GoalZone.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMatchEventController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AdminMatchEventController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> MatchEventList()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/MatchEvent");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMatchEventDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateMatchEvent()
        {
            await LoadMatchesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatchEvent(CreateMatchEventDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7084/api/MatchEvent", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MatchEventList");
            }

            await LoadMatchesAsync();
            return View(dto);
        }

        private async Task LoadMatchesAsync()
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7084/api/FootballMatch");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var matches = JsonConvert.DeserializeObject<List<ResultFootballMatchDto>>(json);
                ViewBag.Matches = matches.Select(x => new SelectListItem
                {
                    Value = x.FootballMatchId.ToString(),
                    Text = $"{x.HomeTeamName} - {x.AwayTeamName} ({x.Week}. Hafta)"
                }).ToList();
            }
        }
    }
}
