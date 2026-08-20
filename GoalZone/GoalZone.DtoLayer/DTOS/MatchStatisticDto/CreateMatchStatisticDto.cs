using GoalZone.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalZone.DtoLayer.DTOS.MatchStatisticDto
{
    public class CreateMatchStatisticDto
    {
        public int FootballMatchId { get; set; }

        public string StatName { get; set; }
        public string HomeValue { get; set; }
        public string AwayValue { get; set; }
    }
}
