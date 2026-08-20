using GoalZone.DtoLayer.DTOS.MatchEventDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.ViewComponents.MatchStatistic
{
    public class MatchStatisticAwayTeamGoalsViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public MatchStatisticAwayTeamGoalsViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int FootballMatchId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7084/api/MatchEvent/AwayTeamMatchEventPlayerGoalList/{FootballMatchId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetMatchEventByFootballIdDto>>(jsonData);
                ViewBag.AwayTeam = values.FirstOrDefault()?.AwayTeam?.Split(" - ")[0];

                return View(values);
            }
            return View();
        }
    }
}
