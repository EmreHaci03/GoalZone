using AutoMapper;
using GoalZone.BusinessLayer.Abstract;
using GoalZone.DtoLayer.DTOS.DefaultDto;
using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardStatisticController : ControllerBase
    {
        private readonly IFootballMatchService matchService;
        private readonly IMapper _mapper;
        public DashboardStatisticController(IFootballMatchService matchService, IMapper mapper)
        {
            this.matchService = matchService;
            _mapper = mapper;
        }

        [HttpGet("MatchWithStatus")]
        public async Task<IActionResult> MatchWithStatus()
        {
            var values = await matchService.TGetFootballMatchStatusCount();
            return Ok(values);
        }

        [HttpGet("AdminDashboard")]
        public async Task<IActionResult> AdminDashboard()
        {
            var values = await matchService.TGetDashboardData();
            return Ok(values);
        }

        [HttpGet("UpComingMatches")]
        public async Task<IActionResult> UpComingMatches()
        {
            var values = await matchService.TUpcomingMatches();
            var mapper = _mapper.Map<List<ResultFootballMatchDto>>(values);
            return Ok(mapper);
        }
        [HttpGet("MostGoalMatch")]
        public async Task<IActionResult> MostGoalMatch()
        {
            var values = await matchService.TGetMostGoalMatch();
            var mapper = _mapper.Map<ResultFootballMatchDto>(values);
            return Ok(mapper);
        }
    }
}
