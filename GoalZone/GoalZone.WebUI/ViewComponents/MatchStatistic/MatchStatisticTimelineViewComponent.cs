using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using GoalZone.DtoLayer.DTOS.MatchEventDto;
using GoalZone.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace GoalZone.WebUI.ViewComponents.MatchStatistic
{
    public class MatchStatisticTimelineViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public MatchStatisticTimelineViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int FootballMatchId)
        {
            var client = httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7084/api/MatchEvent/MatchEventListByFootballMatchId/{FootballMatchId}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                return View(new List<ResultMatchEventDto>());
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMatchEventDto>>(jsonData);

            ViewBag.FootballMatchId = FootballMatchId;
            return View(values ?? new List<ResultMatchEventDto>());
        }
    }
}
