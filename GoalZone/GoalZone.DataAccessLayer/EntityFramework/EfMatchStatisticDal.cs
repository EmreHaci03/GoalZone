using GoalZone.DataAccessLayer.Abstract;
using GoalZone.DataAccessLayer.Context;
using GoalZone.DataAccessLayer.Repository;
using GoalZone.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DataAccessLayer.EntityFramework
{
    public class EfMatchStatisticDal : GenericRepository<MatchStatistic>, IMatchStatisticDal
    {
        private readonly GoalZoneContext _context;
        public EfMatchStatisticDal(GoalZoneContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<MatchStatistic>> MatchStatisticByFootballMatchId(int FootballMatchId)
        {
            return await _context.MatchStatistics
                .Include(x => x.FootballMatch)
                .ThenInclude(fm => fm.HomeTeam)
                .Include(x => x.FootballMatch)
                .ThenInclude(fm => fm.AwayTeam)
                .Where(x => x.FootballMatchId == FootballMatchId)
                .ToListAsync();
        }

        public async Task<List<MatchStatistic>> MatchStatisticListWithMatch()
        {
            return await _context.MatchStatistics.Include(x => x.FootballMatch).ToListAsync();
        }
    }
}
