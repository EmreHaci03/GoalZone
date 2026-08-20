using GoalZone.DtoLayer.DTOS.MatchStatisticDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.ViewComponents.MatchStatistic
{
    public class MatchStatisticViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public MatchStatisticViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int FootballMatchId)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7084/api/MatchStatistic/MatchStatisticByFootballMatchId?footballMatchId={FootballMatchId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMatchStatisticDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
