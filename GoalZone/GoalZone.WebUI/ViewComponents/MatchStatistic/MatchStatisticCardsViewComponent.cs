using GoalZone.DtoLayer.DTOS.MatchEventDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.ViewComponents.MatchStatistic
{
    public class MatchStatisticCardsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public MatchStatisticCardsViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int FootballMatchId)
        {
            var client = httpClientFactory.CreateClient();

            var homeResponse = await client.GetAsync(
                $"https://localhost:7084/api/MatchEvent/HomeTeamCardList/{FootballMatchId}");
            var awayResponse = await client.GetAsync(
                $"https://localhost:7084/api/MatchEvent/AwayTeamCardList/{FootballMatchId}");

            var homeCards = new List<GetMatchEventByFootballIdDto>();
            var awayCards = new List<GetMatchEventByFootballIdDto>();

            if (homeResponse.IsSuccessStatusCode)
            {
                var jsonData = await homeResponse.Content.ReadAsStringAsync();
                homeCards = JsonConvert.DeserializeObject<List<GetMatchEventByFootballIdDto>>(jsonData)
                            ?? new List<GetMatchEventByFootballIdDto>();
            }

            if (awayResponse.IsSuccessStatusCode)
            {
                var jsonData = await awayResponse.Content.ReadAsStringAsync();
                awayCards = JsonConvert.DeserializeObject<List<GetMatchEventByFootballIdDto>>(jsonData)
                            ?? new List<GetMatchEventByFootballIdDto>();
            }

            ViewBag.HomeTeamCard = homeCards;
            ViewBag.AwayTeamCard = awayCards;

            return View();  
        }
    }
}