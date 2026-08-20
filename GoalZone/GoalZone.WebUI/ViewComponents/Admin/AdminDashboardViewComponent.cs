using GoalZone.DtoLayer.DTOS.AdminDashboardDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.ViewComponents.Admin
{
    public class AdminDashboardViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AdminDashboardViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/DashboardStatistic/AdminDashboard");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<DashboardDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
