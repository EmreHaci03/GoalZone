using GoalZone.BusinessLayer.Abstract;
using GoalZone.DataAccessLayer.Abstract;
using GoalZone.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalZone.BusinessLayer.Concrete
{
    public class NewsManager : INewsService
    {
        private readonly INewsDal _newsDal;

        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        public async Task TCreateAsync(News entity)
        {
            await _newsDal.CreateAsync(entity);
        }

        public async Task TDeleteNewsAsync(int id)
        {
            await _newsDal.DeleteNewsAsync(id);
        }

        public async Task<List<News>> TGetAllAsync()
        {
            return await _newsDal.GetAllAsync();
        }

        public async Task<News> TGetByIdAsync(int id)
        {
            return await _newsDal.GetByIdAsync(id);
        }

        public async Task<News> TGetNewsByIdAsync(int id)
        {
            return await _newsDal.GetNewsByIdAsync(id);
        }

        public async Task<List<News>> TGetNewsWithTeamName()
        {
            return await _newsDal.GetNewsWithTeamName();
        }

        public async Task TUpdateAsync(News entity)
        {
            await _newsDal.UpdateAsync(entity);
        }
    }
}