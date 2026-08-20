using GoalZone.DataAccessLayer.Abstract;
using GoalZone.DataAccessLayer.Context;
using GoalZone.DataAccessLayer.Repository;
using GoalZone.DtoLayer.DTOS.AdminDashboardDto;
using GoalZone.DtoLayer.DTOS.DefaultDto;
using GoalZone.EntityLayer.Entities;
using GoalZone.EntityLayer.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DataAccessLayer.EntityFramework
{
    public class EfFootbalMatchDal : GenericRepository<FootballMatch>, IFootballMatchDal
    {
        private readonly GoalZoneContext _context;
        public EfFootbalMatchDal(GoalZoneContext context) : base(context)
        {
            this._context = context;    
        }

        public async Task<List<FootballMatch>> FinishedMatchListByLastWeek()
        {
            var lastWeek = await _context.FootballMatches
               .MaxAsync(x => x.Week);

            return await _context.FootballMatches.Include(x => x.HomeTeam).ThenInclude(x => x.Stadium).Include(x => x.AwayTeam).
                Where(x => x.Week == lastWeek && x.MatchStatus == MatchStatus.Finished)
                .ToListAsync();
        }

        public async Task<List<FootballMatch>> FootballMatchWithDetail()
        {
            return await _context.FootballMatches.Include(x => x.HomeTeam).ThenInclude(x => x.Stadium).Include(x => x.AwayTeam).ToListAsync();
        }

        public async Task<DashboardDto> GetDashboardData()
        {
            var totalMatch = await _context.FootballMatches.CountAsync();

            var totalWin = await _context.FootballMatches
                .CountAsync(x => x.MatchStatus == MatchStatus.Finished
                               && x.FullTimeScoreHome != x.FullTimeScoreAway);

            var totalGoal = await _context.FootballMatches
                .Where(x => x.MatchStatus == MatchStatus.Finished)
                .SumAsync(x => (x.FullTimeScoreHome ?? 0) + (x.FullTimeScoreAway ?? 0));

            var totalLive = await _context.FootballMatches
                .CountAsync(x => x.MatchStatus == MatchStatus.Live);   

            return new DashboardDto
            {
                Win = totalWin,
                Statistic = totalLive,
                TotalGoal = totalGoal,
                TotalMatch = totalMatch,
            };
        }

        public async Task<int> GetFootballMatchLastWeek()
        {
             return await _context.FootballMatches.OrderByDescending(x => x.Week).Select(y => y.Week).FirstOrDefaultAsync();
        }

        public async Task<List<MatchStatusCountDto>> GetFootballMatchStatusCount()
        {
            var lastWeek = await _context.FootballMatches
             .MaxAsync(x => x.Week);

            return await _context.FootballMatches
                .Where(x => x.Week == lastWeek)
                .GroupBy(x => x.MatchStatus)
                .Select(x => new MatchStatusCountDto
                {
                    MatchStatus = x.Key,
                    Count = x.Count()
                })
                .ToListAsync();
        }

        public async Task<List<FootballMatch>> GetFootballMatchWithDetailById(int footballMatchId)
        {
            return await _context.FootballMatches.Include(x => x.HomeTeam).ThenInclude(x => x.Stadium).Include(x => x.AwayTeam).Where(x => x.FootballMatchId == footballMatchId).ToListAsync();
        }

        public async Task<List<FootballMatch>> GetFootballMatchWithDetailByWeekId(int weekId)
        {
            return await _context.FootballMatches.Include(x=>x.HomeTeam).ThenInclude(x=>x.Stadium).Include(x=>x.AwayTeam).Where(x=>x.Week==weekId).ToListAsync();
        }

        public async Task<FootballMatch> GetLastWeekFeatureMatch()
        {
            var lastWeek = await _context.FootballMatches
                .MaxAsync(x => x.Week);

            return await _context.FootballMatches.Include(x => x.HomeTeam).ThenInclude(x => x.Stadium).Include(x => x.AwayTeam).
                Where(x => x.Week == lastWeek && x.MatchStatus==MatchStatus.NotStarted)
                .OrderBy(x=>x.MatchDate)
                .FirstOrDefaultAsync();
        }

        public async Task<FootballMatch?> GetMostGoalMatch()
        {
            return await _context.FootballMatches
                .Include(x => x.HomeTeam)
                    .ThenInclude(x => x.Stadium)
                .Include(x => x.AwayTeam)
                .Where(x => x.MatchStatus == MatchStatus.Finished)
                .OrderByDescending(x => x.FullTimeScoreHome + x.FullTimeScoreAway)
                .FirstOrDefaultAsync();
        }

        public async Task<List<FootballMatch>> LiveMatchListByLastWeek()
        {
            var lastWeek = await _context.FootballMatches
               .MaxAsync(x => x.Week);

            return await _context.FootballMatches.Include(x => x.HomeTeam).ThenInclude(x => x.Stadium).Include(x => x.AwayTeam).
                Where(x => x.Week == lastWeek && x.MatchStatus == MatchStatus.Live)
                .ToListAsync();
                
        }

        public async Task<List<FootballMatch>> NotStartedMatchListByLastWeek()
        {
            var lastWeek = await _context.FootballMatches
              .MaxAsync(x => x.Week);

            return await _context.FootballMatches.Include(x => x.HomeTeam).ThenInclude(x => x.Stadium).Include(x => x.AwayTeam).
                Where(x => x.Week == lastWeek && x.MatchStatus == MatchStatus.NotStarted)
                .ToListAsync();
        }

        public async Task<List<FootballMatch>> UpcomingMatches()
        {
            var lastWeek = await _context.FootballMatches
             .MaxAsync(x => x.Week);

            return await _context.FootballMatches.Include(x => x.HomeTeam).ThenInclude(x => x.Stadium).Include(x => x.AwayTeam).
                Where(x => x.Week == lastWeek && x.MatchStatus == MatchStatus.NotStarted)
                .OrderByDescending(x=>x.MatchDate)
                .ToListAsync();
        }
    }
}
