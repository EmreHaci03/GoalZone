using GoalZone.DtoLayer.DTOS.MatchEventDto;
using GoalZone.DtoLayer.DTOS.MatchStatisticDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.ViewComponents.MatchStatistic
{
    public class MatchStatisticEventsViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public MatchStatisticEventsViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int FootballMatchId)
        {
            var client = httpClientFactory.CreateClient();

            var homeResponse = await client.GetAsync(
                $"https://localhost:7084/api/MatchEvent/HomeTeamEventListByFootballMatchId/{FootballMatchId}");
            var awayResponse = await client.GetAsync(
                $"https://localhost:7084/api/MatchEvent/AwayTeamEventListByFootballMatchId/{FootballMatchId}");

            var homeEvents = new List<ResultMatchEventDto>();
            var awayEvents = new List<ResultMatchEventDto>();

            if (homeResponse.IsSuccessStatusCode)
            {
                var jsonData = await homeResponse.Content.ReadAsStringAsync();
                homeEvents = JsonConvert.DeserializeObject<List<ResultMatchEventDto>>(jsonData)
                             ?? new List<ResultMatchEventDto>();
            }

            if (awayResponse.IsSuccessStatusCode)
            {
                var jsonData = await awayResponse.Content.ReadAsStringAsync();
                awayEvents = JsonConvert.DeserializeObject<List<ResultMatchEventDto>>(jsonData)
                             ?? new List<ResultMatchEventDto>();
            }

            var allEvents = homeEvents
                .Concat(awayEvents)
                .OrderBy(x => x.Minute)
                .ToList();

            ViewBag.HomeEventIds = homeEvents.Select(x => x.MatchEventId).ToHashSet();
            ViewBag.FootballMatchId = FootballMatchId;

            return View(allEvents);
        }
    }
}
