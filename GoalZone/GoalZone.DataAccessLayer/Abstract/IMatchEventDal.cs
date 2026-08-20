using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DataAccessLayer.Abstract
{
    public interface IMatchEventDal:IGenericDal<MatchEvent>
    {
        Task<List<MatchEvent>> MatchEventListByFootballMatchId(int footballMatchId);

        Task<List<MatchEvent>> HomeTeamEventListByFootballMatchId(int footballMatchId);
        Task<List<MatchEvent>> AwayTeamEventListByFootballMatchId(int footballMatchId);

        Task<List<MatchEvent>> HomeTeamMatchEventPlayerGoalList(int footballMatchId);

        Task<List<MatchEvent>> AwayTeamMatchEventPlayerGoalList(int footballMatchId);
        Task<List<MatchEvent>> HomeTeamCardList(int footballMatchId);
        Task<List<MatchEvent>> AwayTeamCardList(int footballMatchId);

        Task<List<MatchEvent>> HomeTeamSubstitution(int footballMatchId);

        Task<List<MatchEvent>> AwayTeamSubstitution(int footballMatchId);

    }
}
