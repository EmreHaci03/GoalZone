using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DataAccessLayer.Abstract
{
    public interface IMatchStatisticDal:IGenericDal<MatchStatistic>
    {
        Task<List<MatchStatistic>> MatchStatisticListWithMatch();

        Task<List<MatchStatistic>> MatchStatisticByFootballMatchId(int FootballMatchId);
    }
}
