using GoalZone.DtoLayer.DTOS.DefaultDto;
using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.ViewComponents.Default
{
    public class DefaultFinishedMatchViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public DefaultFinishedMatchViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var statusResponse = await client.GetAsync("https://localhost:7084/api/FootballMatch/FinishedMatchList");

            if (statusResponse.IsSuccessStatusCode)
            {
                var jsonData = await statusResponse.Content.ReadAsStringAsync();
                var statusCounts =JsonConvert.DeserializeObject<List<ResultFootballMatchDto>>(jsonData);
                return View(statusCounts ?? new List<ResultFootballMatchDto>());
            }
            return View();
        }
    }
}
