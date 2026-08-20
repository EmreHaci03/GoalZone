using AutoMapper;
using GoalZone.BusinessLayer.Abstract;
using GoalZone.DtoLayer.DTOS.PlayerDto;
using GoalZone.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoalZone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;
        private readonly IMapper _mapper;
        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            this.playerService = playerService;
            _mapper = mapper;
        }

        [HttpGet("PlayerListWithTeam")]
        public async Task<IActionResult> PlayerListWithTeam()
        {
            var values = await playerService.TGetPlayerListWithTeam();
            var mapper = _mapper.Map<List<ResultPlayerDto>>(values);
            return Ok(mapper);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var values = await playerService.TPlayerGetByIdAsync(id);
            var mapper = _mapper.Map<GetPlayerByIdDto>(values);
            return Ok(mapper);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlayer(CreatePlayerDto dto)
        {
            var mapper = _mapper.Map<Player>(dto);
            await playerService.TCreateAsync(mapper);
            return Ok("Oyuncu Başarıyla Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await playerService.TGetByIdAsync(id);
            await playerService.TDeleteAsync(player);
            return Ok("Oyuncu Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(UpdatePlayerDto dto)
        {
            var mapper = _mapper.Map<Player>(dto);
            await playerService.TUpdateAsync(mapper);
            return Ok("Oyuncu Başarıyla Güncellendi");
        }
    }
}
