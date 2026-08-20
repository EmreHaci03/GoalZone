using GoalZone.BusinessLayer.Abstract;
using GoalZone.DataAccessLayer.Abstract;
using GoalZone.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalZone.BusinessLayer.Concrete
{
    public class PlayerManager : IPlayerService
    {
        private readonly IPlayerDal _playerDal;

        public PlayerManager(IPlayerDal playerDal)
        {
            _playerDal = playerDal;
        }

        public async Task TCreateAsync(Player entity)
        {
            await _playerDal.CreateAsync(entity);
        }

        public async Task TDeleteAsync(Player player)
        {
            await _playerDal.DeleteAsync(player);
        }

        public async Task<List<Player>> TGetAllAsync()
        {
            return await _playerDal.GetAllAsync();
        }

        public async Task<Player> TGetByIdAsync(int id)
        {
            return await _playerDal.GetByIdAsync(id);
        }

        public async Task<List<Player>> TGetPlayerListWithTeam()
        {
            return await _playerDal.GetPlayerListWithTeam();
        }

        public async Task<Player> TPlayerGetByIdAsync(int id)
        {
            return await _playerDal.PlayerGetByIdAsync(id);
        }

        public async Task TUpdateAsync(Player entity)
        {
            await _playerDal.UpdateAsync(entity);
        }
    }
}