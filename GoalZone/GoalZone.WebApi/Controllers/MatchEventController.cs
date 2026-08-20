using AutoMapper;
using GoalZone.BusinessLayer.Abstract;
using GoalZone.DtoLayer.DTOS.MatchEventDto;
using GoalZone.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchEventController : ControllerBase
    {
        private readonly IMatchEventService matchEventService;
        private readonly IMapper _mapper;

        public MatchEventController(IMatchEventService matchEventService, IMapper mapper)
        {
            this.matchEventService = matchEventService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> MatchEventList()
        {
            var values = await matchEventService.TGetAllAsync();
            var mapper = _mapper.Map<List<ResultMatchEventDto>>(values);
            return Ok(mapper);
        }
        [HttpGet("MatchEventListByFootballMatchId/{footballMatchId}")]
        public async Task<IActionResult> MatchEventListByFootballMatchId(int footballMatchId)
        {
            var values = await matchEventService.TMatchEventListByFootballMatchId(footballMatchId);
            var mapper = _mapper.Map<List<GetMatchEventByIdDto>>(values);
            return Ok(mapper);
        }

        [HttpGet("HomeTeamMatchEventPlayerGoalList/{footballMatchId}")]
        public async Task<IActionResult> HomeTeamMatchEventPlayerGoalList(int footballMatchId)
        {
            var values = await matchEventService.THomeTeamMatchEventPlayerGoalList(footballMatchId);
            var mapper = _mapper.Map<List<GetMatchEventByFootballIdDto>>(values);
            return Ok(mapper);
        }

        [HttpGet("AwayTeamMatchEventPlayerGoalList/{footballMatchId}")]
        public async Task<IActionResult> AwayTeamMatchEventPlayerGoalList(int footballMatchId)
        {
            var values = await matchEventService.TAwayTeamMatchEventPlayerGoalList(footballMatchId);
            var mapper = _mapper.Map<List<GetMatchEventByFootballIdDto>>(values);
            return Ok(mapper);
        }

        [HttpGet("HomeTeamCardList/{footballMatchId}")]
        public async Task<IActionResult> HomeTeamCardList(int footballMatchId)
        {
            var values = await matchEventService.THomeTeamCardList(footballMatchId);
            var mapper = _mapper.Map<List<GetMatchEventByFootballIdDto>>(values);
            return Ok(mapper);
        }
        [HttpGet("AwayTeamCardList/{footballMatchId}")]
        public async Task<IActionResult> TeamAwayTeamCardListsCardList(int footballMatchId)
        {
            var values = await matchEventService.TAwayTeamCardList(footballMatchId);
            var mapper = _mapper.Map<List<GetMatchEventByFootballIdDto>>(values);
            return Ok(mapper);
        }

        [HttpGet("HomeTeamSubstitution/{footballMatchId}")]
        public async Task<IActionResult> HomeTeamSubstitutionList(int footballMatchId)
        {
            var values = await matchEventService.THomeTeamSubstitution(footballMatchId);
            var mapper = _mapper.Map<List<GetMatchEventByFootballIdDto>>(values);
            return Ok(mapper);
        }

        [HttpGet("AwayTeamSubstitution/{footballMatchId}")]
        public async Task<IActionResult> AwayTeamSubstitutionList(int footballMatchId)
        {
            var values = await matchEventService.TAwayTeamSubstitution(footballMatchId);
            var mapper = _mapper.Map<List<GetMatchEventByFootballIdDto>>(values);
            return Ok(mapper);
        }

        [HttpGet("HomeTeamEventListByFootballMatchId/{footballMatchId}")]
        public async Task<IActionResult> HomeTeamEventListByFootballMatch(int footballMatchId)
        {
            var values = await matchEventService.THomeTeamEventListByFootballMatchId(footballMatchId);
            var mapper = _mapper.Map<List<GetMatchEventByFootballIdDto>>(values);
            return Ok(mapper);
        }


        [HttpGet("AwayTeamEventListByFootballMatchId/{footballMatchId}")]
        public async Task<IActionResult> AwayTeamEventListByFootballMatch(int footballMatchId)
        {
            var values = await matchEventService.TAwayTeamEventListByFootballMatchId(footballMatchId);
            var mapper = _mapper.Map<List<GetMatchEventByFootballIdDto>>(values);
            return Ok(mapper);
        }


        [HttpPost]
        public async Task<IActionResult> CreateMatchEvent(CreateMatchEventDto dto)
        {
            var mapper = _mapper.Map<MatchEvent>(dto);
            await matchEventService.TCreateAsync(mapper);
            return Ok("Maç Olayı Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatchEvent(UpdateMatchEventDto dto)
        {
            var mapper = _mapper.Map<MatchEvent>(dto);
            await matchEventService.TUpdateAsync(mapper);
            return Ok("Maç Olayı Güncellendi");
        }

    }
}
