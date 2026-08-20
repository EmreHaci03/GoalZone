using AutoMapper;
using GoalZone.BusinessLayer.Abstract;
using GoalZone.DtoLayer.DTOS.StadiumDto;
using GoalZone.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumService stadiumService;
        private readonly IMapper _mapper;
        public StadiumController(IStadiumService stadiumService, IMapper mapper)
        {
            this.stadiumService = stadiumService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> StadiumList()
        {
            var values=await stadiumService.TGetAllAsync();
            var mapper = _mapper.Map<List<ResultStadiumDto>>(values);
            return Ok(mapper);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStadiumById(int id)
        {
            var values = await stadiumService.TGetByIdAsync(id);
            var mapper = _mapper.Map<GetStadiumByIdDto>(values);
            return Ok(mapper);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStadium(CreateStadiumDto dto)
        {
            var mapper = _mapper.Map<Stadium>(dto);
            await stadiumService.TCreateAsync(mapper);
            return Ok("Stadyum Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStadium(UpdateStadiumDto dto)
        {
            var mapper = _mapper.Map<Stadium>(dto);
            await stadiumService.TUpdateAsync(mapper);
            return Ok("Stadyum Güncellendi");
        }
    }
}
