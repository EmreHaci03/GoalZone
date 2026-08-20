using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.ViewComponents.Default
{
    public class DefaultLiveMatchViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public DefaultLiveMatchViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/FootballMatch/LiveMatchList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLiveMatchDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}
