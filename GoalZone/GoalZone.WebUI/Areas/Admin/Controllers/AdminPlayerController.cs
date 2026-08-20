using GoalZone.DtoLayer.DTOS.PlayerDto;
using GoalZone.DtoLayer.DTOS.TeamDto;
using GoalZone.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace GoalZone.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPlayerController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AdminPlayerController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> PlayerList()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/Player/PlayerListWithTeam");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPlayerDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreatePlayer()
        {
            var teamClient = httpClientFactory.CreateClient();
            var teamResponseMessage = await teamClient.GetAsync("https://localhost:7084/api/Teams");
            if (teamResponseMessage.IsSuccessStatusCode)
            {
                var teamJsonData = await teamResponseMessage.Content.ReadAsStringAsync();
                var teamValues = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamJsonData);
                ViewBag.Teams = teamValues.Select(x => new SelectListItem
                {
                    Value = x.TeamId.ToString(),
                    Text = x.TeamName
                }).ToList();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(CreatePlayerDto dto)
        {

            var teamClient = httpClientFactory.CreateClient();
            var teamResponseMessage = await teamClient.GetAsync("https://localhost:7084/api/Teams");
            if (teamResponseMessage.IsSuccessStatusCode)
            {
                var teamJsonData = await teamResponseMessage.Content.ReadAsStringAsync();
                var teamValues = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamJsonData);
                ViewBag.Teams = teamValues.Select(x => new SelectListItem
                {
                    Value = x.TeamId.ToString(),
                    Text = x.TeamName
                }).ToList();
            }


            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var ResponseMessage = await client.PostAsync($"https://localhost:7084/api/Player", content);
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("PlayerList");
            }
            return View(dto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7084/api/Player/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("PlayerList");

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdatePlayer(int id)
        {
            var teamClient = httpClientFactory.CreateClient();
            var teamResponseMessage = await teamClient.GetAsync("https://localhost:7084/api/Team");
            if (teamResponseMessage.IsSuccessStatusCode)
            {
                var teamJsonData = await teamResponseMessage.Content.ReadAsStringAsync();
                var teamValues = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamJsonData);
                ViewBag.Teams = teamValues.Select(x => new SelectListItem
                {
                    Value = x.TeamId.ToString(),
                    Text = x.TeamName
                }).ToList();
            }

            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7084/api/Player/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdatePlayerDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePlayer(UpdatePlayerDto dto)
        {

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7084/api/Player", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("PlayerList");
            }

            var teamClient = httpClientFactory.CreateClient();
            var teamResponseMessage = await teamClient.GetAsync("https://localhost:7084/api/Team");
            if (teamResponseMessage.IsSuccessStatusCode)
            {
                var teamJsonData = await teamResponseMessage.Content.ReadAsStringAsync();
                var teamValues = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamJsonData);
                ViewBag.Teams = teamValues.Select(x => new SelectListItem
                {
                    Value = x.TeamId.ToString(),
                    Text = x.TeamName
                }).ToList();
            }
            return View(dto);
        }
    }
}
