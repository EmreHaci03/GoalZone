using GoalZone.DtoLayer.DTOS.StadiumDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace GoalZone.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminStadiumController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AdminStadiumController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> StadiumList()
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/Stadium");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultStadiumDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateStadium()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStadium(CreateStadiumDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7084/api/Stadium", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("StadiumList");
            }
            var error = await responseMessage.Content.ReadAsStringAsync();
            return View(error);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteStadium(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7084/api/Stadium/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("StadiumList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStadium(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7084/api/Stadium/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStadiumDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStadium(UpdateStadiumDto dto)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7084/api/Stadium", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("StadiumList");
            }
            return View(dto);
        }
    
    }
}