using GoalZone.BusinessLayer.Abstract;
using GoalZone.DataAccessLayer.Abstract;
using GoalZone.EntityLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalZone.BusinessLayer.Concrete
{
    public class StadiumManager : IStadiumService
    {
        private readonly IStadiumDal _stadiumDal;

        public StadiumManager(IStadiumDal stadiumDal)
        {
            _stadiumDal = stadiumDal;
        }

        public async Task TCreateAsync(Stadium entity)
        {
            await _stadiumDal.CreateAsync(entity);
        }

        public async Task<List<Stadium>> TGetAllAsync()
        {
            return await _stadiumDal.GetAllAsync();
        }

        public async Task<Stadium> TGetByIdAsync(int id)
        {
            return await _stadiumDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Stadium entity)
        {
            await _stadiumDal.UpdateAsync(entity);
        }
    }
}