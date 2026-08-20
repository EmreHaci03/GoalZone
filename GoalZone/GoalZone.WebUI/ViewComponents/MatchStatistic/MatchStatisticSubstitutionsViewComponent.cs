using GoalZone.DtoLayer.DTOS.MatchEventDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.ViewComponents.MatchStatistic
{
    public class MatchStatisticSubstitutionsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public MatchStatisticSubstitutionsViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int FootballMatchId)
        {
            var client = httpClientFactory.CreateClient();

            var homeResponse = await client.GetAsync(
                $"https://localhost:7084/api/MatchEvent/HomeTeamSubstitution/{FootballMatchId}");
            var awayResponse = await client.GetAsync(
                $"https://localhost:7084/api/MatchEvent/AwayTeamSubstitution/{FootballMatchId}");

            var homeSubs = new List<GetMatchEventByFootballIdDto>();
            var awaySubs = new List<GetMatchEventByFootballIdDto>();

            if (homeResponse.IsSuccessStatusCode)
            {
                var jsonData = await homeResponse.Content.ReadAsStringAsync();
                homeSubs = JsonConvert.DeserializeObject<List<GetMatchEventByFootballIdDto>>(jsonData)
                           ?? new List<GetMatchEventByFootballIdDto>();
            }

            if (awayResponse.IsSuccessStatusCode)
            {
                var jsonData = await awayResponse.Content.ReadAsStringAsync();
                awaySubs = JsonConvert.DeserializeObject<List<GetMatchEventByFootballIdDto>>(jsonData)
                           ?? new List<GetMatchEventByFootballIdDto>();
            }

            ViewBag.HomeTeamSubstitution = homeSubs;
            ViewBag.AwayTeamSubstitution = awaySubs;

            return View();
        }
    }
}