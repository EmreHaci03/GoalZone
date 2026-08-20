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
    public class EfTeamDal : GenericRepository<Team>, ITeamDal
    {
        private readonly GoalZoneContext _context;
        public EfTeamDal(GoalZoneContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Team>> GetTeamWithDetailAsync()
        {
            return await _context.Teams.Include(x => x.Stadium).ToListAsync();
        }

        public async Task<Team> GetTeamWithDetailById(int id)
        {
            return await _context.Teams.Include(x => x.Stadium).FirstOrDefaultAsync(x => x.TeamId == id);
        }
    }
}
