using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.BusinessLayer.Abstract
{
    public interface IMatchEventService:IGenericService<MatchEvent>
    {
        Task<List<MatchEvent>> TMatchEventListByFootballMatchId(int footballMatchId);
        Task<List<MatchEvent>> THomeTeamMatchEventPlayerGoalList(int footballMatchId);
        Task<List<MatchEvent>> TAwayTeamMatchEventPlayerGoalList(int footballMatchId);
        Task<List<MatchEvent>> THomeTeamCardList(int footballMatchId);
        Task<List<MatchEvent>> TAwayTeamCardList(int footballMatchId);

        Task<List<MatchEvent>> THomeTeamSubstitution(int footballMatchId);

        Task<List<MatchEvent>> TAwayTeamSubstitution(int footballMatchId);

        Task<List<MatchEvent>> THomeTeamEventListByFootballMatchId(int footballMatchId);
        Task<List<MatchEvent>> TAwayTeamEventListByFootballMatchId(int footballMatchId); 
    }
}
