using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.EntityLayer.Entities
{
    public class MatchStatistic
    {
        public int MatchStatisticId { get; set; }
        public int FootballMatchId { get; set; }
        public FootballMatch FootballMatch { get; set; }

        public string StatName { get; set; }  
        public string HomeValue { get; set; }
        public string AwayValue { get; set; }
    }
}
