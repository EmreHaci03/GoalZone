using GoalZone.DataAccessLayer.Abstract;
using GoalZone.DataAccessLayer.Context;
using GoalZone.DataAccessLayer.Repository;
using GoalZone.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DataAccessLayer.EntityFramework
{
    public class EfPlayerDal : GenericRepository<Player>, IPlayerDal
    {
        private readonly GoalZoneContext _context;
        public EfPlayerDal(GoalZoneContext context) : base(context)
        {
            this._context = context;
        }

        public async Task DeleteAsync(Player player)
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Player>> GetPlayerListWithTeam()
        {
            return await _context.Players.Include(x => x.Team).ToListAsync();
        }

        public async Task<Player> PlayerGetByIdAsync(int id)
        {
            return await _context.Players.Include(x => x.Team).FirstOrDefaultAsync(x => x.PlayerId == id);
        }
    }
}
