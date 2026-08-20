using AutoMapper;
using GoalZone.BusinessLayer.Abstract;
using GoalZone.DtoLayer.DTOS.DefaultDto;
using GoalZone.DtoLayer.DTOS.FootballMatchDto;
using GoalZone.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballMatchController : ControllerBase
    {
        private readonly IFootballMatchService footballMatchService;
        private readonly IMapper _mapper;
        public FootballMatchController(IFootballMatchService footballMatchService, IMapper mapper)
        {
            this.footballMatchService = footballMatchService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> FootballMatch()
        {
            var values = await footballMatchService.TFootballMatchWithDetail();
            var mapper = _mapper.Map<List<ResultFootballMatchDto>>(values);
            return Ok(mapper);
        }


        [HttpGet("GetLastFootballMatchWeek")]
        public async Task<IActionResult> GetLastFootballMatchWeek()
        {
            var values = await footballMatchService.TGetFootballMatchLastWeek();
            return Ok(values);
        }
        [HttpGet("LiveMatchList")]
        public async Task<IActionResult> LiveMatchListByLastWeek()
        {
            var values = await footballMatchService.TLiveMatchListByLastWeek();
            var mapper = _mapper.Map<List<ResultLiveMatchDto>>(values);
            return Ok(mapper);
        }

        [HttpGet("NotStartMatchList")]
        public async Task<IActionResult> NotStartMatchListByLastWeek()
        {
            var values = await footballMatchService.TNotStartedMatchListByLastWeek();
            var mapper = _mapper.Map<List<ResultFootballMatchDto>>(values);
            return Ok(mapper);
        }

        [HttpGet("FinishedMatchList")]
        public async Task<IActionResult> FinishedMatchListByLastWeek()
        {
            var values = await footballMatchService.TFinishedMatchListByLastWeek();
            var mapper = _mapper.Map<List<ResultFootballMatchDto>>(values);
            return Ok(mapper);
        }


        [HttpGet("LastWeekFeatureMatch")]
        public async Task<IActionResult> GetLastWeekFeatureMatch()
        {
            var values = await footballMatchService.TGetLastWeekFeatureMatch();
            var mapper = _mapper.Map<GetFeatureMatchDto>(values);
            return Ok(mapper);
        }

        [HttpGet("GetLastFootballMatchCount")]
        public async Task<IActionResult> GetLastFootballMatchCount()
        {
            var values = await footballMatchService.TGetFootballMatchStatusCount();
            var mapper = _mapper.Map<MatchStatusCountDto>(values);
            return Ok(mapper);
        }

        [HttpGet("GetFootballMatchWithDetailByFootball")]
        public async Task<IActionResult> GetFootballMatchWithDetailByFootballId(int footballMatchId)
        {
            var values = await footballMatchService.TGetFootballMatchWithDetailById(footballMatchId);
            var mapper = _mapper.Map<List<ResultFootballMatchDto>>(values);
            return Ok(mapper);
        }


        [HttpGet("{weekId}")]
        public async Task<IActionResult> FootballMatch(int weekId)
        {
            var values = await footballMatchService.TGetFootballMatchWithDetailByWeekId(weekId);
            var mapper = _mapper.Map<List<GetFootballMatchByIdDto>>(values);
            return Ok(mapper);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFootballMatch(CreateFootballMatchDto dto)
        {
            var mapper = _mapper.Map<FootballMatch>(dto);
            await footballMatchService.TCreateAsync(mapper);
            return Ok("Maç Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFootballMatch(UpdateFootballMatchDto dto)
        {
            var mapper = _mapper.Map<FootballMatch>(dto);
            await footballMatchService.TUpdateAsync(mapper);
            return Ok("Maç Güncellendi");
        }
    }
}
