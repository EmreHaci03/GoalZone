using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.BusinessLayer.Abstract
{
    public interface IMatchStatisticService:IGenericService<MatchStatistic>
    {
        Task<List<MatchStatistic>> TMatchStatisticListWithMatch();
        Task<List<MatchStatistic>> MatchStatisticByFootballMatchId(int FootballMatchId);
    }
}
