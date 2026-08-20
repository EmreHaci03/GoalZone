using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DtoLayer.DTOS.AdminDashboardDto
{
    public class DashboardDto
    {
        public int TotalMatch {  get; set; }
        public int Win {  get; set; }
        public int TotalGoal { get; set; }
        public int Statistic { get; set; }
    }
}
