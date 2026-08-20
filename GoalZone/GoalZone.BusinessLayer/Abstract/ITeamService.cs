using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.BusinessLayer.Abstract
{
    public interface ITeamService:IGenericService<Team>
    {
        Task<List<Team>> TGetTeamWithDetailAsync();
        Task<Team> TGetTeamWithDetailById(int id);
    }
}
