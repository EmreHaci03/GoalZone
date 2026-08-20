using GoalZone.DataAccessLayer.Abstract;
using GoalZone.DataAccessLayer.Context;
using GoalZone.DataAccessLayer.Repository;
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
    public class EfMatchEventDal : GenericRepository<MatchEvent>, IMatchEventDal
    {
        private readonly GoalZoneContext _context;
        public EfMatchEventDal(GoalZoneContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<MatchEvent>> MatchEventListByFootballMatchId(int footballMatchId)
        {
            return await _context.MatchEvents.Include(x=>x.FootballMatch).Where(x => x.FootballMatchId == footballMatchId).ToListAsync();
        }

        public async Task<List<MatchEvent>> HomeTeamMatchEventPlayerGoalList(int footballMatchId)
        {
            return await _context.MatchEvents
                .Include(x => x.FootballMatch)
                    .ThenInclude(x => x.HomeTeam)
                .Where(x =>
                    x.FootballMatchId == footballMatchId &&
                    x.EventType == EventType.Goal &&
                    _context.Players.Any(p=>
                    p.PlayerName==x.PlayerName &&
                    p.TeamId==x.FootballMatch.HomeTeamId
                    ))
                .ToListAsync();
        }
        public async Task<List<MatchEvent>> AwayTeamMatchEventPlayerGoalList(int footballMatchId)
        {
            return await _context.MatchEvents
                .Include(x => x.FootballMatch)
                    .ThenInclude(x => x.AwayTeam)
                .Where(x =>
                    x.FootballMatchId == footballMatchId &&
                    x.EventType == EventType.Goal &&
                    _context.Players.Any(p =>
                        p.PlayerName == x.PlayerName &&
                        p.TeamId == x.FootballMatch.AwayTeamId
                    ))
                .ToListAsync();
        }
        public async Task<List<MatchEvent>> HomeTeamCardList(int footballMatchId)
        {
            return await _context.MatchEvents
                .Include(x => x.FootballMatch)
                    .ThenInclude(x => x.HomeTeam)
                .Where(x =>
                    x.FootballMatchId == footballMatchId &&
                    (x.EventType == EventType.YellowCard || x.EventType == EventType.RedCard) &&
                    _context.Players.Any(p =>
                        p.PlayerName == x.PlayerName &&
                        p.TeamId == x.FootballMatch.HomeTeamId
                    ))
                .OrderBy(x => x.Minute)
                .ToListAsync();
        }

        public async Task<List<MatchEvent>> AwayTeamCardList(int footballMatchId)
        {
            return await _context.MatchEvents
                .Include(x => x.FootballMatch)
                    .ThenInclude(x => x.AwayTeam)
                .Where(x =>
                    x.FootballMatchId == footballMatchId &&
                    (x.EventType == EventType.YellowCard || x.EventType == EventType.RedCard) &&
                    _context.Players.Any(p =>
                        p.PlayerName == x.PlayerName &&
                        p.TeamId == x.FootballMatch.AwayTeamId
                    ))
                .OrderBy(x => x.Minute)
                .ToListAsync();
        }

        public async Task<List<MatchEvent>> HomeTeamSubstitution(int footballMatchId)
        {
            return await _context.MatchEvents
                .Include(x => x.FootballMatch)
                .ThenInclude(x => x.HomeTeam)
                .Where(x =>
                 x.FootballMatchId == footballMatchId &&
                 x.EventType == EventType.Substitution &&
                 _context.Players.Any(p =>
                 p.PlayerName==x.PlayerName &&
                 p.TeamId==x.FootballMatch.HomeTeamId

                 )).ToListAsync();
        }

        public async Task<List<MatchEvent>> AwayTeamSubstitution(int footballMatchId)
        {
            return await _context.MatchEvents
               .Include(x => x.FootballMatch)
               .ThenInclude(x => x.AwayTeam)
               .Where(x =>
                x.FootballMatchId == footballMatchId &&
                x.EventType == EventType.Substitution &&
                _context.Players.Any(p =>
                p.PlayerName == x.PlayerName &&
                p.TeamId == x.FootballMatch.AwayTeamId

                )).ToListAsync();
        }

        public async Task<List<MatchEvent>> HomeTeamEventListByFootballMatchId(int footballMatchId)
        {
            return await _context.MatchEvents
               .Include(x => x.FootballMatch)
               .ThenInclude(x => x.HomeTeam)
               .Where(x =>
                x.FootballMatchId == footballMatchId &&
                _context.Players.Any(p =>
                p.PlayerName == x.PlayerName &&
                p.TeamId == x.FootballMatch.HomeTeamId

                )).ToListAsync();
        }

        public async Task<List<MatchEvent>> AwayTeamEventListByFootballMatchId(int footballMatchId)
        {
            return await _context.MatchEvents
                 .Include(x => x.FootballMatch)
                 .ThenInclude(x => x.AwayTeam)
                 .Where(x =>
                 x.FootballMatchId == footballMatchId &&
                 _context.Players.Any(p =>
                 p.PlayerName==x.PlayerName &&
                 p.TeamId==x.FootballMatch.AwayTeamId

                 )).ToListAsync();
        }
    }
}
