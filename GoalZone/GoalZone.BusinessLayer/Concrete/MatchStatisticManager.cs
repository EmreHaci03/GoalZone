using GoalZone.BusinessLayer.Abstract;
using GoalZone.DataAccessLayer.Abstract;
using GoalZone.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalZone.BusinessLayer.Concrete
{
    public class MatchStatisticManager : IMatchStatisticService
    {
        private readonly IMatchStatisticDal _matchStatisticDal;

        public MatchStatisticManager(IMatchStatisticDal matchStatisticDal)
        {
            _matchStatisticDal = matchStatisticDal;
        }

        public async Task<List<MatchStatistic>> MatchStatisticByFootballMatchId(int FootballMatchId)
        {
            return await _matchStatisticDal.MatchStatisticByFootballMatchId(FootballMatchId);
        }

        public async Task TCreateAsync(MatchStatistic entity)
        {
            await _matchStatisticDal.CreateAsync(entity);
        }

        public async Task<List<MatchStatistic>> TGetAllAsync()
        {
            return await _matchStatisticDal.GetAllAsync();
        }

        public async Task<MatchStatistic> TGetByIdAsync(int id)
        {
            return await _matchStatisticDal.GetByIdAsync(id);
        }

        public async Task<List<MatchStatistic>> TMatchStatisticListWithMatch()
        {
            return await _matchStatisticDal.MatchStatisticListWithMatch();
        }

        public async Task TUpdateAsync(MatchStatistic entity)
        {
            await _matchStatisticDal.UpdateAsync(entity);
        }
    }
}