using GoalZone.BusinessLayer.Abstract;
using GoalZone.DataAccessLayer.Abstract;
using GoalZone.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalZone.BusinessLayer.Concrete
{
    public class MatchEventManager : IMatchEventService
    {
        private readonly IMatchEventDal _matchEventDal;

        public MatchEventManager(IMatchEventDal matchEventDal)
        {
            _matchEventDal = matchEventDal;
        }

        public async Task<List<MatchEvent>> TAwayTeamCardList(int footballMatchId)
        {
            return await _matchEventDal.AwayTeamCardList(footballMatchId);
        }

        public async Task<List<MatchEvent>> TAwayTeamEventListByFootballMatchId(int footballMatchId)
        {
            return await _matchEventDal.AwayTeamEventListByFootballMatchId(footballMatchId);
        }

        public async Task<List<MatchEvent>> TAwayTeamMatchEventPlayerGoalList(int footballMatchId)
        {
            return await _matchEventDal.AwayTeamMatchEventPlayerGoalList(footballMatchId);
        }

        public async Task<List<MatchEvent>> TAwayTeamSubstitution(int footballMatchId)
        {
            return await _matchEventDal.AwayTeamSubstitution(footballMatchId);
        }

        public async Task TCreateAsync(MatchEvent entity)
        {
            await _matchEventDal.CreateAsync(entity);
        }

        public async Task<List<MatchEvent>> TGetAllAsync()
        {
            return await _matchEventDal.GetAllAsync();
        }

        public async Task<MatchEvent> TGetByIdAsync(int id)
        {
            return await _matchEventDal.GetByIdAsync(id);
        }

        public async Task<List<MatchEvent>> THomeTeamCardList(int footballMatchId)
        {
            return await _matchEventDal.HomeTeamCardList(footballMatchId);
        }

        public async Task<List<MatchEvent>> THomeTeamEventListByFootballMatchId(int footballMatchId)
        {
            return await _matchEventDal.HomeTeamEventListByFootballMatchId(footballMatchId);
        }

        public async Task<List<MatchEvent>> THomeTeamMatchEventPlayerGoalList(int footballMatchId)
        {
            return await _matchEventDal.HomeTeamMatchEventPlayerGoalList(footballMatchId); 
        }

        public async Task<List<MatchEvent>> THomeTeamSubstitution(int footballMatchId)
        {
            return await _matchEventDal.HomeTeamSubstitution(footballMatchId);
        }

        public async Task<List<MatchEvent>> TMatchEventListByFootballMatchId(int footballMatchId)
        {
            return await _matchEventDal.MatchEventListByFootballMatchId(footballMatchId);
        }

        public async Task TUpdateAsync(MatchEvent entity)
        {
            await _matchEventDal.UpdateAsync(entity);
        }
    }
}