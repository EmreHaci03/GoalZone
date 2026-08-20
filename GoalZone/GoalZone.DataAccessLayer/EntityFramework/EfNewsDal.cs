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
    public class EfNewsDal : GenericRepository<News>, INewsDal
    {
        private readonly GoalZoneContext _context;
        public EfNewsDal(GoalZoneContext context) : base(context)
        {
            this._context = context;
        }

        public async Task DeleteNewsAsync(int id)
        {
            var news = await _context.News.FindAsync(id);

            if (news == null)
                return;

            _context.News.Remove(news);
            await _context.SaveChangesAsync();
        }

        public async Task<News> GetNewsByIdAsync(int id)
        {
            return await _context.News.Include(x => x.RelatedTeam).FirstOrDefaultAsync(x=>x.NewsId==id);

        }

        public async Task<List<News>> GetNewsWithTeamName()
        {
            return await _context.News.Include(x => x.RelatedTeam).ToListAsync();
        }
    }
}
