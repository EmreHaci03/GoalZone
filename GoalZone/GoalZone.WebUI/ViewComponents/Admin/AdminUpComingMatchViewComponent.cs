using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.ViewComponents.Admin
{
    public class AdminUpComingMatchViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public AdminUpComingMatchViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/DashboardStatistic/UpComingMatches");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFootballMatchDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
