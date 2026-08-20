using GoalZone.DataAccessLayer.Abstract;
using GoalZone.DataAccessLayer.Context;
using GoalZone.DataAccessLayer.Repository;
using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DataAccessLayer.EntityFramework
{
    public class EfStadiumDal : GenericRepository<Stadium>, IStadiumDal
    {
        public EfStadiumDal(GoalZoneContext context) : base(context)
        {
        }
    }
}
