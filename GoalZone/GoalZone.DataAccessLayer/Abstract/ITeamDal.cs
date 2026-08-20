using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DataAccessLayer.Abstract
{
    public interface ITeamDal:IGenericDal<Team>
    {
        Task<List<Team>> GetTeamWithDetailAsync();

        Task<Team> GetTeamWithDetailById(int id);
    }
}
