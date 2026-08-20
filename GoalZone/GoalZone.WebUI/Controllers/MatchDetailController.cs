using GoalZone.DtoLayer.DTOS.MatchStatisticDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.Controllers
{
    public class MatchDetailController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public MatchDetailController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int FootballMatchId)
        {
            ViewBag.FootBallMatchId = FootballMatchId;
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7084/api/MatchStatistic/MatchStatisticByFootballMatchId?footballMatchId={FootballMatchId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetMatchStatisticByIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
