using GoalZone.DtoLayer.DTOS.StadiumDto;
using GoalZone.DtoLayer.DTOS.TeamDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace GoalZone.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTeamController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AdminTeamController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> TeamList()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/Teams");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTeamDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateTeam()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/Stadium");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(jsonData);
                ViewBag.Stadiums = values.Select(x => new SelectListItem
                {
                    Value = x.StadiumId.ToString(),
                    Text=x.StadiumName
                }).ToList();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7084/api/Teams", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("TeamList");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeam(int id)
        {
            var client = httpClientFactory.CreateClient();
            var stadiumResponse = await client.GetAsync("https://localhost:7084/api/Stadium");
            if (stadiumResponse.IsSuccessStatusCode)
            {
                var stadiumJson = await stadiumResponse.Content.ReadAsStringAsync();
                var stadiums = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(stadiumJson);
                ViewBag.Stadiums = stadiums.Select(x => new SelectListItem
                {
                    Value = x.StadiumId.ToString(),
                    Text = x.StadiumName
                }).ToList();
            }

            var teamResponse = await client.GetAsync($"https://localhost:7084/api/Teams/{id}");
            if (teamResponse.IsSuccessStatusCode)
            {
                var teamJson = await teamResponse.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateTeamDto>(teamJson);
                return View(value);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7084/api/Teams", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("TeamList");

            var stadiumResponse = await client.GetAsync("https://localhost:7084/api/Stadium");
            if (stadiumResponse.IsSuccessStatusCode)
            {
                var stadiumJson = await stadiumResponse.Content.ReadAsStringAsync();
                var stadiums = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(stadiumJson);
                ViewBag.Stadiums = stadiums.Select(x => new SelectListItem
                {
                    Value = x.StadiumId.ToString(),
                    Text = x.StadiumName
                }).ToList();
            }

            return View(dto);
        }
    }
}
