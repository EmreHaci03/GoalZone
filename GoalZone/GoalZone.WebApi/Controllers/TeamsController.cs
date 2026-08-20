using AutoMapper;
using GoalZone.BusinessLayer.Abstract;
using GoalZone.DtoLayer.DTOS.TeamDto;
using GoalZone.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;
        public TeamsController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> TeamListWithStadium()
        {
            var values =await  _teamService.TGetTeamWithDetailAsync();
            var mapper = _mapper.Map<List<ResultTeamDto>>(values);
            return Ok(mapper);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var values = await _teamService.TGetTeamWithDetailById(id);
            var mapper = _mapper.Map<GetTeamByIdDto>(values);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto dto)
        {
            var mapper = _mapper.Map<Team>(dto);
            await _teamService.TCreateAsync(mapper);
            return Ok("Takım başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDto dto)
        {
            var mapper = _mapper.Map<Team>(dto);
             await _teamService.TUpdateAsync(mapper);
            return Ok("Takım başarıyla Güncellendi");
        }
    }
}
