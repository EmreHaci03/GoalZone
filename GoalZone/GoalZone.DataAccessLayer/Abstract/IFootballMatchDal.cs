using GoalZone.DtoLayer.DTOS.AdminDashboardDto;
using GoalZone.DtoLayer.DTOS.DefaultDto;
using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DataAccessLayer.Abstract
{
    public interface IFootballMatchDal:IGenericDal<FootballMatch>
    {
        Task<List<FootballMatch>> FootballMatchWithDetail();

        Task<List<FootballMatch>> GetFootballMatchWithDetailByWeekId(int weekId);

        Task<List<FootballMatch>> GetFootballMatchWithDetailById(int footballMatchId);

        Task<FootballMatch> GetMostGoalMatch();

        Task<DashboardDto> GetDashboardData();

        Task<List<FootballMatch>> UpcomingMatches();

        Task<int> GetFootballMatchLastWeek();

        Task<List<FootballMatch>> LiveMatchListByLastWeek();

        Task<List<FootballMatch>> NotStartedMatchListByLastWeek();

        Task<List<FootballMatch>> FinishedMatchListByLastWeek();

        Task<List<MatchStatusCountDto>> GetFootballMatchStatusCount();

        Task<FootballMatch> GetLastWeekFeatureMatch();

    }
}
