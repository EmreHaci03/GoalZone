using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DataAccessLayer.Abstract
{
    public interface IPlayerDal:IGenericDal<Player>
    {
        Task<List<Player>> GetPlayerListWithTeam();
        Task<Player> PlayerGetByIdAsync(int id);
        Task DeleteAsync(Player player);
    }
}
