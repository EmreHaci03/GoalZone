using GoalZone.BusinessLayer.Abstract;
using GoalZone.DataAccessLayer.Abstract;
using GoalZone.EntityLayer.Entities;

namespace GoalZone.BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public async Task TCreateAsync(Team entity)
        {
            await _teamDal.CreateAsync(entity);
        }

        public async Task<List<Team>> TGetAllAsync()
        {
            return await _teamDal.GetAllAsync();
        }

        public async Task<Team> TGetByIdAsync(int id)
        {
            return await _teamDal.GetByIdAsync(id);
        }

        public async Task<List<Team>> TGetTeamWithDetailAsync()
        {
            return await _teamDal.GetTeamWithDetailAsync();
        }

        public async Task<Team> TGetTeamWithDetailById(int id)
        {
              return await _teamDal.GetTeamWithDetailById(id);
        }

        public async Task TUpdateAsync(Team entity)
        {
            await _teamDal.UpdateAsync(entity);
        }
    }
}