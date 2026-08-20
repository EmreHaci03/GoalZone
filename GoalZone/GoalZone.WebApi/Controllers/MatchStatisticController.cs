using AutoMapper;
using GoalZone.BusinessLayer.Abstract;
using GoalZone.DtoLayer.DTOS.MatchStatisticDto;
using GoalZone.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchStatisticController : ControllerBase
    {
        private readonly IMatchStatisticService matchStatisticService;
        private readonly IMapper _mapper;
        public MatchStatisticController(IMatchStatisticService matchStatisticService, IMapper mapper)
        {
            this.matchStatisticService = matchStatisticService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> MatchStatisticList()
        {
            var values = await matchStatisticService.TMatchStatisticListWithMatch();
            var mapper = _mapper.Map<List<ResultMatchStatisticDto>>(values);
            return Ok(mapper);
        }

        [HttpGet("MatchStatisticByFootballMatchId")]
        public async Task<IActionResult> MatchStatisticByFootballMatch(int footballMatchId)
        {
            var values = await matchStatisticService.MatchStatisticByFootballMatchId(footballMatchId);
            var mapper = _mapper.Map<List<ResultMatchStatisticDto>>(values);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatchStatistic(CreateMatchStatisticDto dto)
        {
            var mapper = _mapper.Map<MatchStatistic>(dto);
            await matchStatisticService.TCreateAsync(mapper);
            return Ok("Maç İstatistiği Eklendi");
        }
    }
}
