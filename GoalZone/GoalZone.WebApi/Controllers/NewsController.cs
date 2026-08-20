using AutoMapper;
using GoalZone.DataAccessLayer.Abstract;
using GoalZone.DtoLayer.DTOS.NewsDto;
using GoalZone.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsDal _newsDal;
        private readonly IMapper _mapper;
        public NewsController(INewsDal newsDal, IMapper mapper)
        {
            _newsDal = newsDal;
            _mapper = mapper;
        }

        [HttpGet("NewsListWithTeam")]
        public async Task<IActionResult> NewsListWithTeam()
        {
            var values = await _newsDal.GetNewsWithTeamName();
            var mapper=_mapper.Map<List<ResultNewsDto>>(values);
            return Ok(mapper);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNewsById(int id)
        {
            var values = await _newsDal.GetNewsByIdAsync(id);
            var mapper = _mapper.Map<GetNewsByIdDto>(values);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews(CreateNewsDto dto)
        {
            var values = _mapper.Map<News>(dto);
            await _newsDal.CreateAsync(values);
            return Ok("Yeni Haber Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            await _newsDal.DeleteNewsAsync(id);
            return Ok("Yeni Haber Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNews(UpdateNewsDto dto)
        {
            var values= _mapper.Map<News>(dto);   
            await _newsDal.UpdateAsync(values);
            return Ok("Haber Haber Güncellendi");
        }
    }
}
