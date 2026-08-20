using GoalZone.BusinessLayer.Abstract;
using GoalZone.BusinessLayer.Concrete;
using GoalZone.DataAccessLayer.Abstract;
using GoalZone.DataAccessLayer.EntityFramework;
using GoalZone.DataAccessLayer.Repository;

namespace GoalZone.WebApi.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITeamDal, EfTeamDal>();
            services.AddScoped<IStadiumDal, EfStadiumDal>();
            services.AddScoped<IPlayerDal, EfPlayerDal>();
            services.AddScoped<IMatchStatisticDal, EfMatchStatisticDal>();
            services.AddScoped<IMatchEventDal, EfMatchEventDal>();
            services.AddScoped<IFootballMatchDal, EfFootbalMatchDal>();
            services.AddScoped<INewsDal, EfNewsDal>();


            services.AddScoped<ITeamService, TeamManager>();
            services.AddScoped<IFootballMatchService, FootballMatchManager>();
            services.AddScoped<IPlayerService, PlayerManager>();
            services.AddScoped<IStadiumService, StadiumManager>();
            services.AddScoped<IMatchEventService, MatchEventManager>();
            services.AddScoped<IMatchStatisticService, MatchStatisticManager>();
            services.AddScoped<INewsService, NewsManager>();
        }
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
        }
    }
}
