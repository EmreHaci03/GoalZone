using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.ViewComponents.MatchStatistic
{
    public class MatchStatisticFeatureViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MatchStatisticFeatureViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int FootballMatchId)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7084/api/FootballMatch/GetFootballMatchWithDetailByFootball?footballMatchId={FootballMatchId}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                return View(new List<ResultFootballMatchDto>());
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFootballMatchDto>>(jsonData);

            return View(values ?? new List<ResultFootballMatchDto>());
        }
    }
}