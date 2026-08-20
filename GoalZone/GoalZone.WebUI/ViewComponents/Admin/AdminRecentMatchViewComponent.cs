using GoalZone.DataAccessLayer.Context;
using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoalZone.WebUI.ViewComponents.Admin
{
    public class AdminRecentMatchViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly GoalZoneContext _context;
        public AdminRecentMatchViewComponent(IHttpClientFactory httpClientFactory, GoalZoneContext context)
        {
            this.httpClientFactory = httpClientFactory;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var lastWeek = _context.FootballMatches.Max(x => x.Week);
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7084/api/FootballMatch/{lastWeek}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFootballMatchDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
