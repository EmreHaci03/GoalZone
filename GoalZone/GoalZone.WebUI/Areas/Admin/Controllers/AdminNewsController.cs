using GoalZone.BusinessLayer.Abstract;
using GoalZone.DtoLayer.DTOS.NewsDto;
using GoalZone.DtoLayer.DTOS.TeamDto;
using GoalZone.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace GoalZone.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminNewsController : Controller
    {
        private readonly IHttpClientFactory httpClient;

        public AdminNewsController(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
        }
        [HttpGet]
        public async Task<IActionResult> NewsList()
        {
            var client = httpClient.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/News/NewsListWithTeam");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNewsDto>>(jsonData);
                return View(values);
            }
           return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateNews()
        {
            var TeamClient = httpClient.CreateClient();
            var TeamResponseMessage = await TeamClient.GetAsync("https://localhost:7084/api/Teams");
            if (TeamResponseMessage.IsSuccessStatusCode)
            {
                var TeamjsonData = await TeamResponseMessage.Content.ReadAsStringAsync();
                var Teamvalues = JsonConvert.DeserializeObject<List<ResultTeamDto>>(TeamjsonData);
                ViewBag.Teams = Teamvalues.Select(x => new SelectListItem
                {
                    Value = x.TeamId.ToString(),
                    Text = x.TeamName
                }).ToList();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews(CreateNewsDto dto)
        {
            var client = httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7084/api/News/",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("NewsList");
            }
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteNews(int id)
        {
            var client = httpClient.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7084/api/News/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("NewsList");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateNews(int id)
        {

            var TeamClient = httpClient.CreateClient();
            var TeamresponseMessage = await TeamClient.GetAsync($"https://localhost:7084/api/Teams");
            if (TeamresponseMessage.IsSuccessStatusCode)
            {
                var TeamjsonData = await TeamresponseMessage.Content.ReadAsStringAsync();
                var Teamvalues = JsonConvert.DeserializeObject<List<ResultTeamDto>>(TeamjsonData);
                ViewBag.Teams = Teamvalues.Select(x => new SelectListItem
                {
                    Value = x.TeamId.ToString(),
                    Text = x.TeamName
                });
            }

            var client = httpClient.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7084/api/News/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateNewsDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNews(UpdateNewsDto dto)
        {
            var client = httpClient.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content=new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7084/api/News",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("NewsList");
            }

            var errorContent = await responseMessage.Content.ReadAsStringAsync();
            return Content(errorContent);
        }

    }
}
