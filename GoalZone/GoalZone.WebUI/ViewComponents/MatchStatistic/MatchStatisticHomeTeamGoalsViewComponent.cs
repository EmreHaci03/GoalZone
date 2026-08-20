using GoalZone.DtoLayer.DTOS.MatchEventDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.ViewComponents.MatchStatistic
{
    public class MatchStatisticHomeTeamGoalsViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public MatchStatisticHomeTeamGoalsViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int FootballMatchId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7084/api/MatchEvent/HomeTeamMatchEventPlayerGoalList/{FootballMatchId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetMatchEventByFootballIdDto>>(jsonData);
                ViewBag.HomeTeam = values.FirstOrDefault()?.AwayTeam?.Split(" - ")[0];

                return View(values);
            }
            return View();
        }
    }
}
