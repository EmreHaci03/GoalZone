using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.BusinessLayer.Abstract
{
    public interface INewsService:IGenericService<News>
    {
        Task<List<News>> TGetNewsWithTeamName();
        Task TDeleteNewsAsync(int id);
        Task<News> TGetNewsByIdAsync(int id);
    }
}
