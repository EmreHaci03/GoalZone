using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DataAccessLayer.Abstract
{
    public interface INewsDal:IGenericDal<News>
    {
        Task<List<News>> GetNewsWithTeamName();
        Task DeleteNewsAsync(int id);
        Task<News> GetNewsByIdAsync(int id);
    }
}
