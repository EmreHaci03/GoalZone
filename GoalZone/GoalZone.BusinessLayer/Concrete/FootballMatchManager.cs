using GoalZone.BusinessLayer.Abstract;
using GoalZone.DataAccessLayer.Abstract;
using GoalZone.DtoLayer.DTOS.AdminDashboardDto;
using GoalZone.DtoLayer.DTOS.DefaultDto;
using GoalZone.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalZone.BusinessLayer.Concrete
{
    public class FootballMatchManager : IFootballMatchService
    {
        private readonly IFootballMatchDal _footballMatchDal;

        public FootballMatchManager(IFootballMatchDal footballMatchDal)
        {
            _footballMatchDal = footballMatchDal;
        }

        public async Task TCreateAsync(FootballMatch entity)
        {
            await _footballMatchDal.CreateAsync(entity);
        }

        public async Task<List<FootballMatch>> TFinishedMatchListByLastWeek()
        {
            return await _footballMatchDal.FinishedMatchListByLastWeek();
        }

        public async Task<List<FootballMatch>> TFootballMatchWithDetail()
        {
            return await _footballMatchDal.FootballMatchWithDetail();
        }

        public async Task<List<FootballMatch>> TGetAllAsync()
        {
            return await _footballMatchDal.GetAllAsync();
        }

        public async Task<FootballMatch> TGetByIdAsync(int id)
        {
            return await _footballMatchDal.GetByIdAsync(id);
        }

        public async Task<DashboardDto> TGetDashboardData()
        {
            return await _footballMatchDal.GetDashboardData();
        }

        public Task<int> TGetFootballMatchLastWeek()
        {
            return  _footballMatchDal.GetFootballMatchLastWeek();
        }

        public async Task<List<MatchStatusCountDto>> TGetFootballMatchStatusCount()
        {
            return await _footballMatchDal.GetFootballMatchStatusCount();
        }

        public async Task<List<FootballMatch>> TGetFootballMatchWithDetailById(int footballMatchId)
        {
            return await _footballMatchDal.GetFootballMatchWithDetailById(footballMatchId);
        }

        public async Task<List<FootballMatch>> TGetFootballMatchWithDetailByWeekId(int weekId)
        {
            return await _footballMatchDal.GetFootballMatchWithDetailByWeekId(weekId);
        }

        public async Task<FootballMatch> TGetLastWeekFeatureMatch()
        {
            return await _footballMatchDal.GetLastWeekFeatureMatch();
        }

        public async Task TGetLastWeekWithDetail()
        {
             await _footballMatchDal.GetFootballMatchLastWeek();
        }

        public async Task<FootballMatch> TGetMostGoalMatch()
        {
            return await _footballMatchDal.GetMostGoalMatch();
        }

        public async Task<List<FootballMatch>> TLiveMatchListByLastWeek()
        {
            return await _footballMatchDal.LiveMatchListByLastWeek();
        }

        public async Task<List<FootballMatch>> TNotStartedMatchListByLastWeek()
        {
            return await _footballMatchDal.NotStartedMatchListByLastWeek();
        }

        public async Task<List<FootballMatch>> TUpcomingMatches()
        {
            return await _footballMatchDal.UpcomingMatches();
        }

        public async Task TUpdateAsync(FootballMatch entity)
        {
            await _footballMatchDal.UpdateAsync(entity);
        }
    }
}