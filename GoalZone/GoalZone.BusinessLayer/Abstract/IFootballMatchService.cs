using GoalZone.DtoLayer.DTOS.AdminDashboardDto;
using GoalZone.DtoLayer.DTOS.DefaultDto;
using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.BusinessLayer.Abstract
{
    public interface IFootballMatchService:IGenericService<FootballMatch>
    {
        Task<List<FootballMatch>> TFootballMatchWithDetail();
        Task<List<FootballMatch>> TGetFootballMatchWithDetailByWeekId(int weekId);
        Task<List<FootballMatch>> TGetFootballMatchWithDetailById(int footballMatchId);
        Task<int> TGetFootballMatchLastWeek();
        Task<List<FootballMatch>> TUpcomingMatches();
        Task<FootballMatch> TGetMostGoalMatch();
        Task TGetLastWeekWithDetail();
        Task<List<MatchStatusCountDto>> TGetFootballMatchStatusCount();
        Task<FootballMatch> TGetLastWeekFeatureMatch();
        Task<List<FootballMatch>> TLiveMatchListByLastWeek();

        Task<List<FootballMatch>> TNotStartedMatchListByLastWeek();

        Task<List<FootballMatch>> TFinishedMatchListByLastWeek();

        Task<DashboardDto> TGetDashboardData();

    }
}
