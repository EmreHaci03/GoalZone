using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using GoalZone.DtoLayer.DTOS.TeamDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace GoalZone.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminFootballMatchController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AdminFootballMatchController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> FootballMatchList()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/FootballMatch");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFootballMatchDto>>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateFootballMatch()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/Teams");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTeamDto>>(jsondata);
                ViewBag.Teams = values.Select(x => new SelectListItem
                {
                    Value = x.TeamId.ToString(),
                    Text = x.TeamName
                }).ToList();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFootballMatch(CreateFootballMatchDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"https://localhost:7084/api/FootballMatch",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("FootballMatchList");
            }
            return View();
        }


    }
}
