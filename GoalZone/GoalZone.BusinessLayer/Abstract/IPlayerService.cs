using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.BusinessLayer.Abstract
{
    public interface IPlayerService:IGenericService<Player>
    {
        Task<List<Player>> TGetPlayerListWithTeam();
        Task<Player> TPlayerGetByIdAsync(int id);
        Task TDeleteAsync(Player player);
    }
}
